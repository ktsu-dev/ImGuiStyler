// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Defines a rendering relationship between two color families, specifying contrast requirements
/// and selection preferences for optimal theme generation.
/// </summary>
/// <param name="foregroundFamily">The color family that renders on top (e.g., text, accent).</param>
/// <param name="backgroundFamily">The color family that renders underneath (e.g., backgrounds, surfaces).</param>
/// <param name="minimumContrast">The minimum acceptable contrast ratio for this relationship.</param>
/// <param name="preferredContrast">The preferred contrast ratio for optimal readability.</param>
/// <param name="allowFallback">Whether to allow fallback to contrast adjustment if no suitable colors are found.</param>
public class ColorFamilyRelationship(
	ColorFamily foregroundFamily,
	ColorFamily backgroundFamily,
	float minimumContrast = 3.0f,
	float preferredContrast = 4.5f,
	bool allowFallback = true)
{
	/// <summary>Gets the foreground color family (renders on top).</summary>
	public ColorFamily ForegroundFamily { get; } = foregroundFamily;

	/// <summary>Gets the background color family (renders underneath).</summary>
	public ColorFamily BackgroundFamily { get; } = backgroundFamily;

	/// <summary>Gets the minimum acceptable contrast ratio.</summary>
	public float MinimumContrast { get; } = minimumContrast;

	/// <summary>Gets the preferred contrast ratio for optimal readability.</summary>
	public float PreferredContrast { get; } = preferredContrast;

	/// <summary>Gets whether fallback to contrast adjustment is allowed.</summary>
	public bool AllowFallback { get; } = allowFallback;

	/// <summary>
	/// Finds the optimal color pair from the two families that best satisfies the contrast requirements
	/// while staying as close as possible to the original authentic colors.
	/// </summary>
	/// <param name="preferredForeground">Optional preferred foreground color to stay close to.</param>
	/// <param name="preferredBackground">Optional preferred background color to stay close to.</param>
	/// <returns>The optimal color pair with metadata about the selection.</returns>
	public OptimalColorPair FindOptimalPair(ImColor? preferredForeground = null, ImColor? preferredBackground = null)
	{
		float bestScore = float.MinValue;
		ImColor bestForeground = ForegroundFamily[0];
		ImColor bestBackground = BackgroundFamily[0];
		float bestContrast = 0f;

		// Try all combinations of foreground and background colors
		foreach (ImColor foreground in ForegroundFamily.GetAllColors())
		{
			foreach (ImColor background in BackgroundFamily.GetAllColors())
			{
				float contrast = foreground.GetContrastRatioOver(background);

				// Skip combinations that don't meet minimum requirements
				if (contrast < MinimumContrast)
				{
					continue;
				}

				// Calculate score based on contrast quality and color authenticity
				float score = CalculatePairScore(foreground, background, contrast, preferredForeground, preferredBackground);

				if (score > bestScore)
				{
					bestScore = score;
					bestForeground = foreground;
					bestBackground = background;
					bestContrast = contrast;
				}
			}
		}

		// If no combination meets minimum contrast and fallback is allowed, use contrast adjustment
		if (bestContrast < MinimumContrast && AllowFallback)
		{
			// Find the most authentic combination and adjust it
			OptimalColorPair authenticPair = FindMostAuthenticPair(preferredForeground, preferredBackground);
			bestBackground = authenticPair.Background.AdjustForSufficientContrast(authenticPair.Foreground, PreferredContrast);
			bestForeground = authenticPair.Foreground;
			bestContrast = bestForeground.GetContrastRatioOver(bestBackground);
		}

		return new OptimalColorPair(
			bestForeground,
			bestBackground,
			bestContrast,
			bestContrast >= PreferredContrast,
			bestContrast >= MinimumContrast,
			bestScore);
	}

	/// <summary>
	/// Calculates a score for a foreground/background color pair based on contrast quality and authenticity.
	/// </summary>
	private float CalculatePairScore(ImColor foreground, ImColor background, float contrast,
		ImColor? preferredForeground, ImColor? preferredBackground)
	{
		float score = 0f;

		// Contrast score (higher is better, with bonus for meeting preferred contrast)
		float contrastScore = contrast;
		if (contrast >= PreferredContrast)
		{
			contrastScore += 2.0f; // Bonus for meeting preferred contrast
		}

		score += contrastScore * 10f; // Weight contrast heavily

		// Authenticity score (lower distance to preferred colors is better)
		if (preferredForeground.HasValue)
		{
			float fgDistance = foreground.GetColorDistance(preferredForeground.Value);
			score += Math.Max(0, 2.0f - fgDistance) * 5f; // Bonus for being close to preferred
		}

		if (preferredBackground.HasValue)
		{
			float bgDistance = background.GetColorDistance(preferredBackground.Value);
			score += Math.Max(0, 2.0f - bgDistance) * 5f; // Bonus for being close to preferred
		}

		return score;
	}

	/// <summary>
	/// Finds the most authentic color pair (closest to preferred colors) regardless of contrast.
	/// </summary>
	private OptimalColorPair FindMostAuthenticPair(ImColor? preferredForeground, ImColor? preferredBackground)
	{
		ImColor bestFg = preferredForeground ?? ForegroundFamily.GetClosestToColor(preferredForeground ?? ForegroundFamily[0]);
		ImColor bestBg = preferredBackground ?? BackgroundFamily.GetClosestToColor(preferredBackground ?? BackgroundFamily[0]);

		// If no preferences provided, use the middle colors from each family as most representative
		if (!preferredForeground.HasValue)
		{
			int midIndex = Math.Max(0, ForegroundFamily.Count / 2);
			bestFg = ForegroundFamily[midIndex];
		}

		if (!preferredBackground.HasValue)
		{
			int midIndex = Math.Max(0, BackgroundFamily.Count / 2);
			bestBg = BackgroundFamily[midIndex];
		}

		float contrast = bestFg.GetContrastRatioOver(bestBg);
		return new OptimalColorPair(bestFg, bestBg, contrast, false, contrast >= MinimumContrast, 0f);
	}
}

/// <summary>
/// Represents an optimal color pair selected from two color families, with metadata about the selection quality.
/// </summary>
/// <param name="foreground">The selected foreground color.</param>
/// <param name="background">The selected background color.</param>
/// <param name="contrastRatio">The actual contrast ratio between the colors.</param>
/// <param name="meetsPreferredContrast">Whether the pair meets the preferred contrast ratio.</param>
/// <param name="meetsMinimumContrast">Whether the pair meets the minimum contrast ratio.</param>
/// <param name="qualityScore">The overall quality score of this pairing.</param>
public class OptimalColorPair(ImColor foreground, ImColor background, float contrastRatio,
	bool meetsPreferredContrast, bool meetsMinimumContrast, float qualityScore)
{
	/// <summary>Gets the selected foreground color.</summary>
	public ImColor Foreground { get; } = foreground;

	/// <summary>Gets the selected background color.</summary>
	public ImColor Background { get; } = background;

	/// <summary>Gets the actual contrast ratio between the colors.</summary>
	public float ContrastRatio { get; } = contrastRatio;

	/// <summary>Gets whether this pair meets the preferred contrast ratio.</summary>
	public bool MeetsPreferredContrast { get; } = meetsPreferredContrast;

	/// <summary>Gets whether this pair meets the minimum contrast ratio.</summary>
	public bool MeetsMinimumContrast { get; } = meetsMinimumContrast;

	/// <summary>Gets the overall quality score of this pairing.</summary>
	public float QualityScore { get; } = qualityScore;

	/// <summary>Returns a string representation of this color pair.</summary>
	public override string ToString() =>
		$"OptimalColorPair: Contrast {ContrastRatio:F2}:1, Quality {QualityScore:F1}, " +
		$"Preferred: {MeetsPreferredContrast}, Minimum: {MeetsMinimumContrast}";
}
