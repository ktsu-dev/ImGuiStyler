// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using ktsu.ImGuiStyler;
using ktsu.ImGuiStyler.ThemeSources;
using Hexa.NET.ImGui;

namespace ImGuiStyler.Tests;

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
		var themeProperties = typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))
			.ToList();

		Assert.IsTrue(themeProperties.Count > 0, "No theme definitions found");

		var failedThemes = new List<string>();

		foreach (var themeProperty in themeProperties)
		{
			var themeName = themeProperty.Name;
			var themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			// Test background vs text contrast
			var backgroundContrastRatio = themeDefinition.TextColor.GetContrastRatioOver(themeDefinition.BackgroundColor);
			if (backgroundContrastRatio < WcagAANormalText)
			{
				failedThemes.Add($"{themeName}: Background/Text contrast {backgroundContrastRatio:F2} < {WcagAANormalText}");
			}

			// Test interactive elements that need contrast with text
			var elementsToTest = new Dictionary<string, ImColor>
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

			foreach (var element in elementsToTest)
			{
				var contrastRatio = themeDefinition.TextColor.GetContrastRatioOver(element.Value);
				if (contrastRatio < WcagAANormalText)
				{
					failedThemes.Add($"{themeName}: {element.Key}/Text contrast {contrastRatio:F2} < {WcagAANormalText}");
				}
			}
		}

		if (failedThemes.Count > 0)
		{
			var failureMessage = "The following themes have insufficient contrast ratios:\n" +
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
		var themeProperties = typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))
			.ToList();

		var failedThemes = new List<string>();

		foreach (var themeProperty in themeProperties)
		{
			var themeName = themeProperty.Name;
			var themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			// Test accent color vs background contrast
			var accentContrastRatio = themeDefinition.AccentColor.GetContrastRatioOver(themeDefinition.BackgroundColor);
			if (accentContrastRatio < WcagAALargeText)
			{
				failedThemes.Add($"{themeName}: Accent/Background contrast {accentContrastRatio:F2} < {WcagAALargeText}");
			}

			// Test other important accent elements
			var accentElements = new Dictionary<string, ImColor>
			{
				["CheckMarkColor"] = themeDefinition.CheckMarkColor,
				["SliderGrabColor"] = themeDefinition.SliderGrabColor,
				["PlotLinesColor"] = themeDefinition.PlotLinesColor,
				["PlotHistogramColor"] = themeDefinition.PlotHistogramColor
			};

			foreach (var element in accentElements)
			{
				var contrastRatio = element.Value.GetContrastRatioOver(themeDefinition.BackgroundColor);
				if (contrastRatio < WcagAALargeText)
				{
					failedThemes.Add($"{themeName}: {element.Key}/Background contrast {contrastRatio:F2} < {WcagAALargeText}");
				}
			}
		}

		if (failedThemes.Count > 0)
		{
			var failureMessage = "The following themes have insufficient accent color contrast ratios:\n" +
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
		var themeProperties = typeof(Theme)
			.GetProperties(BindingFlags.Public | BindingFlags.Static)
			.Where(p => p.PropertyType == typeof(ThemeDefinition))
			.ToList();

		Assert.IsTrue(themeProperties.Count > 0, "No theme definitions found");

		foreach (var themeProperty in themeProperties)
		{
			var themeName = themeProperty.Name;
			var themeDefinition = (ThemeDefinition)themeProperty.GetValue(null)!;

			Assert.IsNotNull(themeDefinition, $"{themeName} theme definition is null");

			// Check that all color properties are defined (non-zero)
			var colorProperties = typeof(ThemeDefinition)
				.GetProperties()
				.Where(p => p.PropertyType == typeof(ImColor))
				.ToList();

			foreach (var colorProperty in colorProperties)
			{
				var color = (ImColor)colorProperty.GetValue(themeDefinition)!;
				// ImColor should not be completely transparent or uninitialized
				// Vector4 components: X=Red, Y=Green, Z=Blue, W=Alpha
				Assert.IsTrue(color.Value.W > 0,
					$"{themeName}.{colorProperty.Name} appears to have zero alpha (completely transparent)");

				// Check that at least one of RGB components is non-zero (unless it's intentionally pure black)
				var hasColor = color.Value.X > 0 || color.Value.Y > 0 || color.Value.Z > 0;
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
		var darkGray = Color.FromHex("#333333");
		var lightGray = Color.FromHex("#666666");

		// These should have low contrast
		var originalContrast = lightGray.GetContrastRatioOver(darkGray);

		// Adjust for sufficient contrast
		var adjustedBackground = darkGray.AdjustForSufficientContrast(lightGray);
		var adjustedContrast = lightGray.GetContrastRatioOver(adjustedBackground);

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
		var draculaTextColor = ktsu.ImGuiStyler.ThemeSources.Dracula.Foreground;

		// Test that the ColorFamily can find optimal colors for different contrast requirements
		var optimalBackground = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(draculaTextColor, 4.5f);
		var backgroundContrast = draculaTextColor.GetContrastRatioOver(optimalBackground);

		Assert.IsTrue(backgroundContrast >= 4.5f,
			$"ColorFamily should select background with contrast ≥4.5, got {backgroundContrast:F2}");

		// Test accent color selection
		var optimalAccent = ThemeSwatches.Dracula.Accents.GetOptimalColor(draculaTextColor, 3.0f);
		var accentContrast = draculaTextColor.GetContrastRatioOver(optimalAccent);

		// This should be better than just picking the first accent color
		var firstAccentColor = ThemeSwatches.Dracula.Accents[0];
		var firstAccentContrast = draculaTextColor.GetContrastRatioOver(firstAccentColor);

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
		var gruvboxBackgrounds = ThemeSwatches.Gruvbox.Backgrounds;

		Assert.IsTrue(gruvboxBackgrounds.Count > 1, "Should have multiple background colors");

		// Check that they are properly sorted
		for (int i = 0; i < gruvboxBackgrounds.Count - 1; i++)
		{
			var currentLuminance = gruvboxBackgrounds[i].GetRelativeLuminance();
			var nextLuminance = gruvboxBackgrounds[i + 1].GetRelativeLuminance();

			Assert.IsTrue(currentLuminance <= nextLuminance,
				$"Colors should be sorted by luminance: color {i} ({currentLuminance:F3}) should be darker than color {i + 1} ({nextLuminance:F3})");
		}

		// Test that Darkest and Lightest properties work correctly
		var darkestLuminance = gruvboxBackgrounds.Darkest.GetRelativeLuminance();
		var lightestLuminance = gruvboxBackgrounds.Lightest.GetRelativeLuminance();

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
		var draculaSwatches = ThemeSwatches.GetThemeSwatches("dracula");
		Assert.IsNotNull(draculaSwatches, "Should return valid swatches for Dracula theme");
		Assert.IsTrue(draculaSwatches.ContainsKey("Accents"), "Should contain Accents family");
		Assert.IsTrue(draculaSwatches.ContainsKey("Backgrounds"), "Should contain Backgrounds family");

		var nordSwatches = ThemeSwatches.GetThemeSwatches("NORD");
		Assert.IsNotNull(nordSwatches, "Should return valid swatches for Nord theme (case insensitive)");
		Assert.IsTrue(nordSwatches.ContainsKey("Aurora"), "Should contain Aurora family");

		// Test invalid theme name
		var invalidSwatches = ThemeSwatches.GetThemeSwatches("NonexistentTheme");
		Assert.IsNull(invalidSwatches, "Should return null for invalid theme names");

		// Test null/empty input
		var nullSwatches = ThemeSwatches.GetThemeSwatches(null!);
		Assert.IsNull(nullSwatches, "Should return null for null input");

		var emptySwatches = ThemeSwatches.GetThemeSwatches("");
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
		var textColor = ktsu.ImGuiStyler.ThemeSources.Dracula.Foreground;

		// Generate theme colors using intelligent selection
		var backgroundColor = ThemeSwatches.Dracula.Backgrounds.GetOptimalColor(textColor, 4.5f);
		var buttonColor = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(textColor, 4.5f);
		var buttonHoveredColor = ThemeSwatches.Dracula.Neutrals.GetLighterThan(buttonColor);  // Get a lighter variant
		var accentColor = ThemeSwatches.Dracula.Accents.GetOptimalColor(backgroundColor, 3.0f);
		var headerColor = ThemeSwatches.Dracula.Neutrals.GetOptimalColor(textColor, 4.5f, buttonColor);

		// Verify all generated colors meet or exceed contrast requirements
		var bgContrast = textColor.GetContrastRatioOver(backgroundColor);
		var buttonContrast = textColor.GetContrastRatioOver(buttonColor);
		var buttonHoveredContrast = textColor.GetContrastRatioOver(buttonHoveredColor);
		var accentContrast = accentColor.GetContrastRatioOver(backgroundColor);
		var headerContrast = textColor.GetContrastRatioOver(headerColor);

		Assert.IsTrue(bgContrast >= 4.5f, $"Background contrast should be ≥4.5, got {bgContrast:F2}");
		Assert.IsTrue(buttonContrast >= 4.5f, $"Button contrast should be ≥4.5, got {buttonContrast:F2}");
		Assert.IsTrue(buttonHoveredContrast >= 4.5f, $"ButtonHovered contrast should be ≥4.5, got {buttonHoveredContrast:F2}");
		Assert.IsTrue(accentContrast >= 3.0f, $"Accent contrast should be ≥3.0, got {accentContrast:F2}");
		Assert.IsTrue(headerContrast >= 4.5f, $"Header contrast should be ≥4.5, got {headerContrast:F2}");

		// Verify that button and buttonHovered are different (providing visual feedback)
		var buttonDistance = buttonColor.GetColorDistance(buttonHoveredColor);
		Assert.IsTrue(buttonDistance > 0.01f, $"Button states should be visually distinct, distance: {buttonDistance:F3}");
	}
}
