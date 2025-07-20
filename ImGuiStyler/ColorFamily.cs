// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Represents a family of related colors sorted by luminance, providing intelligent color selection based on contrast requirements.
/// </summary>
/// <param name="name">The name of this color family.</param>
/// <param name="colors">The colors in this family, which will be sorted by luminance.</param>
public class ColorFamily(string name, params ImColor[] colors)
{
	private readonly ImColor[] colors = [.. colors.OrderBy(c => c.GetRelativeLuminance())];

	/// <summary>
	/// Gets the name of this color family.
	/// </summary>
	public string Name { get; } = name;

	/// <summary>
	/// Gets the number of colors in this family.
	/// </summary>
	public int Count => colors.Length;

	/// <summary>
	/// Gets the darkest color in this family.
	/// </summary>
	public ImColor Darkest => colors[0];

	/// <summary>
	/// Gets the lightest color in this family.
	/// </summary>
	public ImColor Lightest => colors[^1];

	/// <summary>
	/// Gets a color by index (0 = darkest, Count-1 = lightest).
	/// </summary>
	/// <param name="index">The index of the color to get.</param>
	/// <returns>The color at the specified index.</returns>
	public ImColor this[int index] => colors[index];

	/// <summary>
	/// Finds the optimal color from this family that provides the best contrast with the reference color,
	/// prioritizing colors that meet or exceed the target contrast ratio.
	/// </summary>
	/// <param name="referenceColor">The color to contrast against (usually text or background).</param>
	/// <param name="targetContrast">The minimum acceptable contrast ratio.</param>
	/// <param name="preferCloserToOriginal">If provided, prefer colors closer to this original color when multiple colors meet the contrast requirement.</param>
	/// <returns>The optimal color from this family.</returns>
	public ImColor GetOptimalColor(ImColor referenceColor, float targetContrast = 4.5f, ImColor? preferCloserToOriginal = null)
	{
		if (colors.Length == 0)
		{
			throw new InvalidOperationException($"Color family '{Name}' is empty");
		}

		ImColor bestColor = colors[0];
		float bestContrast = referenceColor.GetContrastRatioOver(bestColor);
		float bestDistance = preferCloserToOriginal?.GetColorDistance(bestColor) ?? float.MaxValue;

		// Find the color with the best contrast, preferring those that meet the target
		foreach (ImColor color in colors)
		{
			float contrast = referenceColor.GetContrastRatioOver(color);
			float distance = preferCloserToOriginal?.GetColorDistance(color) ?? float.MaxValue;

			// Prefer colors that meet the target contrast
			bool currentMeetsTarget = contrast >= targetContrast;
			bool bestMeetsTarget = bestContrast >= targetContrast;

			if (currentMeetsTarget && !bestMeetsTarget)
			{
				// Current meets target, best doesn't - choose current
				bestColor = color;
				bestContrast = contrast;
				bestDistance = distance;
			}
			else if (currentMeetsTarget && bestMeetsTarget)
			{
				// Both meet target - choose the one closer to original, or better contrast if no original
				if (preferCloserToOriginal.HasValue && distance < bestDistance)
				{
					bestColor = color;
					bestContrast = contrast;
					bestDistance = distance;
				}
				else if (!preferCloserToOriginal.HasValue && contrast > bestContrast)
				{
					bestColor = color;
					bestContrast = contrast;
					bestDistance = distance;
				}
			}
			else if (!currentMeetsTarget && !bestMeetsTarget)
			{
				// Neither meets target - choose the one with better contrast
				if (contrast > bestContrast)
				{
					bestColor = color;
					bestContrast = contrast;
					bestDistance = distance;
				}
			}
			// If current doesn't meet target but best does, keep best
		}

		return bestColor;
	}

	/// <summary>
	/// Gets the color closest to the specified luminance value.
	/// </summary>
	/// <param name="targetLuminance">The target luminance (0.0 to 1.0).</param>
	/// <returns>The color with luminance closest to the target.</returns>
	public ImColor GetClosestToLuminance(float targetLuminance)
	{
		if (colors.Length == 0)
		{
			throw new InvalidOperationException($"Color family '{Name}' is empty");
		}

		return colors.OrderBy(c => Math.Abs(c.GetRelativeLuminance() - targetLuminance)).First();
	}

	/// <summary>
	/// Gets the color closest to the specified color in terms of color distance.
	/// </summary>
	/// <param name="targetColor">The target color to match.</param>
	/// <returns>The color closest to the target color.</returns>
	public ImColor GetClosestToColor(ImColor targetColor)
	{
		if (colors.Length == 0)
		{
			throw new InvalidOperationException($"Color family '{Name}' is empty");
		}

		return colors.OrderBy(c => targetColor.GetColorDistance(c)).First();
	}

	/// <summary>
	/// Gets a color that is lighter than the reference color.
	/// </summary>
	/// <param name="referenceColor">The reference color.</param>
	/// <returns>The lightest color that is lighter than the reference, or the lightest color if none are lighter.</returns>
	public ImColor GetLighterThan(ImColor referenceColor)
	{
		float referenceLuminance = referenceColor.GetRelativeLuminance();
		ImColor[] lighterColors = [.. colors.Where(c => c.GetRelativeLuminance() > referenceLuminance)];
		return lighterColors.Length > 0 ? lighterColors[0] : Lightest;
	}

	/// <summary>
	/// Gets a color that is darker than the reference color.
	/// </summary>
	/// <param name="referenceColor">The reference color.</param>
	/// <returns>The darkest color that is darker than the reference, or the darkest color if none are darker.</returns>
	public ImColor GetDarkerThan(ImColor referenceColor)
	{
		float referenceLuminance = referenceColor.GetRelativeLuminance();
		ImColor[] darkerColors = [.. colors.Where(c => c.GetRelativeLuminance() < referenceLuminance)];
		return darkerColors.Length > 0 ? darkerColors[^1] : Darkest;
	}

	/// <summary>
	/// Returns all colors in this family, sorted from darkest to lightest.
	/// </summary>
	/// <returns>An enumerable of all colors in luminance order.</returns>
	public IEnumerable<ImColor> GetAllColors() => colors.AsEnumerable();

	/// <summary>
	/// Returns a string representation of this color family.
	/// </summary>
	/// <returns>A string describing this color family.</returns>
	public override string ToString() => $"ColorFamily '{Name}' with {colors.Length} colors";
}
