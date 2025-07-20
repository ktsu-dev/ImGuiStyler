// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Catppuccin Frappe theme colors with authentic palette names.
/// Dark theme with purple accents and proper color hierarchy.
/// </summary>
public static class CatppuccinFrappe
{
	// Base colors
	/// <summary>Gets the rosewater accent color.</summary>
	public static ImColor Rosewater => Color.FromHex("#f2d5cf");
	/// <summary>Gets the flamingo accent color.</summary>
	public static ImColor Flamingo => Color.FromHex("#eebebe");
	/// <summary>Gets the pink accent color.</summary>
	public static ImColor Pink => Color.FromHex("#f4b8e4");
	/// <summary>Gets the mauve accent color.</summary>
	public static ImColor Mauve => Color.FromHex("#ca9ee6");
	/// <summary>Gets the red accent color.</summary>
	public static ImColor Red => Color.FromHex("#e78284");
	/// <summary>Gets the maroon accent color.</summary>
	public static ImColor Maroon => Color.FromHex("#ea999c");
	/// <summary>Gets the peach accent color.</summary>
	public static ImColor Peach => Color.FromHex("#ef9f76");
	/// <summary>Gets the yellow accent color.</summary>
	public static ImColor Yellow => Color.FromHex("#e5c890");
	/// <summary>Gets the green accent color.</summary>
	public static ImColor Green => Color.FromHex("#a6d189");
	/// <summary>Gets the teal accent color.</summary>
	public static ImColor Teal => Color.FromHex("#81c8be");
	/// <summary>Gets the sky accent color.</summary>
	public static ImColor Sky => Color.FromHex("#99d1db");
	/// <summary>Gets the sapphire accent color.</summary>
	public static ImColor Sapphire => Color.FromHex("#85c1dc");
	/// <summary>Gets the blue accent color.</summary>
	public static ImColor Blue => Color.FromHex("#8caaee");
	/// <summary>Gets the lavender accent color.</summary>
	public static ImColor Lavender => Color.FromHex("#babbf1");

	// Surface colors (from lightest to darkest for dark theme)
	/// <summary>Gets the main text color.</summary>
	public static ImColor Text => Color.FromHex("#c6d0f5");
	/// <summary>Gets the secondary text color.</summary>
	public static ImColor Subtext1 => Color.FromHex("#b5bfe2");
	/// <summary>Gets the tertiary text color.</summary>
	public static ImColor Subtext0 => Color.FromHex("#a5adce");
	/// <summary>Gets the overlay level 2 color.</summary>
	public static ImColor Overlay2 => Color.FromHex("#949cbb");
	/// <summary>Gets the overlay level 1 color.</summary>
	public static ImColor Overlay1 => Color.FromHex("#838ba7");
	/// <summary>Gets the overlay level 0 color.</summary>
	public static ImColor Overlay0 => Color.FromHex("#737994");
	/// <summary>Gets the surface level 2 color.</summary>
	public static ImColor Surface2 => Color.FromHex("#626880");
	/// <summary>Gets the surface level 1 color.</summary>
	public static ImColor Surface1 => Color.FromHex("#51576d");
	/// <summary>Gets the surface level 0 color.</summary>
	public static ImColor Surface0 => Color.FromHex("#414559");
	/// <summary>Gets the main base background color.</summary>
	public static ImColor Base => Color.FromHex("#303446");
	/// <summary>Gets the mantle background color.</summary>
	public static ImColor Mantle => Color.FromHex("#292c3c");
	/// <summary>Gets the crust background color.</summary>
	public static ImColor Crust => Color.FromHex("#232634");
}
