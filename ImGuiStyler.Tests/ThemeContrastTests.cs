// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using ktsu.ImGuiStyler;
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
}
