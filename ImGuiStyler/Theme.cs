// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using System.Collections.Immutable;
using System.Numerics;
using Hexa.NET.ImGui;
using ktsu.ThemeProvider;
using ktsu.ThemeProvider.ImGui;

/// <summary>
/// Provides methods and properties to manage and apply themes for ImGui elements using ThemeProvider.
/// </summary>
public static class Theme
{
	private static readonly ImGuiPaletteMapper paletteMapper = new();
	private static string? currentThemeName;

	#region Theme Application

	/// <summary>
	/// Applies a semantic theme to ImGui using ThemeProvider's color mapping system.
	/// </summary>
	/// <param name="theme">The semantic theme to apply.</param>
	public static void Apply(ISemanticTheme theme)
	{
		ArgumentNullException.ThrowIfNull(theme);

		// Map the theme to ImGui colors
		ImmutableDictionary<ImGuiCol, Vector4> colorMapping = paletteMapper.MapTheme(theme);

		// Apply all colors to ImGui
		unsafe
		{
			ImGuiStylePtr style = ImGui.GetStyle();
			foreach ((ImGuiCol imguiCol, Vector4 color) in colorMapping)
			{
				style.Colors[(int)imguiCol] = color;
			}
		}
	}

	/// <summary>
	/// Applies a semantic theme to ImGui using ThemeProvider's color mapping system.
	/// This is an alias for Apply(ISemanticTheme).
	/// </summary>
	/// <param name="theme">The semantic theme to apply.</param>
	public static void ApplyTheme(ISemanticTheme theme) => Apply(theme);

	/// <summary>
	/// Applies a theme by name using ThemeRegistry.
	/// </summary>
	/// <param name="themeName">The name of the theme to apply.</param>
	/// <returns>True if the theme was found and applied, false otherwise.</returns>
	public static bool Apply(string themeName)
	{
		ThemeRegistry.ThemeInfo? themeInfo = ThemeRegistry.FindTheme(themeName);
		if (themeInfo is null)
		{
			return false;
		}

		Apply(themeInfo.CreateInstance());
		currentThemeName = themeName;
		return true;
	}

	/// <summary>
	/// Resets ImGui to default styling with no theme applied.
	/// </summary>
	public static void ResetToDefault()
	{
		// Use ImGui's built-in classic color scheme to restore proper defaults
		ImGui.StyleColorsDark();
		currentThemeName = null;
	}

	#endregion

	#region Current Theme Tracking

	/// <summary>
	/// Gets or sets the name of the currently selected theme.
	/// Setting this will apply the theme if it exists, or reset to default if set to null.
	/// </summary>
	public static string? CurrentThemeName
	{
		get => currentThemeName;
		set
		{
			if (value is null)
			{
				ResetToDefault();
			}
			else if (Apply(value))
			{
				currentThemeName = value;
			}
		}
	}

	/// <summary>
	/// Gets the ThemeInfo for the currently selected theme, if any.
	/// </summary>
	public static ThemeRegistry.ThemeInfo? CurrentTheme =>
		currentThemeName is not null ? FindTheme(currentThemeName) : null;

	#endregion

	#region Theme Menu Rendering

	/// <summary>
	/// Renders a theme selection submenu for use in an application's main menu bar.
	/// </summary>
	/// <param name="menuLabel">The label for the theme submenu (default: "Theme")</param>
	/// <returns>True if a theme was selected and changed, false otherwise.</returns>
	public static bool RenderMenu(string menuLabel = "Theme")
	{
		bool themeChanged = false;

		if (ImGui.BeginMenu(menuLabel))
		{
			// Reset option at the top
			bool isReset = currentThemeName is null;
			if (ImGui.MenuItem("Reset to Default", "", isReset))
			{
				if (!isReset)
				{
					ResetToDefault();
					themeChanged = true;
				}
			}

			if (ImGui.IsItemHovered())
			{
				ImGui.SetTooltip("Reset to default ImGui styling with no theme applied");
			}

			ImGui.Separator();

			// Group themes by family for better organization
			IOrderedEnumerable<KeyValuePair<string, ImmutableArray<ThemeRegistry.ThemeInfo>>> themesByFamily = ThemesByFamily.OrderBy(kvp => kvp.Key);

			foreach ((string family, ImmutableArray<ThemeRegistry.ThemeInfo> themes) in themesByFamily)
			{
				if (themes.Length == 1)
				{
					// Single theme - render directly
					ThemeRegistry.ThemeInfo theme = themes[0];
					bool isSelected = currentThemeName == theme.Name;

					if (ImGui.MenuItem(theme.Name, "", isSelected))
					{
						if (!isSelected && Apply(theme.Name))
						{
							themeChanged = true;
						}
					}

					// Add tooltip with theme description
					if (ImGui.IsItemHovered())
					{
						ImGui.SetTooltip(theme.Description);
					}
				}
				else
				{
					themeChanged |= RenderFamilySubmenu(family, themes);
				}
			}

			ImGui.EndMenu();
		}

		return themeChanged;
	}

	/// <summary>
	/// Renders a submenu for a theme family.
	/// </summary>
	/// <param name="family">The theme family name.</param>
	/// <param name="themes">The themes in the family.</param>
	/// <returns>True if a theme was selected and changed, false otherwise.</returns>
	private static bool RenderFamilySubmenu(string family, ImmutableArray<ThemeRegistry.ThemeInfo> themes)
	{
		bool themeChanged = false;

		if (ImGui.BeginMenu(family))
		{
			// Group by dark/light for families with many variants
			if (themes.Length > 4)
			{
				ThemeRegistry.ThemeInfo[] darkThemes = [.. themes.Where(t => t.IsDark)];
				ThemeRegistry.ThemeInfo[] lightThemes = [.. themes.Where(t => !t.IsDark)];

				themeChanged |= RenderThemeGroup("Dark", darkThemes);

				if (darkThemes.Length > 0 && lightThemes.Length > 0)
				{
					ImGui.Separator();
				}

				themeChanged |= RenderThemeGroup("Light", lightThemes);
			}
			else
			{
				// Few themes - render directly
				foreach (ThemeRegistry.ThemeInfo theme in themes)
				{
					bool isSelected = currentThemeName == theme.Name;
					string displayName = theme.Variant ?? theme.Name;

					if (ImGui.MenuItem(displayName, "", isSelected))
					{
						if (!isSelected && Apply(theme.Name))
						{
							themeChanged = true;
						}
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.SetTooltip(theme.Description);
					}
				}
			}

			ImGui.EndMenu();
		}

		return themeChanged;
	}

	/// <summary>
	/// Renders a group of themes with an optional header.
	/// </summary>
	/// <param name="groupName">The group name (e.g., "Dark" or "Light").</param>
	/// <param name="themes">The themes to render.</param>
	/// <returns>True if a theme was selected and changed, false otherwise.</returns>
	private static bool RenderThemeGroup(string groupName, ThemeRegistry.ThemeInfo[] themes)
	{
		bool themeChanged = false;

		if (themes.Length > 0)
		{
			if (!string.IsNullOrEmpty(groupName))
			{
				ImGui.TextDisabled(groupName);
				ImGui.Separator();
			}

			foreach (ThemeRegistry.ThemeInfo theme in themes)
			{
				bool isSelected = currentThemeName == theme.Name;
				string displayName = theme.Variant ?? theme.Name;

				if (ImGui.MenuItem(displayName, "", isSelected))
				{
					if (!isSelected && Apply(theme.Name))
					{
						themeChanged = true;
					}
				}

				if (ImGui.IsItemHovered())
				{
					ImGui.SetTooltip(theme.Description);
				}
			}
		}

		return themeChanged;
	}

	/// <summary>
	/// Renders a simple theme selection menu without family grouping.
	/// </summary>
	/// <param name="menuLabel">The label for the theme submenu (default: "Theme")</param>
	/// <returns>True if a theme was selected and changed, false otherwise.</returns>
	public static bool RenderSimpleMenu(string menuLabel = "Theme")
	{
		bool themeChanged = false;

		if (ImGui.BeginMenu(menuLabel))
		{
			// Reset option at the top
			bool isReset = currentThemeName is null;
			if (ImGui.MenuItem("Reset to Default", "", isReset))
			{
				if (!isReset)
				{
					ResetToDefault();
					themeChanged = true;
				}
			}

			if (ImGui.IsItemHovered())
			{
				ImGui.SetTooltip("Reset to default ImGui styling with no theme applied");
			}

			ImGui.Separator();

			// Group by dark/light
			ThemeRegistry.ThemeInfo[] darkThemes = [.. DarkThemes.OrderBy(t => t.Name)];
			ThemeRegistry.ThemeInfo[] lightThemes = [.. LightThemes.OrderBy(t => t.Name)];

			if (darkThemes.Length > 0)
			{
				ImGui.TextDisabled("Dark Themes");
				ImGui.Separator();

				foreach (ThemeRegistry.ThemeInfo theme in darkThemes)
				{
					bool isSelected = currentThemeName == theme.Name;

					if (ImGui.MenuItem(theme.Name, "", isSelected))
					{
						if (!isSelected && Apply(theme.Name))
						{
							themeChanged = true;
						}
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.SetTooltip(theme.Description);
					}
				}

				if (lightThemes.Length > 0)
				{
					ImGui.Separator();
				}
			}

			if (lightThemes.Length > 0)
			{
				if (darkThemes.Length > 0)
				{
					ImGui.TextDisabled("Light Themes");
					ImGui.Separator();
				}

				foreach (ThemeRegistry.ThemeInfo theme in lightThemes)
				{
					bool isSelected = currentThemeName == theme.Name;

					if (ImGui.MenuItem(theme.Name, "", isSelected))
					{
						if (!isSelected && Apply(theme.Name))
						{
							themeChanged = true;
						}
					}

					if (ImGui.IsItemHovered())
					{
						ImGui.SetTooltip(theme.Description);
					}
				}
			}

			ImGui.EndMenu();
		}

		return themeChanged;
	}

	#endregion

	#region Theme Discovery

	/// <summary>
	/// Gets all available themes with their metadata.
	/// </summary>
	public static ImmutableArray<ThemeRegistry.ThemeInfo> AllThemes => ThemeRegistry.AllThemes;

	/// <summary>
	/// Gets all dark themes.
	/// </summary>
	public static ImmutableArray<ThemeRegistry.ThemeInfo> DarkThemes => ThemeRegistry.DarkThemes;

	/// <summary>
	/// Gets all light themes.
	/// </summary>
	public static ImmutableArray<ThemeRegistry.ThemeInfo> LightThemes => ThemeRegistry.LightThemes;

	/// <summary>
	/// Gets themes grouped by family.
	/// </summary>
	public static ImmutableDictionary<string, ImmutableArray<ThemeRegistry.ThemeInfo>> ThemesByFamily => ThemeRegistry.ThemesByFamily;

	/// <summary>
	/// Gets all theme families.
	/// </summary>
	public static ImmutableArray<string> Families => ThemeRegistry.Families;

	/// <summary>
	/// Finds a theme by name (case-insensitive).
	/// </summary>
	/// <param name="name">The theme name to search for.</param>
	/// <returns>The theme info if found, null otherwise.</returns>
	public static ThemeRegistry.ThemeInfo? FindTheme(string name) => ThemeRegistry.FindTheme(name);

	/// <summary>
	/// Gets all themes in a specific family.
	/// </summary>
	/// <param name="family">The family name.</param>
	/// <returns>Array of themes in the family.</returns>
	public static ImmutableArray<ThemeRegistry.ThemeInfo> GetThemesInFamily(string family) => ThemeRegistry.GetThemesInFamily(family);

	/// <summary>
	/// Creates instances of all themes.
	/// </summary>
	/// <returns>Array of all theme instances.</returns>
	public static ImmutableArray<ISemanticTheme> CreateAllThemeInstances() => ThemeRegistry.CreateAllThemeInstances();

	/// <summary>
	/// Creates theme instances for a specific family.
	/// </summary>
	/// <param name="family">The family name.</param>
	/// <returns>Array of theme instances in the family.</returns>
	public static ImmutableArray<ISemanticTheme> CreateThemeInstancesInFamily(string family) => ThemeRegistry.CreateThemeInstancesInFamily(family);

	#endregion

	#region Scoped Theme Colors

	/// <summary>
	/// Creates a scoped theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance.</returns>
	public static ScopedThemeColor FromColor(ImColor color) => new(color, enabled: true);

	/// <summary>
	/// Creates a scoped disabled theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance with disabled state.</returns>
	public static ScopedThemeColor DisabledFromColor(ImColor color) => new(color, enabled: false);

	#endregion
}
