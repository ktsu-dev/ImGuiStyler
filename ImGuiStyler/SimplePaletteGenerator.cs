// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;
using ktsu.ImGuiStyler.ThemeSources;

/// <summary>
/// Simplified palette generator that creates theme definitions using color family relationships.
/// </summary>
public static class SimplePaletteGenerator
{
	/// <summary>
	/// Creates a Dracula theme using intelligent color family selection.
	/// </summary>
	/// <returns>An optimized Dracula theme definition.</returns>
	public static ThemeDefinition CreateDraculaTheme()
	{
		// Define the authentic colors we want to preserve
		ImColor preferredText = Dracula.Foreground;
		ImColor preferredBackground = Dracula.Background;
		ImColor preferredAccent = Dracula.Purple;

		// Use intelligent selection from color families with fallback to adjustment
		ImColor optimalBackground = GetOptimalColorWithFallback(ThemeSwatches.Dracula.Backgrounds, preferredText, 4.5f, preferredBackground);
		ImColor optimalButtonBg = GetOptimalColorWithFallback(ThemeSwatches.Dracula.Neutrals, preferredText, 4.5f);

		// For hover state, try to get a lighter variant, fallback to slightly adjusted version
		ImColor lighterCandidate = ThemeSwatches.Dracula.Neutrals.GetLighterThan(optimalButtonBg);
		ImColor optimalButtonHover = lighterCandidate.GetColorDistance(optimalButtonBg) > 0.05f
			? GetOptimalColorWithFallback(ThemeSwatches.Dracula.Neutrals, preferredText, 4.5f, lighterCandidate)
			: optimalButtonBg.AdjustForSufficientContrast(preferredText); // Fallback for distinctiveness

		ImColor optimalAccent = GetOptimalColorWithFallback(ThemeSwatches.Dracula.Accents, optimalBackground, 3.0f, preferredAccent);
		ImColor optimalHeaderBg = GetOptimalColorWithFallback(ThemeSwatches.Dracula.Neutrals, preferredText, 4.5f);

		return new ThemeDefinition
		{
			BackgroundColor = optimalBackground,
			TextColor = preferredText,
			AccentColor = optimalAccent,

			ButtonColor = optimalButtonBg,
			ButtonHoveredColor = optimalButtonHover,
			ButtonActiveColor = optimalAccent,

			FrameColor = optimalButtonBg,
			FrameHoveredColor = optimalButtonHover,
			FrameActiveColor = optimalAccent,

			HeaderColor = optimalHeaderBg,
			HeaderHoveredColor = optimalButtonHover,
			HeaderActiveColor = optimalAccent,

			BorderColor = optimalButtonBg,
			ScrollbarColor = optimalButtonBg,
			ScrollbarHoveredColor = optimalButtonHover,
			ScrollbarActiveColor = optimalAccent,

			CheckMarkColor = optimalAccent,
			SliderGrabColor = optimalAccent,
			SliderGrabActiveColor = ThemeSwatches.Dracula.Accents.GetLighterThan(optimalAccent),

			TabColor = optimalButtonBg,
			TabHoveredColor = optimalButtonHover,
			TabActiveColor = GetOptimalColorWithFallback(ThemeSwatches.Dracula.Accents, preferredText, 4.5f, preferredAccent),

			PlotLinesColor = ThemeSwatches.Dracula.Accents.GetClosestToColor(Dracula.Cyan),
			PlotHistogramColor = ThemeSwatches.Dracula.Accents.GetClosestToColor(Dracula.Green)
		};
	}

	/// <summary>
	/// Creates a Nord theme using intelligent color family selection.
	/// </summary>
	/// <returns>An optimized Nord theme definition.</returns>
	public static ThemeDefinition CreateNordTheme()
	{
		// Define the authentic colors we want to preserve
		ImColor preferredText = Nord.Nord4;
		ImColor preferredBackground = Nord.Nord0;
		ImColor preferredAccent = Nord.Nord10;

		// Use intelligent selection from color families with fallback to adjustment
		ImColor optimalBackground = GetOptimalColorWithFallback(ThemeSwatches.Nord.Backgrounds, preferredText, 4.5f, preferredBackground);
		ImColor optimalButtonBg = GetOptimalColorWithFallback(ThemeSwatches.Nord.Neutrals, preferredText, 4.5f);

		// For hover state, try to get a lighter variant, fallback to slightly adjusted version
		ImColor lighterCandidate = ThemeSwatches.Nord.Neutrals.GetLighterThan(optimalButtonBg);
		ImColor optimalButtonHover = lighterCandidate.GetColorDistance(optimalButtonBg) > 0.05f
			? GetOptimalColorWithFallback(ThemeSwatches.Nord.Neutrals, preferredText, 4.5f, lighterCandidate)
			: optimalButtonBg.AdjustForSufficientContrast(preferredText); // Fallback for distinctiveness

		ImColor optimalAccent = GetOptimalColorWithFallback(ThemeSwatches.Nord.Accents, optimalBackground, 3.0f, preferredAccent);
		ImColor optimalAurora = GetOptimalColorWithFallback(ThemeSwatches.Nord.Aurora, optimalBackground, 3.0f);

		return new ThemeDefinition
		{
			BackgroundColor = optimalBackground,
			TextColor = preferredText,
			AccentColor = optimalAccent,

			ButtonColor = optimalButtonBg,
			ButtonHoveredColor = optimalButtonHover,
			ButtonActiveColor = optimalAccent,

			FrameColor = optimalButtonBg,
			FrameHoveredColor = optimalButtonHover,
			FrameActiveColor = optimalAccent,

			HeaderColor = optimalButtonBg,
			HeaderHoveredColor = optimalButtonHover,
			HeaderActiveColor = optimalAccent,

			BorderColor = optimalButtonBg,
			ScrollbarColor = optimalButtonBg,
			ScrollbarHoveredColor = optimalButtonHover,
			ScrollbarActiveColor = optimalAccent,

			CheckMarkColor = optimalAccent,
			SliderGrabColor = optimalAccent,
			SliderGrabActiveColor = ThemeSwatches.Nord.Accents.GetLighterThan(optimalAccent),

			TabColor = optimalButtonBg,
			TabHoveredColor = optimalButtonHover,
			TabActiveColor = GetOptimalColorWithFallback(ThemeSwatches.Nord.Accents, preferredText, 4.5f, preferredAccent),

			PlotLinesColor = optimalAurora,
			PlotHistogramColor = ThemeSwatches.Nord.Aurora.GetClosestToColor(Nord.Nord14)
		};
	}

	/// <summary>
	/// Creates a Gruvbox theme using intelligent color family selection.
	/// </summary>
	/// <returns>An optimized Gruvbox theme definition.</returns>
	public static ThemeDefinition CreateGruvboxTheme()
	{
		// Define the authentic colors we want to preserve
		ImColor preferredText = Gruvbox.Light1;
		ImColor preferredBackground = Gruvbox.Dark0;
		ImColor preferredAccent = Gruvbox.BrightOrange;

		// Use intelligent selection from color families with fallback to adjustment
		ImColor optimalBackground = GetOptimalColorWithFallback(ThemeSwatches.Gruvbox.Backgrounds, preferredText, 4.5f, preferredBackground);
		ImColor optimalButtonBg = GetOptimalColorWithFallback(ThemeSwatches.Gruvbox.Neutrals, preferredText, 4.5f);

		// For hover state, try to get a lighter variant, fallback to slightly adjusted version
		ImColor lighterCandidate = ThemeSwatches.Gruvbox.Neutrals.GetLighterThan(optimalButtonBg);
		ImColor optimalButtonHover = lighterCandidate.GetColorDistance(optimalButtonBg) > 0.05f
			? GetOptimalColorWithFallback(ThemeSwatches.Gruvbox.Neutrals, preferredText, 4.5f, lighterCandidate)
			: optimalButtonBg.AdjustForSufficientContrast(preferredText); // Fallback for distinctiveness

		ImColor optimalAccent = GetOptimalColorWithFallback(ThemeSwatches.Gruvbox.BrightAccents, optimalBackground, 3.0f, preferredAccent);

		return new ThemeDefinition
		{
			BackgroundColor = optimalBackground,
			TextColor = preferredText,
			AccentColor = optimalAccent,

			ButtonColor = optimalButtonBg,
			ButtonHoveredColor = optimalButtonHover,
			ButtonActiveColor = optimalAccent,

			FrameColor = optimalButtonBg,
			FrameHoveredColor = optimalButtonHover,
			FrameActiveColor = optimalAccent,

			HeaderColor = optimalButtonBg,
			HeaderHoveredColor = optimalButtonHover,
			HeaderActiveColor = optimalAccent,

			BorderColor = optimalButtonBg,
			ScrollbarColor = optimalButtonBg,
			ScrollbarHoveredColor = optimalButtonHover,
			ScrollbarActiveColor = optimalAccent,

			CheckMarkColor = optimalAccent,
			SliderGrabColor = optimalAccent,
			SliderGrabActiveColor = ThemeSwatches.Gruvbox.BrightAccents.GetLighterThan(optimalAccent),

			TabColor = optimalButtonBg,
			TabHoveredColor = optimalButtonHover,
			TabActiveColor = GetOptimalColorWithFallback(ThemeSwatches.Gruvbox.BrightAccents, preferredText, 4.5f, preferredAccent),

			PlotLinesColor = ThemeSwatches.Gruvbox.BrightAccents.GetClosestToColor(Gruvbox.BrightBlue),
			PlotHistogramColor = ThemeSwatches.Gruvbox.BrightAccents.GetClosestToColor(Gruvbox.BrightAqua)
		};
	}

	/// <summary>
	/// Gets an optimal color from a family that meets the contrast requirement,
	/// falling back to automatic adjustment if no suitable color is found.
	/// </summary>
	/// <param name="colorFamily">The color family to search.</param>
	/// <param name="referenceColor">The color to contrast against.</param>
	/// <param name="targetContrast">The minimum required contrast ratio.</param>
	/// <param name="preferredColor">Optional preferred color to stay close to.</param>
	/// <returns>An optimal color that meets the contrast requirement.</returns>
	private static ImColor GetOptimalColorWithFallback(ColorFamily colorFamily, ImColor referenceColor,
		float targetContrast, ImColor? preferredColor = null)
	{
		// Try to find optimal color from family first
		ImColor optimalColor = colorFamily.GetOptimalColor(referenceColor, targetContrast, preferredColor);

		// Check if it meets our requirement
		float actualContrast = optimalColor.GetContrastRatioOver(referenceColor);
		if (actualContrast >= targetContrast)
		{
			return optimalColor;
		}

		// If not sufficient, use contrast adjustment on the preferred color or optimal color
		ImColor baseColor = preferredColor ?? optimalColor;
		return baseColor.AdjustForSufficientContrast(referenceColor, targetContrast);
	}
}
