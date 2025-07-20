// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Catppuccin Latte theme colors with authentic palette names.
/// Warm, light pastel theme with proper color hierarchy.
/// </summary>
public static class CatppuccinLatte
{
	// Base colors
	/// <summary>Gets the rosewater accent color.</summary>
	public static ImColor Rosewater => Color.FromHex("#dc8a78");
	/// <summary>Gets the flamingo accent color.</summary>
	public static ImColor Flamingo => Color.FromHex("#dd7878");
	/// <summary>Gets the pink accent color.</summary>
	public static ImColor Pink => Color.FromHex("#ea76cb");
	/// <summary>Gets the mauve accent color.</summary>
	public static ImColor Mauve => Color.FromHex("#8839ef");
	/// <summary>Gets the red accent color.</summary>
	public static ImColor Red => Color.FromHex("#d20f39");
	/// <summary>Gets the maroon accent color.</summary>
	public static ImColor Maroon => Color.FromHex("#e64553");
	/// <summary>Gets the peach accent color.</summary>
	public static ImColor Peach => Color.FromHex("#fe640b");
	/// <summary>Gets the yellow accent color.</summary>
	public static ImColor Yellow => Color.FromHex("#df8e1d");
	/// <summary>Gets the green accent color.</summary>
	public static ImColor Green => Color.FromHex("#40a02b");
	/// <summary>Gets the teal accent color.</summary>
	public static ImColor Teal => Color.FromHex("#179299");
	/// <summary>Gets the sky accent color.</summary>
	public static ImColor Sky => Color.FromHex("#04a5e5");
	/// <summary>Gets the sapphire accent color.</summary>
	public static ImColor Sapphire => Color.FromHex("#209fb5");
	/// <summary>Gets the blue accent color.</summary>
	public static ImColor Blue => Color.FromHex("#1e66f5");
	/// <summary>Gets the lavender accent color.</summary>
	public static ImColor Lavender => Color.FromHex("#7287fd");

	// Surface colors (from darkest to lightest for light theme)
	/// <summary>Gets the main text color.</summary>
	public static ImColor Text => Color.FromHex("#4c4f69");
	/// <summary>Gets the secondary text color.</summary>
	public static ImColor Subtext1 => Color.FromHex("#5c5f77");
	/// <summary>Gets the tertiary text color.</summary>
	public static ImColor Subtext0 => Color.FromHex("#6c6f85");
	/// <summary>Gets the overlay level 2 color.</summary>
	public static ImColor Overlay2 => Color.FromHex("#7c7f93");
	/// <summary>Gets the overlay level 1 color.</summary>
	public static ImColor Overlay1 => Color.FromHex("#8c8fa1");
	/// <summary>Gets the overlay level 0 color.</summary>
	public static ImColor Overlay0 => Color.FromHex("#9ca0b0");
	/// <summary>Gets the surface level 2 color.</summary>
	public static ImColor Surface2 => Color.FromHex("#acb0be");
	/// <summary>Gets the surface level 1 color.</summary>
	public static ImColor Surface1 => Color.FromHex("#bcc0cc");
	/// <summary>Gets the surface level 0 color.</summary>
	public static ImColor Surface0 => Color.FromHex("#ccd0da");
	/// <summary>Gets the main base background color.</summary>
	public static ImColor Base => Color.FromHex("#eff1f5");
	/// <summary>Gets the mantle background color.</summary>
	public static ImColor Mantle => Color.FromHex("#e6e9ef");
	/// <summary>Gets the crust background color.</summary>
	public static ImColor Crust => Color.FromHex("#dce0e8");
}
