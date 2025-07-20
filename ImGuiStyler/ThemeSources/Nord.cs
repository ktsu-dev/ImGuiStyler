// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Nord theme colors with authentic palette names.
/// Arctic-inspired 16-color palette organized by purpose.
/// </summary>
public static class Nord
{
	// Polar Night - Dark colors
	/// <summary>Gets Nord0 - darkest polar night color.</summary>
	public static ImColor Nord0 => Color.FromHex("#2e3440");
	/// <summary>Gets Nord1 - polar night color.</summary>
	public static ImColor Nord1 => Color.FromHex("#3b4252");
	/// <summary>Gets Nord2 - polar night color.</summary>
	public static ImColor Nord2 => Color.FromHex("#434c5e");
	/// <summary>Gets Nord3 - lightest polar night color.</summary>
	public static ImColor Nord3 => Color.FromHex("#4c566a");

	// Snow Storm - Light colors
	/// <summary>Gets Nord4 - darkest snow storm color.</summary>
	public static ImColor Nord4 => Color.FromHex("#d8dee9");
	/// <summary>Gets Nord5 - snow storm color.</summary>
	public static ImColor Nord5 => Color.FromHex("#e5e9f0");
	/// <summary>Gets Nord6 - lightest snow storm color.</summary>
	public static ImColor Nord6 => Color.FromHex("#eceff4");

	// Frost - Blue tones
	/// <summary>Gets Nord7 - frost cyan color.</summary>
	public static ImColor Nord7 => Color.FromHex("#8fbcbb");
	/// <summary>Gets Nord8 - frost light blue color.</summary>
	public static ImColor Nord8 => Color.FromHex("#88c0d0");
	/// <summary>Gets Nord9 - frost blue color.</summary>
	public static ImColor Nord9 => Color.FromHex("#81a1c1");
	/// <summary>Gets Nord10 - frost dark blue color.</summary>
	public static ImColor Nord10 => Color.FromHex("#5e81ac");

	// Aurora - Colorful accents
	/// <summary>Gets Nord11 - aurora red color.</summary>
	public static ImColor Nord11 => Color.FromHex("#bf616a");
	/// <summary>Gets Nord12 - aurora orange color.</summary>
	public static ImColor Nord12 => Color.FromHex("#d08770");
	/// <summary>Gets Nord13 - aurora yellow color.</summary>
	public static ImColor Nord13 => Color.FromHex("#ebcb8b");
	/// <summary>Gets Nord14 - aurora green color.</summary>
	public static ImColor Nord14 => Color.FromHex("#a3be8c");
	/// <summary>Gets Nord15 - aurora purple color.</summary>
	public static ImColor Nord15 => Color.FromHex("#b48ead");
}
