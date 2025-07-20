// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// OneDark theme colors with authentic palette names.
/// Popular dark theme with balanced colors from Atom editor.
/// </summary>
public static class OneDark
{
	/// <summary>Gets the main background color.</summary>
	public static ImColor Background => Color.FromHex("#282c34");
	/// <summary>Gets the darker background color.</summary>
	public static ImColor BackgroundDark => Color.FromHex("#21252b");
	/// <summary>Gets the lighter background color.</summary>
	public static ImColor BackgroundLight => Color.FromHex("#2c313c");
	/// <summary>Gets the gutter background color.</summary>
	public static ImColor Gutter => Color.FromHex("#636d83");
	/// <summary>Gets the selection background color.</summary>
	public static ImColor Selection => Color.FromHex("#3e4451");
	/// <summary>Gets the line highlight background color.</summary>
	public static ImColor LineHighlight => Color.FromHex("#2c313c");
	/// <summary>Gets the foreground text color.</summary>
	public static ImColor Foreground => Color.FromHex("#abb2bf");
	/// <summary>Gets the comment color.</summary>
	public static ImColor Comment => Color.FromHex("#5c6370");
	/// <summary>Gets the red color.</summary>
	public static ImColor Red => Color.FromHex("#e06c75");
	/// <summary>Gets the orange color.</summary>
	public static ImColor Orange => Color.FromHex("#d19a66");
	/// <summary>Gets the yellow color.</summary>
	public static ImColor Yellow => Color.FromHex("#e5c07b");
	/// <summary>Gets the green color.</summary>
	public static ImColor Green => Color.FromHex("#98c379");
	/// <summary>Gets the cyan color.</summary>
	public static ImColor Cyan => Color.FromHex("#56b6c2");
	/// <summary>Gets the blue color.</summary>
	public static ImColor Blue => Color.FromHex("#61afef");
	/// <summary>Gets the purple/magenta color.</summary>
	public static ImColor Purple => Color.FromHex("#c678dd");
	/// <summary>Gets the mono1 color (lighter text).</summary>
	public static ImColor Mono1 => Color.FromHex("#abb2bf");
	/// <summary>Gets the mono2 color (medium text).</summary>
	public static ImColor Mono2 => Color.FromHex("#828997");
	/// <summary>Gets the mono3 color (darker text).</summary>
	public static ImColor Mono3 => Color.FromHex("#5c6370");
}
