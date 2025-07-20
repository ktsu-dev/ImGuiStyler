// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Dracula theme colors with authentic palette names.
/// Official Dracula color specification with vampire-inspired naming.
/// </summary>
public static class Dracula
{
	/// <summary>Gets the main background color.</summary>
	public static ImColor Background => Color.FromHex("#282a36");
	/// <summary>Gets the current line highlight color.</summary>
	public static ImColor CurrentLine => Color.FromHex("#44475a");
	/// <summary>Gets the selection highlight color.</summary>
	public static ImColor Selection => Color.FromHex("#44475a");
	/// <summary>Gets the main foreground/text color.</summary>
	public static ImColor Foreground => Color.FromHex("#f8f8f2");
	/// <summary>Gets the comment text color.</summary>
	public static ImColor Comment => Color.FromHex("#6272a4");
	/// <summary>Gets the cyan accent color.</summary>
	public static ImColor Cyan => Color.FromHex("#8be9fd");
	/// <summary>Gets the green accent color.</summary>
	public static ImColor Green => Color.FromHex("#50fa7b");
	/// <summary>Gets the orange accent color.</summary>
	public static ImColor Orange => Color.FromHex("#ffb86c");
	/// <summary>Gets the pink accent color.</summary>
	public static ImColor Pink => Color.FromHex("#ff79c6");
	/// <summary>Gets the purple accent color.</summary>
	public static ImColor Purple => Color.FromHex("#bd93f9");
	/// <summary>Gets the red accent color.</summary>
	public static ImColor Red => Color.FromHex("#ff5555");
	/// <summary>Gets the yellow accent color.</summary>
	public static ImColor Yellow => Color.FromHex("#f1fa8c");
}
