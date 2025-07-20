// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Information about an available theme.
/// </summary>
public class ThemeInfo
{
	/// <summary>
	/// Gets the name of the theme.
	/// </summary>
	public required string Name { get; init; }

	/// <summary>
	/// Gets the description of the theme.
	/// </summary>
	public required string Description { get; init; }

	/// <summary>
	/// Gets the category of the theme (Light, Dark, etc.).
	/// </summary>
	public required string Category { get; init; }

	/// <summary>
	/// Gets the palette color associated with this theme.
	/// </summary>
	public required ImColor Color { get; init; }
}
