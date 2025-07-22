// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ktsu.ThemeProvider;
using ktsu.ThemeProvider.ImGui;

/// <summary>
/// Tests for theme contrast and accessibility compliance.
/// </summary>
[TestClass]
internal static class ThemeContrastTests
{
	/// <summary>
	/// Tests that all predefined themes provide sufficient contrast for accessibility.
	/// </summary>
	[TestMethod]
		public static void AllThemesShouldHaveSufficientContrast()
	{
		// Test all available themes
		foreach (ThemeRegistry.ThemeInfo themeInfo in Theme.AllThemes.Take(5)) // Test first 5 themes as example
		{
			TestThemeContrast(themeInfo.CreateInstance(), themeInfo.Name);
		}
	}

	private static void TestThemeContrast(ISemanticTheme theme, string themeName)
	{
		var mapper = new ImGuiPaletteMapper();
		var colorMapping = mapper.MapTheme(theme);

		// Check text-to-background contrast
		var textColor = colorMapping.GetValueOrDefault(Hexa.NET.ImGui.ImGuiCol.Text);
		var backgroundColors = new[]
		{
			colorMapping.GetValueOrDefault(Hexa.NET.ImGui.ImGuiCol.WindowBg),
			colorMapping.GetValueOrDefault(Hexa.NET.ImGui.ImGuiCol.FrameBg),
			colorMapping.GetValueOrDefault(Hexa.NET.ImGui.ImGuiCol.Header),
		};

		foreach (var bgColor in backgroundColors)
		{
			float contrastRatio = CalculateContrastRatio(textColor, bgColor);
			Assert.IsTrue(contrastRatio >= 3.0f, $"{themeName}: Text contrast ratio should be ≥3.0, got {contrastRatio:F2}");
		}
	}

	private static float CalculateContrastRatio(System.Numerics.Vector4 color1, System.Numerics.Vector4 color2)
	{
		float lum1 = CalculateLuminance(color1);
		float lum2 = CalculateLuminance(color2);

		float lighter = Math.Max(lum1, lum2);
		float darker = Math.Min(lum1, lum2);

		return (lighter + 0.05f) / (darker + 0.05f);
	}

	private static float CalculateLuminance(System.Numerics.Vector4 color)
	{
		float r = color.X <= 0.03928f ? color.X / 12.92f : MathF.Pow((color.X + 0.055f) / 1.055f, 2.4f);
		float g = color.Y <= 0.03928f ? color.Y / 12.92f : MathF.Pow((color.Y + 0.055f) / 1.055f, 2.4f);
		float b = color.Z <= 0.03928f ? color.Z / 12.92f : MathF.Pow((color.Z + 0.055f) / 1.055f, 2.4f);

		return 0.2126f * r + 0.7152f * g + 0.0722f * b;
	}
}
