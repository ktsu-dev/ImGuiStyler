// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Solarized theme colors with authentic palette names.
/// Precision colors for machines and people designed by Ethan Schoonover.
/// </summary>
public static class Solarized
{
	// Base colors (from darkest to lightest)
	/// <summary>Gets Base03 - darkest base color.</summary>
	public static ImColor Base03 => Color.FromHex("#002b36");
	/// <summary>Gets Base02 - dark base color.</summary>
	public static ImColor Base02 => Color.FromHex("#073642");
	/// <summary>Gets Base01 - optional emphasized content color.</summary>
	public static ImColor Base01 => Color.FromHex("#586e75");
	/// <summary>Gets Base00 - body text color.</summary>
	public static ImColor Base00 => Color.FromHex("#657b83");
	/// <summary>Gets Base0 - body text color.</summary>
	public static ImColor Base0 => Color.FromHex("#839496");
	/// <summary>Gets Base1 - optional emphasized content color.</summary>
	public static ImColor Base1 => Color.FromHex("#93a1a1");
	/// <summary>Gets Base2 - background highlights color.</summary>
	public static ImColor Base2 => Color.FromHex("#eee8d5");
	/// <summary>Gets Base3 - lightest base color.</summary>
	public static ImColor Base3 => Color.FromHex("#fdf6e3");

	// Accent colors
	/// <summary>Gets the yellow accent color.</summary>
	public static ImColor Yellow => Color.FromHex("#b58900");
	/// <summary>Gets the orange accent color.</summary>
	public static ImColor Orange => Color.FromHex("#cb4b16");
	/// <summary>Gets the red accent color.</summary>
	public static ImColor Red => Color.FromHex("#dc322f");
	/// <summary>Gets the magenta accent color.</summary>
	public static ImColor Magenta => Color.FromHex("#d33682");
	/// <summary>Gets the violet accent color.</summary>
	public static ImColor Violet => Color.FromHex("#6c71c4");
	/// <summary>Gets the blue accent color.</summary>
	public static ImColor Blue => Color.FromHex("#268bd2");
	/// <summary>Gets the cyan accent color.</summary>
	public static ImColor Cyan => Color.FromHex("#2aa198");
	/// <summary>Gets the green accent color.</summary>
	public static ImColor Green => Color.FromHex("#859900");
}
