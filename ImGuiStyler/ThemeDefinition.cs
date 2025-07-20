// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Represents a complete theme definition with all color properties.
/// </summary>
public class ThemeDefinition
{
	/// <summary>
	/// Gets or sets the primary background color.
	/// </summary>
	public ImColor BackgroundColor { get; set; }

	/// <summary>
	/// Gets or sets the primary text color.
	/// </summary>
	public ImColor TextColor { get; set; }

	/// <summary>
	/// Gets or sets the primary accent color.
	/// </summary>
	public ImColor AccentColor { get; set; }

	/// <summary>
	/// Gets or sets the button background color.
	/// </summary>
	public ImColor ButtonColor { get; set; }

	/// <summary>
	/// Gets or sets the button hover color.
	/// </summary>
	public ImColor ButtonHoveredColor { get; set; }

	/// <summary>
	/// Gets or sets the button active color.
	/// </summary>
	public ImColor ButtonActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the frame background color.
	/// </summary>
	public ImColor FrameColor { get; set; }

	/// <summary>
	/// Gets or sets the frame hover color.
	/// </summary>
	public ImColor FrameHoveredColor { get; set; }

	/// <summary>
	/// Gets or sets the frame active color.
	/// </summary>
	public ImColor FrameActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the header color.
	/// </summary>
	public ImColor HeaderColor { get; set; }

	/// <summary>
	/// Gets or sets the header hover color.
	/// </summary>
	public ImColor HeaderHoveredColor { get; set; }

	/// <summary>
	/// Gets or sets the header active color.
	/// </summary>
	public ImColor HeaderActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the border color.
	/// </summary>
	public ImColor BorderColor { get; set; }

	/// <summary>
	/// Gets or sets the scrollbar color.
	/// </summary>
	public ImColor ScrollbarColor { get; set; }

	/// <summary>
	/// Gets or sets the scrollbar hover color.
	/// </summary>
	public ImColor ScrollbarHoveredColor { get; set; }

	/// <summary>
	/// Gets or sets the scrollbar active color.
	/// </summary>
	public ImColor ScrollbarActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the check mark color.
	/// </summary>
	public ImColor CheckMarkColor { get; set; }

	/// <summary>
	/// Gets or sets the slider grab color.
	/// </summary>
	public ImColor SliderGrabColor { get; set; }

	/// <summary>
	/// Gets or sets the slider grab active color.
	/// </summary>
	public ImColor SliderGrabActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the tab color.
	/// </summary>
	public ImColor TabColor { get; set; }

	/// <summary>
	/// Gets or sets the tab hover color.
	/// </summary>
	public ImColor TabHoveredColor { get; set; }

	/// <summary>
	/// Gets or sets the tab active color.
	/// </summary>
	public ImColor TabActiveColor { get; set; }

	/// <summary>
	/// Gets or sets the plot lines color.
	/// </summary>
	public ImColor PlotLinesColor { get; set; }

	/// <summary>
	/// Gets or sets the plot histogram color.
	/// </summary>
	public ImColor PlotHistogramColor { get; set; }
}
