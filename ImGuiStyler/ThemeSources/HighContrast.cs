// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// High Contrast theme colors with authentic palette names.
/// Accessibility-focused themes with maximum contrast ratios.
/// </summary>
public static class HighContrast
{
	/// <summary>
	/// High Contrast Dark variant colors.
	/// </summary>
	public static class Dark
	{
		/// <summary>Gets the pure black background color.</summary>
		public static ImColor Background => Color.FromHex("#000000");
		/// <summary>Gets the dark surface color.</summary>
		public static ImColor Surface => Color.FromHex("#1a1a1a");
		/// <summary>Gets the selection background color.</summary>
		public static ImColor Selection => Color.FromHex("#333333");
		/// <summary>Gets the pure white text color.</summary>
		public static ImColor Text => Color.FromHex("#ffffff");
		/// <summary>Gets the pure white border color.</summary>
		public static ImColor Border => Color.FromHex("#ffffff");
		/// <summary>Gets the bright cyan accent color.</summary>
		public static ImColor AccentCyan => Color.FromHex("#00ffff");
		/// <summary>Gets the bright green success color.</summary>
		public static ImColor Green => Color.FromHex("#00ff00");
		/// <summary>Gets the bright yellow warning color.</summary>
		public static ImColor Yellow => Color.FromHex("#ffff00");
		/// <summary>Gets the bright red error color.</summary>
		public static ImColor Red => Color.FromHex("#ff0000");
		/// <summary>Gets the bright magenta accent color.</summary>
		public static ImColor Magenta => Color.FromHex("#ff00ff");
		/// <summary>Gets the bright blue info color.</summary>
		public static ImColor Blue => Color.FromHex("#0000ff");
	}

	/// <summary>
	/// High Contrast Light variant colors.
	/// </summary>
	public static class Light
	{
		/// <summary>Gets the pure white background color.</summary>
		public static ImColor Background => Color.FromHex("#ffffff");
		/// <summary>Gets the light surface color.</summary>
		public static ImColor Surface => Color.FromHex("#e6e6e6");
		/// <summary>Gets the selection background color.</summary>
		public static ImColor Selection => Color.FromHex("#cccccc");
		/// <summary>Gets the pure black text color.</summary>
		public static ImColor Text => Color.FromHex("#000000");
		/// <summary>Gets the pure black border color.</summary>
		public static ImColor Border => Color.FromHex("#000000");
		/// <summary>Gets the dark blue accent color.</summary>
		public static ImColor AccentBlue => Color.FromHex("#0000ff");
		/// <summary>Gets the dark green success color.</summary>
		public static ImColor Green => Color.FromHex("#008000");
		/// <summary>Gets the dark purple accent color.</summary>
		public static ImColor Purple => Color.FromHex("#8000ff");
		/// <summary>Gets the dark red error color.</summary>
		public static ImColor Red => Color.FromHex("#ff0000");
		/// <summary>Gets the dark magenta accent color.</summary>
		public static ImColor Magenta => Color.FromHex("#800080");
		/// <summary>Gets the dark teal accent color.</summary>
		public static ImColor Teal => Color.FromHex("#008080");
	}
}
