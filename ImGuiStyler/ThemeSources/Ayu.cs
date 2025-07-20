// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// Ayu theme colors with authentic palette names.
/// Modern theme inspired by Rust with Dark, Light, and Mirage variants.
/// </summary>
public static class Ayu
{
	/// <summary>
	/// Ayu Dark variant colors.
	/// </summary>
	public static class Dark
	{
		/// <summary>Gets the background color.</summary>
		public static ImColor Background => Color.FromHex("#0d1117");
		/// <summary>Gets the panel background color.</summary>
		public static ImColor Panel => Color.FromHex("#21262d");
		/// <summary>Gets the selection color.</summary>
		public static ImColor Selection => Color.FromHex("#30363d");
		/// <summary>Gets the foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#c9d1d9");
		/// <summary>Gets the comment color.</summary>
		public static ImColor Comment => Color.FromHex("#8b949e");
		/// <summary>Gets the orange accent color.</summary>
		public static ImColor Orange => Color.FromHex("#ffb454");
		/// <summary>Gets the yellow color.</summary>
		public static ImColor Yellow => Color.FromHex("#f29718");
		/// <summary>Gets the green color.</summary>
		public static ImColor Green => Color.FromHex("#7fd962");
		/// <summary>Gets the cyan color.</summary>
		public static ImColor Cyan => Color.FromHex("#39bae6");
		/// <summary>Gets the blue color.</summary>
		public static ImColor Blue => Color.FromHex("#59c2ff");
		/// <summary>Gets the purple color.</summary>
		public static ImColor Purple => Color.FromHex("#d2a6ff");
		/// <summary>Gets the red color.</summary>
		public static ImColor Red => Color.FromHex("#f07178");
	}

	/// <summary>
	/// Ayu Light variant colors.
	/// </summary>
	public static class Light
	{
		/// <summary>Gets the background color.</summary>
		public static ImColor Background => Color.FromHex("#fafafa");
		/// <summary>Gets the panel background color.</summary>
		public static ImColor Panel => Color.FromHex("#f0f0f0");
		/// <summary>Gets the selection color.</summary>
		public static ImColor Selection => Color.FromHex("#e6e6e6");
		/// <summary>Gets the foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#5c6166");
		/// <summary>Gets the comment color.</summary>
		public static ImColor Comment => Color.FromHex("#abb0b6");
		/// <summary>Gets the orange accent color.</summary>
		public static ImColor Orange => Color.FromHex("#ff8f40");
		/// <summary>Gets the yellow color.</summary>
		public static ImColor Yellow => Color.FromHex("#f29718");
		/// <summary>Gets the green color.</summary>
		public static ImColor Green => Color.FromHex("#86b300");
		/// <summary>Gets the cyan color.</summary>
		public static ImColor Cyan => Color.FromHex("#41a6d9");
		/// <summary>Gets the blue color.</summary>
		public static ImColor Blue => Color.FromHex("#3d91b5");
		/// <summary>Gets the purple color.</summary>
		public static ImColor Purple => Color.FromHex("#a37acc");
		/// <summary>Gets the red color.</summary>
		public static ImColor Red => Color.FromHex("#f51818");
	}

	/// <summary>
	/// Ayu Mirage variant colors.
	/// </summary>
	public static class Mirage
	{
		/// <summary>Gets the background color.</summary>
		public static ImColor Background => Color.FromHex("#1f2430");
		/// <summary>Gets the panel background color.</summary>
		public static ImColor Panel => Color.FromHex("#242936");
		/// <summary>Gets the selection color.</summary>
		public static ImColor Selection => Color.FromHex("#2d3142");
		/// <summary>Gets the foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#cbccc6");
		/// <summary>Gets the comment color.</summary>
		public static ImColor Comment => Color.FromHex("#707a8c");
		/// <summary>Gets the orange accent color.</summary>
		public static ImColor Orange => Color.FromHex("#ffcc66");
		/// <summary>Gets the yellow color.</summary>
		public static ImColor Yellow => Color.FromHex("#ffd580");
		/// <summary>Gets the green color.</summary>
		public static ImColor Green => Color.FromHex("#bae67e");
		/// <summary>Gets the cyan color.</summary>
		public static ImColor Cyan => Color.FromHex("#73d0ff");
		/// <summary>Gets the blue color.</summary>
		public static ImColor Blue => Color.FromHex("#5ccfe6");
		/// <summary>Gets the purple color.</summary>
		public static ImColor Purple => Color.FromHex("#d4bfff");
		/// <summary>Gets the red color.</summary>
		public static ImColor Red => Color.FromHex("#ff8a65");
	}
}
