// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;
using ktsu.ScopedAction;

/// <summary>
/// Represents a scoped action that applies a theme color to ImGui elements.
/// </summary>
public class ScopedThemeColor : ScopedAction
{
	/// <summary>
	/// Initializes a new instance of the <see cref="ScopedThemeColor"/> class.
	/// </summary>
	/// <param name="baseColor">The base color to apply to the theme.</param>
	/// <param name="enabled">Whether the theme should be enabled or disabled.</param>
	public ScopedThemeColor(ImColor baseColor, bool enabled)
	{
		ImColor stateColor = Theme.GetStateColor(baseColor, enabled);
		ImColor normalColor = Theme.GetNormalColor(stateColor);
		ImColor accentColor = Theme.GetAccentColor(baseColor);
		ImColor accentHoveredColor = Theme.GetAccentHoveredColor(baseColor);
		ImColor headerColor = Theme.GetHeaderColor(stateColor);
		ImColor hoveredColor = Theme.GetHoveredColor(stateColor);
		ImColor activeColor = Theme.GetActiveColor(stateColor);
		ImColor backgroundColor = Theme.GetBackgroundColor(stateColor);
		ImColor dragColor = Theme.GetDragColor(stateColor);
		ImColor textColor = Theme.GetTextColor(backgroundColor);
		ImColor borderColor = textColor.MultiplyLuminance(0.7f);

		int numStyles = 0;
		PushStyleAndCount(ImGuiCol.Text, textColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TextSelectedBg, stateColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TextDisabled, textColor.MultiplySaturation(0.5f), ref numStyles);
		PushStyleAndCount(ImGuiCol.Button, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ButtonActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ButtonHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.CheckMark, textColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.Header, headerColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.HeaderActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.HeaderHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.SliderGrab, stateColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.SliderGrabActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.Tab, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TabSelected, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TabHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TitleBg, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TitleBgActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.TitleBgCollapsed, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.Border, borderColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.FrameBg, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.FrameBgActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.FrameBgHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.NavCursor, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ResizeGrip, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ResizeGripActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ResizeGripHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.PlotLines, accentColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.PlotLinesHovered, accentHoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.PlotHistogram, accentColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.PlotHistogramHovered, accentHoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ScrollbarGrab, normalColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ScrollbarGrabActive, activeColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ScrollbarGrabHovered, hoveredColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.WindowBg, backgroundColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.ChildBg, backgroundColor, ref numStyles);
		PushStyleAndCount(ImGuiCol.PopupBg, backgroundColor, ref numStyles);

		OnClose = () => ImGui.PopStyleColor(numStyles);
	}

	private static void PushStyleAndCount(ImGuiCol style, ImColor color, ref int numStyles)
	{
		ImGui.PushStyleColor(style, color.Value);
		++numStyles;
	}
}
