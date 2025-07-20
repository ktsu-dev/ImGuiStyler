// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// PaperColor theme colors with authentic palette names.
/// Clean paper-inspired theme with dark and light variants.
/// </summary>
public static class PaperColor
{
	/// <summary>
	/// PaperColor Dark variant colors.
	/// </summary>
	public static class Dark
	{
		/// <summary>Gets the main background color.</summary>
		public static ImColor Background => Color.FromHex("#1c1c1c");
		/// <summary>Gets the surface background color.</summary>
		public static ImColor Surface => Color.FromHex("#262626");
		/// <summary>Gets the elevated surface color.</summary>
		public static ImColor SurfaceElevated => Color.FromHex("#3a3a3a");
		/// <summary>Gets the selection background color.</summary>
		public static ImColor Selection => Color.FromHex("#4e4e4e");
		/// <summary>Gets the main foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#d0d0d0");
		/// <summary>Gets the secondary text color.</summary>
		public static ImColor ForegroundDim => Color.FromHex("#808080");
		/// <summary>Gets the comment color.</summary>
		public static ImColor Comment => Color.FromHex("#5f5f5f");
		/// <summary>Gets the border color.</summary>
		public static ImColor Border => Color.FromHex("#4e4e4e");
		/// <summary>Gets the red color.</summary>
		public static ImColor Red => Color.FromHex("#af5f5f");
		/// <summary>Gets the green color.</summary>
		public static ImColor Green => Color.FromHex("#5faf5f");
		/// <summary>Gets the yellow color.</summary>
		public static ImColor Yellow => Color.FromHex("#dfaf5f");
		/// <summary>Gets the blue color.</summary>
		public static ImColor Blue => Color.FromHex("#5f87af");
		/// <summary>Gets the cyan color.</summary>
		public static ImColor Cyan => Color.FromHex("#8fbcbb");
		/// <summary>Gets the magenta/purple color.</summary>
		public static ImColor Magenta => Color.FromHex("#af87af");
		/// <summary>Gets the orange color.</summary>
		public static ImColor Orange => Color.FromHex("#ffaf87");
	}

	/// <summary>
	/// PaperColor Light variant colors.
	/// </summary>
	public static class Light
	{
		/// <summary>Gets the main background color.</summary>
		public static ImColor Background => Color.FromHex("#eeeeee");
		/// <summary>Gets the surface background color.</summary>
		public static ImColor Surface => Color.FromHex("#e4e4e4");
		/// <summary>Gets the elevated surface color.</summary>
		public static ImColor SurfaceElevated => Color.FromHex("#d0d0d0");
		/// <summary>Gets the selection background color.</summary>
		public static ImColor Selection => Color.FromHex("#bcbcbc");
		/// <summary>Gets the main foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#444444");
		/// <summary>Gets the secondary text color.</summary>
		public static ImColor ForegroundDim => Color.FromHex("#8a8a8a");
		/// <summary>Gets the comment color.</summary>
		public static ImColor Comment => Color.FromHex("#bcbcbc");
		/// <summary>Gets the border color.</summary>
		public static ImColor Border => Color.FromHex("#bcbcbc");
		/// <summary>Gets the red color.</summary>
		public static ImColor Red => Color.FromHex("#d70000");
		/// <summary>Gets the green color.</summary>
		public static ImColor Green => Color.FromHex("#008700");
		/// <summary>Gets the yellow color.</summary>
		public static ImColor Yellow => Color.FromHex("#af8700");
		/// <summary>Gets the blue color.</summary>
		public static ImColor Blue => Color.FromHex("#005f87");
		/// <summary>Gets the cyan color.</summary>
		public static ImColor Cyan => Color.FromHex("#0087af");
		/// <summary>Gets the magenta/purple color.</summary>
		public static ImColor Magenta => Color.FromHex("#8700af");
		/// <summary>Gets the orange color.</summary>
		public static ImColor Orange => Color.FromHex("#d75f00");
	}
}
