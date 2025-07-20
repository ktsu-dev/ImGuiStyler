// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

/// <summary>
/// Provides organized color families (swatches) for each theme, enabling intelligent color selection
/// based on contrast requirements and color relationships.
/// </summary>
public static class ThemeSwatches
{
	/// <summary>
	/// Dracula theme color families organized by function and luminance.
	/// </summary>
	public static class Dracula
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Dracula Backgrounds",
			ThemeSources.Dracula.Background, ThemeSources.Dracula.CurrentLine, ThemeSources.Dracula.Selection);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Dracula Neutrals",
			ThemeSources.Dracula.Background, ThemeSources.Dracula.CurrentLine, ThemeSources.Dracula.Selection, ThemeSources.Dracula.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Dracula Accents",
			ThemeSources.Dracula.Purple, ThemeSources.Dracula.Pink, ThemeSources.Dracula.Cyan, ThemeSources.Dracula.Green, ThemeSources.Dracula.Yellow);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Dracula Text",
			ThemeSources.Dracula.Comment, ThemeSources.Dracula.Foreground);
	}

	/// <summary>
	/// Nord theme color families organized by function and luminance.
	/// </summary>
	public static class Nord
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Nord Backgrounds",
			ThemeSources.Nord.Nord0, ThemeSources.Nord.Nord1, ThemeSources.Nord.Nord2, ThemeSources.Nord.Nord3);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Nord Neutrals",
			ThemeSources.Nord.Nord0, ThemeSources.Nord.Nord1, ThemeSources.Nord.Nord2, ThemeSources.Nord.Nord3, ThemeSources.Nord.Nord4, ThemeSources.Nord.Nord5, ThemeSources.Nord.Nord6);

		/// <summary>Gets frost accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Nord Accents",
			ThemeSources.Nord.Nord7, ThemeSources.Nord.Nord8, ThemeSources.Nord.Nord9, ThemeSources.Nord.Nord10);

		/// <summary>Gets aurora accent colors from darkest to lightest.</summary>
		public static ColorFamily Aurora { get; } = new("Nord Aurora",
			ThemeSources.Nord.Nord11, ThemeSources.Nord.Nord12, ThemeSources.Nord.Nord13, ThemeSources.Nord.Nord14, ThemeSources.Nord.Nord15);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Nord Text",
			ThemeSources.Nord.Nord3, ThemeSources.Nord.Nord4, ThemeSources.Nord.Nord5, ThemeSources.Nord.Nord6);
	}

	/// <summary>
	/// VSCode theme color families organized by function and luminance.
	/// </summary>
	public static class VSCode
	{
		/// <summary>
		/// VSCode Dark theme color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("VSCode Dark Backgrounds",
				ThemeSources.VSCode.Dark.Background, ThemeSources.VSCode.Dark.InputBackground, ThemeSources.VSCode.Dark.Button);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("VSCode Dark Neutrals",
				ThemeSources.VSCode.Dark.Background, ThemeSources.VSCode.Dark.InputBackground, ThemeSources.VSCode.Dark.Button, ThemeSources.VSCode.Dark.ButtonHover);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("VSCode Dark Accents",
				ThemeSources.VSCode.Dark.AccentBlue, ThemeSources.VSCode.Dark.AccentGreen);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("VSCode Dark Text",
				ThemeSources.VSCode.Dark.Foreground);
		}

		/// <summary>
		/// VSCode Light theme color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("VSCode Light Backgrounds",
				ThemeSources.VSCode.Light.Button, ThemeSources.VSCode.Light.ButtonHover, ThemeSources.VSCode.Light.InputBackground, ThemeSources.VSCode.Light.Background);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("VSCode Light Neutrals",
				ThemeSources.VSCode.Light.Button, ThemeSources.VSCode.Light.ButtonHover, ThemeSources.VSCode.Light.InputBackground, ThemeSources.VSCode.Light.Background);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("VSCode Light Accents",
				ThemeSources.VSCode.Light.AccentBlue, ThemeSources.VSCode.Light.AccentGreen);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("VSCode Light Text",
				ThemeSources.VSCode.Light.Foreground);
		}
	}

	/// <summary>
	/// Gruvbox theme color families organized by function and luminance.
	/// </summary>
	public static class Gruvbox
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Gruvbox Backgrounds",
			ThemeSources.Gruvbox.Dark0, ThemeSources.Gruvbox.Dark1, ThemeSources.Gruvbox.Dark2, ThemeSources.Gruvbox.Dark3, ThemeSources.Gruvbox.Dark4);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Gruvbox Neutrals",
			ThemeSources.Gruvbox.Dark0, ThemeSources.Gruvbox.Dark1, ThemeSources.Gruvbox.Dark2, ThemeSources.Gruvbox.Dark3, ThemeSources.Gruvbox.Dark4,
			ThemeSources.Gruvbox.Gray, ThemeSources.Gruvbox.Light4, ThemeSources.Gruvbox.Light3, ThemeSources.Gruvbox.Light2, ThemeSources.Gruvbox.Light1, ThemeSources.Gruvbox.Light0);

		/// <summary>Gets bright accent colors from darkest to lightest.</summary>
		public static ColorFamily BrightAccents { get; } = new("Gruvbox Bright Accents",
			ThemeSources.Gruvbox.BrightRed, ThemeSources.Gruvbox.BrightGreen, ThemeSources.Gruvbox.BrightYellow,
			ThemeSources.Gruvbox.BrightBlue, ThemeSources.Gruvbox.BrightPurple, ThemeSources.Gruvbox.BrightAqua, ThemeSources.Gruvbox.BrightOrange);

		/// <summary>Gets neutral accent colors from darkest to lightest.</summary>
		public static ColorFamily NeutralAccents { get; } = new("Gruvbox Neutral Accents",
			ThemeSources.Gruvbox.NeutralRed, ThemeSources.Gruvbox.NeutralGreen, ThemeSources.Gruvbox.NeutralYellow,
			ThemeSources.Gruvbox.NeutralBlue, ThemeSources.Gruvbox.NeutralPurple, ThemeSources.Gruvbox.NeutralAqua, ThemeSources.Gruvbox.NeutralOrange);

		/// <summary>Gets faded accent colors from darkest to lightest.</summary>
		public static ColorFamily FadedAccents { get; } = new("Gruvbox Faded Accents",
			ThemeSources.Gruvbox.FadedRed, ThemeSources.Gruvbox.FadedGreen, ThemeSources.Gruvbox.FadedYellow,
			ThemeSources.Gruvbox.FadedBlue, ThemeSources.Gruvbox.FadedPurple, ThemeSources.Gruvbox.FadedAqua, ThemeSources.Gruvbox.FadedOrange);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Gruvbox Text",
			ThemeSources.Gruvbox.Dark4, ThemeSources.Gruvbox.Gray, ThemeSources.Gruvbox.Light4, ThemeSources.Gruvbox.Light3,
			ThemeSources.Gruvbox.Light2, ThemeSources.Gruvbox.Light1, ThemeSources.Gruvbox.Light0);
	}

	/// <summary>
	/// Gets a theme swatch by name for dynamic theme generation.
	/// </summary>
	/// <param name="themeName">The name of the theme.</param>
	/// <returns>A dictionary of color families for the theme, or null if not found.</returns>
	public static Dictionary<string, ColorFamily>? GetThemeSwatches(string themeName)
	{
		if (string.IsNullOrEmpty(themeName))
		{
			return null;
		}

		return themeName.ToLowerInvariant() switch
		{
			"dracula" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Dracula.Backgrounds,
				["Neutrals"] = Dracula.Neutrals,
				["Accents"] = Dracula.Accents,
				["Text"] = Dracula.Text
			},
			"nord" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Nord.Backgrounds,
				["Neutrals"] = Nord.Neutrals,
				["Accents"] = Nord.Accents,
				["Aurora"] = Nord.Aurora,
				["Text"] = Nord.Text
			},
			"gruvbox" or "gruvboxdark" or "gruvboxlight" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Gruvbox.Backgrounds,
				["Neutrals"] = Gruvbox.Neutrals,
				["BrightAccents"] = Gruvbox.BrightAccents,
				["NeutralAccents"] = Gruvbox.NeutralAccents,
				["FadedAccents"] = Gruvbox.FadedAccents,
				["Text"] = Gruvbox.Text
			},
			_ => null
		};
	}
}
