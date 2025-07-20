// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Monokai theme colors with authentic palette names.
/// Classic dark theme with bright accents inspired by the Monokai editor theme.
/// </summary>
public static class Monokai
{
	/// <summary>Gets the main background color.</summary>
	public static ImColor Background => Color.FromHex("#272822");
	/// <summary>Gets the foreground text color.</summary>
	public static ImColor Foreground => Color.FromHex("#f8f8f2");
	/// <summary>Gets the selection background color.</summary>
	public static ImColor Selection => Color.FromHex("#49483e");
	/// <summary>Gets the current line background color.</summary>
	public static ImColor LineHighlight => Color.FromHex("#3e3d32");
	/// <summary>Gets the comment color.</summary>
	public static ImColor Comment => Color.FromHex("#75715e");
	/// <summary>Gets the pink/magenta color for keywords.</summary>
	public static ImColor Pink => Color.FromHex("#f92672");
	/// <summary>Gets the orange color for constants and numbers.</summary>
	public static ImColor Orange => Color.FromHex("#fd971f");
	/// <summary>Gets the yellow color for strings.</summary>
	public static ImColor Yellow => Color.FromHex("#e6db74");
	/// <summary>Gets the green color for functions and methods.</summary>
	public static ImColor Green => Color.FromHex("#a6e22e");
	/// <summary>Gets the cyan/blue color for types and classes.</summary>
	public static ImColor Cyan => Color.FromHex("#66d9ef");
	/// <summary>Gets the purple color for variables and parameters.</summary>
	public static ImColor Purple => Color.FromHex("#ae81ff");
}
