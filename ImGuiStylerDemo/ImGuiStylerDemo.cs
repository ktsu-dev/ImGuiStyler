// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiWidgetsDemo;

using System.Linq;
using System.Numerics;
using Hexa.NET.ImGui;
using ktsu.ImGuiApp;
using ktsu.ImGuiStyler;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
internal class ImGuiStylerDemo
{
	private static bool valueBool = true;
	private static int valueInt = 42;
	private static string valueString = "Hello ImGuiStyler!";
	private static float valueFloat = 0.5f;
	private static int selectedThemeColor;
	private static int selectedTextColor;
	private static int selectedColorFormat;
	private static string hexColorInput = "#ff4a49";
	private static readonly float[] rgbColorInput = [1.0f, 0.29f, 0.29f];
	private static readonly float[] hslColorInput = [0.0f, 1.0f, 0.5f];
	private static float saturationMult = 1.0f;
	private static float luminanceMult = 1.0f;
	private static float hueOffset;
	private static float alphaValue = 1.0f;
	private static float indentWidth = 20.0f;
	private static int buttonAlignment = 1; // 0=Left, 1=Center
	private static readonly float[] styleVarValues = [4.0f, 8.0f, 6.0f, 12.0f]; // FramePadding.X, FramePadding.Y, ItemSpacing.X, ItemSpacing.Y

	private static readonly string[] themeColorNames = [
		"Normal", "Red", "Green", "Blue", "Cyan", "Magenta", "Yellow",
		"Orange", "Pink", "Lime", "Purple", "White", "Gray", "LightGray", "DarkGray"
	];

	private static readonly ImColor[] themeColors = [
		Theme.Palette.Normal, Theme.Palette.Red, Theme.Palette.Green, Theme.Palette.Blue,
		Theme.Palette.Cyan, Theme.Palette.Magenta, Theme.Palette.Yellow, Theme.Palette.Orange,
		Theme.Palette.Pink, Theme.Palette.Lime, Theme.Palette.Purple, Theme.Palette.White,
		Theme.Palette.Gray, Theme.Palette.LightGray, Theme.Palette.DarkGray
	];

	private static readonly string[] textColorNames = ["Normal", "Error", "Warning", "Info", "Success"];

	private static void Main(string[] args)
	{
		ImGuiStylerDemo demo = new();
		ImGuiApp.Start(new()
		{
			Title = "ImGuiStyler Demo - Comprehensive Feature Showcase",
			OnAppMenu = demo.OnMenu,
			OnMoveOrResize = demo.OnWindowResized,
			OnRender = demo.OnTick,
			OnStart = demo.OnStart,
			SaveIniSettings = false,
		});
	}

	private void OnStart() => Theme.Apply(Theme.Palette.Normal);

	private void OnTick(float dt)
	{
		ImGui.Text("Welcome to the ImGuiStyler library comprehensive demo!");
		ImGui.Text("This demo showcases all features and capabilities of the ImGuiStyler library.");
		ImGui.Separator();

		if (ImGui.BeginTabBar("DemoTabs"))
		{
			if (ImGui.BeginTabItem("Theme System"))
			{
				ShowThemeSystemDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Text Colors"))
			{
				ShowTextColorsDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Color Manipulation"))
			{
				ShowColorManipulationDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Alignment"))
			{
				ShowAlignmentDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Button Styling"))
			{
				ShowButtonStylingDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Indentation"))
			{
				ShowIndentationDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Style Variables"))
			{
				ShowStyleVariablesDemo();
				ImGui.EndTabItem();
			}

			if (ImGui.BeginTabItem("Interactive Examples"))
			{
				ShowInteractiveExamplesDemo();
				ImGui.EndTabItem();
			}

			ImGui.EndTabBar();
		}
	}

	private static void ShowThemeSystemDemo()
	{
		ImGui.TextUnformatted("Theme System Demonstration");
		ImGui.Text("The theme system provides comprehensive color theming for all ImGui elements.");
		ImGui.Separator();

		// Global theme selection
		ImGui.Text("Global Theme:");
		if (ImGui.Combo("Theme Color", ref selectedThemeColor, themeColorNames, themeColorNames.Length))
		{
			Theme.Apply(themeColors[selectedThemeColor]);
		}

		ImGui.Separator();

		// Theme palette showcase
		ImGui.Text("Theme Palette Colors:");
		ImGui.Columns(5, "ThemePalette");
		for (int i = 0; i < themeColors.Length; i++)
		{
			ImGui.ColorButton($"##{themeColorNames[i]}", themeColors[i].Value, ImGuiColorEditFlags.None, new Vector2(60, 40));
			ImGui.Text(themeColorNames[i]);
			ImGui.NextColumn();
		}
		ImGui.Columns(1);

		ImGui.Separator();

		// Scoped theme demonstration
		ImGui.Text("Scoped Theme Colors:");
		ImGui.Text("Normal theme elements:");
		ImGui.Button("Normal Button");
		ImGui.Checkbox("Normal Checkbox", ref valueBool);
		ImGui.SliderFloat("Normal Slider", ref valueFloat, 0.0f, 1.0f);

		ImGui.Text("Scoped Red theme:");
		using (Theme.Color(Theme.Palette.Red))
		{
			ImGui.Button("Red Themed Button");
			ImGui.Checkbox("Red Themed Checkbox", ref valueBool);
			ImGui.SliderFloat("Red Themed Slider", ref valueFloat, 0.0f, 1.0f);
		}

		ImGui.Text("Scoped Green theme:");
		using (Theme.Color(Theme.Palette.Green))
		{
			ImGui.Button("Green Themed Button");
			ImGui.Checkbox("Green Themed Checkbox", ref valueBool);
			ImGui.SliderFloat("Green Themed Slider", ref valueFloat, 0.0f, 1.0f);
		}

		ImGui.Text("Disabled theme state:");
		using (Theme.ColorDisabled(Theme.Palette.Blue))
		{
			ImGui.Button("Disabled Themed Button");
			ImGui.Checkbox("Disabled Themed Checkbox", ref valueBool);
			ImGui.SliderFloat("Disabled Themed Slider", ref valueFloat, 0.0f, 1.0f);
		}

		// Show theme color calculations
		ImGui.Separator();
		ImGui.Text("Theme Color Calculations:");
		ImColor baseColor = themeColors[selectedThemeColor];
		ImGui.Text($"Base Color: {baseColor.Value.X:F2}, {baseColor.Value.Y:F2}, {baseColor.Value.Z:F2}");
		ImGui.ColorButton("Base", baseColor.Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
		ImGui.SameLine();
		ImGui.ColorButton("Normal", Theme.GetNormalColor(baseColor).Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
		ImGui.SameLine();
		ImGui.ColorButton("Accent", Theme.GetAccentColor(baseColor).Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
		ImGui.SameLine();
		ImGui.ColorButton("Hovered", Theme.GetHoveredColor(baseColor).Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
		ImGui.SameLine();
		ImGui.ColorButton("Active", Theme.GetActiveColor(baseColor).Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
		ImGui.SameLine();
		ImGui.ColorButton("Background", Theme.GetBackgroundColor(baseColor).Value, ImGuiColorEditFlags.None, new Vector2(40, 20));
	}

	private static void ShowTextColorsDemo()
	{
		ImGui.TextUnformatted("Text Color System Demonstration");
		ImGui.Text("Semantic text colors provide consistent meaning across your application.");
		ImGui.Separator();

		// Basic text colors
		ImGui.Text("Basic Text Colors:");
		ImGui.TextUnformatted("Normal text (default)");

		using (Text.Color.Error())
		{
			ImGui.TextUnformatted("Error text - Used for error messages and warnings");
		}

		using (Text.Color.Warning())
		{
			ImGui.TextUnformatted("Warning text - Used for caution and attention");
		}

		using (Text.Color.Info())
		{
			ImGui.TextUnformatted("Info text - Used for informational messages");
		}

		using (Text.Color.Success())
		{
			ImGui.TextUnformatted("Success text - Used for positive feedback");
		}

		ImGui.Separator();

		// Interactive text color demonstration
		ImGui.Text("Interactive Text Color Selection:");
		if (ImGui.Combo("Text Color", ref selectedTextColor, textColorNames, textColorNames.Length))
		{
			// Color will be applied below
		}

		ImGui.Text("Sample text with selected color:");
		Text.Color.ScopedTextColor textColorScope = selectedTextColor switch
		{
			0 => Text.Color.Normal(),
			1 => Text.Color.Error(),
			2 => Text.Color.Warning(),
			3 => Text.Color.Info(),
			4 => Text.Color.Success(),
			_ => Text.Color.Normal()
		};

		using (textColorScope)
		{
			ImGui.TextUnformatted("This text uses the selected semantic color.");
			ImGui.TextUnformatted("You can see how it affects readability and meaning.");
			ImGui.BulletText("Bullet points also inherit the color");
			ImGui.Text($"Formatted text: Value = {valueInt}");
		}

		ImGui.Separator();

		// Color definitions
		ImGui.Text("Text Color Definitions:");
		ImGui.Text($"Normal: #{(int)(Text.Color.Definitions.Normal.Value.X * 255):X2}{(int)(Text.Color.Definitions.Normal.Value.Y * 255):X2}{(int)(Text.Color.Definitions.Normal.Value.Z * 255):X2}");
		ImGui.Text($"Error: #{(int)(Text.Color.Definitions.Error.Value.X * 255):X2}{(int)(Text.Color.Definitions.Error.Value.Y * 255):X2}{(int)(Text.Color.Definitions.Error.Value.Z * 255):X2}");
		ImGui.Text($"Warning: #{(int)(Text.Color.Definitions.Warning.Value.X * 255):X2}{(int)(Text.Color.Definitions.Warning.Value.Y * 255):X2}{(int)(Text.Color.Definitions.Warning.Value.Z * 255):X2}");
		ImGui.Text($"Info: #{(int)(Text.Color.Definitions.Info.Value.X * 255):X2}{(int)(Text.Color.Definitions.Info.Value.Y * 255):X2}{(int)(Text.Color.Definitions.Info.Value.Z * 255):X2}");
		ImGui.Text($"Success: #{(int)(Text.Color.Definitions.Success.Value.X * 255):X2}{(int)(Text.Color.Definitions.Success.Value.Y * 255):X2}{(int)(Text.Color.Definitions.Success.Value.Z * 255):X2}");

		ImGui.Separator();

		// Practical usage examples
		ImGui.Text("Practical Usage Examples:");
		ImGui.TextUnformatted("Form validation:");
		ImGui.InputText("Username", ref valueString, 128);
		if (string.IsNullOrEmpty(valueString))
		{
			using (Text.Color.Error())
			{
				ImGui.TextUnformatted("⚠ Username is required");
			}
		}
		else if (valueString.Length < 3)
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
				ImGui.TextUnformatted("✓ Username is valid");
			}
		}
	}

	private static void ShowColorManipulationDemo()
	{
		ImGui.TextUnformatted("Color Manipulation and Creation");
		ImGui.Text("Comprehensive color creation and manipulation utilities.");
		ImGui.Separator();

		// Color creation methods
		ImGui.Text("Color Creation Methods:");

		string[] colorFormats = ["Hex", "RGB", "HSL"];
		ImGui.Combo("Color Format", ref selectedColorFormat, colorFormats, colorFormats.Length);

		ImColor createdColor = selectedColorFormat switch
		{
			0 => CreateColorFromHex(),
			1 => CreateColorFromRGB(),
			2 => CreateColorFromHSL(),
			_ => Color.White
		};

		ImGui.ColorButton("Created Color", createdColor.Value, ImGuiColorEditFlags.None, new Vector2(100, 40));
		ImGui.SameLine();
		ImGui.Text($"Created Color: #{(int)(createdColor.Value.X * 255):X2}{(int)(createdColor.Value.Y * 255):X2}{(int)(createdColor.Value.Z * 255):X2}");

		ImGui.Separator();

		// Color manipulation
		ImGui.Text("Color Manipulation:");
		ImGui.SliderFloat("Saturation Multiplier", ref saturationMult, 0.0f, 2.0f);
		ImGui.SliderFloat("Luminance Multiplier", ref luminanceMult, 0.0f, 2.0f);
		ImGui.SliderFloat("Hue Offset", ref hueOffset, -1.0f, 1.0f);
		ImGui.SliderFloat("Alpha", ref alphaValue, 0.0f, 1.0f);

		ImColor manipulatedColor = createdColor
			.MultiplySaturation(saturationMult)
			.MultiplyLuminance(luminanceMult)
			.OffsetHue(hueOffset)
			.WithAlpha(alphaValue);

		ImGui.ColorButton("Manipulated Color", manipulatedColor.Value, ImGuiColorEditFlags.None, new Vector2(100, 40));
		ImGui.SameLine();
		ImGui.Text($"Manipulated: #{(int)(manipulatedColor.Value.X * 255):X2}{(int)(manipulatedColor.Value.Y * 255):X2}{(int)(manipulatedColor.Value.Z * 255):X2}{(int)(manipulatedColor.Value.W * 255):X2}");

		ImGui.Separator();

		// Predefined color palette
		ImGui.Text("Predefined Color Palette:");
		ImGui.Columns(4, "ColorPalette");

		ImColor[] predefinedColors = [
			Color.Red, Color.Green, Color.Blue, Color.Yellow,
			Color.Cyan, Color.Magenta, Color.Orange, Color.Purple,
			Color.Pink, Color.Lime, Color.Brown, Color.Gold,
			Color.Silver, Color.Teal, Color.Olive, Color.Navy
		];

		string[] predefinedNames = [
			"Red", "Green", "Blue", "Yellow",
			"Cyan", "Magenta", "Orange", "Purple",
			"Pink", "Lime", "Brown", "Gold",
			"Silver", "Teal", "Olive", "Navy"
		];

		for (int i = 0; i < predefinedColors.Length; i++)
		{
			ImGui.ColorButton($"##{predefinedNames[i]}", predefinedColors[i].Value, ImGuiColorEditFlags.None, new Vector2(50, 30));
			ImGui.Text(predefinedNames[i]);
			ImGui.NextColumn();
		}
		ImGui.Columns(1);

		ImGui.Separator();

		// Color analysis
		ImGui.Text("Color Analysis:");
		ImGui.Text($"Original Relative Luminance: {createdColor.GetRelativeLuminance():F3}");
		ImGui.Text($"Manipulated Relative Luminance: {manipulatedColor.GetRelativeLuminance():F3}");
		ImGui.Text($"Contrast Ratio: {createdColor.GetContrastRatioOver(manipulatedColor):F2}");

		ImColor optimalContrast = createdColor.CalculateOptimalContrastingColor();
		ImGui.ColorButton("Optimal Contrast", optimalContrast.Value, ImGuiColorEditFlags.None, new Vector2(100, 40));
		ImGui.SameLine();
		ImGui.Text($"Optimal Contrast Color for Text");

		// Show grayscale conversion
		ImColor grayscale = createdColor.ToGrayscale();
		ImGui.ColorButton("Grayscale", grayscale.Value, ImGuiColorEditFlags.None, new Vector2(100, 40));
		ImGui.SameLine();
		ImGui.Text("Grayscale version");
	}

	private static ImColor CreateColorFromHex()
	{
		ImGui.InputText("Hex Color (e.g., #ff4a49)", ref hexColorInput, 32);
		try
		{
			return Color.FromHex(hexColorInput);
		}
		catch (ArgumentException)
		{
			return Color.Red;
		}
	}

	private static ImColor CreateColorFromRGB()
	{
		ImGui.SliderFloat3("RGB Values", ref rgbColorInput[0], 0.0f, 1.0f);
		return Color.FromRGB(rgbColorInput[0], rgbColorInput[1], rgbColorInput[2]);
	}

	private static ImColor CreateColorFromHSL()
	{
		ImGui.SliderFloat3("HSL Values", ref hslColorInput[0], 0.0f, 1.0f);
		return Color.FromHSL(hslColorInput[0], hslColorInput[1], hslColorInput[2]);
	}

	private static void ShowAlignmentDemo()
	{
		ImGui.TextUnformatted("Alignment System Demonstration");
		ImGui.Text("Flexible content alignment within containers and regions.");
		ImGui.Separator();

		// Basic center alignment
		ImGui.Text("Basic Center Alignment:");
		ImGui.BeginChild("CenterDemo", new Vector2(0, 100), ImGuiChildFlags.Borders);
		{
			string centerText = "This text is centered";
			Vector2 textSize = ImGui.CalcTextSize(centerText);
			using (new Alignment.Center(textSize))
			{
				ImGui.TextUnformatted(centerText);
			}
		}
		ImGui.EndChild();

		ImGui.Separator();

		// Center within specific containers
		ImGui.Text("Center Within Different Container Sizes:");

		Vector2[] containerSizes = [
			new(200, 80),
			new(300, 100),
			new(400, 60),
			new(250, 120)
		];

		string[] containerLabels = ["Small", "Medium", "Wide", "Tall"];

		for (int i = 0; i < containerSizes.Length; i++)
		{
			Vector2 containerSize = containerSizes[i];
			string label = $"Container {containerLabels[i]}";

			Vector2 cursorPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(
				cursorPos,
				cursorPos + containerSize,
				ImGui.GetColorU32(ImGuiCol.ChildBg)
			);
			ImGui.GetWindowDrawList().AddRect(
				cursorPos,
				cursorPos + containerSize,
				ImGui.GetColorU32(ImGuiCol.Border)
			);

			string contentText = $"Centered in {containerLabels[i]}";
			Vector2 contentSize = ImGui.CalcTextSize(contentText);

			using (new Alignment.CenterWithin(contentSize, containerSize))
			{
				ImGui.TextUnformatted(contentText);
			}

			if (i < containerSizes.Length - 1)
			{
				ImGui.SameLine();
			}
		}

		ImGui.Separator();

		// Complex alignment scenarios
		ImGui.Text("Complex Alignment Scenarios:");

		// Multiple items in the same row with different alignments
		ImGui.Text("Multiple centered items in a row:");

		string[] items = ["Item 1", "Longer Item 2", "Item 3"];
		Vector2[] itemSizes = [.. items.Select(item => ImGui.CalcTextSize(item))];
		Vector2 itemContainerSize = new(120, 40);

		for (int i = 0; i < items.Length; i++)
		{
			Vector2 cursorPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(
				cursorPos,
				cursorPos + itemContainerSize,
				ImGui.GetColorU32(ImGuiCol.FrameBg)
			);

			using (new Alignment.CenterWithin(itemSizes[i], itemContainerSize))
			{
				ImGui.TextUnformatted(items[i]);
			}

			if (i < items.Length - 1)
			{
				ImGui.SameLine();
			}
		}

		ImGui.Separator();

		// Nested alignment
		ImGui.Text("Nested Alignment:");
		ImGui.BeginChild("NestedDemo", new Vector2(0, 150), ImGuiChildFlags.Borders);
		{
			string outerText = "Outer Container";
			Vector2 outerSize = ImGui.CalcTextSize(outerText);
			using (new Alignment.Center(outerSize))
			{
				ImGui.TextUnformatted(outerText);
			}

			// Create inner container
			Vector2 innerContainerSize = new(200, 60);
			Vector2 innerContainerPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(
				innerContainerPos,
				innerContainerPos + innerContainerSize,
				ImGui.GetColorU32(ImGuiCol.HeaderHovered)
			);

			string innerText = "Inner Centered";
			Vector2 innerSize = ImGui.CalcTextSize(innerText);
			using (new Alignment.CenterWithin(innerSize, innerContainerSize))
			{
				using (Text.Color.Warning())
				{
					ImGui.TextUnformatted(innerText);
				}
			}
		}
		ImGui.EndChild();
	}

	private static void ShowButtonStylingDemo()
	{
		ImGui.TextUnformatted("Button Styling Demonstration");
		ImGui.Text("Button alignment and styling combinations.");
		ImGui.Separator();

		// Button alignment
		ImGui.Text("Button Text Alignment:");
		string[] alignmentNames = ["Left", "Center"];
		ImGui.Combo("Alignment", ref buttonAlignment, alignmentNames, alignmentNames.Length);

		ImGui.Text("Sample buttons with different alignments:");

		using (buttonAlignment == 0 ? Button.Alignment.Left() : Button.Alignment.Center())
		{
			ImGui.Button("Short", new Vector2(150, 0));
			ImGui.Button("Medium Length", new Vector2(150, 0));
			ImGui.Button("Very Long Button Text", new Vector2(150, 0));
		}

		ImGui.Separator();

		// Button styling with themes
		ImGui.Text("Button Styling with Themes:");

		ImGui.Text("Normal themed buttons:");
		ImGui.Button("Normal Button 1");
		ImGui.SameLine();
		ImGui.Button("Normal Button 2");

		ImGui.Text("Themed buttons with alignment:");
		using (Theme.Color(Theme.Palette.Green))
		{
			using (Button.Alignment.Center())
			{
				ImGui.Button("Green Centered", new Vector2(200, 0));
				ImGui.Button("Another Green", new Vector2(200, 0));
			}
		}

		using (Theme.Color(Theme.Palette.Orange))
		{
			using (Button.Alignment.Left())
			{
				ImGui.Button("Orange Left", new Vector2(200, 0));
				ImGui.Button("Another Orange", new Vector2(200, 0));
			}
		}

		ImGui.Separator();

		// Interactive button styling
		ImGui.Text("Interactive Button Styling:");

		if (ImGui.Button("Success Action", new Vector2(150, 40)))
		{
			// Action performed
		}
		ImGui.SameLine();

		using (Theme.Color(Theme.Palette.Error))
		{
			if (ImGui.Button("Danger Action", new Vector2(150, 40)))
			{
				// Dangerous action
			}
		}

		ImGui.Text("Contextual button group:");
		using (Button.Alignment.Center())
		{
			if (ImGui.Button("Save", new Vector2(80, 0)))
			{
				// Save action
			}
			ImGui.SameLine();

			using (Theme.Color(Theme.Palette.Warning))
			{
				if (ImGui.Button("Cancel", new Vector2(80, 0)))
				{
					// Cancel action
				}
			}
			ImGui.SameLine();

			using (Theme.Color(Theme.Palette.Error))
			{
				if (ImGui.Button("Delete", new Vector2(80, 0)))
				{
					// Delete action
				}
			}
		}

		ImGui.Separator();

		// Disabled button states
		ImGui.Text("Disabled Button States:");

		using (Theme.ColorDisabled(Theme.Palette.Blue))
		{
			ImGui.Button("Disabled Blue");
			ImGui.SameLine();
			ImGui.Button("Another Disabled");
		}

		ImGui.Text("Mix of enabled and disabled:");
		ImGui.Button("Enabled Button");
		ImGui.SameLine();
		using (Theme.ColorDisabled(Theme.Palette.Red))
		{
			ImGui.Button("Disabled Red");
		}
	}

	private static void ShowIndentationDemo()
	{
		ImGui.TextUnformatted("Indentation System Demonstration");
		ImGui.Text("Flexible indentation utilities for organizing content.");
		ImGui.Separator();

		// Basic indentation
		ImGui.Text("Basic Default Indentation:");
		ImGui.TextUnformatted("Normal text at base level");
		using (Indent.ByDefault())
		{
			ImGui.TextUnformatted("This text is indented by default amount");
			ImGui.Button("Indented Button");
		}
		ImGui.TextUnformatted("Back to normal level");

		ImGui.Separator();

		// Custom indentation
		ImGui.Text("Custom Indentation:");
		ImGui.SliderFloat("Indent Width", ref indentWidth, 0.0f, 100.0f);

		ImGui.TextUnformatted("Normal text");
		using (Indent.By(indentWidth))
		{
			ImGui.TextUnformatted($"Custom indented by {indentWidth:F1} pixels");
			ImGui.Checkbox("Indented Checkbox", ref valueBool);
		}

		ImGui.Separator();

		// Nested indentation
		ImGui.Text("Nested Indentation:");
		ImGui.TextUnformatted("Level 0 - Base level");
		using (Indent.ByDefault())
		{
			ImGui.TextUnformatted("Level 1 - First indent");
			ImGui.BulletText("Bullet point at level 1");

			using (Indent.ByDefault())
			{
				ImGui.TextUnformatted("Level 2 - Second indent");
				ImGui.Button("Deeply nested button");

				using (Indent.By(30.0f))
				{
					ImGui.TextUnformatted("Level 3 - Custom indent");
					using (Text.Color.Info())
					{
						ImGui.TextUnformatted("Colored text at level 3");
					}
				}
			}

			ImGui.TextUnformatted("Back to level 1");
		}
		ImGui.TextUnformatted("Back to base level");

		ImGui.Separator();

		// Practical usage example
		ImGui.Text("Practical Usage - Configuration Tree:");
		ImGui.TextUnformatted("⚙ Application Settings");
		using (Indent.ByDefault())
		{
			ImGui.Checkbox("Enable Feature A", ref valueBool);

			if (valueBool)
			{
				using (Indent.By(20.0f))
				{
					ImGui.SliderFloat("Feature A Intensity", ref valueFloat, 0.0f, 1.0f);
					ImGui.Checkbox("Advanced Mode", ref valueBool);
				}
			}

			ImGui.TextUnformatted("📊 Performance Settings");
			using (Indent.ByDefault())
			{
				ImGui.SliderInt("Max FPS", ref valueInt, 30, 144);
				ImGui.Checkbox("V-Sync", ref valueBool);

				using (Indent.By(15.0f))
				{
					using (Text.Color.Warning())
					{
						ImGui.TextUnformatted("⚠ Changing these settings may affect performance");
					}
				}
			}
		}

		ImGui.Separator();

		// Mixed indentation with themes
		ImGui.Text("Indentation with Themes:");
		ImGui.TextUnformatted("🎨 Theme Configuration");
		using (Indent.ByDefault())
		{
			using (Theme.Color(Theme.Palette.Blue))
			{
				ImGui.Button("Blue Theme Section");
			}

			using (Indent.By(25.0f))
			{
				using (Theme.Color(Theme.Palette.Green))
				{
					ImGui.TextUnformatted("Green subsection");
					ImGui.Button("Green Action");
				}
			}

			using (Theme.Color(Theme.Palette.Orange))
			{
				ImGui.Button("Orange Theme Section");
			}
		}
	}

	private static void ShowStyleVariablesDemo()
	{
		ImGui.TextUnformatted("Style Variables Demonstration");
		ImGui.Text("Dynamic modification of ImGui style variables.");
		ImGui.Separator();

		// Style variable controls
		ImGui.Text("Style Variable Controls:");
		ImGui.SliderFloat("Frame Padding X", ref styleVarValues[0], 0.0f, 20.0f);
		ImGui.SliderFloat("Frame Padding Y", ref styleVarValues[1], 0.0f, 20.0f);
		ImGui.SliderFloat("Item Spacing X", ref styleVarValues[2], 0.0f, 20.0f);
		ImGui.SliderFloat("Item Spacing Y", ref styleVarValues[3], 0.0f, 20.0f);

		ImGui.Separator();

		// Apply style variables
		ImGui.Text("Elements with Modified Style Variables:");

		using (new ScopedStyleVar(ImGuiStyleVar.FramePadding, new Vector2(styleVarValues[0], styleVarValues[1])))
		using (new ScopedStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(styleVarValues[2], styleVarValues[3])))
		{
			ImGui.TextUnformatted("This content uses modified style variables:");
			ImGui.Button("Modified Button");
			ImGui.SameLine();
			ImGui.Button("Another Button");

			ImGui.Checkbox("Modified Checkbox", ref valueBool);
			ImGui.SliderFloat("Modified Slider", ref valueFloat, 0.0f, 1.0f);
			ImGui.InputText("Modified Input", ref valueString, 128);
		}

		ImGui.Separator();

		ImGui.Text("Normal elements (original style):");
		ImGui.Button("Normal Button");
		ImGui.SameLine();
		ImGui.Button("Another Normal");
		ImGui.Checkbox("Normal Checkbox", ref valueBool);
		ImGui.SliderFloat("Normal Slider", ref valueFloat, 0.0f, 1.0f);

		ImGui.Separator();

		// Multiple style variable combinations
		ImGui.Text("Different Style Variable Combinations:");

		ImGui.Text("Tight spacing:");
		using (new ScopedStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(2.0f, 2.0f)))
		using (new ScopedStyleVar(ImGuiStyleVar.FramePadding, new Vector2(2.0f, 2.0f)))
		{
			ImGui.Button("Tight 1");
			ImGui.SameLine();
			ImGui.Button("Tight 2");
			ImGui.SameLine();
			ImGui.Button("Tight 3");
		}

		ImGui.Text("Loose spacing:");
		using (new ScopedStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(15.0f, 15.0f)))
		using (new ScopedStyleVar(ImGuiStyleVar.FramePadding, new Vector2(15.0f, 10.0f)))
		{
			ImGui.Button("Loose 1");
			ImGui.SameLine();
			ImGui.Button("Loose 2");
			ImGui.SameLine();
			ImGui.Button("Loose 3");
		}

		ImGui.Separator();

		// Window rounding example
		ImGui.Text("Window Rounding Example:");
		using (new ScopedStyleVar(ImGuiStyleVar.WindowRounding, 15.0f))
		using (new ScopedStyleVar(ImGuiStyleVar.ChildRounding, 10.0f))
		{
			ImGui.BeginChild("RoundedChild", new Vector2(0, 80), ImGuiChildFlags.Borders);
			ImGui.TextUnformatted("This child window has rounded corners");
			ImGui.Button("Rounded Button");
			ImGui.EndChild();
		}
	}

	private static void ShowInteractiveExamplesDemo()
	{
		ImGui.TextUnformatted("Interactive Examples");
		ImGui.Text("Real-world usage scenarios combining multiple ImGuiStyler features.");
		ImGui.Separator();

		// Example 1: Settings Panel
		ImGui.Text("Example 1: Settings Panel");
		ImGui.BeginChild("SettingsPanel", new Vector2(0, 200), ImGuiChildFlags.Borders);
		{
			using (Theme.Color(Theme.Palette.Blue))
			{
				string headerText = "⚙ Application Settings";
				Vector2 headerSize = ImGui.CalcTextSize(headerText);
				using (new Alignment.Center(headerSize))
				{
					ImGui.TextUnformatted(headerText);
				}
			}

			ImGui.Separator();

			using (Indent.ByDefault())
			{
				ImGui.Checkbox("Enable Notifications", ref valueBool);

				if (valueBool)
				{
					using (Indent.By(20.0f))
					using (Text.Color.Info())
					{
						ImGui.TextUnformatted("ℹ Notifications will be shown in the system tray");
					}
				}

				ImGui.SliderFloat("Volume", ref valueFloat, 0.0f, 1.0f);

				using (new ScopedStyleVar(ImGuiStyleVar.FramePadding, new Vector2(10.0f, 5.0f)))
				{
					using (Button.Alignment.Center())
					{
						if (ImGui.Button("Apply Settings", new Vector2(150, 0)))
						{
							// Apply settings
						}
						ImGui.SameLine();

						using (Theme.Color(Theme.Palette.Warning))
						{
							if (ImGui.Button("Reset to Default", new Vector2(150, 0)))
							{
								// Reset settings
							}
						}
					}
				}
			}
		}
		ImGui.EndChild();

		ImGui.Separator();

		// Example 2: Status Dashboard
		ImGui.Text("Example 2: Status Dashboard");
		ImGui.BeginChild("StatusDashboard", new Vector2(0, 180), ImGuiChildFlags.Borders);
		{
			using (Theme.Color(Theme.Palette.Green))
			{
				string titleText = "📊 System Status";
				Vector2 titleSize = ImGui.CalcTextSize(titleText);
				using (new Alignment.Center(titleSize))
				{
					ImGui.TextUnformatted(titleText);
				}
			}

			ImGui.Separator();

			// Status indicators
			ImGui.Columns(3, "StatusColumns");

			// CPU Status
			Vector2 cpuContainerSize = new(100, 60);
			Vector2 cpuPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(cpuPos, cpuPos + cpuContainerSize, ImGui.GetColorU32(ImGuiCol.FrameBg));

			using (new Alignment.CenterWithin(ImGui.CalcTextSize("CPU: 45%"), cpuContainerSize))
			{
				using (valueFloat < 0.7f ? Text.Color.Success() : Text.Color.Warning())
				{
					ImGui.TextUnformatted($"CPU: {valueFloat * 100:F0}%");
				}
			}
			ImGui.NextColumn();

			// Memory Status
			Vector2 memPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(memPos, memPos + cpuContainerSize, ImGui.GetColorU32(ImGuiCol.FrameBg));

			using (new Alignment.CenterWithin(ImGui.CalcTextSize("RAM: 67%"), cpuContainerSize))
			{
				using (Text.Color.Info())
				{
					ImGui.TextUnformatted("RAM: 67%");
				}
			}
			ImGui.NextColumn();

			// Network Status
			Vector2 netPos = ImGui.GetCursorScreenPos();
			ImGui.GetWindowDrawList().AddRectFilled(netPos, netPos + cpuContainerSize, ImGui.GetColorU32(ImGuiCol.FrameBg));

			using (new Alignment.CenterWithin(ImGui.CalcTextSize("Network: OK"), cpuContainerSize))
			{
				using (Text.Color.Success())
				{
					ImGui.TextUnformatted("Network: OK");
				}
			}

			ImGui.Columns(1);

			using (Indent.ByDefault())
			{
				ImGui.ProgressBar(valueFloat, new Vector2(-1, 0), $"Overall Health: {valueFloat * 100:F0}%");
			}
		}
		ImGui.EndChild();

		ImGui.Separator();

		// Example 3: Form with Validation
		ImGui.Text("Example 3: Form with Validation");
		ImGui.BeginChild("FormExample", new Vector2(0, 200), ImGuiChildFlags.Borders);
		{
			using (Theme.Color(Theme.Palette.Purple))
			{
				string formTitle = "📝 User Registration";
				Vector2 formTitleSize = ImGui.CalcTextSize(formTitle);
				using (new Alignment.Center(formTitleSize))
				{
					ImGui.TextUnformatted(formTitle);
				}
			}

			ImGui.Separator();

			using (Indent.ByDefault())
			{
				// Username field
				ImGui.InputText("Username", ref valueString, 128);
				if (string.IsNullOrEmpty(valueString))
				{
					using (Indent.By(10.0f))
					using (Text.Color.Error())
					{
						ImGui.TextUnformatted("⚠ Username is required");
					}
				}
				else if (valueString.Length < 3)
				{
					using (Indent.By(10.0f))
					using (Text.Color.Warning())
					{
						ImGui.TextUnformatted("⚠ Username must be at least 3 characters");
					}
				}

				// Age field
				ImGui.SliderInt("Age", ref valueInt, 0, 120);
				if (valueInt < 13)
				{
					using (Indent.By(10.0f))
					using (Text.Color.Warning())
					{
						ImGui.TextUnformatted("⚠ Must be at least 13 years old");
					}
				}

				// Terms acceptance
				ImGui.Checkbox("I accept the terms and conditions", ref valueBool);

				// Submit button
				using (new ScopedStyleVar(ImGuiStyleVar.FramePadding, new Vector2(15.0f, 8.0f)))
				{
					bool canSubmit = !string.IsNullOrEmpty(valueString) && valueString.Length >= 3 && valueInt >= 13 && valueBool;

					if (canSubmit)
					{
						using (Theme.Color(Theme.Palette.Success))
						{
							if (ImGui.Button("Submit Registration", new Vector2(200, 0)))
							{
								// Submit form
							}
						}
					}
					else
					{
						using (Theme.ColorDisabled(Theme.Palette.Gray))
						{
							ImGui.Button("Submit Registration", new Vector2(200, 0));
						}
					}
				}
			}
		}
		ImGui.EndChild();
	}

	private void OnMenu()
	{
		// Application menu can be implemented here
	}

	private void OnWindowResized()
	{
		// Handle window resize events
	}
}
