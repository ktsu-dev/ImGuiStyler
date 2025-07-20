// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler.ThemeSources;

using Hexa.NET.ImGui;

/// <summary>
/// VS Code theme colors with authentic palette names.
/// Official color tokens from Visual Studio Code.
/// </summary>
public static class VSCode
{
	/// <summary>
	/// Dark theme colors.
	/// </summary>
	public static class Dark
	{
		/// <summary>Gets the main background color.</summary>
		public static ImColor Background => Color.FromHex("#1e1e1e");
		/// <summary>Gets the main foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#cccccc");
		/// <summary>Gets the secondary foreground text color.</summary>
		public static ImColor ForegroundSecondary => Color.FromHex("#c0c0c0");
		/// <summary>Gets the button background color.</summary>
		public static ImColor Button => Color.FromHex("#2d2d30");
		/// <summary>Gets the button hover background color.</summary>
		public static ImColor ButtonHover => Color.FromHex("#3e3e42");
		/// <summary>Gets the button foreground text color.</summary>
		public static ImColor ButtonForeground => Color.FromHex("#ffffff");
		/// <summary>Gets the input background color.</summary>
		public static ImColor InputBackground => Color.FromHex("#2d2d30");
		/// <summary>Gets the input border color.</summary>
		public static ImColor InputBorder => Color.FromHex("#3e3e42");
		/// <summary>Gets the input foreground text color.</summary>
		public static ImColor InputForeground => Color.FromHex("#cccccc");
		/// <summary>Gets the blue accent color.</summary>
		public static ImColor AccentBlue => Color.FromHex("#0078d4");
		/// <summary>Gets the bright blue accent color.</summary>
		public static ImColor AccentBlueBright => Color.FromHex("#1f9cf0");
		/// <summary>Gets the green accent color.</summary>
		public static ImColor AccentGreen => Color.FromHex("#14ce14");
		/// <summary>Gets the border color.</summary>
		public static ImColor Border => Color.FromHex("#3e3e42");
	}

	/// <summary>
	/// Light theme colors.
	/// </summary>
	public static class Light
	{
		/// <summary>Gets the main background color.</summary>
		public static ImColor Background => Color.FromHex("#ffffff");
		/// <summary>Gets the main foreground text color.</summary>
		public static ImColor Foreground => Color.FromHex("#000000");
		/// <summary>Gets the secondary foreground text color.</summary>
		public static ImColor ForegroundSecondary => Color.FromHex("#323130");
		/// <summary>Gets the button background color.</summary>
		public static ImColor Button => Color.FromHex("#f3f2f1");
		/// <summary>Gets the button hover background color.</summary>
		public static ImColor ButtonHover => Color.FromHex("#e1dfdd");
		/// <summary>Gets the button foreground text color.</summary>
		public static ImColor ButtonForeground => Color.FromHex("#323130");
		/// <summary>Gets the input background color.</summary>
		public static ImColor InputBackground => Color.FromHex("#f3f2f1");
		/// <summary>Gets the input border color.</summary>
		public static ImColor InputBorder => Color.FromHex("#c8c6c4");
		/// <summary>Gets the input foreground text color.</summary>
		public static ImColor InputForeground => Color.FromHex("#323130");
		/// <summary>Gets the blue accent color.</summary>
		public static ImColor AccentBlue => Color.FromHex("#0078d4");
		/// <summary>Gets the bright blue accent color.</summary>
		public static ImColor AccentBlueBright => Color.FromHex("#106ebe");
		/// <summary>Gets the green accent color.</summary>
		public static ImColor AccentGreen => Color.FromHex("#107c10");
		/// <summary>Gets the purple accent color.</summary>
		public static ImColor AccentPurple => Color.FromHex("#881280");
		/// <summary>Gets the teal accent color.</summary>
		public static ImColor AccentTeal => Color.FromHex("#098658");
		/// <summary>Gets the border color.</summary>
		public static ImColor Border => Color.FromHex("#c8c6c4");
	}
}
