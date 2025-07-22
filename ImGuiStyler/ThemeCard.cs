// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Numerics;
using Hexa.NET.ImGui;
using ktsu.ThemeProvider;

/// <summary>
/// Provides theme preview card widgets for displaying theme information in a dialog window style.
/// </summary>
public static class ThemeCard
{
	/// <summary>
	/// Renders a theme preview card styled like a mini dialog window with title bar and content area.
	/// </summary>
	/// <param name="theme">The theme to render.</param>
	/// <param name="size">The size of the card. If not specified, uses a default size.</param>
	/// <param name="isSelected">Whether this theme is currently selected.</param>
	/// <returns>True if the theme card was clicked, false otherwise.</returns>
	public static bool Render(ThemeRegistry.ThemeInfo theme, Vector2? size = null, bool? isSelected = null) =>
		Render(theme, theme?.Name ?? string.Empty, size, isSelected);

	/// <summary>
	/// Renders a theme preview card styled like a mini dialog window with title bar and content area.
	/// </summary>
	/// <param name="theme">The theme to render.</param>
	/// <param name="displayName">The display name for the theme (shown in the card).</param>
	/// <param name="size">The size of the card. If not specified, uses a default size.</param>
	/// <param name="isSelected">Whether this theme is currently selected. If not specified, compares against current theme.</param>
	/// <returns>True if the theme card was clicked, false otherwise.</returns>
	public static bool Render(ThemeRegistry.ThemeInfo theme, string displayName, Vector2? size = null, bool? isSelected = null)
	{
		ArgumentNullException.ThrowIfNull(theme);
		ArgumentNullException.ThrowIfNull(displayName);

		bool clicked = false;

		// Create a unique ID for this card
		ImGui.PushID($"ThemeCard_{theme.Name}");

		try
		{
			// Determine if this theme is selected
			bool isCurrentTheme = isSelected ?? (Theme.CurrentThemeName == theme.Name);

			// Use default size if not specified
			Vector2 cardSize = size ?? new Vector2(180, 70);

			// Get colors for dialog window style from complete palette
			ImColor primaryColor = Color.Palette.Basic.Blue; // Fallback
			ImColor surfaceColor = Color.Palette.Neutral.Gray; // Fallback
			ImColor textColor = Color.Palette.Neutral.White; // Fallback

			try
			{
				// Use the complete palette for efficient color extraction
				ImmutableDictionary<SemanticColorRequest, PerceptualColor> completePalette = Theme.GetCompletePalette(theme.CreateInstance());

				// Get primary color for title bar
				if (completePalette.TryGetValue(new SemanticColorRequest(SemanticMeaning.Primary, Priority.High), out PerceptualColor primary))
				{
					primaryColor = Color.FromPerceptualColor(primary);
				}

				// Get surface color for background
				if (completePalette.TryGetValue(new SemanticColorRequest(SemanticMeaning.Neutral, Priority.Low), out PerceptualColor surface))
				{
					surfaceColor = Color.FromPerceptualColor(surface);
				}
				else if (completePalette.TryGetValue(new SemanticColorRequest(SemanticMeaning.Neutral, Priority.Medium), out PerceptualColor surfaceMed))
				{
					surfaceColor = Color.FromPerceptualColor(surfaceMed);
				}

				// Get highest priority neutral for text
				if (completePalette.TryGetValue(new SemanticColorRequest(SemanticMeaning.Neutral, Priority.VeryHigh), out PerceptualColor textVeryHigh))
				{
					textColor = Color.FromPerceptualColor(textVeryHigh);
				}
				else if (completePalette.TryGetValue(new SemanticColorRequest(SemanticMeaning.Neutral, Priority.High), out PerceptualColor textHigh))
				{
					textColor = Color.FromPerceptualColor(textHigh);
				}
			}
			catch (ArgumentException)
			{
				// Use fallback colors if extraction fails
			}
			catch (InvalidOperationException)
			{
				// Use fallback colors if extraction fails
			}

			// Use invisible button for interaction
			clicked = ImGui.InvisibleButton($"##card_{theme.Name}", cardSize);

			// Get button bounds for custom drawing
			Vector2 cardMin = ImGui.GetItemRectMin();
			Vector2 cardMax = ImGui.GetItemRectMax();
			ImDrawListPtr drawList = ImGui.GetWindowDrawList();

			bool isHovered = ImGui.IsItemHovered();
			bool isActive = ImGui.IsItemActive();

			float titleBarHeight = 16.0f; // Height of the dialog title bar
			float margin = 3.0f;

			// Calculate dialog window bounds (with margins)
			Vector2 dialogMin = new(cardMin.X + margin, cardMin.Y + margin);
			Vector2 dialogMax = new(cardMax.X - margin, cardMax.Y - margin);
			Vector2 titleBarMax = new(dialogMax.X, dialogMin.Y + titleBarHeight);

			// Draw enhanced shadow for selected themes
			Vector2 shadowOffset = isCurrentTheme ? new(3.0f, 3.0f) : new(2.0f, 2.0f);
			float shadowOpacity = isCurrentTheme ? 0.4f : 0.2f;
			drawList.AddRectFilled(
				dialogMin + shadowOffset,
				dialogMax + shadowOffset,
				ImGui.ColorConvertFloat4ToU32(new Vector4(0.0f, 0.0f, 0.0f, shadowOpacity)),
				3.0f
			);

			// Draw main surface background
			drawList.AddRectFilled(
				dialogMin,
				dialogMax,
				ImGui.ColorConvertFloat4ToU32(surfaceColor.Value),
				3.0f
			);

			// Draw primary color title bar
			drawList.AddRectFilled(
				dialogMin,
				titleBarMax,
				ImGui.ColorConvertFloat4ToU32(primaryColor.Value),
				3.0f,
				ImDrawFlags.RoundCornersTop
			);

			// Add subtle inner glow for selected themes
			if (isCurrentTheme)
			{
				// Inner glow - subtle white glow inside the card
				drawList.AddRect(
					dialogMin + Vector2.One,
					dialogMax - Vector2.One,
					ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.3f)),
					2.5f,
					ImDrawFlags.None,
					1.0f
				);

				// Secondary inner glow for more prominence
				drawList.AddRect(
					dialogMin + new Vector2(2.0f, 2.0f),
					dialogMax - new Vector2(2.0f, 2.0f),
					ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.15f)),
					2.0f,
					ImDrawFlags.None,
					0.5f
				);
			}

			// Add hover effect
			if (isHovered)
			{
				drawList.AddRect(
					dialogMin,
					dialogMax,
					ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.6f)),
					3.0f,
					ImDrawFlags.None,
					1.5f
				);
			}

			// Add active (pressed) effect
			if (isActive)
			{
				drawList.AddRectFilled(
					dialogMin,
					dialogMax,
					ImGui.ColorConvertFloat4ToU32(new Vector4(1.0f, 1.0f, 1.0f, 0.1f)),
					3.0f
				);
			}

			// Draw theme name centered in content area (below title bar)
			// Calculate display text (remove checkmark to avoid layout jumping)
			string displayText = displayName;
			Vector2 textSize = ImGui.CalcTextSize(displayText);

			// Calculate content area bounds (below title bar)
			float contentHeight = dialogMax.Y - titleBarMax.Y;

			Vector2 textPos = new(
				dialogMin.X + ((dialogMax.X - dialogMin.X - textSize.X) * 0.5f), // Centered horizontally
				titleBarMax.Y + ((contentHeight - textSize.Y) * 0.5f) // Centered vertically in content area
			);

			drawList.AddText(textPos, ImGui.ColorConvertFloat4ToU32(textColor.Value), displayText);

			// Add tooltip with theme description if hovered
			if (isHovered)
			{
				ImGui.SetTooltip($"{theme.Description}\n\nFamily: {theme.Family}\nType: {(theme.IsDark ? "Dark" : "Light")}\n\nClick to apply this theme");
			}
		}
		finally
		{
			ImGui.PopID();
		}

		return clicked;
	}

	/// <summary>
	/// Renders a grid of theme preview cards.
	/// </summary>
	/// <param name="themes">The themes to display in the grid.</param>
	/// <param name="cardSize">Size of each card. If not specified, uses default size.</param>
	/// <param name="columnsPerRow">Number of cards per row. If not specified, calculates based on available width.</param>
	/// <returns>The theme that was clicked, or null if no theme was clicked.</returns>
	public static ThemeRegistry.ThemeInfo? RenderGrid(IEnumerable<ThemeRegistry.ThemeInfo> themes, Vector2? cardSize = null, int? columnsPerRow = null)
	{
		ArgumentNullException.ThrowIfNull(themes);

		Vector2 size = cardSize ?? new Vector2(180, 70);
		int columns = columnsPerRow ?? Math.Max(1, (int)(ImGui.GetContentRegionAvail().X / (size.X + 10))); // 10px spacing

		ImGui.Columns(columns, "ThemeCardGrid", false);

		foreach (ThemeRegistry.ThemeInfo theme in themes)
		{
			if (Render(theme, size))
			{
				ImGui.Columns(1); // Reset columns
				return theme;
			}

			ImGui.NextColumn();
		}

		ImGui.Columns(1); // Reset columns
		return null;
	}
}
