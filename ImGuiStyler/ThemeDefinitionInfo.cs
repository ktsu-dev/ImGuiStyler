// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

/// <summary>
/// Information about an available complete theme definition.
/// </summary>
public class ThemeDefinitionInfo
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
	/// Gets the complete theme definition.
	/// </summary>
	public required ThemeDefinition Definition { get; init; }
}
