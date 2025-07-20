// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ImGuiStyler.Tests;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Hexa.NET.ImGui;
using ktsu.ImGuiStyler;
using ktsu.ImGuiStyler.ThemeSources;

/// <summary>
/// Tests to ensure theme definitions meet accessibility contrast requirements.
/// Uses WCAG 2.1 guidelines for contrast ratios.
/// </summary>
[TestClass]
[SuppressMessage("Microsoft.Performance", "CA1515:Consider making public types internal", Justification = "Test classes must be public for MSTest discovery")]
public sealed class ThemeContrastTests
{
	/// <summary>
	/// WCAG AA standard contrast ratio for normal text (4.5:1).
	/// </summary>
	private const double WcagAANormalText = 4.5;

	/// <summary>
	/// WCAG AA standard contrast ratio for large text (3:1).
	/// </summary>
	private const double WcagAALargeText = 3.0;

	/// <summary>
	/// Tests that all theme definitions have sufficient contrast ratios.
	/// This test verifies that background colors have adequate contrast with text colors.
	/// </summary>
	[TestMethod]
	public void AllThemesShouldHaveSufficientContrast()
	{
		// Get all theme definition properties from the Theme class
		List<PropertyInfo> themeProperties = [.. typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))];

		Assert.IsTrue(themeProperties.Count > 0, "No theme definitions found");

		List<string> failedThemes = [];

		foreach (PropertyInfo? themeProperty in themeProperties)
		{
			string themeName = themeProperty.Name;
			ThemeDefinition themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			// Test background vs text contrast
			float backgroundContrastRatio = themeDefinition.TextColor.GetContrastRatioOver(themeDefinition.BackgroundColor);
			if (backgroundContrastRatio < WcagAANormalText)
			{
				failedThemes.Add($"{themeName}: Background/Text contrast {backgroundContrastRatio:F2} < {WcagAANormalText}");
			}

			// Test interactive elements that need contrast with text
			Dictionary<string, ImColor> elementsToTest = new()
			{
				["ButtonColor"] = themeDefinition.ButtonColor,
				["ButtonHoveredColor"] = themeDefinition.ButtonHoveredColor,
				["FrameColor"] = themeDefinition.FrameColor,
				["FrameHoveredColor"] = themeDefinition.FrameHoveredColor,
				["HeaderColor"] = themeDefinition.HeaderColor,
				["HeaderHoveredColor"] = themeDefinition.HeaderHoveredColor,
				["TabColor"] = themeDefinition.TabColor,
				["TabHoveredColor"] = themeDefinition.TabHoveredColor,
				["TabActiveColor"] = themeDefinition.TabActiveColor
			};

			foreach (KeyValuePair<string, ImColor> element in elementsToTest)
			{
				float contrastRatio = themeDefinition.TextColor.GetContrastRatioOver(element.Value);
				if (contrastRatio < WcagAANormalText)
				{
					failedThemes.Add($"{themeName}: {element.Key}/Text contrast {contrastRatio:F2} < {WcagAANormalText}");
				}
			}
		}

		if (failedThemes.Count > 0)
		{
			string failureMessage = "The following themes have insufficient contrast ratios:\n" +
								string.Join("\n", failedThemes);
			Assert.Fail(failureMessage);
		}
	}

	/// <summary>
	/// Tests that accent colors have sufficient contrast with their background.
	/// </summary>
	[TestMethod]
	public void AllThemesAccentColorsShouldHaveSufficientContrast()
	{
		List<PropertyInfo> themeProperties = [.. typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))];

		List<string> failedThemes = [];

		foreach (PropertyInfo? themeProperty in themeProperties)
		{
			string themeName = themeProperty.Name;
			ThemeDefinition themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			// Test accent color vs background contrast
			float accentContrastRatio = themeDefinition.AccentColor.GetContrastRatioOver(themeDefinition.BackgroundColor);
			if (accentContrastRatio < WcagAALargeText)
			{
				failedThemes.Add($"{themeName}: Accent/Background contrast {accentContrastRatio:F2} < {WcagAALargeText}");
			}

			// Test other important accent elements
			Dictionary<string, ImColor> accentElements = new()
			{
				["CheckMarkColor"] = themeDefinition.CheckMarkColor,
				["SliderGrabColor"] = themeDefinition.SliderGrabColor,
				["PlotLinesColor"] = themeDefinition.PlotLinesColor,
				["PlotHistogramColor"] = themeDefinition.PlotHistogramColor
			};

			foreach (KeyValuePair<string, ImColor> element in accentElements)
			{
				float contrastRatio = element.Value.GetContrastRatioOver(themeDefinition.BackgroundColor);
				if (contrastRatio < WcagAALargeText)
				{
					failedThemes.Add($"{themeName}: {element.Key}/Background contrast {contrastRatio:F2} < {WcagAALargeText}");
				}
			}
		}

		if (failedThemes.Count > 0)
		{
			string failureMessage = "The following themes have insufficient accent color contrast ratios:\n" +
								string.Join("\n", failedThemes);
			Assert.Fail(failureMessage);
		}
	}

	/// <summary>
	/// Tests that all themes are properly defined with non-null colors.
	/// </summary>
	[TestMethod]
	public void AllThemesShouldBeProperlyDefined()
	{
		List<PropertyInfo> themeProperties = [.. typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))];

		Assert.IsTrue(themeProperties.Count > 0, "No theme definitions found");

		foreach (PropertyInfo? themeProperty in themeProperties)
		{
			string themeName = themeProperty.Name;
			ThemeDefinition themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			Assert.IsNotNull(themeDefinition, $"{themeName} theme definition is null");

			// Check that all color properties are defined (non-zero)
			List<PropertyInfo> colorProperties = [.. typeof(ThemeDefinition)
				.GetProperties()
				.Where(p => p.PropertyType == typeof(ImColor))];

			foreach (PropertyInfo? colorProperty in colorProperties)
			{
				ImColor color = (ImColor)colorProperty.GetValue(themeDefinition)!;
				// ImColor should not be completely transparent or uninitialized
				// Vector4 components: X=Red, Y=Green, Z=Blue, W=Alpha
				Assert.IsTrue(color.Value.W > 0,
					$"{themeName}.{colorProperty.Name} appears to have zero alpha (completely transparent)");

				// Check that at least one of RGB components is non-zero (unless it's intentionally pure black)
				bool hasColor = color.Value.X > 0 || color.Value.Y > 0 || color.Value.Z > 0;
				Assert.IsTrue(hasColor || (color.Value.X == 0 && color.Value.Y == 0 && color.Value.Z == 0),
					$"{themeName}.{colorProperty.Name} appears to be undefined");
			}
		}
	}

	/// <summary>
	/// Tests that the contrast adjustment system is working properly by verifying
	/// that adjusted colors actually have better contrast than before adjustment.
	/// </summary>
	[TestMethod]
	public void ContrastAdjustmentSystemShouldWork()
	{
		// Test with a known low-contrast combination
		ImColor darkGray = Color.FromHex("#333333");
		ImColor lightGray = Color.FromHex("#666666");

		// These should have low contrast
		float originalContrast = lightGray.GetContrastRatioOver(darkGray);

		// Adjust for sufficient contrast
		ImColor adjustedBackground = darkGray.AdjustForSufficientContrast(lightGray);
		float adjustedContrast = lightGray.GetContrastRatioOver(adjustedBackground);

		// The adjusted version should have better contrast
		Assert.IsTrue(adjustedContrast >= Color.OptimalTextContrastRatio,
			$"Adjusted contrast {adjustedContrast:F2} should be at least {Color.OptimalTextContrastRatio}");
		Assert.IsTrue(adjustedContrast > originalContrast,
			$"Adjusted contrast {adjustedContrast:F2} should be better than original {originalContrast:F2}");
	}

	/// <summary>
	/// Tests that the new ColorFamily system can intelligently select optimal colors
	/// for better contrast than manual color selection.
	/// </summary>
	[TestMethod]
	public void ColorFamilySystemShouldSelectOptimalColors()
	{
		// Test with Dracula theme - get the text color
		ImColor draculaTextColor = Dracula.Foreground;

		// Test that the ColorFamily can find optimal colors for different contrast requirements
		ImColor optimalBackground = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(draculaTextColor, 4.5f);
		float backgroundContrast = draculaTextColor.GetContrastRatioOver(optimalBackground);

		Assert.IsTrue(backgroundContrast >= 4.5f,
			$"ColorFamily should select background with contrast ≥4.5, got {backgroundContrast:F2}");

		// Test accent color selection
		ImColor optimalAccent = ThemeSwatches.Dracula.Accents.GetOptimalColor(draculaTextColor, 3.0f);
		float accentContrast = draculaTextColor.GetContrastRatioOver(optimalAccent);

		// This should be better than just picking the first accent color
		ImColor firstAccentColor = ThemeSwatches.Dracula.Accents[0];
		float firstAccentContrast = draculaTextColor.GetContrastRatioOver(firstAccentColor);

		Assert.IsTrue(accentContrast >= firstAccentContrast,
			$"Optimal accent ({accentContrast:F2}) should have better contrast than first accent ({firstAccentContrast:F2})");
	}

	/// <summary>
	/// Tests that color families are properly sorted by luminance.
	/// </summary>
	[TestMethod]
	public void ColorFamiliesShouldBeSortedByLuminance()
	{
		// Test with Gruvbox backgrounds - should be sorted darkest to lightest
		ColorFamily gruvboxBackgrounds = ThemeSwatches.Gruvbox.Backgrounds;

		Assert.IsTrue(gruvboxBackgrounds.Count > 1, "Should have multiple background colors");

		// Check that they are properly sorted
		for (int i = 0; i < gruvboxBackgrounds.Count - 1; i++)
		{
			float currentLuminance = gruvboxBackgrounds[i].GetRelativeLuminance();
			float nextLuminance = gruvboxBackgrounds[i + 1].GetRelativeLuminance();

			Assert.IsTrue(currentLuminance <= nextLuminance,
				$"Colors should be sorted by luminance: color {i} ({currentLuminance:F3}) should be darker than color {i + 1} ({nextLuminance:F3})");
		}

		// Test that Darkest and Lightest properties work correctly
		float darkestLuminance = gruvboxBackgrounds.Darkest.GetRelativeLuminance();
		float lightestLuminance = gruvboxBackgrounds.Lightest.GetRelativeLuminance();

		Assert.IsTrue(darkestLuminance <= lightestLuminance,
			$"Darkest ({darkestLuminance:F3}) should be darker than Lightest ({lightestLuminance:F3})");
	}

	/// <summary>
	/// Tests that the GetThemeSwatches method works correctly for dynamic theme access.
	/// </summary>
	[TestMethod]
	public void GetThemeSwatchesShouldReturnValidFamilies()
	{
		// Test valid theme names
		Dictionary<string, ColorFamily>? draculaSwatches = ThemeSwatches.GetThemeSwatches("dracula");
		Assert.IsNotNull(draculaSwatches, "Should return valid swatches for Dracula theme");
		Assert.IsTrue(draculaSwatches.ContainsKey("Accents"), "Should contain Accents family");
		Assert.IsTrue(draculaSwatches.ContainsKey("Backgrounds"), "Should contain Backgrounds family");

		Dictionary<string, ColorFamily>? nordSwatches = ThemeSwatches.GetThemeSwatches("NORD");
		Assert.IsNotNull(nordSwatches, "Should return valid swatches for Nord theme (case insensitive)");
		Assert.IsTrue(nordSwatches.ContainsKey("Aurora"), "Should contain Aurora family");

		// Test invalid theme name
		Dictionary<string, ColorFamily>? invalidSwatches = ThemeSwatches.GetThemeSwatches("NonexistentTheme");
		Assert.IsNull(invalidSwatches, "Should return null for invalid theme names");

		// Test null/empty input
		Dictionary<string, ColorFamily>? nullSwatches = ThemeSwatches.GetThemeSwatches(null!);
		Assert.IsNull(nullSwatches, "Should return null for null input");

		Dictionary<string, ColorFamily>? emptySwatches = ThemeSwatches.GetThemeSwatches("");
		Assert.IsNull(emptySwatches, "Should return null for empty input");
	}

	/// <summary>
	/// Demonstrates how the ColorFamily system could be used to automatically generate
	/// a theme definition with optimal contrast ratios.
	/// </summary>
	[TestMethod]
	public void DemonstrateAutomaticThemeGeneration()
	{
		// Use the ColorFamily system to automatically generate optimal colors for a Dracula-based theme
		ImColor textColor = Dracula.Foreground;

		// Generate theme colors using intelligent selection
		ImColor backgroundColor = ThemeSwatches.Dracula.Backgrounds.GetOptimalColor(textColor, 4.5f);
		ImColor buttonColor = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(textColor, 4.5f);
		ImColor buttonHoveredColor = ThemeSwatches.Dracula.Neutrals.GetLighterThan(buttonColor);  // Get a lighter variant
		ImColor accentColor = ThemeSwatches.Dracula.Accents.GetOptimalColor(backgroundColor, 3.0f);
		ImColor headerColor = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(textColor, 4.5f, buttonColor);

		// Verify all generated colors meet or exceed contrast requirements
		float bgContrast = textColor.GetContrastRatioOver(backgroundColor);
		float buttonContrast = textColor.GetContrastRatioOver(buttonColor);
		float buttonHoveredContrast = textColor.GetContrastRatioOver(buttonHoveredColor);
		float accentContrast = accentColor.GetContrastRatioOver(backgroundColor);
		float headerContrast = textColor.GetContrastRatioOver(headerColor);

		Assert.IsTrue(bgContrast >= 4.5f, $"Background contrast should be ≥4.5, got {bgContrast:F2}");
		Assert.IsTrue(buttonContrast >= 4.5f, $"Button contrast should be ≥4.5, got {buttonContrast:F2}");
		Assert.IsTrue(buttonHoveredContrast >= 4.5f, $"ButtonHovered contrast should be ≥4.5, got {buttonHoveredContrast:F2}");
		Assert.IsTrue(accentContrast >= 3.0f, $"Accent contrast should be ≥3.0, got {accentContrast:F2}");
		Assert.IsTrue(headerContrast >= 4.5f, $"Header contrast should be ≥4.5, got {headerContrast:F2}");

		// Verify that button and buttonHovered are different (providing visual feedback)
		float buttonDistance = buttonColor.GetColorDistance(buttonHoveredColor);
		Assert.IsTrue(buttonDistance > 0.05f, $"Button states should be visually distinct, distance: {buttonDistance:F3}");
	}

	/// <summary>
	/// Demonstrates the new ColorFamilyRelationship system for automatically generating
	/// optimal color palettes that balance contrast requirements with authentic theme preservation.
	/// </summary>
	[TestMethod]
	public void DemonstrateColorFamilyRelationshipSystem()
	{
		// Create color family relationships defining how different elements should render
		List<ColorFamilyRelationship> relationships =
		[
			// Text needs high contrast over backgrounds
			new(ThemeSwatches.Dracula.Text, ThemeSwatches.Dracula.Backgrounds, 4.5f, 7.0f),

			// Accents need good contrast over backgrounds (but less than text)
			new(ThemeSwatches.Dracula.Accents, ThemeSwatches.Dracula.Backgrounds, 3.0f, 4.5f),

			// Text needs to be readable over neutral surfaces
			new(ThemeSwatches.Dracula.Text, ThemeSwatches.Dracula.Neutrals, 4.5f, 7.0f)
		];

		// Set preferred authentic colors we want to stay close to
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Dracula Text"] = Dracula.Foreground,
			["Dracula Backgrounds"] = Dracula.Background,
			["Dracula Accents"] = Dracula.Purple
		};

		// Test individual relationship optimization first
		ColorFamilyRelationship textOverBg = relationships[0];
		OptimalColorPair optimalPair = textOverBg.FindOptimalPair(
			Dracula.Foreground,
			Dracula.Background);

		// Generate optimal palette using all relationships
		PaletteGenerator generator = new(relationships, preferredColors);
		OptimalPalette palette = generator.GeneratePalette();

		// Verify the relationship found good contrast
		Assert.IsTrue(optimalPair.MeetsMinimumContrast,
			$"Text over background should meet minimum contrast, got {optimalPair.ContrastRatio:F2}:1");

		Assert.IsTrue(optimalPair.ContrastRatio >= 3.0f,
			$"Should have decent contrast ratio, got {optimalPair.ContrastRatio:F2}:1");

		// Verify quality metrics are reasonable
		Assert.IsTrue(optimalPair.QualityScore > 0,
			$"Should have positive quality score, got {optimalPair.QualityScore:F1}");

		// Test that the system preserves color authenticity
		// The optimal colors should be reasonably close to the preferred authentic colors
		float fgDistance = optimalPair.Foreground.GetColorDistance(Dracula.Foreground);
		float bgDistance = optimalPair.Background.GetColorDistance(Dracula.Background);

		Assert.IsTrue(fgDistance < 1.0f, $"Foreground should stay close to authentic color, distance: {fgDistance:F3}");
		Assert.IsTrue(bgDistance < 1.0f, $"Background should stay close to authentic color, distance: {bgDistance:F3}");
	}

	/// <summary>
	/// Demonstrates that the new palette-generated themes have better contrast ratios
	/// than manually created themes while preserving authentic colors.
	/// </summary>
	[TestMethod]
	public void PaletteGeneratedThemesShouldHaveOptimalContrast()
	{
		// Test the new palette-generated Dracula theme
		ThemeDefinition draculaTheme = Theme.Dracula;

		// Verify all critical contrast ratios
		float bgTextContrast = draculaTheme.TextColor.GetContrastRatioOver(draculaTheme.BackgroundColor);
		float buttonTextContrast = draculaTheme.TextColor.GetContrastRatioOver(draculaTheme.ButtonColor);
		float headerTextContrast = draculaTheme.TextColor.GetContrastRatioOver(draculaTheme.HeaderColor);
		float tabTextContrast = draculaTheme.TextColor.GetContrastRatioOver(draculaTheme.TabColor);

		// All should meet WCAG AA standards for normal text (4.5:1)
		Assert.IsTrue(bgTextContrast >= 4.5f, $"Background/Text contrast should be ≥4.5, got {bgTextContrast:F2}");
		Assert.IsTrue(buttonTextContrast >= 4.5f, $"Button/Text contrast should be ≥4.5, got {buttonTextContrast:F2}");
		Assert.IsTrue(headerTextContrast >= 4.5f, $"Header/Text contrast should be ≥4.5, got {headerTextContrast:F2}");
		Assert.IsTrue(tabTextContrast >= 4.5f, $"Tab/Text contrast should be ≥4.5, got {tabTextContrast:F2}");

		// Test visual distinctiveness between states
		float buttonHoverDistance = draculaTheme.ButtonColor.GetColorDistance(draculaTheme.ButtonHoveredColor);
		Assert.IsTrue(buttonHoverDistance > 0.03f, $"Button states should be visually distinct, distance: {buttonHoverDistance:F3}");

		// Test Nord theme
		ThemeDefinition nordTheme = Theme.Nord;
		float nordBgTextContrast = nordTheme.TextColor.GetContrastRatioOver(nordTheme.BackgroundColor);
		float nordButtonTextContrast = nordTheme.TextColor.GetContrastRatioOver(nordTheme.ButtonColor);

		Assert.IsTrue(nordBgTextContrast >= 4.5f, $"Nord Background/Text contrast should be ≥4.5, got {nordBgTextContrast:F2}");
		Assert.IsTrue(nordButtonTextContrast >= 4.5f, $"Nord Button/Text contrast should be ≥4.5, got {nordButtonTextContrast:F2}");

		// Test Gruvbox theme
		ThemeDefinition gruvboxTheme = Theme.GruvboxDark;
		float gruvboxBgTextContrast = gruvboxTheme.TextColor.GetContrastRatioOver(gruvboxTheme.BackgroundColor);
		float gruvboxButtonTextContrast = gruvboxTheme.TextColor.GetContrastRatioOver(gruvboxTheme.ButtonColor);

		Assert.IsTrue(gruvboxBgTextContrast >= 4.5f, $"Gruvbox Background/Text contrast should be ≥4.5, got {gruvboxBgTextContrast:F2}");
		Assert.IsTrue(gruvboxButtonTextContrast >= 4.5f, $"Gruvbox Button/Text contrast should be ≥4.5, got {gruvboxButtonTextContrast:F2}");

		// Verify authentic color preservation - colors should be reasonably close to originals
		float draculaTextDistance = draculaTheme.TextColor.GetColorDistance(Dracula.Foreground);
		float draculaAccentDistance = draculaTheme.AccentColor.GetColorDistance(Dracula.Purple);

		Assert.IsTrue(draculaTextDistance < 0.1f, $"Dracula text should be close to authentic, distance: {draculaTextDistance:F3}");
		Assert.IsTrue(draculaAccentDistance < 0.5f, $"Dracula accent should be reasonably close to authentic, distance: {draculaAccentDistance:F3}");
	}

	/// <summary>
	/// Tests that the PaletteGenerator methods produce valid theme definitions.
	/// </summary>
	[TestMethod]
	public void SimplePaletteGeneratorShouldProduceValidThemes()
	{
		// Test all three generator methods
		ThemeDefinition draculaTheme = PaletteGenerator.CreateDraculaTheme();
		ThemeDefinition nordTheme = PaletteGenerator.CreateNordTheme();
		ThemeDefinition gruvboxTheme = PaletteGenerator.CreateGruvboxTheme();

		// Verify themes are not null
		Assert.IsNotNull(draculaTheme, "Dracula theme should not be null");
		Assert.IsNotNull(nordTheme, "Nord theme should not be null");
		Assert.IsNotNull(gruvboxTheme, "Gruvbox theme should not be null");

		// Verify all themes have non-transparent alpha values
		Assert.IsTrue(draculaTheme.TextColor.Value.W > 0, "Dracula text should not be transparent");
		Assert.IsTrue(nordTheme.BackgroundColor.Value.W > 0, "Nord background should not be transparent");
		Assert.IsTrue(gruvboxTheme.AccentColor.Value.W > 0, "Gruvbox accent should not be transparent");

		// Verify themes have different characteristics (not all the same)
		float draculaVsNordDistance = draculaTheme.BackgroundColor.GetColorDistance(nordTheme.BackgroundColor);
		float nordVsGruvboxDistance = nordTheme.AccentColor.GetColorDistance(gruvboxTheme.AccentColor);

		Assert.IsTrue(draculaVsNordDistance > 0.1f, $"Themes should be visually distinct, Dracula vs Nord: {draculaVsNordDistance:F3}");
		Assert.IsTrue(nordVsGruvboxDistance > 0.1f, $"Themes should be visually distinct, Nord vs Gruvbox: {nordVsGruvboxDistance:F3}");
	}
}
