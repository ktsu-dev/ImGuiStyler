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
		/// VSCode Dark variant color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("VSCode Dark Backgrounds",
				ThemeSources.VSCode.Dark.Background, ThemeSources.VSCode.Dark.InputBackground);

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
		/// VSCode Light variant color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("VSCode Light Backgrounds",
				ThemeSources.VSCode.Light.InputBackground, ThemeSources.VSCode.Light.Background);

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
	/// Catppuccin theme color families organized by function and luminance.
	/// </summary>
	public static class Catppuccin
	{
		/// <summary>
		/// Catppuccin Latte (Light) variant color families.
		/// </summary>
		public static class Latte
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Catppuccin Latte Backgrounds",
				ThemeSources.CatppuccinLatte.Mantle, ThemeSources.CatppuccinLatte.Base);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Catppuccin Latte Neutrals",
				ThemeSources.CatppuccinLatte.Surface0, ThemeSources.CatppuccinLatte.Surface1, ThemeSources.CatppuccinLatte.Surface2, ThemeSources.CatppuccinLatte.Overlay0, ThemeSources.CatppuccinLatte.Overlay1, ThemeSources.CatppuccinLatte.Overlay2);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Catppuccin Latte Accents",
				ThemeSources.CatppuccinLatte.Red, ThemeSources.CatppuccinLatte.Peach, ThemeSources.CatppuccinLatte.Yellow, ThemeSources.CatppuccinLatte.Green, ThemeSources.CatppuccinLatte.Teal, ThemeSources.CatppuccinLatte.Blue, ThemeSources.CatppuccinLatte.Mauve);

			/// <summary>Gets pastel accent colors from darkest to lightest.</summary>
			public static ColorFamily Pastels { get; } = new("Catppuccin Latte Pastels",
				ThemeSources.CatppuccinLatte.Rosewater, ThemeSources.CatppuccinLatte.Flamingo, ThemeSources.CatppuccinLatte.Pink, ThemeSources.CatppuccinLatte.Lavender);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Catppuccin Latte Text",
				ThemeSources.CatppuccinLatte.Subtext0, ThemeSources.CatppuccinLatte.Subtext1, ThemeSources.CatppuccinLatte.Text);
		}

		/// <summary>
		/// Catppuccin Frappe (Dark) variant color families.
		/// </summary>
		public static class Frappe
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Catppuccin Frappe Backgrounds",
				ThemeSources.CatppuccinFrappe.Base, ThemeSources.CatppuccinFrappe.Mantle);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Catppuccin Frappe Neutrals",
				ThemeSources.CatppuccinFrappe.Base, ThemeSources.CatppuccinFrappe.Surface0, ThemeSources.CatppuccinFrappe.Surface1, ThemeSources.CatppuccinFrappe.Surface2, ThemeSources.CatppuccinFrappe.Overlay0, ThemeSources.CatppuccinFrappe.Overlay1);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Catppuccin Frappe Accents",
				ThemeSources.CatppuccinFrappe.Red, ThemeSources.CatppuccinFrappe.Peach, ThemeSources.CatppuccinFrappe.Yellow, ThemeSources.CatppuccinFrappe.Green, ThemeSources.CatppuccinFrappe.Teal, ThemeSources.CatppuccinFrappe.Blue, ThemeSources.CatppuccinFrappe.Mauve);

			/// <summary>Gets pastel accent colors from darkest to lightest.</summary>
			public static ColorFamily Pastels { get; } = new("Catppuccin Frappe Pastels",
				ThemeSources.CatppuccinFrappe.Rosewater, ThemeSources.CatppuccinFrappe.Flamingo, ThemeSources.CatppuccinFrappe.Pink, ThemeSources.CatppuccinFrappe.Lavender);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Catppuccin Frappe Text",
				ThemeSources.CatppuccinFrappe.Subtext0, ThemeSources.CatppuccinFrappe.Subtext1, ThemeSources.CatppuccinFrappe.Text);
		}

		/// <summary>
		/// Catppuccin Macchiato (Dark) variant color families.
		/// </summary>
		public static class Macchiato
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Catppuccin Macchiato Backgrounds",
				ThemeSources.CatppuccinMacchiato.Base, ThemeSources.CatppuccinMacchiato.Mantle);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Catppuccin Macchiato Neutrals",
				ThemeSources.CatppuccinMacchiato.Base, ThemeSources.CatppuccinMacchiato.Surface0, ThemeSources.CatppuccinMacchiato.Surface1, ThemeSources.CatppuccinMacchiato.Surface2, ThemeSources.CatppuccinMacchiato.Overlay0, ThemeSources.CatppuccinMacchiato.Overlay1);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Catppuccin Macchiato Accents",
				ThemeSources.CatppuccinMacchiato.Red, ThemeSources.CatppuccinMacchiato.Peach, ThemeSources.CatppuccinMacchiato.Yellow, ThemeSources.CatppuccinMacchiato.Green, ThemeSources.CatppuccinMacchiato.Teal, ThemeSources.CatppuccinMacchiato.Blue, ThemeSources.CatppuccinMacchiato.Mauve);

			/// <summary>Gets pastel accent colors from darkest to lightest.</summary>
			public static ColorFamily Pastels { get; } = new("Catppuccin Macchiato Pastels",
				ThemeSources.CatppuccinMacchiato.Rosewater, ThemeSources.CatppuccinMacchiato.Flamingo, ThemeSources.CatppuccinMacchiato.Pink, ThemeSources.CatppuccinMacchiato.Lavender);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Catppuccin Macchiato Text",
				ThemeSources.CatppuccinMacchiato.Subtext0, ThemeSources.CatppuccinMacchiato.Subtext1, ThemeSources.CatppuccinMacchiato.Text);
		}

		/// <summary>
		/// Catppuccin Mocha (Darkest) variant color families.
		/// </summary>
		public static class Mocha
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Catppuccin Mocha Backgrounds",
				ThemeSources.CatppuccinMocha.Base, ThemeSources.CatppuccinMocha.Mantle);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Catppuccin Mocha Neutrals",
				ThemeSources.CatppuccinMocha.Base, ThemeSources.CatppuccinMocha.Surface0, ThemeSources.CatppuccinMocha.Surface1, ThemeSources.CatppuccinMocha.Surface2, ThemeSources.CatppuccinMocha.Overlay0, ThemeSources.CatppuccinMocha.Overlay1);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Catppuccin Mocha Accents",
				ThemeSources.CatppuccinMocha.Red, ThemeSources.CatppuccinMocha.Peach, ThemeSources.CatppuccinMocha.Yellow, ThemeSources.CatppuccinMocha.Green, ThemeSources.CatppuccinMocha.Teal, ThemeSources.CatppuccinMocha.Blue, ThemeSources.CatppuccinMocha.Mauve);

			/// <summary>Gets pastel accent colors from darkest to lightest.</summary>
			public static ColorFamily Pastels { get; } = new("Catppuccin Mocha Pastels",
				ThemeSources.CatppuccinMocha.Rosewater, ThemeSources.CatppuccinMocha.Flamingo, ThemeSources.CatppuccinMocha.Pink, ThemeSources.CatppuccinMocha.Lavender);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Catppuccin Mocha Text",
				ThemeSources.CatppuccinMocha.Subtext0, ThemeSources.CatppuccinMocha.Subtext1, ThemeSources.CatppuccinMocha.Text);
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
	/// OneDark theme color families organized by function and luminance.
	/// </summary>
	public static class OneDark
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("OneDark Backgrounds",
			ThemeSources.OneDark.Background, ThemeSources.OneDark.Selection, ThemeSources.OneDark.BackgroundLight);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("OneDark Neutrals",
			ThemeSources.OneDark.Background, ThemeSources.OneDark.Selection, ThemeSources.OneDark.BackgroundLight, ThemeSources.OneDark.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("OneDark Accents",
			ThemeSources.OneDark.Purple, ThemeSources.OneDark.Blue, ThemeSources.OneDark.Cyan, ThemeSources.OneDark.Green, ThemeSources.OneDark.Yellow, ThemeSources.OneDark.Red);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("OneDark Text",
			ThemeSources.OneDark.Comment, ThemeSources.OneDark.Foreground);
	}

	/// <summary>
	/// Material theme color families organized by function and luminance.
	/// </summary>
	public static class Material
	{
		/// <summary>
		/// Material Darker variant color families.
		/// </summary>
		public static class Darker
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Material Darker Backgrounds",
				ThemeSources.Material.Darker.Background, ThemeSources.Material.Darker.Surface, ThemeSources.Material.Darker.Card);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Material Darker Neutrals",
				ThemeSources.Material.Darker.Background, ThemeSources.Material.Darker.Surface, ThemeSources.Material.Darker.Card);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Material Darker Accents",
				ThemeSources.Material.Darker.Primary, ThemeSources.Material.Darker.Secondary, ThemeSources.Material.Darker.Accent, ThemeSources.Material.Darker.Info, ThemeSources.Material.Darker.Success, ThemeSources.Material.Darker.Warning, ThemeSources.Material.Darker.Error);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Material Darker Text",
				ThemeSources.Material.Darker.OnSurface, ThemeSources.Material.Darker.OnBackground);
		}

		/// <summary>
		/// Material Ocean variant color families.
		/// </summary>
		public static class Ocean
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Material Ocean Backgrounds",
				ThemeSources.Material.Ocean.Background, ThemeSources.Material.Ocean.Surface, ThemeSources.Material.Ocean.Card);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Material Ocean Neutrals",
				ThemeSources.Material.Ocean.Background, ThemeSources.Material.Ocean.Surface, ThemeSources.Material.Ocean.Card);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Material Ocean Accents",
				ThemeSources.Material.Ocean.Primary, ThemeSources.Material.Ocean.Secondary, ThemeSources.Material.Ocean.Accent, ThemeSources.Material.Ocean.Info, ThemeSources.Material.Ocean.Success, ThemeSources.Material.Ocean.Warning, ThemeSources.Material.Ocean.Error);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Material Ocean Text",
				ThemeSources.Material.Ocean.OnSurface, ThemeSources.Material.Ocean.OnBackground);
		}

		/// <summary>
		/// Material Palenight variant color families.
		/// </summary>
		public static class Palenight
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Material Palenight Backgrounds",
				ThemeSources.Material.Palenight.Background, ThemeSources.Material.Palenight.Surface, ThemeSources.Material.Palenight.Card);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Material Palenight Neutrals",
				ThemeSources.Material.Palenight.Background, ThemeSources.Material.Palenight.Surface, ThemeSources.Material.Palenight.Card);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Material Palenight Accents",
				ThemeSources.Material.Palenight.Primary, ThemeSources.Material.Palenight.Secondary, ThemeSources.Material.Palenight.Accent, ThemeSources.Material.Palenight.Info, ThemeSources.Material.Palenight.Success, ThemeSources.Material.Palenight.Warning, ThemeSources.Material.Palenight.Error);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Material Palenight Text",
				ThemeSources.Material.Palenight.OnSurface, ThemeSources.Material.Palenight.OnBackground);
		}
	}

	/// <summary>
	/// Tokyo Night theme color families organized by function and luminance.
	/// </summary>
	public static class TokyoNight
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Tokyo Night Backgrounds",
			ThemeSources.TokyoNight.Bg, ThemeSources.TokyoNight.BgHighlight, ThemeSources.TokyoNight.Dark3);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Tokyo Night Neutrals",
			ThemeSources.TokyoNight.Bg, ThemeSources.TokyoNight.BgHighlight, ThemeSources.TokyoNight.Dark3, ThemeSources.TokyoNight.Dark5, ThemeSources.TokyoNight.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Tokyo Night Accents",
			ThemeSources.TokyoNight.Purple, ThemeSources.TokyoNight.Blue, ThemeSources.TokyoNight.Cyan, ThemeSources.TokyoNight.Green, ThemeSources.TokyoNight.Yellow, ThemeSources.TokyoNight.Orange, ThemeSources.TokyoNight.Red);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Tokyo Night Text",
			ThemeSources.TokyoNight.Comment, ThemeSources.TokyoNight.Fg);
	}

	/// <summary>
	/// Solarized theme color families organized by function and luminance.
	/// </summary>
	public static class Solarized
	{
		/// <summary>Gets background colors from darkest to lightest for both variants.</summary>
		public static ColorFamily Backgrounds { get; } = new("Solarized Backgrounds",
			ThemeSources.Solarized.Base03, ThemeSources.Solarized.Base02, ThemeSources.Solarized.Base2, ThemeSources.Solarized.Base3);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Solarized Neutrals",
			ThemeSources.Solarized.Base03, ThemeSources.Solarized.Base02, ThemeSources.Solarized.Base01, ThemeSources.Solarized.Base00, ThemeSources.Solarized.Base0, ThemeSources.Solarized.Base1, ThemeSources.Solarized.Base2, ThemeSources.Solarized.Base3);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Solarized Accents",
			ThemeSources.Solarized.Yellow, ThemeSources.Solarized.Orange, ThemeSources.Solarized.Red, ThemeSources.Solarized.Magenta, ThemeSources.Solarized.Violet, ThemeSources.Solarized.Blue, ThemeSources.Solarized.Cyan, ThemeSources.Solarized.Green);

		/// <summary>Gets primary text colors for dark variant.</summary>
		public static ColorFamily TextDark { get; } = new("Solarized Text Dark",
			ThemeSources.Solarized.Base01, ThemeSources.Solarized.Base0, ThemeSources.Solarized.Base1);

		/// <summary>Gets primary text colors for light variant.</summary>
		public static ColorFamily TextLight { get; } = new("Solarized Text Light",
			ThemeSources.Solarized.Base1, ThemeSources.Solarized.Base00, ThemeSources.Solarized.Base01);
	}

	/// <summary>
	/// Monokai theme color families organized by function and luminance.
	/// </summary>
	public static class Monokai
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Monokai Backgrounds",
			ThemeSources.Monokai.Background, ThemeSources.Monokai.LineHighlight, ThemeSources.Monokai.Selection);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Monokai Neutrals",
			ThemeSources.Monokai.Background, ThemeSources.Monokai.LineHighlight, ThemeSources.Monokai.Selection, ThemeSources.Monokai.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Monokai Accents",
			ThemeSources.Monokai.Purple, ThemeSources.Monokai.Pink, ThemeSources.Monokai.Cyan, ThemeSources.Monokai.Green, ThemeSources.Monokai.Yellow, ThemeSources.Monokai.Orange);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Monokai Text",
			ThemeSources.Monokai.Comment, ThemeSources.Monokai.Foreground);
	}

	/// <summary>
	/// Ayu theme color families organized by function and luminance.
	/// </summary>
	public static class Ayu
	{
		/// <summary>
		/// Ayu Dark variant color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Ayu Dark Backgrounds",
				ThemeSources.Ayu.Dark.Background, ThemeSources.Ayu.Dark.Panel, ThemeSources.Ayu.Dark.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Ayu Dark Neutrals",
				ThemeSources.Ayu.Dark.Background, ThemeSources.Ayu.Dark.Panel, ThemeSources.Ayu.Dark.Selection);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Ayu Dark Accents",
				ThemeSources.Ayu.Dark.Purple, ThemeSources.Ayu.Dark.Blue, ThemeSources.Ayu.Dark.Cyan, ThemeSources.Ayu.Dark.Green, ThemeSources.Ayu.Dark.Yellow, ThemeSources.Ayu.Dark.Orange, ThemeSources.Ayu.Dark.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Ayu Dark Text",
				ThemeSources.Ayu.Dark.Comment, ThemeSources.Ayu.Dark.Foreground);
		}

		/// <summary>
		/// Ayu Light variant color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Ayu Light Backgrounds",
				ThemeSources.Ayu.Light.Panel, ThemeSources.Ayu.Light.Background, ThemeSources.Ayu.Light.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Ayu Light Neutrals",
				ThemeSources.Ayu.Light.Panel, ThemeSources.Ayu.Light.Background, ThemeSources.Ayu.Light.Selection);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Ayu Light Accents",
				ThemeSources.Ayu.Light.Purple, ThemeSources.Ayu.Light.Blue, ThemeSources.Ayu.Light.Cyan, ThemeSources.Ayu.Light.Green, ThemeSources.Ayu.Light.Yellow, ThemeSources.Ayu.Light.Orange, ThemeSources.Ayu.Light.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Ayu Light Text",
				ThemeSources.Ayu.Light.Comment, ThemeSources.Ayu.Light.Foreground);
		}

		/// <summary>
		/// Ayu Mirage variant color families.
		/// </summary>
		public static class Mirage
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Ayu Mirage Backgrounds",
				ThemeSources.Ayu.Mirage.Background, ThemeSources.Ayu.Mirage.Panel, ThemeSources.Ayu.Mirage.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Ayu Mirage Neutrals",
				ThemeSources.Ayu.Mirage.Background, ThemeSources.Ayu.Mirage.Panel, ThemeSources.Ayu.Mirage.Selection);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Ayu Mirage Accents",
				ThemeSources.Ayu.Mirage.Purple, ThemeSources.Ayu.Mirage.Blue, ThemeSources.Ayu.Mirage.Cyan, ThemeSources.Ayu.Mirage.Green, ThemeSources.Ayu.Mirage.Yellow, ThemeSources.Ayu.Mirage.Orange, ThemeSources.Ayu.Mirage.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Ayu Mirage Text",
				ThemeSources.Ayu.Mirage.Comment, ThemeSources.Ayu.Mirage.Foreground);
		}
	}

	/// <summary>
	/// Nightfly theme color families organized by function and luminance.
	/// </summary>
	public static class Nightfly
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Nightfly Backgrounds",
			ThemeSources.Nightfly.Background, ThemeSources.Nightfly.Selection, ThemeSources.Nightfly.Surface);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Nightfly Neutrals",
			ThemeSources.Nightfly.Background, ThemeSources.Nightfly.Selection, ThemeSources.Nightfly.Surface, ThemeSources.Nightfly.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Nightfly Accents",
			ThemeSources.Nightfly.Purple, ThemeSources.Nightfly.Blue, ThemeSources.Nightfly.Cyan, ThemeSources.Nightfly.Green, ThemeSources.Nightfly.Yellow, ThemeSources.Nightfly.Orange, ThemeSources.Nightfly.Red);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Nightfly Text",
			ThemeSources.Nightfly.Comment, ThemeSources.Nightfly.Foreground);
	}

	/// <summary>
	/// Kanagawa theme color families organized by function and luminance.
	/// </summary>
	public static class Kanagawa
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Kanagawa Backgrounds",
			ThemeSources.Kanagawa.BackgroundDark, ThemeSources.Kanagawa.Background, ThemeSources.Kanagawa.Selection, ThemeSources.Kanagawa.Surface);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Kanagawa Neutrals",
			ThemeSources.Kanagawa.BackgroundDark, ThemeSources.Kanagawa.Background, ThemeSources.Kanagawa.Selection, ThemeSources.Kanagawa.Surface, ThemeSources.Kanagawa.Comment);

		/// <summary>Gets accent colors with traditional Japanese names.</summary>
		public static ColorFamily Accents { get; } = new("Kanagawa Accents",
			ThemeSources.Kanagawa.SpringViolet, ThemeSources.Kanagawa.CrystalBlue, ThemeSources.Kanagawa.WaveAqua, ThemeSources.Kanagawa.AutumnGreen, ThemeSources.Kanagawa.AutumnYellow, ThemeSources.Kanagawa.SurimihanaOrange, ThemeSources.Kanagawa.AutumnRed);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Kanagawa Text",
			ThemeSources.Kanagawa.Comment, ThemeSources.Kanagawa.ForegroundDim, ThemeSources.Kanagawa.Foreground, ThemeSources.Kanagawa.OldWhite);
	}

	/// <summary>
	/// Synthwave '84 theme color families organized by function and luminance.
	/// </summary>
	public static class Synthwave84
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Synthwave '84 Backgrounds",
			ThemeSources.Synthwave84.BackgroundDark, ThemeSources.Synthwave84.Background, ThemeSources.Synthwave84.Surface, ThemeSources.Synthwave84.SurfaceElevated);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Synthwave '84 Neutrals",
			ThemeSources.Synthwave84.BackgroundDark, ThemeSources.Synthwave84.Background, ThemeSources.Synthwave84.Surface, ThemeSources.Synthwave84.Selection);

		/// <summary>Gets neon accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Synthwave '84 Accents",
			ThemeSources.Synthwave84.NeonPurple, ThemeSources.Synthwave84.NeonPink, ThemeSources.Synthwave84.NeonCyan, ThemeSources.Synthwave84.NeonGreen, ThemeSources.Synthwave84.NeonYellow, ThemeSources.Synthwave84.NeonOrange);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Synthwave '84 Text",
			ThemeSources.Synthwave84.TextMuted, ThemeSources.Synthwave84.TextSecondary, ThemeSources.Synthwave84.Text);
	}

	/// <summary>
	/// Everforest theme color families organized by function and luminance.
	/// </summary>
	public static class Everforest
	{
		/// <summary>
		/// Everforest Dark variant color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Everforest Dark Backgrounds",
				ThemeSources.Everforest.Dark.BgDim, ThemeSources.Everforest.Dark.Bg0, ThemeSources.Everforest.Dark.Bg1, ThemeSources.Everforest.Dark.Bg2, ThemeSources.Everforest.Dark.Bg3);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Everforest Dark Neutrals",
				ThemeSources.Everforest.Dark.BgDim, ThemeSources.Everforest.Dark.Bg0, ThemeSources.Everforest.Dark.Bg1, ThemeSources.Everforest.Dark.Bg2, ThemeSources.Everforest.Dark.Bg3, ThemeSources.Everforest.Dark.Bg4, ThemeSources.Everforest.Dark.Bg5);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Everforest Dark Accents",
				ThemeSources.Everforest.Dark.Purple, ThemeSources.Everforest.Dark.Blue, ThemeSources.Everforest.Dark.Aqua, ThemeSources.Everforest.Dark.Green, ThemeSources.Everforest.Dark.Yellow, ThemeSources.Everforest.Dark.Orange, ThemeSources.Everforest.Dark.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Everforest Dark Text",
				ThemeSources.Everforest.Dark.Fg);
		}

		/// <summary>
		/// Everforest Light variant color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("Everforest Light Backgrounds",
				ThemeSources.Everforest.Light.Bg1, ThemeSources.Everforest.Light.Bg0, ThemeSources.Everforest.Light.Bg2, ThemeSources.Everforest.Light.Bg3);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("Everforest Light Neutrals",
				ThemeSources.Everforest.Light.Bg1, ThemeSources.Everforest.Light.Bg0, ThemeSources.Everforest.Light.Bg2, ThemeSources.Everforest.Light.Bg3, ThemeSources.Everforest.Light.Bg4, ThemeSources.Everforest.Light.Bg5);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("Everforest Light Accents",
				ThemeSources.Everforest.Light.Purple, ThemeSources.Everforest.Light.Blue, ThemeSources.Everforest.Light.Aqua, ThemeSources.Everforest.Light.Green, ThemeSources.Everforest.Light.Yellow, ThemeSources.Everforest.Light.Orange, ThemeSources.Everforest.Light.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("Everforest Light Text",
				ThemeSources.Everforest.Light.Fg);
		}
	}

	/// <summary>
	/// PaperColor theme color families organized by function and luminance.
	/// </summary>
	public static class PaperColor
	{
		/// <summary>
		/// PaperColor Dark variant color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("PaperColor Dark Backgrounds",
				ThemeSources.PaperColor.Dark.Background, ThemeSources.PaperColor.Dark.Surface, ThemeSources.PaperColor.Dark.SurfaceElevated, ThemeSources.PaperColor.Dark.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("PaperColor Dark Neutrals",
				ThemeSources.PaperColor.Dark.Background, ThemeSources.PaperColor.Dark.Surface, ThemeSources.PaperColor.Dark.SurfaceElevated, ThemeSources.PaperColor.Dark.Selection, ThemeSources.PaperColor.Dark.Comment);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("PaperColor Dark Accents",
				ThemeSources.PaperColor.Dark.Magenta, ThemeSources.PaperColor.Dark.Blue, ThemeSources.PaperColor.Dark.Cyan, ThemeSources.PaperColor.Dark.Green, ThemeSources.PaperColor.Dark.Yellow, ThemeSources.PaperColor.Dark.Orange, ThemeSources.PaperColor.Dark.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("PaperColor Dark Text",
				ThemeSources.PaperColor.Dark.ForegroundDim, ThemeSources.PaperColor.Dark.Foreground);
		}

		/// <summary>
		/// PaperColor Light variant color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("PaperColor Light Backgrounds",
				ThemeSources.PaperColor.Light.Surface, ThemeSources.PaperColor.Light.Background, ThemeSources.PaperColor.Light.SurfaceElevated, ThemeSources.PaperColor.Light.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("PaperColor Light Neutrals",
				ThemeSources.PaperColor.Light.Surface, ThemeSources.PaperColor.Light.Background, ThemeSources.PaperColor.Light.SurfaceElevated, ThemeSources.PaperColor.Light.Selection, ThemeSources.PaperColor.Light.Comment);

			/// <summary>Gets accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("PaperColor Light Accents",
				ThemeSources.PaperColor.Light.Magenta, ThemeSources.PaperColor.Light.Blue, ThemeSources.PaperColor.Light.Cyan, ThemeSources.PaperColor.Light.Green, ThemeSources.PaperColor.Light.Yellow, ThemeSources.PaperColor.Light.Orange, ThemeSources.PaperColor.Light.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("PaperColor Light Text",
				ThemeSources.PaperColor.Light.ForegroundDim, ThemeSources.PaperColor.Light.Foreground);
		}
	}

	/// <summary>
	/// High Contrast theme color families organized by function and luminance.
	/// </summary>
	public static class HighContrast
	{
		/// <summary>
		/// High Contrast Dark variant color families.
		/// </summary>
		public static class Dark
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("High Contrast Dark Backgrounds",
				ThemeSources.HighContrast.Dark.Background, ThemeSources.HighContrast.Dark.Surface, ThemeSources.HighContrast.Dark.Selection);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("High Contrast Dark Neutrals",
				ThemeSources.HighContrast.Dark.Background, ThemeSources.HighContrast.Dark.Surface, ThemeSources.HighContrast.Dark.Selection, ThemeSources.HighContrast.Dark.Border);

			/// <summary>Gets bright accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("High Contrast Dark Accents",
				ThemeSources.HighContrast.Dark.Magenta, ThemeSources.HighContrast.Dark.Blue, ThemeSources.HighContrast.Dark.AccentCyan, ThemeSources.HighContrast.Dark.Green, ThemeSources.HighContrast.Dark.Yellow, ThemeSources.HighContrast.Dark.Red);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("High Contrast Dark Text",
				ThemeSources.HighContrast.Dark.Text);
		}

		/// <summary>
		/// High Contrast Light variant color families.
		/// </summary>
		public static class Light
		{
			/// <summary>Gets background colors from darkest to lightest.</summary>
			public static ColorFamily Backgrounds { get; } = new("High Contrast Light Backgrounds",
				ThemeSources.HighContrast.Light.Surface, ThemeSources.HighContrast.Light.Background);

			/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
			public static ColorFamily Neutrals { get; } = new("High Contrast Light Neutrals",
				ThemeSources.HighContrast.Light.Surface, ThemeSources.HighContrast.Light.Background, ThemeSources.HighContrast.Light.Selection, ThemeSources.HighContrast.Light.Border);

			/// <summary>Gets dark accent colors from darkest to lightest.</summary>
			public static ColorFamily Accents { get; } = new("High Contrast Light Accents",
				ThemeSources.HighContrast.Light.Purple, ThemeSources.HighContrast.Light.AccentBlue, ThemeSources.HighContrast.Light.Teal, ThemeSources.HighContrast.Light.Green, ThemeSources.HighContrast.Light.Red, ThemeSources.HighContrast.Light.Magenta);

			/// <summary>Gets primary text colors.</summary>
			public static ColorFamily Text { get; } = new("High Contrast Light Text",
				ThemeSources.HighContrast.Light.Text);
		}
	}

	/// <summary>
	/// Nightfox theme color families organized by function and luminance.
	/// </summary>
	public static class Nightfox
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("Nightfox Backgrounds",
			ThemeSources.Nightfox.Background, ThemeSources.Nightfox.Selection, ThemeSources.Nightfox.Surface);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("Nightfox Neutrals",
			ThemeSources.Nightfox.Background, ThemeSources.Nightfox.Selection, ThemeSources.Nightfox.Surface, ThemeSources.Nightfox.Comment);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("Nightfox Accents",
			ThemeSources.Nightfox.Magenta, ThemeSources.Nightfox.Blue, ThemeSources.Nightfox.Cyan, ThemeSources.Nightfox.Green, ThemeSources.Nightfox.Yellow, ThemeSources.Nightfox.Orange, ThemeSources.Nightfox.Red);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("Nightfox Text",
			ThemeSources.Nightfox.Comment, ThemeSources.Nightfox.ForegroundDim, ThemeSources.Nightfox.Foreground);
	}

	/// <summary>
	/// OneDark Pro theme color families organized by function and luminance.
	/// </summary>
	public static class OneDarkPro
	{
		/// <summary>Gets background colors from darkest to lightest.</summary>
		public static ColorFamily Backgrounds { get; } = new("OneDark Pro Backgrounds",
			ThemeSources.OneDarkPro.Background, ThemeSources.OneDarkPro.Selection, ThemeSources.OneDarkPro.BackgroundLight);

		/// <summary>Gets neutral/surface colors from darkest to lightest.</summary>
		public static ColorFamily Neutrals { get; } = new("OneDark Pro Neutrals",
			ThemeSources.OneDarkPro.Background, ThemeSources.OneDarkPro.Selection, ThemeSources.OneDarkPro.BackgroundLight);

		/// <summary>Gets accent colors from darkest to lightest.</summary>
		public static ColorFamily Accents { get; } = new("OneDark Pro Accents",
			ThemeSources.OneDarkPro.Purple, ThemeSources.OneDarkPro.Blue, ThemeSources.OneDarkPro.Cyan, ThemeSources.OneDarkPro.Green, ThemeSources.OneDarkPro.Yellow, ThemeSources.OneDarkPro.Orange, ThemeSources.OneDarkPro.Red);

		/// <summary>Gets primary text colors.</summary>
		public static ColorFamily Text { get; } = new("OneDark Pro Text",
			ThemeSources.OneDarkPro.Foreground);
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
			"vscodedark" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = VSCode.Dark.Backgrounds,
				["Neutrals"] = VSCode.Dark.Neutrals,
				["Accents"] = VSCode.Dark.Accents,
				["Text"] = VSCode.Dark.Text
			},
			"vscodelight" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = VSCode.Light.Backgrounds,
				["Neutrals"] = VSCode.Light.Neutrals,
				["Accents"] = VSCode.Light.Accents,
				["Text"] = VSCode.Light.Text
			},
			"catppuccinlatte" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Catppuccin.Latte.Backgrounds,
				["Neutrals"] = Catppuccin.Latte.Neutrals,
				["Accents"] = Catppuccin.Latte.Accents,
				["Pastels"] = Catppuccin.Latte.Pastels,
				["Text"] = Catppuccin.Latte.Text
			},
			"catppuccinfrappe" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Catppuccin.Frappe.Backgrounds,
				["Neutrals"] = Catppuccin.Frappe.Neutrals,
				["Accents"] = Catppuccin.Frappe.Accents,
				["Pastels"] = Catppuccin.Frappe.Pastels,
				["Text"] = Catppuccin.Frappe.Text
			},
			"catppuccinmacchiato" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Catppuccin.Macchiato.Backgrounds,
				["Neutrals"] = Catppuccin.Macchiato.Neutrals,
				["Accents"] = Catppuccin.Macchiato.Accents,
				["Pastels"] = Catppuccin.Macchiato.Pastels,
				["Text"] = Catppuccin.Macchiato.Text
			},
			"catppuccinmocha" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Catppuccin.Mocha.Backgrounds,
				["Neutrals"] = Catppuccin.Mocha.Neutrals,
				["Accents"] = Catppuccin.Mocha.Accents,
				["Pastels"] = Catppuccin.Mocha.Pastels,
				["Text"] = Catppuccin.Mocha.Text
			},
			"onedark" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = OneDark.Backgrounds,
				["Neutrals"] = OneDark.Neutrals,
				["Accents"] = OneDark.Accents,
				["Text"] = OneDark.Text
			},
			"onedarkpro" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = OneDarkPro.Backgrounds,
				["Neutrals"] = OneDarkPro.Neutrals,
				["Accents"] = OneDarkPro.Accents,
				["Text"] = OneDarkPro.Text
			},
			"tokyonight" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = TokyoNight.Backgrounds,
				["Neutrals"] = TokyoNight.Neutrals,
				["Accents"] = TokyoNight.Accents,
				["Text"] = TokyoNight.Text
			},
			"solarized" or "solarizeddark" or "solarizedlight" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Solarized.Backgrounds,
				["Neutrals"] = Solarized.Neutrals,
				["Accents"] = Solarized.Accents,
				["TextDark"] = Solarized.TextDark,
				["TextLight"] = Solarized.TextLight
			},
			"monokai" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Monokai.Backgrounds,
				["Neutrals"] = Monokai.Neutrals,
				["Accents"] = Monokai.Accents,
				["Text"] = Monokai.Text
			},
			"nightfly" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Nightfly.Backgrounds,
				["Neutrals"] = Nightfly.Neutrals,
				["Accents"] = Nightfly.Accents,
				["Text"] = Nightfly.Text
			},
			"nightfox" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Nightfox.Backgrounds,
				["Neutrals"] = Nightfox.Neutrals,
				["Accents"] = Nightfox.Accents,
				["Text"] = Nightfox.Text
			},
			"kanagawa" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Kanagawa.Backgrounds,
				["Neutrals"] = Kanagawa.Neutrals,
				["Accents"] = Kanagawa.Accents,
				["Text"] = Kanagawa.Text
			},
			"synthwave84" => new Dictionary<string, ColorFamily>
			{
				["Backgrounds"] = Synthwave84.Backgrounds,
				["Neutrals"] = Synthwave84.Neutrals,
				["Accents"] = Synthwave84.Accents,
				["Text"] = Synthwave84.Text
			},
			_ => null
		};
	}
}
