// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Generates optimal color palettes from color family relationships, balancing contrast requirements
/// with preservation of authentic theme colors.
/// </summary>
/// <param name="relationships">The color family relationships defining the rendering constraints.</param>
/// <param name="preferredColors">Optional dictionary of preferred authentic colors to stay close to.</param>
public class OptimalPaletteGenerator(IEnumerable<ColorFamilyRelationship> relationships,
	Dictionary<string, ImColor>? preferredColors = null)
{
	private readonly List<ColorFamilyRelationship> relationships = [.. relationships];
	private readonly Dictionary<string, ImColor> preferredColors = preferredColors ?? [];

	/// <summary>
	/// Generates an optimal palette that satisfies all contrast relationships while staying as close
	/// as possible to the preferred authentic colors.
	/// </summary>
	/// <returns>An optimal palette containing the selected colors and quality metrics.</returns>
	public OptimalPalette GeneratePalette()
	{
		Dictionary<string, ImColor> paletteColors = [];
		List<OptimalColorPair> pairResults = [];
		List<string> warnings = [];

		float totalQualityScore = 0f;
		int processedRelationships = 0;

		// Process each relationship to find optimal color pairs
		foreach (ColorFamilyRelationship relationship in relationships)
		{
			// Look for preferred colors that match this relationship
			ImColor? preferredFg = FindPreferredColor(relationship.ForegroundFamily);
			ImColor? preferredBg = FindPreferredColor(relationship.BackgroundFamily);

			// Find the optimal pair for this relationship
			OptimalColorPair pair = relationship.FindOptimalPair(preferredFg, preferredBg);
			pairResults.Add(pair);

			// Store colors using family names as keys
			string fgKey = relationship.ForegroundFamily.Name;
			string bgKey = relationship.BackgroundFamily.Name;

			// Only update if this is a better quality result or first occurrence
			if (!paletteColors.ContainsKey(fgKey) || pair.QualityScore > GetPairQuality(fgKey, pairResults))
			{
				paletteColors[fgKey] = pair.Foreground;
			}

			if (!paletteColors.ContainsKey(bgKey) || pair.QualityScore > GetPairQuality(bgKey, pairResults))
			{
				paletteColors[bgKey] = pair.Background;
			}

			// Track quality and warnings
			totalQualityScore += pair.QualityScore;
			processedRelationships++;

			if (!pair.MeetsMinimumContrast)
			{
				warnings.Add($"{fgKey} over {bgKey}: Insufficient contrast ({pair.ContrastRatio:F2}:1)");
			}
			else if (!pair.MeetsPreferredContrast)
			{
				warnings.Add($"{fgKey} over {bgKey}: Below preferred contrast ({pair.ContrastRatio:F2}:1)");
			}
		}

		float averageQuality = processedRelationships > 0 ? totalQualityScore / processedRelationships : 0f;

		return new OptimalPalette(paletteColors, pairResults.AsReadOnly(), averageQuality, warnings.AsReadOnly());
	}

	/// <summary>
	/// Creates a theme definition from the generated optimal palette using a mapping function.
	/// </summary>
	/// <param name="paletteMapper">Function that maps palette colors to ThemeDefinition properties.</param>
	/// <returns>A theme definition with optimal colors applied.</returns>
	public ThemeDefinition GenerateThemeDefinition(Func<Dictionary<string, ImColor>, ThemeDefinition> paletteMapper)
	{
		ArgumentNullException.ThrowIfNull(paletteMapper);
		OptimalPalette palette = GeneratePalette();
		return paletteMapper(palette.Colors);
	}

	/// <summary>
	/// Finds the preferred color that best matches the given color family.
	/// </summary>
	private ImColor? FindPreferredColor(ColorFamily family)
	{
		// Look for exact family name match
		if (preferredColors.TryGetValue(family.Name, out ImColor exactMatch))
		{
			return exactMatch;
		}

		// Look for partial matches (e.g., "Dracula Text" contains "Text")
		string familyName = family.Name.ToLowerInvariant();
		foreach (KeyValuePair<string, ImColor> kvp in preferredColors)
		{
			string keyLower = kvp.Key?.ToLowerInvariant() ?? string.Empty;
			if (!string.IsNullOrEmpty(keyLower) &&
				(familyName.Contains(keyLower, StringComparison.OrdinalIgnoreCase) ||
				 keyLower.Contains(familyName, StringComparison.OrdinalIgnoreCase)))
			{
				return kvp.Value;
			}
		}

		return null; // No preferred color found
	}

	/// <summary>
	/// Gets the best quality score for colors associated with the given key.
	/// </summary>
	private static float GetPairQuality(string colorKey, List<OptimalColorPair> pairs) =>
		pairs.Where(p => (p.Foreground.ToString()?.Contains(colorKey, StringComparison.OrdinalIgnoreCase) ?? false) ||
						 (p.Background.ToString()?.Contains(colorKey, StringComparison.OrdinalIgnoreCase) ?? false))
			  .DefaultIfEmpty(new OptimalColorPair(Color.FromHex("#000000"), Color.FromHex("#FFFFFF"), 1.0f, false, false, 0f))
			  .Max(p => p.QualityScore);
}

/// <summary>
/// Represents an optimal color palette generated from color family relationships.
/// </summary>
/// <param name="colors">Dictionary of color family names to optimal colors.</param>
/// <param name="colorPairs">List of all optimal color pairs found during generation.</param>
/// <param name="averageQuality">Average quality score across all color relationships.</param>
/// <param name="warnings">List of warnings about contrast or quality issues.</param>
public class OptimalPalette(Dictionary<string, ImColor> colors, IReadOnlyList<OptimalColorPair> colorPairs,
	float averageQuality, IReadOnlyList<string> warnings)
{
	/// <summary>Gets the dictionary of optimal colors keyed by color family name.</summary>
	public Dictionary<string, ImColor> Colors { get; } = colors;

	/// <summary>Gets all optimal color pairs found during palette generation.</summary>
	public IReadOnlyList<OptimalColorPair> ColorPairs { get; } = colorPairs;

	/// <summary>Gets the average quality score across all color relationships.</summary>
	public float AverageQuality { get; } = averageQuality;

	/// <summary>Gets warnings about contrast or quality issues in the generated palette.</summary>
	public IReadOnlyList<string> Warnings { get; } = warnings;

	/// <summary>Gets whether this palette meets all minimum contrast requirements.</summary>
	public bool MeetsAllMinimumContrast => ColorPairs.All(p => p.MeetsMinimumContrast);

	/// <summary>Gets whether this palette meets all preferred contrast requirements.</summary>
	public bool MeetsAllPreferredContrast => ColorPairs.All(p => p.MeetsPreferredContrast);

	/// <summary>Gets the percentage of color pairs that meet preferred contrast.</summary>
	public float PreferredContrastPercentage =>
		ColorPairs.Count > 0 ? ColorPairs.Count(p => p.MeetsPreferredContrast) / (float)ColorPairs.Count * 100f : 100f;

	/// <summary>
	/// Gets a color by family name, or returns a default color if not found.
	/// </summary>
	/// <param name="familyName">The name of the color family.</param>
	/// <param name="defaultColor">Default color to return if not found.</param>
	/// <returns>The optimal color for the family, or the default color.</returns>
	public ImColor GetColor(string familyName, ImColor? defaultColor = null) =>
		Colors.TryGetValue(familyName, out ImColor color) ? color : defaultColor ?? Color.FromHex("#FF00FF");

	/// <summary>Returns a string representation of this palette's quality metrics.</summary>
	public override string ToString() =>
		$"OptimalPalette: Quality {AverageQuality:F1}, " +
		$"Preferred Contrast {PreferredContrastPercentage:F0}%, " +
		$"Colors: {Colors.Count}, Warnings: {Warnings.Count}";
}
