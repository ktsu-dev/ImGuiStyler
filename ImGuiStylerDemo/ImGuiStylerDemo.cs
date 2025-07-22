// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStylerDemo;

using System.Linq;
using System.Numerics;
using System.Collections.ObjectModel;

using Hexa.NET.ImGui;

using ktsu.ImGuiApp;
using ktsu.ImGuiStyler;
using ktsu.ThemeProvider;

/// <summary>
/// Comprehensive demonstration of the ImGuiStyler library capabilities.
/// </summary>
internal sealed class ImGuiStylerDemo
{
	private static bool valueBool = true;
	private static bool valueBool2;
	private static int valueInt = 42;
	private static string valueString = "Hello ImGuiStyler!";
	private static float valueFloat = 0.5f;
	private static float valueFloat2 = 0.75f;
	private static int selectedFamily;
	private static readonly float[] colorValue = [0.4f, 0.7f, 0.0f, 1.0f];
	private static readonly string[] comboItems = ["Option A", "Option B", "Option C", "Option D"];
	private static int comboSelection;
	private static int radioSelection = 1;
	private static readonly float[] plotData = [0.6f, 0.1f, 1.0f, 0.5f, 0.92f, 0.1f, 0.2f];

	// Form validation fields
	private static string formUsername = "";
	private static string formEmail = "";

	// Use ThemeProvider registry for all available themes
	private static readonly List<ThemeRegistry.ThemeInfo> availableThemes = [.. Theme.AllThemes];
	private static readonly List<string> availableFamilies = [.. Theme.Families.OrderBy(f => f)];

	private static void Main()
	{
		ImGuiStylerDemo demo = new();
		ImGuiApp.Start(new()
		{
			Title = "ImGuiStyler Demo - Comprehensive Theme & Color Showcase",
			OnAppMenu = demo.OnMenu,
			OnMoveOrResize = demo.OnWindowResized,
			OnRender = demo.OnTick,
			OnStart = demo.OnStart,
			SaveIniSettings = false,
		});
	}

	private void OnStart() => Theme.ResetToDefault(); // Start with default ImGui styling

	private void OnTick(float dt)
	{
		// Header with current theme info
		if (Theme.CurrentThemeName is not null)
		{
			ImGui.Text($"🎨 Current Theme: {Theme.CurrentThemeName}");
			if (Theme.CurrentTheme is not null)
			{
				ImGui.SameLine();
				ImGui.Text($"({(Theme.CurrentTheme.IsDark ? "Dark" : "Light")})");
			}
		}
		else
		{
			ImGui.Text("🎨 Current Theme: Default (Reset)");
		}

		ImGui.Separator();

		if (ImGui.BeginTabBar("DemoTabs"))
		{
			if (ImGui.BeginTabItem("🎨 Theme Gallery"))
			{
				ShowThemeGallery();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("🎨 Color Palettes"))
			{
				ShowColorPalettesDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("🖱️ Widget Showcase"))
			{
				ShowWidgetShowcase();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("💡 Interactive Examples"))
			{
				ShowInteractiveExamples();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("📚 Documentation"))
			{
				ShowDocumentationDemo();
				ImGui.EndTabItem();
			}

			ImGui.EndTabBar();
		}
	}

	private static void ShowThemeGallery()
	{
		ImGui.TextUnformatted("🎨 Theme Gallery");
		ImGui.Text("Explore all available themes from the ThemeProvider registry.");
		ImGui.Separator();

		// Theme family selector
		ImGui.Text("Filter by Family:");
		if (ImGui.Combo("##Family", ref selectedFamily, ["All", .. availableFamilies], availableFamilies.Count + 1))
		{
			// selectedTheme = 0; // Reset selection when family changes
		}

		ImGui.Separator();

		// Get filtered themes
		IEnumerable<ThemeRegistry.ThemeInfo> filteredThemes = selectedFamily == 0
			? availableThemes
			: availableThemes.Where(t => t.Family == availableFamilies[selectedFamily - 1]);

		List<ThemeRegistry.ThemeInfo> themesToShow = [.. filteredThemes];

		// Theme grid
		ImGui.Text($"Available Themes ({themesToShow.Count}):");
		ImGui.BeginChild("ThemeGrid", new Vector2(0, 300), ImGuiChildFlags.Borders);

		int columns = Math.Max(1, (int)(ImGui.GetContentRegionAvail().X / 200));
		ImGui.Columns(columns, "ThemeColumns", false);

		foreach (ThemeRegistry.ThemeInfo theme in themesToShow)
		{
			// Theme preview card
			ImGui.PushID(theme.Name);

			bool isCurrentTheme = Theme.CurrentThemeName == theme.Name;

			// Get a representative color from the theme for styling the button
			ISemanticTheme themeInstance = theme.CreateInstance();
			ImColor themeColor = Color.Palette.Semantic.Primary; // Fallback

			try
			{
				// Try to get primary color from the theme
				if (themeInstance.SemanticMapping.TryGetValue(SemanticMeaning.Primary, out Collection<PerceptualColor>? primaryColors) && primaryColors?.Count > 0)
				{
					themeColor = Color.FromPerceptualColor(primaryColors[0]);
				}
				else if (themeInstance.SemanticMapping.TryGetValue(SemanticMeaning.Alternate, out Collection<PerceptualColor>? alternateColors) && alternateColors?.Count > 0)
				{
					themeColor = Color.FromPerceptualColor(alternateColors[0]);
				}
				else
				{
					// Get any available color from the theme
					KeyValuePair<SemanticMeaning, Collection<PerceptualColor>> firstMapping = themeInstance.SemanticMapping.FirstOrDefault();
					if (firstMapping.Value?.Count > 0)
					{
						themeColor = Color.FromPerceptualColor(firstMapping.Value[0]);
					}
				}
			}
			catch (System.ArgumentException)
			{
				// Use fallback color if argument is invalid
			}
			catch (System.InvalidOperationException)
			{
				// Use fallback color if operation is invalid
			}

			Vector2 buttonSize = new(ImGui.GetColumnWidth() - 10, 60);

			// Apply theme styling to this button, with current theme indicator
			if (isCurrentTheme)
			{
				// Current theme gets a special green highlight
				using (Theme.FromColor(Color.FromRGB(0.2f, 0.7f, 0.2f)))
				{
					if (ImGui.Button($"✓ {theme.Name}", buttonSize))
					{
						Theme.Apply(theme.Name);
					}
				}
			}
			else
			{
				// Other themes get styled with their representative color
				using (Theme.FromColor(themeColor))
				{
					if (ImGui.Button(theme.Name, buttonSize))
					{
						Theme.Apply(theme.Name);
					}
				}
			}

			if (ImGui.IsItemHovered())
			{
				ImGui.SetTooltip($"{theme.Description}\n\nFamily: {theme.Family}\nType: {(theme.IsDark ? "Dark" : "Light")}\n\nClick to apply this theme");
			}

			ImGui.PopID();
			ImGui.NextColumn();
		}

		ImGui.Columns(1);
		ImGui.EndChild();

		ImGui.Separator();

		// Quick theme preview with widgets
		ImGui.Text("Theme Preview:");
		ImGui.BeginChild("PreviewArea", new Vector2(0, 200), ImGuiChildFlags.Borders);

		ImGui.Text("Sample UI Elements:");
		if (ImGui.Button("Sample Button"))
		{
			// Button clicked
		}
		ImGui.SameLine();
		if (ImGui.SmallButton("Small"))
		{
			// Small button clicked
		}

		ImGui.Checkbox("Sample Checkbox", ref valueBool);
		ImGui.SliderFloat("Sample Slider", ref valueFloat, 0.0f, 1.0f);
		ImGui.InputText("Sample Input", ref valueString, 128);

		ImGui.Text("Radio Buttons:");
		ImGui.RadioButton("Option 1", ref radioSelection, 0);
		ImGui.SameLine();
		ImGui.RadioButton("Option 2", ref radioSelection, 1);
		ImGui.SameLine();
		ImGui.RadioButton("Option 3", ref radioSelection, 2);

		ImGui.EndChild();
	}

	private static void ShowColorPalettesDemo()
	{
		ImGui.TextUnformatted("🎨 Color Palette System");
		ImGui.Text("Comprehensive color palette with theme-aware colors.");
		ImGui.Separator();

		// Basic Colors Palette
		RenderColorPaletteSection("Basic Colors", [
			("Red", Color.Palette.Basic.Red),
			("Green", Color.Palette.Basic.Green),
			("Blue", Color.Palette.Basic.Blue),
			("Yellow", Color.Palette.Basic.Yellow),
			("Cyan", Color.Palette.Basic.Cyan),
			("Magenta", Color.Palette.Basic.Magenta),
			("Orange", Color.Palette.Basic.Orange),
			("Pink", Color.Palette.Basic.Pink),
			("Lime", Color.Palette.Basic.Lime),
			("Purple", Color.Palette.Basic.Purple),
		]);

		// Semantic Colors Palette
		RenderColorPaletteSection("Semantic Colors", [
			("Error", Color.Palette.Semantic.Error),
			("Warning", Color.Palette.Semantic.Warning),
			("Success", Color.Palette.Semantic.Success),
			("Info", Color.Palette.Semantic.Info),
			("Primary", Color.Palette.Semantic.Primary),
			("Secondary", Color.Palette.Semantic.Secondary),
		]);

		// Neutral Colors Palette
		RenderColorPaletteSection("Neutral Colors", [
			("White", Color.Palette.Neutral.White),
			("Light Gray", Color.Palette.Neutral.LightGray),
			("Gray", Color.Palette.Neutral.Gray),
			("Dark Gray", Color.Palette.Neutral.DarkGray),
			("Black", Color.Palette.Neutral.Black),
		]);

		// Natural Colors Palette
		RenderColorPaletteSection("Natural Colors", [
			("Brown", Color.Palette.Natural.Brown),
			("Olive", Color.Palette.Natural.Olive),
			("Maroon", Color.Palette.Natural.Maroon),
			("Navy", Color.Palette.Natural.Navy),
			("Teal", Color.Palette.Natural.Teal),
			("Indigo", Color.Palette.Natural.Indigo),
		]);

		// Vibrant Colors Palette
		RenderColorPaletteSection("Vibrant Colors", [
			("Coral", Color.Palette.Vibrant.Coral),
			("Salmon", Color.Palette.Vibrant.Salmon),
			("Turquoise", Color.Palette.Vibrant.Turquoise),
			("Violet", Color.Palette.Vibrant.Violet),
			("Gold", Color.Palette.Vibrant.Gold),
			("Silver", Color.Palette.Vibrant.Silver),
		]);

		// Pastel Colors Palette
		RenderColorPaletteSection("Pastel Colors", [
			("Beige", Color.Palette.Pastel.Beige),
			("Peach", Color.Palette.Pastel.Peach),
			("Mint", Color.Palette.Pastel.Mint),
			("Lavender", Color.Palette.Pastel.Lavender),
			("Khaki", Color.Palette.Pastel.Khaki),
			("Plum", Color.Palette.Pastel.Plum),
		]);

		ImGui.Separator();

		// Interactive color manipulation
		ImGui.Text("🔧 Interactive Color Tools:");
		ImGui.ColorEdit4("Custom Color", ref colorValue[0]);

		// Show color variations
		ImColor baseColor = Color.FromRGBA(colorValue[0], colorValue[1], colorValue[2], colorValue[3]);
		ImGui.Text("Color Variations:");

		ImGui.BeginGroup();
		RenderColorSwatch("Original", baseColor);
		RenderColorSwatch("Darker", baseColor.MultiplyLuminance(0.7f));
		RenderColorSwatch("Lighter", baseColor.MultiplyLuminance(1.3f));
		RenderColorSwatch("Desaturated", baseColor.MultiplySaturation(0.5f));
		RenderColorSwatch("Saturated", baseColor.MultiplySaturation(1.5f));
		ImGui.EndGroup();
	}

	private static void RenderColorPaletteSection(string title, (string Name, ImColor Color)[] colors)
	{
		ImGui.Text($"• {title}:");
		ImGui.BeginGroup();

		foreach ((string name, ImColor color) in colors)
		{
			RenderColorSwatch(name, color);
		}

		ImGui.EndGroup();
		ImGui.Separator();
	}

	private static void RenderColorSwatch(string name, ImColor color)
	{
		Vector2 swatchSize = new(30, 25);
		ImGui.ColorButton($"##{name}Swatch", color.Value, ImGuiColorEditFlags.None, swatchSize);

		if (ImGui.IsItemHovered())
		{
			Vector4 c = color.Value;
			ImGui.SetTooltip($"{name}\nRGBA: ({c.X:F2}, {c.Y:F2}, {c.Z:F2}, {c.W:F2})\nHex: #{(int)(c.X * 255):X2}{(int)(c.Y * 255):X2}{(int)(c.Z * 255):X2}");
		}

		ImGui.SameLine();
		ImGui.Text(name);
	}

	private static void ShowWidgetShowcase()
	{
		ImGui.TextUnformatted("🖱️ Comprehensive Widget Showcase");
		ImGui.Text("All ImGui widgets styled with the current theme.");
		ImGui.Separator();

		// Layout in columns for better organization
		ImGui.Columns(2, "WidgetColumns", true);

		// Column 1: Input widgets
		ImGui.Text("📝 Input Widgets:");

		ImGui.Button("Standard Button");
		ImGui.SameLine();
		ImGui.SmallButton("Small");

		if (ImGui.ArrowButton("##left", ImGuiDir.Left))
		{
			// Left arrow clicked
		}
		ImGui.SameLine();
		if (ImGui.ArrowButton("##right", ImGuiDir.Right))
		{
			// Right arrow clicked
		}

		ImGui.Checkbox("Checkbox", ref valueBool);
		ImGui.Checkbox("Checkbox 2", ref valueBool2);

		ImGui.RadioButton("Radio A", ref radioSelection, 0);
		ImGui.RadioButton("Radio B", ref radioSelection, 1);
		ImGui.RadioButton("Radio C", ref radioSelection, 2);

		ImGui.SliderFloat("Slider", ref valueFloat, 0.0f, 1.0f);
		ImGui.SliderFloat("Slider 2", ref valueFloat2, -10.0f, 10.0f);
		ImGui.SliderInt("Int Slider", ref valueInt, 0, 100);

		ImGui.InputText("Text Input", ref valueString, 128);

		if (ImGui.BeginCombo("Combo", comboItems[comboSelection]))
		{
			for (int i = 0; i < comboItems.Length; i++)
			{
				bool isSelected = comboSelection == i;
				if (ImGui.Selectable(comboItems[i], isSelected))
				{
					comboSelection = i;
				}
				if (isSelected)
				{
					ImGui.SetItemDefaultFocus();
				}
			}
			ImGui.EndCombo();
		}

		ImGui.ColorEdit3("Color", ref colorValue[0]);

		ImGui.NextColumn();

		// Column 2: Display widgets
		ImGui.Text("📊 Display Widgets:");

		ImGui.Text($"Current Values:");
		ImGui.BulletText($"Bool: {valueBool}");
		ImGui.BulletText($"Int: {valueInt}");
		ImGui.BulletText($"Float: {valueFloat:F2}");
		ImGui.BulletText($"String: {valueString}");

		unsafe
		{
			fixed (float* plotPtr = plotData)
			{
				ImGui.PlotLines("##Plot"u8, plotPtr, plotData.Length, 0, "Sample Plot"u8, 0.0f, 1.0f, new Vector2(0, 80));
			}
		}

		ImGui.ProgressBar(valueFloat, new Vector2(-1, 0), $"{valueFloat * 100:F0}%");

		// Separator
		ImGui.Separator();

		// Tree node
		if (ImGui.TreeNode("Tree Node"u8))
		{
			ImGui.Text("Tree content");
			if (ImGui.TreeNode("Nested Node"u8))
			{
				ImGui.Text("Nested content");
				ImGui.TreePop();
			}
			ImGui.TreePop();
		}

		// Collapsing header
		if (ImGui.CollapsingHeader("Collapsing Header"u8))
		{
			ImGui.Text("Header content");
			ImGui.Indent();
			ImGui.Text("Indented text");
			ImGui.Unindent();
		}

		ImGui.Columns(1);

		// Full-width section
		ImGui.Separator();
		ImGui.Text("📋 Tables & Lists:");

		if (ImGui.BeginTable("DemoTable"u8, 3, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg))
		{
			ImGui.TableSetupColumn("Column A"u8);
			ImGui.TableSetupColumn("Column B"u8);
			ImGui.TableSetupColumn("Column C"u8);
			ImGui.TableHeadersRow();

			for (int row = 0; row < 5; row++)
			{
				ImGui.TableNextRow();
				for (int col = 0; col < 3; col++)
				{
					ImGui.TableSetColumnIndex(col);
					ImGui.Text($"Row {row}, Col {col}");
				}
			}
			ImGui.EndTable();
		}
	}

	private static void ShowInteractiveExamples()
	{
		ImGui.TextUnformatted("💡 Interactive Theme Examples");
		ImGui.Text("See how themes affect real UI components and workflows.");
		ImGui.Separator();

		// Theme-aware text colors demonstration
		ImGui.Text("🎨 Semantic Text Colors in Action:");
		ImGui.BeginChild("TextColorDemo", new Vector2(0, 120), ImGuiChildFlags.Borders);

		using (Text.Color.Error())
		{
			ImGui.TextUnformatted("❌ Error: Connection failed!");
		}

		using (Text.Color.Warning())
		{
			ImGui.TextUnformatted("⚠️ Warning: Low disk space");
		}

		using (Text.Color.Success())
		{
			ImGui.TextUnformatted("✅ Success: File saved successfully");
		}

		using (Text.Color.Info())
		{
			ImGui.TextUnformatted("ℹ️ Info: 5 items processed");
		}

		ImGui.EndChild();

		ImGui.Separator();

		// Scoped theming demonstration
		ImGui.Text("🎯 Scoped Theme Applications:");

		ImGui.Text("Normal themed section:");
		ImGui.Button("Normal Button");
		ImGui.SliderFloat("Normal Slider", ref valueFloat, 0.0f, 1.0f);

		ImGui.Separator();

		ImGui.Text("Scoped color themes:");
		using (Theme.FromColor(Color.Palette.Semantic.Error))
		{
			ImGui.Text("Error-themed section:");
			ImGui.Button("Danger Button");
			ImGui.ProgressBar(0.8f, new Vector2(-1, 0), "80% Critical");
		}

		using (Theme.FromColor(Color.Palette.Semantic.Success))
		{
			ImGui.Text("Success-themed section:");
			ImGui.Button("Success Button");
			ImGui.ProgressBar(0.9f, new Vector2(-1, 0), "90% Complete");
		}

		ImGui.Separator();

		// Form example with validation
		ImGui.Text("📋 Form Example with Validation:");
		ImGui.BeginChild("FormExample", new Vector2(0, 150), ImGuiChildFlags.Borders);

		ImGui.Text("User Registration:");
		ImGui.InputText("Username", ref formUsername, 64);

		if (string.IsNullOrWhiteSpace(formUsername))
		{
			using (Text.Color.Error())
			{
				ImGui.TextUnformatted("⚠ Username is required");
			}
		}
		else if (formUsername.Length < 3)
		{
			using (Text.Color.Warning())
			{
				ImGui.TextUnformatted("⚠ Username should be at least 3 characters");
			}
		}
		else
		{
			using (Text.Color.Success())
			{
				ImGui.TextUnformatted("✓ Username looks good");
			}
		}

		ImGui.InputText("Email", ref formEmail, 128);

		bool validEmail = formEmail.Contains('@') && formEmail.Contains('.');
		if (!string.IsNullOrWhiteSpace(formEmail) && !validEmail)
		{
			using (Text.Color.Error())
			{
				ImGui.TextUnformatted("⚠ Invalid email format");
			}
		}
		else if (validEmail)
		{
			using (Text.Color.Success())
			{
				ImGui.TextUnformatted("✓ Email looks valid");
			}
		}

		bool canSubmit = !string.IsNullOrWhiteSpace(formUsername) && formUsername.Length >= 3 && validEmail;

		if (!canSubmit)
		{
			using (Theme.DisabledFromColor(Color.Palette.Neutral.Gray))
			{
				ImGui.Button("Submit (Complete form first)");
			}
		}
		else
		{
			using (Theme.FromColor(Color.Palette.Semantic.Success))
			{
				if (ImGui.Button("Submit Registration"))
				{
					// Handle submission
				}
			}
		}

		ImGui.EndChild();
	}

	private void OnMenu()
	{
		// Demonstrate Theme.RenderMenu() - renders theme selection submenu
		if (Theme.RenderMenu())
		{
			// Theme changed - this is where you would save the current theme to settings
			// For example: Settings.Theme = Theme.CurrentThemeName;
			if (Theme.CurrentThemeName is null)
			{
				Console.WriteLine("Theme reset to default");
			}
			else
			{
				Console.WriteLine($"Theme changed to: {Theme.CurrentThemeName}");
			}
		}

		if (ImGui.BeginMenu("Help"))
		{
			if (ImGui.MenuItem("About ImGuiStyler"))
			{
				// Show about dialog - placeholder for demonstration
			}
			ImGui.EndMenu();
		}
	}

	private static void ShowDocumentationDemo()
	{
		ImGui.TextUnformatted("📚 ImGuiStyler Documentation & Examples");
		ImGui.Separator();

		ImGui.TextWrapped("ImGuiStyler provides comprehensive theming and styling capabilities for Dear ImGui applications. It integrates with ThemeProvider to offer semantic theming with consistent color meanings across different themes.");

		ImGui.Separator();
		ImGui.Text("Usage Examples:");

		ImGui.BeginChild("CodeExamples", new Vector2(0, 0), ImGuiChildFlags.Borders);

		ImGui.Text("// Apply semantic themes using ThemeProvider");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.Apply(\"Dracula\");");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.Apply(\"Nord\");");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.Apply(\"Catppuccin Mocha\");");
		ImGui.TextUnformatted("");

		ImGui.Text("// Reset to default ImGui styling");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.ResetToDefault();");
		ImGui.Text("// or via property");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.CurrentThemeName = null;");
		ImGui.TextUnformatted("");

		ImGui.Text("// Render theme selection menu in your main menu bar");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "if (Theme.RenderMenu())");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "{");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "    // Save current theme to settings (null = default)");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "    Settings.Theme = Theme.CurrentThemeName;");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "}");
		ImGui.TextUnformatted("");

		ImGui.Text("// Restore theme on application start");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "Theme.CurrentThemeName = Settings.Theme; // null restores default");
		ImGui.TextUnformatted("");

		ImGui.Text("// Use semantic text colors");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "using (Text.Color.Error())");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "{");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "    ImGui.Text(\"Error message\");");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "}");
		ImGui.TextUnformatted("");

		ImGui.Text("// Use color palette (theme-aware)");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "ImColor primaryColor = Color.Palette.Semantic.Primary;");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "ImColor errorColor = Color.Palette.Semantic.Error;");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "ImColor customRed = Color.Palette.Basic.Red; // Adapts to theme");
		ImGui.TextUnformatted("");

		ImGui.Text("// Scoped theme colors for UI sections");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "using (Theme.FromColor(Color.Palette.Semantic.Success))");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "{");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "    ImGui.Button(\"Success Button\");");
		ImGui.TextColored(new Vector4(0.6f, 0.8f, 0.6f, 1.0f), "}");

		ImGui.EndChild();
	}

	private void OnWindowResized()
	{
		// Handle window resize if needed
	}
}
