// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Provides methods and properties to manage and apply themes for ImGui elements.
/// </summary>
public static class Theme
{
	#region Theme Generation Parameters

	private static float NormalLuminanceMult { get; set; } = 0.4f;
	private static float NormalSaturationMult { get; set; } = 0.5f;
	private static float AccentLuminanceMult { get; set; } = 0.7f;
	private static float AccentSaturationMult { get; set; } = 0.8f;
	private static float AccentHoveredLuminanceMult { get; set; } = 1.0f;
	private static float AccentHoveredSaturationMult { get; set; } = 0.9f;
	private static float AccentHueOffset { get; set; } = 0.5f;
	private static float HeaderLuminanceMult { get; set; } = 0.5f;
	private static float HeaderSaturationMult { get; set; } = 0.6f;
	private static float ActiveLuminanceMult { get; set; } = .6f;
	private static float ActiveSaturationMult { get; set; } = .7f;
	private static float HoverLuminanceMult { get; set; } = .7f;
	private static float HoverSaturationMult { get; set; } = .8f;
	private static float DragLuminanceMult { get; set; } = 1.1f;
	private static float BackgroundLuminanceMult { get; set; } = .13f;
	private static float BackgroundSaturationMult { get; set; } = .05f;
	private static float DisabledSaturationMult { get; set; } = .1f;
	private static float BorderLuminanceMult { get; set; } = .7f;

	#endregion

	#region Color Calculation Methods

	/// <summary>
	/// Gets the state color based on whether it is enabled or disabled.
	/// </summary>
	/// <param name="baseColor">The base color.</param>
	/// <param name="enabled">A boolean indicating if the state is enabled.</param>
	/// <returns>The state color.</returns>
	public static ImColor GetStateColor(ImColor baseColor, bool enabled) => enabled ? baseColor : baseColor.MultiplySaturation(DisabledSaturationMult);

	/// <summary>
	/// Gets the normal color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The normal color.</returns>
	public static ImColor GetNormalColor(ImColor stateColor) => stateColor.MultiplyLuminance(NormalLuminanceMult).MultiplySaturation(NormalSaturationMult);

	/// <summary>
	/// Gets the accent color by adjusting the luminance, saturation, and hue of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The accent color.</returns>
	public static ImColor GetAccentColor(ImColor stateColor) => stateColor.MultiplyLuminance(AccentLuminanceMult).MultiplySaturation(AccentSaturationMult).OffsetHue(AccentHueOffset).WithAlpha(1);

	/// <summary>
	/// Gets the accent hovered color by adjusting the luminance, saturation, and hue of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The accent hovered color.</returns>
	public static ImColor GetAccentHoveredColor(ImColor stateColor) => stateColor.MultiplyLuminance(AccentHoveredLuminanceMult).MultiplySaturation(AccentHoveredSaturationMult).OffsetHue(AccentHueOffset).WithAlpha(1);

	/// <summary>
	/// Gets the header color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The header color.</returns>
	public static ImColor GetHeaderColor(ImColor stateColor) => stateColor.MultiplyLuminance(HeaderLuminanceMult).MultiplySaturation(HeaderSaturationMult);

	/// <summary>
	/// Gets the active color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The active color.</returns>
	public static ImColor GetActiveColor(ImColor stateColor) => stateColor.MultiplyLuminance(ActiveLuminanceMult).MultiplySaturation(ActiveSaturationMult);

	/// <summary>
	/// Gets the hovered color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The hovered color.</returns>
	public static ImColor GetHoveredColor(ImColor stateColor) => stateColor.MultiplyLuminance(HoverLuminanceMult).MultiplySaturation(HoverSaturationMult);

	/// <summary>
	/// Gets the drag color by adjusting the luminance of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The drag color.</returns>
	public static ImColor GetDragColor(ImColor stateColor) => stateColor.MultiplyLuminance(DragLuminanceMult);

	/// <summary>
	/// Gets the background color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The background color.</returns>
	public static ImColor GetBackgroundColor(ImColor stateColor) => stateColor.MultiplyLuminance(BackgroundLuminanceMult).MultiplySaturation(BackgroundSaturationMult);

	/// <summary>
	/// Gets the text color that contrasts optimally with the background color.
	/// </summary>
	/// <param name="backgroundColor">The background color.</param>
	/// <returns>The text color.</returns>
	public static ImColor GetTextColor(ImColor backgroundColor) => backgroundColor.CalculateOptimalContrastingColor();

	#endregion

	#region Predefined Themes

	/// <summary>
	/// Dracula theme - A dark theme with purple accents.
	/// Uses authentic Dracula color palette with semantic naming.
	/// </summary>
	public static ThemeDefinition Dracula => new()
	{
		BackgroundColor = ThemeSources.Dracula.Background.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		TextColor = ThemeSources.Dracula.Foreground,
		AccentColor = ThemeSources.Dracula.Purple,
		ButtonColor = ThemeSources.Dracula.CurrentLine.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		ButtonHoveredColor = ThemeSources.Dracula.Comment.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		ButtonActiveColor = ThemeSources.Dracula.Purple,
		FrameColor = ThemeSources.Dracula.CurrentLine.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		FrameHoveredColor = ThemeSources.Dracula.Comment.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		FrameActiveColor = ThemeSources.Dracula.Purple,
		HeaderColor = ThemeSources.Dracula.CurrentLine.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		HeaderHoveredColor = ThemeSources.Dracula.Comment.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		HeaderActiveColor = ThemeSources.Dracula.Purple,
		BorderColor = ThemeSources.Dracula.Comment,
		ScrollbarColor = ThemeSources.Dracula.CurrentLine,
		ScrollbarHoveredColor = ThemeSources.Dracula.Comment,
		ScrollbarActiveColor = ThemeSources.Dracula.Purple,
		CheckMarkColor = ThemeSources.Dracula.Green,
		SliderGrabColor = ThemeSources.Dracula.Purple,
		SliderGrabActiveColor = ThemeSources.Dracula.Pink,
		TabColor = ThemeSources.Dracula.CurrentLine.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		TabHoveredColor = ThemeSources.Dracula.Comment.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		TabActiveColor = ThemeSources.Dracula.Purple.AdjustForSufficientContrast(ThemeSources.Dracula.Foreground),
		PlotLinesColor = ThemeSources.Dracula.Cyan,
		PlotHistogramColor = ThemeSources.Dracula.Green
	};

	/// <summary>
	/// Nord theme - A dark theme with cool blue tones inspired by the arctic.
	/// Uses authentic Nord color palette with semantic naming.
	/// </summary>
	public static ThemeDefinition Nord => new()
	{
		BackgroundColor = ThemeSources.Nord.Nord0.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		TextColor = ThemeSources.Nord.Nord4,
		AccentColor = ThemeSources.Nord.Nord10,
		ButtonColor = ThemeSources.Nord.Nord1.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		ButtonHoveredColor = ThemeSources.Nord.Nord2.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		ButtonActiveColor = ThemeSources.Nord.Nord10,
		FrameColor = ThemeSources.Nord.Nord1.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		FrameHoveredColor = ThemeSources.Nord.Nord2.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		FrameActiveColor = ThemeSources.Nord.Nord10,
		HeaderColor = ThemeSources.Nord.Nord1.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		HeaderHoveredColor = ThemeSources.Nord.Nord2.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		HeaderActiveColor = ThemeSources.Nord.Nord10,
		BorderColor = ThemeSources.Nord.Nord3,
		ScrollbarColor = ThemeSources.Nord.Nord1,
		ScrollbarHoveredColor = ThemeSources.Nord.Nord2,
		ScrollbarActiveColor = ThemeSources.Nord.Nord10,
		CheckMarkColor = ThemeSources.Nord.Nord14,
		SliderGrabColor = ThemeSources.Nord.Nord10,
		SliderGrabActiveColor = ThemeSources.Nord.Nord9,
		TabColor = ThemeSources.Nord.Nord1.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		TabHoveredColor = ThemeSources.Nord.Nord2.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		TabActiveColor = ThemeSources.Nord.Nord10.AdjustForSufficientContrast(ThemeSources.Nord.Nord4),
		PlotLinesColor = ThemeSources.Nord.Nord8,
		PlotHistogramColor = ThemeSources.Nord.Nord14
	};

	/// <summary>
	/// VS Code Dark theme - The popular dark theme from Visual Studio Code.
	/// Uses authentic VS Code color palette with semantic naming.
	/// </summary>
	public static ThemeDefinition VSCodeDark => new()
	{
		BackgroundColor = ThemeSources.VSCode.Dark.Background.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		TextColor = ThemeSources.VSCode.Dark.Foreground,
		AccentColor = ThemeSources.VSCode.Dark.AccentBlue,
		ButtonColor = ThemeSources.VSCode.Dark.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		ButtonHoveredColor = ThemeSources.VSCode.Dark.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		ButtonActiveColor = ThemeSources.VSCode.Dark.AccentBlue,
		FrameColor = ThemeSources.VSCode.Dark.InputBackground.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		FrameHoveredColor = ThemeSources.VSCode.Dark.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		FrameActiveColor = ThemeSources.VSCode.Dark.AccentBlue,
		HeaderColor = ThemeSources.VSCode.Dark.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		HeaderHoveredColor = ThemeSources.VSCode.Dark.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		HeaderActiveColor = ThemeSources.VSCode.Dark.AccentBlue,
		BorderColor = ThemeSources.VSCode.Dark.Border,
		ScrollbarColor = ThemeSources.VSCode.Dark.Button,
		ScrollbarHoveredColor = ThemeSources.VSCode.Dark.ButtonHover,
		ScrollbarActiveColor = ThemeSources.VSCode.Dark.AccentBlue,
		CheckMarkColor = ThemeSources.VSCode.Dark.AccentGreen,
		SliderGrabColor = ThemeSources.VSCode.Dark.AccentBlue,
		SliderGrabActiveColor = ThemeSources.VSCode.Dark.AccentBlueBright,
		TabColor = ThemeSources.VSCode.Dark.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		TabHoveredColor = ThemeSources.VSCode.Dark.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		TabActiveColor = ThemeSources.VSCode.Dark.AccentBlue.AdjustForSufficientContrast(ThemeSources.VSCode.Dark.Foreground),
		PlotLinesColor = ThemeSources.VSCode.Dark.AccentBlue,
		PlotHistogramColor = ThemeSources.VSCode.Dark.AccentGreen
	};

	/// <summary>
	/// OneDark theme - Popular dark theme with balanced colors.
	/// </summary>
	public static ThemeDefinition OneDark => new()
	{
		BackgroundColor = ThemeSources.OneDark.Background.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		TextColor = ThemeSources.OneDark.Foreground,
		AccentColor = ThemeSources.OneDark.Blue,
		ButtonColor = ThemeSources.OneDark.Selection.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		ButtonHoveredColor = ThemeSources.OneDark.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		ButtonActiveColor = ThemeSources.OneDark.Blue,
		FrameColor = ThemeSources.OneDark.Selection.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		FrameHoveredColor = ThemeSources.OneDark.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		FrameActiveColor = ThemeSources.OneDark.Blue,
		HeaderColor = ThemeSources.OneDark.Selection.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		HeaderHoveredColor = ThemeSources.OneDark.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		HeaderActiveColor = ThemeSources.OneDark.Blue,
		BorderColor = ThemeSources.OneDark.BackgroundLight,
		ScrollbarColor = ThemeSources.OneDark.Selection,
		ScrollbarHoveredColor = ThemeSources.OneDark.BackgroundLight,
		ScrollbarActiveColor = ThemeSources.OneDark.Blue,
		CheckMarkColor = ThemeSources.OneDark.Green,
		SliderGrabColor = ThemeSources.OneDark.Blue,
		SliderGrabActiveColor = ThemeSources.OneDark.Cyan,
		TabColor = ThemeSources.OneDark.Selection.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		TabHoveredColor = ThemeSources.OneDark.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		TabActiveColor = ThemeSources.OneDark.Blue.AdjustForSufficientContrast(ThemeSources.OneDark.Foreground),
		PlotLinesColor = ThemeSources.OneDark.Purple,
		PlotHistogramColor = ThemeSources.OneDark.Red
	};

	/// <summary>
	/// Gruvbox Dark theme - Retro groove color scheme with warm tones.
	/// </summary>
	public static ThemeDefinition GruvboxDark => new()
	{
		BackgroundColor = ThemeSources.Gruvbox.Dark0.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		TextColor = ThemeSources.Gruvbox.Light1,
		AccentColor = ThemeSources.Gruvbox.BrightOrange,
		ButtonColor = ThemeSources.Gruvbox.Dark1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		ButtonHoveredColor = ThemeSources.Gruvbox.Dark2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		ButtonActiveColor = ThemeSources.Gruvbox.BrightOrange,
		FrameColor = ThemeSources.Gruvbox.Dark1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		FrameHoveredColor = ThemeSources.Gruvbox.Dark2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		FrameActiveColor = ThemeSources.Gruvbox.BrightOrange,
		HeaderColor = ThemeSources.Gruvbox.Dark1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		HeaderHoveredColor = ThemeSources.Gruvbox.Dark2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		HeaderActiveColor = ThemeSources.Gruvbox.BrightOrange,
		BorderColor = ThemeSources.Gruvbox.Dark2,
		ScrollbarColor = ThemeSources.Gruvbox.Dark1,
		ScrollbarHoveredColor = ThemeSources.Gruvbox.Dark2,
		ScrollbarActiveColor = ThemeSources.Gruvbox.BrightOrange,
		CheckMarkColor = ThemeSources.Gruvbox.BrightGreen,
		SliderGrabColor = ThemeSources.Gruvbox.BrightOrange,
		SliderGrabActiveColor = ThemeSources.Gruvbox.BrightYellow,
		TabColor = ThemeSources.Gruvbox.Dark1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		TabHoveredColor = ThemeSources.Gruvbox.Dark2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		TabActiveColor = ThemeSources.Gruvbox.BrightOrange.AdjustForSufficientContrast(ThemeSources.Gruvbox.Light1),
		PlotLinesColor = ThemeSources.Gruvbox.BrightBlue,
		PlotHistogramColor = ThemeSources.Gruvbox.BrightAqua
	};

	/// <summary>
	/// Catppuccin Latte theme - Light and warm pastel theme.
	/// Uses proper color hierarchy: Base → Surface0 → Surface1 for consistent text readability.
	/// </summary>
	public static ThemeDefinition CatppuccinLatte => new()
	{
		BackgroundColor = ThemeSources.CatppuccinLatte.Base.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		TextColor = ThemeSources.CatppuccinLatte.Text,
		AccentColor = ThemeSources.CatppuccinLatte.Mauve,
		ButtonColor = ThemeSources.CatppuccinLatte.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		ButtonHoveredColor = ThemeSources.CatppuccinLatte.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		ButtonActiveColor = ThemeSources.CatppuccinLatte.Mauve,
		FrameColor = ThemeSources.CatppuccinLatte.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		FrameHoveredColor = ThemeSources.CatppuccinLatte.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		FrameActiveColor = ThemeSources.CatppuccinLatte.Mauve,
		HeaderColor = ThemeSources.CatppuccinLatte.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		HeaderHoveredColor = ThemeSources.CatppuccinLatte.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		HeaderActiveColor = ThemeSources.CatppuccinLatte.Mauve,
		BorderColor = ThemeSources.CatppuccinLatte.Surface1,
		ScrollbarColor = ThemeSources.CatppuccinLatte.Surface0,
		ScrollbarHoveredColor = ThemeSources.CatppuccinLatte.Surface1,
		ScrollbarActiveColor = ThemeSources.CatppuccinLatte.Mauve,
		CheckMarkColor = ThemeSources.CatppuccinLatte.Mauve,
		SliderGrabColor = ThemeSources.CatppuccinLatte.Mauve,
		SliderGrabActiveColor = ThemeSources.CatppuccinLatte.Mauve,
		TabColor = ThemeSources.CatppuccinLatte.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		TabHoveredColor = ThemeSources.CatppuccinLatte.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		TabActiveColor = ThemeSources.CatppuccinLatte.Mauve.AdjustForSufficientContrast(ThemeSources.CatppuccinLatte.Text),
		PlotLinesColor = ThemeSources.CatppuccinLatte.Blue,
		PlotHistogramColor = ThemeSources.CatppuccinLatte.Green
	};

	/// <summary>
	/// Catppuccin Frappe theme - Dark theme with purple accents.
	/// Uses proper color hierarchy: Base → Surface0 → Surface1 for consistent text readability.
	/// </summary>
	public static ThemeDefinition CatppuccinFrappe => new()
	{
		BackgroundColor = ThemeSources.CatppuccinFrappe.Base.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		TextColor = ThemeSources.CatppuccinFrappe.Text,
		AccentColor = ThemeSources.CatppuccinFrappe.Mauve,
		ButtonColor = ThemeSources.CatppuccinFrappe.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		ButtonHoveredColor = ThemeSources.CatppuccinFrappe.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		ButtonActiveColor = ThemeSources.CatppuccinFrappe.Mauve,
		FrameColor = ThemeSources.CatppuccinFrappe.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		FrameHoveredColor = ThemeSources.CatppuccinFrappe.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		FrameActiveColor = ThemeSources.CatppuccinFrappe.Mauve,
		HeaderColor = ThemeSources.CatppuccinFrappe.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		HeaderHoveredColor = ThemeSources.CatppuccinFrappe.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		HeaderActiveColor = ThemeSources.CatppuccinFrappe.Mauve,
		BorderColor = ThemeSources.CatppuccinFrappe.Surface1,
		ScrollbarColor = ThemeSources.CatppuccinFrappe.Surface0,
		ScrollbarHoveredColor = ThemeSources.CatppuccinFrappe.Surface1,
		ScrollbarActiveColor = ThemeSources.CatppuccinFrappe.Mauve,
		CheckMarkColor = ThemeSources.CatppuccinFrappe.Mauve,
		SliderGrabColor = ThemeSources.CatppuccinFrappe.Mauve,
		SliderGrabActiveColor = ThemeSources.CatppuccinFrappe.Mauve,
		TabColor = ThemeSources.CatppuccinFrappe.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		TabHoveredColor = ThemeSources.CatppuccinFrappe.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		TabActiveColor = ThemeSources.CatppuccinFrappe.Mauve.AdjustForSufficientContrast(ThemeSources.CatppuccinFrappe.Text),
		PlotLinesColor = ThemeSources.CatppuccinFrappe.Blue,
		PlotHistogramColor = ThemeSources.CatppuccinFrappe.Green
	};

	/// <summary>
	/// Catppuccin Macchiato theme - Dark theme with soft purple tones.
	/// Uses proper color hierarchy: Base → Surface0 → Surface1 for consistent text readability.
	/// </summary>
	public static ThemeDefinition CatppuccinMacchiato => new()
	{
		BackgroundColor = Color.FromHex("#24273a"),    // Base - main background
		TextColor = Color.FromHex("#cad3f5"),          // Text - official text color
		AccentColor = Color.FromHex("#c6a0f6"),        // Mauve - accent color
		ButtonColor = Color.FromHex("#363a4f"),        // Surface0 - consistent with background
		ButtonHoveredColor = Color.FromHex("#494d64"), // Surface1 - one step lighter
		ButtonActiveColor = Color.FromHex("#363a4f"),  // Surface0 - same as button for consistency
		FrameColor = Color.FromHex("#363a4f"),         // Surface0 - consistent with buttons
		FrameHoveredColor = Color.FromHex("#494d64"),  // Surface1 - hover state
		FrameActiveColor = Color.FromHex("#363a4f"),   // Surface0 - active state
		HeaderColor = Color.FromHex("#363a4f"),        // Surface0 - consistent
		HeaderHoveredColor = Color.FromHex("#494d64"), // Surface1 - hover
		HeaderActiveColor = Color.FromHex("#363a4f"),  // Surface0 - active
		BorderColor = Color.FromHex("#494d64"),        // Surface1 - subtle borders
		ScrollbarColor = Color.FromHex("#363a4f"),     // Surface0 - consistent
		ScrollbarHoveredColor = Color.FromHex("#494d64"), // Surface1 - hover
		ScrollbarActiveColor = Color.FromHex("#363a4f"), // Surface0 - active
		CheckMarkColor = Color.FromHex("#c6a0f6"),     // Mauve - accent for checkmarks
		SliderGrabColor = Color.FromHex("#c6a0f6"),    // Mauve - accent
		SliderGrabActiveColor = Color.FromHex("#c6a0f6"), // Mauve - consistent
		TabColor = Color.FromHex("#363a4f"),           // Surface0 - consistent with buttons
		TabHoveredColor = Color.FromHex("#494d64"),    // Surface1 - hover
		TabActiveColor = Color.FromHex("#c6a0f6"),     // Mauve - clearly active
		PlotLinesColor = Color.FromHex("#8aadf4"),     // Blue - accent
		PlotHistogramColor = Color.FromHex("#a6da95")  // Green - accent
	};

	/// <summary>
	/// Catppuccin Mocha theme - Dark theme with blue accents.
	/// Uses authentic Catppuccin color palette with semantic naming and proper color hierarchy.
	/// </summary>
	public static ThemeDefinition CatppuccinMocha => new()
	{
		BackgroundColor = ThemeSources.CatppuccinMocha.Base,
		TextColor = ThemeSources.CatppuccinMocha.Text,
		AccentColor = ThemeSources.CatppuccinMocha.Blue,
		ButtonColor = ThemeSources.CatppuccinMocha.Surface0,
		ButtonHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		ButtonActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		FrameColor = ThemeSources.CatppuccinMocha.Surface0,
		FrameHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		FrameActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		HeaderColor = ThemeSources.CatppuccinMocha.Surface0,
		HeaderHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		HeaderActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		BorderColor = ThemeSources.CatppuccinMocha.Surface1,
		ScrollbarColor = ThemeSources.CatppuccinMocha.Surface0,
		ScrollbarHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		ScrollbarActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		CheckMarkColor = ThemeSources.CatppuccinMocha.Blue,
		SliderGrabColor = ThemeSources.CatppuccinMocha.Blue,
		SliderGrabActiveColor = ThemeSources.CatppuccinMocha.Blue,
		TabColor = ThemeSources.CatppuccinMocha.Surface0,
		TabHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		TabActiveColor = ThemeSources.CatppuccinMocha.Blue,
		PlotLinesColor = ThemeSources.CatppuccinMocha.Sky,
		PlotHistogramColor = ThemeSources.CatppuccinMocha.Green
	};

	/// <summary>
	/// Monokai theme - Classic dark theme with bright accents.
	/// </summary>
	public static ThemeDefinition Monokai => new()
	{
		BackgroundColor = ThemeSources.Monokai.Background.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		TextColor = ThemeSources.Monokai.Foreground,
		AccentColor = ThemeSources.Monokai.Pink,
		ButtonColor = ThemeSources.Monokai.LineHighlight.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		ButtonHoveredColor = ThemeSources.Monokai.Selection.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		ButtonActiveColor = ThemeSources.Monokai.Pink,
		FrameColor = ThemeSources.Monokai.LineHighlight.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		FrameHoveredColor = ThemeSources.Monokai.Selection.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		FrameActiveColor = ThemeSources.Monokai.Pink,
		HeaderColor = ThemeSources.Monokai.LineHighlight.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		HeaderHoveredColor = ThemeSources.Monokai.Selection.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		HeaderActiveColor = ThemeSources.Monokai.Pink,
		BorderColor = ThemeSources.Monokai.Comment,
		ScrollbarColor = ThemeSources.Monokai.LineHighlight,
		ScrollbarHoveredColor = ThemeSources.Monokai.Selection,
		ScrollbarActiveColor = ThemeSources.Monokai.Pink,
		CheckMarkColor = ThemeSources.Monokai.Green,
		SliderGrabColor = ThemeSources.Monokai.Pink,
		SliderGrabActiveColor = ThemeSources.Monokai.Orange,
		TabColor = ThemeSources.Monokai.LineHighlight.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		TabHoveredColor = ThemeSources.Monokai.Selection.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		TabActiveColor = ThemeSources.Monokai.Pink.AdjustForSufficientContrast(ThemeSources.Monokai.Foreground),
		PlotLinesColor = ThemeSources.Monokai.Cyan,
		PlotHistogramColor = ThemeSources.Monokai.Purple
	};

	/// <summary>
	/// Tokyo Night theme - Dark blue theme inspired by Tokyo's night skyline.
	/// </summary>
	public static ThemeDefinition TokyoNight => new()
	{
		BackgroundColor = Color.FromHex("#1a1b26"),
		TextColor = Color.FromHex("#a9b1d6"),
		AccentColor = Color.FromHex("#7aa2f7"),
		ButtonColor = Color.FromHex("#24283b"),
		ButtonHoveredColor = Color.FromHex("#414868"),
		ButtonActiveColor = Color.FromHex("#7aa2f7"),
		FrameColor = Color.FromHex("#24283b"),
		FrameHoveredColor = Color.FromHex("#414868"),
		FrameActiveColor = Color.FromHex("#7aa2f7"),
		HeaderColor = Color.FromHex("#24283b"),
		HeaderHoveredColor = Color.FromHex("#414868"),
		HeaderActiveColor = Color.FromHex("#7aa2f7"),
		BorderColor = Color.FromHex("#565f89"),
		ScrollbarColor = Color.FromHex("#24283b"),
		ScrollbarHoveredColor = Color.FromHex("#414868"),
		ScrollbarActiveColor = Color.FromHex("#7aa2f7"),
		CheckMarkColor = Color.FromHex("#9ece6a"),
		SliderGrabColor = Color.FromHex("#7aa2f7"),
		SliderGrabActiveColor = Color.FromHex("#bb9af7"),
		TabColor = Color.FromHex("#24283b"),
		TabHoveredColor = Color.FromHex("#414868"),
		TabActiveColor = Color.FromHex("#7aa2f7"),
		PlotLinesColor = Color.FromHex("#7dcfff"),
		PlotHistogramColor = Color.FromHex("#f7768e")
	};

	/// <summary>
	/// Nightfly theme - Dark theme with blue and purple accents.
	/// </summary>
	public static ThemeDefinition Nightfly => new()
	{
		BackgroundColor = Color.FromHex("#011627"),
		TextColor = Color.FromHex("#acb4c2"),
		AccentColor = Color.FromHex("#82aaff"),
		ButtonColor = Color.FromHex("#1d3b53"),
		ButtonHoveredColor = Color.FromHex("#2d5084"),
		ButtonActiveColor = Color.FromHex("#82aaff"),
		FrameColor = Color.FromHex("#1d3b53"),
		FrameHoveredColor = Color.FromHex("#2d5084"),
		FrameActiveColor = Color.FromHex("#82aaff"),
		HeaderColor = Color.FromHex("#1d3b53"),
		HeaderHoveredColor = Color.FromHex("#2d5084"),
		HeaderActiveColor = Color.FromHex("#82aaff"),
		BorderColor = Color.FromHex("#2b5a84"),
		ScrollbarColor = Color.FromHex("#1d3b53"),
		ScrollbarHoveredColor = Color.FromHex("#2d5084"),
		ScrollbarActiveColor = Color.FromHex("#82aaff"),
		CheckMarkColor = Color.FromHex("#21c7a8"),
		SliderGrabColor = Color.FromHex("#82aaff"),
		SliderGrabActiveColor = Color.FromHex("#c792ea"),
		TabColor = Color.FromHex("#1d3b53"),
		TabHoveredColor = Color.FromHex("#2d5084"),
		TabActiveColor = Color.FromHex("#82aaff"),
		PlotLinesColor = Color.FromHex("#addb67"),
		PlotHistogramColor = Color.FromHex("#fc514e")
	};

	/// <summary>
	/// Kanagawa theme - Japanese-inspired earthy theme.
	/// </summary>
	public static ThemeDefinition Kanagawa => new()
	{
		BackgroundColor = Color.FromHex("#1f1f28"),
		TextColor = Color.FromHex("#dcd7ba"),
		AccentColor = Color.FromHex("#7e9cd8"),
		ButtonColor = Color.FromHex("#2a2a37"),
		ButtonHoveredColor = Color.FromHex("#363646"),
		ButtonActiveColor = Color.FromHex("#7e9cd8"),
		FrameColor = Color.FromHex("#2a2a37"),
		FrameHoveredColor = Color.FromHex("#363646"),
		FrameActiveColor = Color.FromHex("#7e9cd8"),
		HeaderColor = Color.FromHex("#2a2a37"),
		HeaderHoveredColor = Color.FromHex("#363646"),
		HeaderActiveColor = Color.FromHex("#7e9cd8"),
		BorderColor = Color.FromHex("#54546d"),
		ScrollbarColor = Color.FromHex("#2a2a37"),
		ScrollbarHoveredColor = Color.FromHex("#363646"),
		ScrollbarActiveColor = Color.FromHex("#7e9cd8"),
		CheckMarkColor = Color.FromHex("#76946a"),
		SliderGrabColor = Color.FromHex("#7e9cd8"),
		SliderGrabActiveColor = Color.FromHex("#957fb8"),
		TabColor = Color.FromHex("#2a2a37"),
		TabHoveredColor = Color.FromHex("#363646"),
		TabActiveColor = Color.FromHex("#7e9cd8"),
		PlotLinesColor = Color.FromHex("#7fb4ca"),
		PlotHistogramColor = Color.FromHex("#ffa066")
	};

	/// <summary>
	/// Paper Color Dark theme - Dark variant with warm colors.
	/// </summary>
	public static ThemeDefinition PaperColorDark => new()
	{
		BackgroundColor = Color.FromHex("#1c1c1c"),
		TextColor = Color.FromHex("#d0d0d0"),
		AccentColor = Color.FromHex("#8fbcbb"),
		ButtonColor = Color.FromHex("#262626"),
		ButtonHoveredColor = Color.FromHex("#3a3a3a"),
		ButtonActiveColor = Color.FromHex("#8fbcbb"),
		FrameColor = Color.FromHex("#262626"),
		FrameHoveredColor = Color.FromHex("#3a3a3a"),
		FrameActiveColor = Color.FromHex("#8fbcbb"),
		HeaderColor = Color.FromHex("#262626"),
		HeaderHoveredColor = Color.FromHex("#3a3a3a"),
		HeaderActiveColor = Color.FromHex("#8fbcbb"),
		BorderColor = Color.FromHex("#4e4e4e"),
		ScrollbarColor = Color.FromHex("#262626"),
		ScrollbarHoveredColor = Color.FromHex("#3a3a3a"),
		ScrollbarActiveColor = Color.FromHex("#8fbcbb"),
		CheckMarkColor = Color.FromHex("#af87af"),
		SliderGrabColor = Color.FromHex("#8fbcbb"),
		SliderGrabActiveColor = Color.FromHex("#5f8787"),
		TabColor = Color.FromHex("#262626"),
		TabHoveredColor = Color.FromHex("#3a3a3a"),
		TabActiveColor = Color.FromHex("#8fbcbb"),
		PlotLinesColor = Color.FromHex("#ffaf87"),
		PlotHistogramColor = Color.FromHex("#5faf5f")
	};

	/// <summary>
	/// Nightfox theme - Dark theme with orange accents.
	/// </summary>
	public static ThemeDefinition Nightfox => new()
	{
		BackgroundColor = Color.FromHex("#192330"),
		TextColor = Color.FromHex("#cdcecf"),
		AccentColor = Color.FromHex("#719cd6"),
		ButtonColor = Color.FromHex("#29394f"),
		ButtonHoveredColor = Color.FromHex("#39506d"),
		ButtonActiveColor = Color.FromHex("#719cd6"),
		FrameColor = Color.FromHex("#29394f"),
		FrameHoveredColor = Color.FromHex("#39506d"),
		FrameActiveColor = Color.FromHex("#719cd6"),
		HeaderColor = Color.FromHex("#29394f"),
		HeaderHoveredColor = Color.FromHex("#39506d"),
		HeaderActiveColor = Color.FromHex("#719cd6"),
		BorderColor = Color.FromHex("#738091"),
		ScrollbarColor = Color.FromHex("#29394f"),
		ScrollbarHoveredColor = Color.FromHex("#39506d"),
		ScrollbarActiveColor = Color.FromHex("#719cd6"),
		CheckMarkColor = Color.FromHex("#81b29a"),
		SliderGrabColor = Color.FromHex("#719cd6"),
		SliderGrabActiveColor = Color.FromHex("#86abdc"),
		TabColor = Color.FromHex("#29394f"),
		TabHoveredColor = Color.FromHex("#39506d"),
		TabActiveColor = Color.FromHex("#719cd6"),
		PlotLinesColor = Color.FromHex("#f4a261"),
		PlotHistogramColor = Color.FromHex("#c94f6d")
	};

	/// <summary>
	/// Everforest Dark theme - Forest-inspired dark green theme.
	/// </summary>
	public static ThemeDefinition EverforestDark => new()
	{
		BackgroundColor = Color.FromHex("#2d353b"),
		TextColor = Color.FromHex("#d3c6aa"),
		AccentColor = Color.FromHex("#a7c080"),
		ButtonColor = Color.FromHex("#343f44"),
		ButtonHoveredColor = Color.FromHex("#3d484d"),
		ButtonActiveColor = Color.FromHex("#a7c080"),
		FrameColor = Color.FromHex("#343f44"),
		FrameHoveredColor = Color.FromHex("#3d484d"),
		FrameActiveColor = Color.FromHex("#a7c080"),
		HeaderColor = Color.FromHex("#343f44"),
		HeaderHoveredColor = Color.FromHex("#3d484d"),
		HeaderActiveColor = Color.FromHex("#a7c080"),
		BorderColor = Color.FromHex("#503946"),
		ScrollbarColor = Color.FromHex("#343f44"),
		ScrollbarHoveredColor = Color.FromHex("#3d484d"),
		ScrollbarActiveColor = Color.FromHex("#a7c080"),
		CheckMarkColor = Color.FromHex("#83c092"),
		SliderGrabColor = Color.FromHex("#a7c080"),
		SliderGrabActiveColor = Color.FromHex("#dbbc7f"),
		TabColor = Color.FromHex("#343f44"),
		TabHoveredColor = Color.FromHex("#3d484d"),
		TabActiveColor = Color.FromHex("#a7c080"),
		PlotLinesColor = Color.FromHex("#7fbbb3"),
		PlotHistogramColor = Color.FromHex("#d699b6")
	};

	/// <summary>
	/// VS Code Light theme - The popular light theme from Visual Studio Code.
	/// Uses authentic VS Code color palette with semantic naming.
	/// </summary>
	public static ThemeDefinition VSCodeLight => new()
	{
		BackgroundColor = ThemeSources.VSCode.Light.Background,
		TextColor = ThemeSources.VSCode.Light.Foreground,
		AccentColor = ThemeSources.VSCode.Light.AccentBlue,
		ButtonColor = ThemeSources.VSCode.Light.Button,
		ButtonHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		ButtonActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		FrameColor = ThemeSources.VSCode.Light.InputBackground,
		FrameHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		FrameActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		HeaderColor = ThemeSources.VSCode.Light.Button,
		HeaderHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		HeaderActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		BorderColor = ThemeSources.VSCode.Light.Border,
		ScrollbarColor = ThemeSources.VSCode.Light.Button,
		ScrollbarHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		ScrollbarActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		CheckMarkColor = ThemeSources.VSCode.Light.AccentGreen,
		SliderGrabColor = ThemeSources.VSCode.Light.AccentBlue,
		SliderGrabActiveColor = ThemeSources.VSCode.Light.AccentBlueBright,
		TabColor = ThemeSources.VSCode.Light.Button,
		TabHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		TabActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		PlotLinesColor = ThemeSources.VSCode.Light.AccentPurple,
		PlotHistogramColor = ThemeSources.VSCode.Light.AccentTeal
	};

	/// <summary>
	/// Gruvbox Light theme - Light variant of the retro groove color scheme.
	/// </summary>
	public static ThemeDefinition GruvboxLight => new()
	{
		BackgroundColor = Color.FromHex("#fbf1c7"),
		TextColor = Color.FromHex("#3c3836"),
		AccentColor = Color.FromHex("#af3a03"),
		ButtonColor = Color.FromHex("#f2e5bc"),
		ButtonHoveredColor = Color.FromHex("#ebdbb2"),
		ButtonActiveColor = Color.FromHex("#af3a03"),
		FrameColor = Color.FromHex("#f2e5bc"),
		FrameHoveredColor = Color.FromHex("#ebdbb2"),
		FrameActiveColor = Color.FromHex("#af3a03"),
		HeaderColor = Color.FromHex("#f2e5bc"),
		HeaderHoveredColor = Color.FromHex("#ebdbb2"),
		HeaderActiveColor = Color.FromHex("#af3a03"),
		BorderColor = Color.FromHex("#bdae93"),
		ScrollbarColor = Color.FromHex("#f2e5bc"),
		ScrollbarHoveredColor = Color.FromHex("#ebdbb2"),
		ScrollbarActiveColor = Color.FromHex("#af3a03"),
		CheckMarkColor = Color.FromHex("#79740e"),
		SliderGrabColor = Color.FromHex("#af3a03"),
		SliderGrabActiveColor = Color.FromHex("#d65d0e"),
		TabColor = Color.FromHex("#f2e5bc"),
		TabHoveredColor = Color.FromHex("#ebdbb2"),
		TabActiveColor = Color.FromHex("#af3a03"),
		PlotLinesColor = Color.FromHex("#076678"),
		PlotHistogramColor = Color.FromHex("#8f3f71")
	};

	/// <summary>
	/// Paper Color Light theme - Light variant with cool colors.
	/// </summary>
	public static ThemeDefinition PaperColorLight => new()
	{
		BackgroundColor = Color.FromHex("#eeeeee"),
		TextColor = Color.FromHex("#444444"),
		AccentColor = Color.FromHex("#005f87"),
		ButtonColor = Color.FromHex("#e4e4e4"),
		ButtonHoveredColor = Color.FromHex("#d0d0d0"),
		ButtonActiveColor = Color.FromHex("#005f87"),
		FrameColor = Color.FromHex("#e4e4e4"),
		FrameHoveredColor = Color.FromHex("#d0d0d0"),
		FrameActiveColor = Color.FromHex("#005f87"),
		HeaderColor = Color.FromHex("#e4e4e4"),
		HeaderHoveredColor = Color.FromHex("#d0d0d0"),
		HeaderActiveColor = Color.FromHex("#005f87"),
		BorderColor = Color.FromHex("#bcbcbc"),
		ScrollbarColor = Color.FromHex("#e4e4e4"),
		ScrollbarHoveredColor = Color.FromHex("#d0d0d0"),
		ScrollbarActiveColor = Color.FromHex("#005f87"),
		CheckMarkColor = Color.FromHex("#8700af"),
		SliderGrabColor = Color.FromHex("#005f87"),
		SliderGrabActiveColor = Color.FromHex("#0087af"),
		TabColor = Color.FromHex("#e4e4e4"),
		TabHoveredColor = Color.FromHex("#d0d0d0"),
		TabActiveColor = Color.FromHex("#005f87"),
		PlotLinesColor = Color.FromHex("#d70000"),
		PlotHistogramColor = Color.FromHex("#008700")
	};

	/// <summary>
	/// Everforest Light theme - Light variant of the forest-inspired theme.
	/// </summary>
	public static ThemeDefinition EverforestLight => new()
	{
		BackgroundColor = Color.FromHex("#fdf6e3"),
		TextColor = Color.FromHex("#5c6a72"),
		AccentColor = Color.FromHex("#8da101"),
		ButtonColor = Color.FromHex("#f4f0d9"),
		ButtonHoveredColor = Color.FromHex("#efebd4"),
		ButtonActiveColor = Color.FromHex("#8da101"),
		FrameColor = Color.FromHex("#f4f0d9"),
		FrameHoveredColor = Color.FromHex("#efebd4"),
		FrameActiveColor = Color.FromHex("#8da101"),
		HeaderColor = Color.FromHex("#f4f0d9"),
		HeaderHoveredColor = Color.FromHex("#efebd4"),
		HeaderActiveColor = Color.FromHex("#8da101"),
		BorderColor = Color.FromHex("#a6b0a0"),
		ScrollbarColor = Color.FromHex("#f4f0d9"),
		ScrollbarHoveredColor = Color.FromHex("#efebd4"),
		ScrollbarActiveColor = Color.FromHex("#8da101"),
		CheckMarkColor = Color.FromHex("#35a77c"),
		SliderGrabColor = Color.FromHex("#8da101"),
		SliderGrabActiveColor = Color.FromHex("#dfa000"),
		TabColor = Color.FromHex("#f4f0d9"),
		TabHoveredColor = Color.FromHex("#efebd4"),
		TabActiveColor = Color.FromHex("#8da101"),
		PlotLinesColor = Color.FromHex("#3a94c5"),
		PlotHistogramColor = Color.FromHex("#df69ba")
	};

	/// <summary>
	/// Tokyo Night Storm theme - Darker variant of Tokyo Night.
	/// </summary>
	public static ThemeDefinition TokyoNightStorm => new()
	{
		BackgroundColor = Color.FromHex("#24283b"),
		TextColor = Color.FromHex("#a9b1d6"),
		AccentColor = Color.FromHex("#7aa2f7"),
		ButtonColor = Color.FromHex("#32344a"),
		ButtonHoveredColor = Color.FromHex("#414868"),
		ButtonActiveColor = Color.FromHex("#7aa2f7"),
		FrameColor = Color.FromHex("#32344a"),
		FrameHoveredColor = Color.FromHex("#414868"),
		FrameActiveColor = Color.FromHex("#7aa2f7"),
		HeaderColor = Color.FromHex("#32344a"),
		HeaderHoveredColor = Color.FromHex("#414868"),
		HeaderActiveColor = Color.FromHex("#7aa2f7"),
		BorderColor = Color.FromHex("#565f89"),
		ScrollbarColor = Color.FromHex("#32344a"),
		ScrollbarHoveredColor = Color.FromHex("#414868"),
		ScrollbarActiveColor = Color.FromHex("#7aa2f7"),
		CheckMarkColor = Color.FromHex("#9ece6a"),
		SliderGrabColor = Color.FromHex("#7aa2f7"),
		SliderGrabActiveColor = Color.FromHex("#bb9af7"),
		TabColor = Color.FromHex("#32344a"),
		TabHoveredColor = Color.FromHex("#414868"),
		TabActiveColor = Color.FromHex("#7aa2f7"),
		PlotLinesColor = Color.FromHex("#7dcfff"),
		PlotHistogramColor = Color.FromHex("#f7768e")
	};

	/// <summary>
	/// Solarized Dark theme - Popular color scheme designed for readability.
	/// </summary>
	public static ThemeDefinition SolarizedDark => new()
	{
		BackgroundColor = Color.FromHex("#002b36"),
		TextColor = Color.FromHex("#839496"),
		AccentColor = Color.FromHex("#268bd2"),
		ButtonColor = Color.FromHex("#073642"),
		ButtonHoveredColor = Color.FromHex("#586e75"),
		ButtonActiveColor = Color.FromHex("#268bd2"),
		FrameColor = Color.FromHex("#073642"),
		FrameHoveredColor = Color.FromHex("#586e75"),
		FrameActiveColor = Color.FromHex("#268bd2"),
		HeaderColor = Color.FromHex("#073642"),
		HeaderHoveredColor = Color.FromHex("#586e75"),
		HeaderActiveColor = Color.FromHex("#268bd2"),
		BorderColor = Color.FromHex("#586e75"),
		ScrollbarColor = Color.FromHex("#073642"),
		ScrollbarHoveredColor = Color.FromHex("#586e75"),
		ScrollbarActiveColor = Color.FromHex("#268bd2"),
		CheckMarkColor = Color.FromHex("#859900"),
		SliderGrabColor = Color.FromHex("#268bd2"),
		SliderGrabActiveColor = Color.FromHex("#2aa198"),
		TabColor = Color.FromHex("#073642"),
		TabHoveredColor = Color.FromHex("#586e75"),
		TabActiveColor = Color.FromHex("#268bd2"),
		PlotLinesColor = Color.FromHex("#cb4b16"),
		PlotHistogramColor = Color.FromHex("#dc322f")
	};

	/// <summary>
	/// Solarized Light theme - Light variant of the popular Solarized color scheme.
	/// </summary>
	public static ThemeDefinition SolarizedLight => new()
	{
		BackgroundColor = Color.FromHex("#fdf6e3"),
		TextColor = Color.FromHex("#657b83"),
		AccentColor = Color.FromHex("#268bd2"),
		ButtonColor = Color.FromHex("#eee8d5"),
		ButtonHoveredColor = Color.FromHex("#93a1a1"),
		ButtonActiveColor = Color.FromHex("#268bd2"),
		FrameColor = Color.FromHex("#eee8d5"),
		FrameHoveredColor = Color.FromHex("#93a1a1"),
		FrameActiveColor = Color.FromHex("#268bd2"),
		HeaderColor = Color.FromHex("#eee8d5"),
		HeaderHoveredColor = Color.FromHex("#93a1a1"),
		HeaderActiveColor = Color.FromHex("#268bd2"),
		BorderColor = Color.FromHex("#93a1a1"),
		ScrollbarColor = Color.FromHex("#eee8d5"),
		ScrollbarHoveredColor = Color.FromHex("#93a1a1"),
		ScrollbarActiveColor = Color.FromHex("#268bd2"),
		CheckMarkColor = Color.FromHex("#859900"),
		SliderGrabColor = Color.FromHex("#268bd2"),
		SliderGrabActiveColor = Color.FromHex("#2aa198"),
		TabColor = Color.FromHex("#eee8d5"),
		TabHoveredColor = Color.FromHex("#93a1a1"),
		TabActiveColor = Color.FromHex("#268bd2"),
		PlotLinesColor = Color.FromHex("#cb4b16"),
		PlotHistogramColor = Color.FromHex("#dc322f")
	};

	/// <summary>
	/// Material Darker theme - Dark variant of Google's Material Design.
	/// </summary>
	public static ThemeDefinition MaterialDarker => new()
	{
		BackgroundColor = Color.FromHex("#212121"),
		TextColor = Color.FromHex("#eeffff"),
		AccentColor = Color.FromHex("#82aaff"),
		ButtonColor = Color.FromHex("#303030"),
		ButtonHoveredColor = Color.FromHex("#424242"),
		ButtonActiveColor = Color.FromHex("#82aaff"),
		FrameColor = Color.FromHex("#303030"),
		FrameHoveredColor = Color.FromHex("#424242"),
		FrameActiveColor = Color.FromHex("#82aaff"),
		HeaderColor = Color.FromHex("#303030"),
		HeaderHoveredColor = Color.FromHex("#424242"),
		HeaderActiveColor = Color.FromHex("#82aaff"),
		BorderColor = Color.FromHex("#424242"),
		ScrollbarColor = Color.FromHex("#303030"),
		ScrollbarHoveredColor = Color.FromHex("#424242"),
		ScrollbarActiveColor = Color.FromHex("#82aaff"),
		CheckMarkColor = Color.FromHex("#c3e88d"),
		SliderGrabColor = Color.FromHex("#82aaff"),
		SliderGrabActiveColor = Color.FromHex("#ffcb6b"),
		TabColor = Color.FromHex("#303030"),
		TabHoveredColor = Color.FromHex("#424242"),
		TabActiveColor = Color.FromHex("#82aaff"),
		PlotLinesColor = Color.FromHex("#f07178"),
		PlotHistogramColor = Color.FromHex("#c792ea")
	};

	/// <summary>
	/// Material Ocean theme - Ocean blue variant of Material Design.
	/// </summary>
	public static ThemeDefinition MaterialOcean => new()
	{
		BackgroundColor = Color.FromHex("#0f111a"),
		TextColor = Color.FromHex("#8f93a2"),
		AccentColor = Color.FromHex("#82aaff"),
		ButtonColor = Color.FromHex("#1e2030"),
		ButtonHoveredColor = Color.FromHex("#32374a"),
		ButtonActiveColor = Color.FromHex("#82aaff"),
		FrameColor = Color.FromHex("#1e2030"),
		FrameHoveredColor = Color.FromHex("#32374a"),
		FrameActiveColor = Color.FromHex("#82aaff"),
		HeaderColor = Color.FromHex("#1e2030"),
		HeaderHoveredColor = Color.FromHex("#32374a"),
		HeaderActiveColor = Color.FromHex("#82aaff"),
		BorderColor = Color.FromHex("#464b5d"),
		ScrollbarColor = Color.FromHex("#1e2030"),
		ScrollbarHoveredColor = Color.FromHex("#32374a"),
		ScrollbarActiveColor = Color.FromHex("#82aaff"),
		CheckMarkColor = Color.FromHex("#c3e88d"),
		SliderGrabColor = Color.FromHex("#82aaff"),
		SliderGrabActiveColor = Color.FromHex("#ffcb6b"),
		TabColor = Color.FromHex("#1e2030"),
		TabHoveredColor = Color.FromHex("#32374a"),
		TabActiveColor = Color.FromHex("#82aaff"),
		PlotLinesColor = Color.FromHex("#f07178"),
		PlotHistogramColor = Color.FromHex("#c792ea")
	};

	/// <summary>
	/// Material Palenight theme - Purple variant of Material Design.
	/// </summary>
	public static ThemeDefinition MaterialPalenight => new()
	{
		BackgroundColor = Color.FromHex("#292d3e"),
		TextColor = Color.FromHex("#a6accd"),
		AccentColor = Color.FromHex("#c792ea"),
		ButtonColor = Color.FromHex("#32374a"),
		ButtonHoveredColor = Color.FromHex("#444267"),
		ButtonActiveColor = Color.FromHex("#c792ea"),
		FrameColor = Color.FromHex("#32374a"),
		FrameHoveredColor = Color.FromHex("#444267"),
		FrameActiveColor = Color.FromHex("#c792ea"),
		HeaderColor = Color.FromHex("#32374a"),
		HeaderHoveredColor = Color.FromHex("#444267"),
		HeaderActiveColor = Color.FromHex("#c792ea"),
		BorderColor = Color.FromHex("#676e95"),
		ScrollbarColor = Color.FromHex("#32374a"),
		ScrollbarHoveredColor = Color.FromHex("#444267"),
		ScrollbarActiveColor = Color.FromHex("#c792ea"),
		CheckMarkColor = Color.FromHex("#c3e88d"),
		SliderGrabColor = Color.FromHex("#c792ea"),
		SliderGrabActiveColor = Color.FromHex("#ffcb6b"),
		TabColor = Color.FromHex("#32374a"),
		TabHoveredColor = Color.FromHex("#444267"),
		TabActiveColor = Color.FromHex("#c792ea"),
		PlotLinesColor = Color.FromHex("#82aaff"),
		PlotHistogramColor = Color.FromHex("#f07178")
	};

	/// <summary>
	/// Ayu Dark theme - Modern dark theme inspired by Rust.
	/// </summary>
	public static ThemeDefinition AyuDark => new()
	{
		BackgroundColor = Color.FromHex("#0d1117"),
		TextColor = Color.FromHex("#c9d1d9"),
		AccentColor = Color.FromHex("#ffb454"),
		ButtonColor = Color.FromHex("#21262d"),
		ButtonHoveredColor = Color.FromHex("#30363d"),
		ButtonActiveColor = Color.FromHex("#ffb454"),
		FrameColor = Color.FromHex("#21262d"),
		FrameHoveredColor = Color.FromHex("#30363d"),
		FrameActiveColor = Color.FromHex("#ffb454"),
		HeaderColor = Color.FromHex("#21262d"),
		HeaderHoveredColor = Color.FromHex("#30363d"),
		HeaderActiveColor = Color.FromHex("#ffb454"),
		BorderColor = Color.FromHex("#30363d"),
		ScrollbarColor = Color.FromHex("#21262d"),
		ScrollbarHoveredColor = Color.FromHex("#30363d"),
		ScrollbarActiveColor = Color.FromHex("#ffb454"),
		CheckMarkColor = Color.FromHex("#7fd962"),
		SliderGrabColor = Color.FromHex("#ffb454"),
		SliderGrabActiveColor = Color.FromHex("#f29718"),
		TabColor = Color.FromHex("#21262d"),
		TabHoveredColor = Color.FromHex("#30363d"),
		TabActiveColor = Color.FromHex("#ffb454"),
		PlotLinesColor = Color.FromHex("#39bae6"),
		PlotHistogramColor = Color.FromHex("#f07178")
	};

	/// <summary>
	/// Ayu Light theme - Light variant of the modern Ayu theme.
	/// </summary>
	public static ThemeDefinition AyuLight => new()
	{
		BackgroundColor = Color.FromHex("#fafafa"),
		TextColor = Color.FromHex("#5c6166"),
		AccentColor = Color.FromHex("#ff8f40"),
		ButtonColor = Color.FromHex("#f0f0f0"),
		ButtonHoveredColor = Color.FromHex("#e6e6e6"),
		ButtonActiveColor = Color.FromHex("#ff8f40"),
		FrameColor = Color.FromHex("#f0f0f0"),
		FrameHoveredColor = Color.FromHex("#e6e6e6"),
		FrameActiveColor = Color.FromHex("#ff8f40"),
		HeaderColor = Color.FromHex("#f0f0f0"),
		HeaderHoveredColor = Color.FromHex("#e6e6e6"),
		HeaderActiveColor = Color.FromHex("#ff8f40"),
		BorderColor = Color.FromHex("#d9d9d9"),
		ScrollbarColor = Color.FromHex("#f0f0f0"),
		ScrollbarHoveredColor = Color.FromHex("#e6e6e6"),
		ScrollbarActiveColor = Color.FromHex("#ff8f40"),
		CheckMarkColor = Color.FromHex("#86b300"),
		SliderGrabColor = Color.FromHex("#ff8f40"),
		SliderGrabActiveColor = Color.FromHex("#f29718"),
		TabColor = Color.FromHex("#f0f0f0"),
		TabHoveredColor = Color.FromHex("#e6e6e6"),
		TabActiveColor = Color.FromHex("#ff8f40"),
		PlotLinesColor = Color.FromHex("#41a6d9"),
		PlotHistogramColor = Color.FromHex("#f51818")
	};

	/// <summary>
	/// Ayu Mirage theme - Medium contrast variant of Ayu theme.
	/// </summary>
	public static ThemeDefinition AyuMirage => new()
	{
		BackgroundColor = Color.FromHex("#1f2430"),
		TextColor = Color.FromHex("#cbccc6"),
		AccentColor = Color.FromHex("#ffcc66"),
		ButtonColor = Color.FromHex("#242936"),
		ButtonHoveredColor = Color.FromHex("#2d3142"),
		ButtonActiveColor = Color.FromHex("#ffcc66"),
		FrameColor = Color.FromHex("#242936"),
		FrameHoveredColor = Color.FromHex("#2d3142"),
		FrameActiveColor = Color.FromHex("#ffcc66"),
		HeaderColor = Color.FromHex("#242936"),
		HeaderHoveredColor = Color.FromHex("#2d3142"),
		HeaderActiveColor = Color.FromHex("#ffcc66"),
		BorderColor = Color.FromHex("#707a8c"),
		ScrollbarColor = Color.FromHex("#242936"),
		ScrollbarHoveredColor = Color.FromHex("#2d3142"),
		ScrollbarActiveColor = Color.FromHex("#ffcc66"),
		CheckMarkColor = Color.FromHex("#bae67e"),
		SliderGrabColor = Color.FromHex("#ffcc66"),
		SliderGrabActiveColor = Color.FromHex("#ffd580"),
		TabColor = Color.FromHex("#242936"),
		TabHoveredColor = Color.FromHex("#2d3142"),
		TabActiveColor = Color.FromHex("#ffcc66"),
		PlotLinesColor = Color.FromHex("#73d0ff"),
		PlotHistogramColor = Color.FromHex("#ff8a65")
	};

	/// <summary>
	/// One Dark Pro theme - Enhanced version of the popular One Dark theme.
	/// </summary>
	public static ThemeDefinition OneDarkPro => new()
	{
		BackgroundColor = Color.FromHex("#1e2127"),
		TextColor = Color.FromHex("#abb2bf"),
		AccentColor = Color.FromHex("#61afef"),
		ButtonColor = Color.FromHex("#282c34"),
		ButtonHoveredColor = Color.FromHex("#3e4451"),
		ButtonActiveColor = Color.FromHex("#61afef"),
		FrameColor = Color.FromHex("#282c34"),
		FrameHoveredColor = Color.FromHex("#3e4451"),
		FrameActiveColor = Color.FromHex("#61afef"),
		HeaderColor = Color.FromHex("#282c34"),
		HeaderHoveredColor = Color.FromHex("#3e4451"),
		HeaderActiveColor = Color.FromHex("#61afef"),
		BorderColor = Color.FromHex("#4b5263"),
		ScrollbarColor = Color.FromHex("#282c34"),
		ScrollbarHoveredColor = Color.FromHex("#3e4451"),
		ScrollbarActiveColor = Color.FromHex("#61afef"),
		CheckMarkColor = Color.FromHex("#98c379"),
		SliderGrabColor = Color.FromHex("#61afef"),
		SliderGrabActiveColor = Color.FromHex("#73c5f0"),
		TabColor = Color.FromHex("#282c34"),
		TabHoveredColor = Color.FromHex("#3e4451"),
		TabActiveColor = Color.FromHex("#61afef"),
		PlotLinesColor = Color.FromHex("#e06c75"),
		PlotHistogramColor = Color.FromHex("#d19a66")
	};

	/// <summary>
	/// Synthwave '84 theme - Retro neon-inspired theme.
	/// </summary>
	public static ThemeDefinition Synthwave84 => new()
	{
		BackgroundColor = Color.FromHex("#2a2139"),
		TextColor = Color.FromHex("#f92aad"),
		AccentColor = Color.FromHex("#ff7edb"),
		ButtonColor = Color.FromHex("#463465"),
		ButtonHoveredColor = Color.FromHex("#684c7a"),
		ButtonActiveColor = Color.FromHex("#ff7edb"),
		FrameColor = Color.FromHex("#463465"),
		FrameHoveredColor = Color.FromHex("#684c7a"),
		FrameActiveColor = Color.FromHex("#ff7edb"),
		HeaderColor = Color.FromHex("#463465"),
		HeaderHoveredColor = Color.FromHex("#684c7a"),
		HeaderActiveColor = Color.FromHex("#ff7edb"),
		BorderColor = Color.FromHex("#848bbd"),
		ScrollbarColor = Color.FromHex("#463465"),
		ScrollbarHoveredColor = Color.FromHex("#684c7a"),
		ScrollbarActiveColor = Color.FromHex("#ff7edb"),
		CheckMarkColor = Color.FromHex("#72f1b8"),
		SliderGrabColor = Color.FromHex("#ff7edb"),
		SliderGrabActiveColor = Color.FromHex("#fede5d"),
		TabColor = Color.FromHex("#463465"),
		TabHoveredColor = Color.FromHex("#684c7a"),
		TabActiveColor = Color.FromHex("#ff7edb"),
		PlotLinesColor = Color.FromHex("#36f9f6"),
		PlotHistogramColor = Color.FromHex("#fe4450")
	};

	/// <summary>
	/// High Contrast Dark theme - Dark theme optimized for accessibility.
	/// </summary>
	public static ThemeDefinition HighContrastDark => new()
	{
		BackgroundColor = Color.FromHex("#000000"),
		TextColor = Color.FromHex("#ffffff"),
		AccentColor = Color.FromHex("#00ffff"),
		ButtonColor = Color.FromHex("#1a1a1a"),
		ButtonHoveredColor = Color.FromHex("#333333"),
		ButtonActiveColor = Color.FromHex("#00ffff"),
		FrameColor = Color.FromHex("#1a1a1a"),
		FrameHoveredColor = Color.FromHex("#333333"),
		FrameActiveColor = Color.FromHex("#00ffff"),
		HeaderColor = Color.FromHex("#1a1a1a"),
		HeaderHoveredColor = Color.FromHex("#333333"),
		HeaderActiveColor = Color.FromHex("#00ffff"),
		BorderColor = Color.FromHex("#ffffff"),
		ScrollbarColor = Color.FromHex("#1a1a1a"),
		ScrollbarHoveredColor = Color.FromHex("#333333"),
		ScrollbarActiveColor = Color.FromHex("#00ffff"),
		CheckMarkColor = Color.FromHex("#00ff00"),
		SliderGrabColor = Color.FromHex("#00ffff"),
		SliderGrabActiveColor = Color.FromHex("#ffff00"),
		TabColor = Color.FromHex("#1a1a1a"),
		TabHoveredColor = Color.FromHex("#333333"),
		TabActiveColor = Color.FromHex("#00ffff"),
		PlotLinesColor = Color.FromHex("#ff00ff"),
		PlotHistogramColor = Color.FromHex("#ff0000")
	};

	/// <summary>
	/// High Contrast Light theme - Light theme optimized for accessibility.
	/// </summary>
	public static ThemeDefinition HighContrastLight => new()
	{
		BackgroundColor = Color.FromHex("#ffffff"),
		TextColor = Color.FromHex("#000000"),
		AccentColor = Color.FromHex("#0000ff"),
		ButtonColor = Color.FromHex("#e6e6e6"),
		ButtonHoveredColor = Color.FromHex("#cccccc"),
		ButtonActiveColor = Color.FromHex("#0000ff"),
		FrameColor = Color.FromHex("#e6e6e6"),
		FrameHoveredColor = Color.FromHex("#cccccc"),
		FrameActiveColor = Color.FromHex("#0000ff"),
		HeaderColor = Color.FromHex("#e6e6e6"),
		HeaderHoveredColor = Color.FromHex("#cccccc"),
		HeaderActiveColor = Color.FromHex("#0000ff"),
		BorderColor = Color.FromHex("#000000"),
		ScrollbarColor = Color.FromHex("#e6e6e6"),
		ScrollbarHoveredColor = Color.FromHex("#cccccc"),
		ScrollbarActiveColor = Color.FromHex("#0000ff"),
		CheckMarkColor = Color.FromHex("#008000"),
		SliderGrabColor = Color.FromHex("#0000ff"),
		SliderGrabActiveColor = Color.FromHex("#8000ff"),
		TabColor = Color.FromHex("#e6e6e6"),
		TabHoveredColor = Color.FromHex("#cccccc"),
		TabActiveColor = Color.FromHex("#0000ff"),
		PlotLinesColor = Color.FromHex("#800080"),
		PlotHistogramColor = Color.FromHex("#ff0000")
	};

	#endregion

	#region Theme Application

	/// <summary>
	/// Applies a simple color-based theme to ImGui.
	/// </summary>
	/// <param name="baseColor">The base color to generate the theme from.</param>
	public static void Apply(ImColor baseColor)
	{
		ImColor normalColor = GetNormalColor(baseColor);
		ImColor accentColor = GetAccentColor(baseColor);
		ImColor accentHoveredColor = GetAccentHoveredColor(baseColor);
		ImColor headerColor = GetHeaderColor(baseColor);
		ImColor hoveredColor = GetHoveredColor(baseColor);
		ImColor activeColor = GetActiveColor(baseColor);
		ImColor backgroundColor = GetBackgroundColor(baseColor);
		ImColor dragColor = GetDragColor(baseColor);
		ImColor textColor = GetTextColor(backgroundColor);
		ImColor borderColor = textColor.MultiplyLuminance(BorderLuminanceMult);

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = textColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = baseColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = textColor.MultiplySaturation(0.5f).Value;
		colors[(int)ImGuiCol.Button] = normalColor.Value;
		colors[(int)ImGuiCol.ButtonActive] = activeColor.Value;
		colors[(int)ImGuiCol.ButtonHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.CheckMark] = textColor.Value;
		colors[(int)ImGuiCol.Header] = headerColor.Value;
		colors[(int)ImGuiCol.HeaderActive] = activeColor.Value;
		colors[(int)ImGuiCol.HeaderHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.SliderGrab] = dragColor.Value;
		colors[(int)ImGuiCol.SliderGrabActive] = baseColor.Value;
		colors[(int)ImGuiCol.Tab] = normalColor.Value;
		colors[(int)ImGuiCol.TabSelected] = activeColor.Value;
		colors[(int)ImGuiCol.TabHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.TitleBg] = normalColor.Value;
		colors[(int)ImGuiCol.TitleBgActive] = activeColor.Value;
		colors[(int)ImGuiCol.TitleBgCollapsed] = normalColor.Value;
		colors[(int)ImGuiCol.Border] = borderColor.Value;
		colors[(int)ImGuiCol.FrameBg] = normalColor.Value;
		colors[(int)ImGuiCol.FrameBgActive] = activeColor.Value;
		colors[(int)ImGuiCol.FrameBgHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.NavCursor] = activeColor.Value;
		colors[(int)ImGuiCol.ResizeGrip] = normalColor.Value;
		colors[(int)ImGuiCol.ResizeGripActive] = activeColor.Value;
		colors[(int)ImGuiCol.ResizeGripHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.PlotLines] = accentColor.Value;
		colors[(int)ImGuiCol.PlotLinesHovered] = accentHoveredColor.Value;
		colors[(int)ImGuiCol.PlotHistogram] = accentColor.Value;
		colors[(int)ImGuiCol.PlotHistogramHovered] = accentHoveredColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrab] = normalColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.ScrollbarGrabActive] = activeColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.ScrollbarGrabHovered] = hoveredColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.WindowBg] = backgroundColor.Value;
		colors[(int)ImGuiCol.ChildBg] = backgroundColor.Value;
		colors[(int)ImGuiCol.PopupBg] = backgroundColor.Value;
	}

	/// <summary>
	/// Applies a complete theme definition to ImGui.
	/// </summary>
	/// <param name="themeDefinition">The complete theme definition to apply.</param>
	public static void Apply(ThemeDefinition themeDefinition)
	{
		ArgumentNullException.ThrowIfNull(themeDefinition, nameof(themeDefinition));

		// Use the theme's original text color to maintain authenticity
		ImColor textColor = themeDefinition.TextColor;

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = textColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = textColor.MultiplySaturation(0.5f).Value;
		colors[(int)ImGuiCol.Button] = themeDefinition.ButtonColor.Value;
		colors[(int)ImGuiCol.ButtonActive] = themeDefinition.ButtonActiveColor.Value;
		colors[(int)ImGuiCol.ButtonHovered] = themeDefinition.ButtonHoveredColor.Value;
		colors[(int)ImGuiCol.CheckMark] = themeDefinition.CheckMarkColor.Value;
		colors[(int)ImGuiCol.Header] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.HeaderActive] = themeDefinition.HeaderActiveColor.Value;
		colors[(int)ImGuiCol.HeaderHovered] = themeDefinition.HeaderHoveredColor.Value;
		colors[(int)ImGuiCol.SliderGrab] = themeDefinition.SliderGrabColor.Value;
		colors[(int)ImGuiCol.SliderGrabActive] = themeDefinition.SliderGrabActiveColor.Value;
		colors[(int)ImGuiCol.Tab] = themeDefinition.TabColor.Value;
		colors[(int)ImGuiCol.TabSelected] = themeDefinition.TabActiveColor.Value;
		colors[(int)ImGuiCol.TabHovered] = themeDefinition.TabHoveredColor.Value;
		colors[(int)ImGuiCol.TitleBg] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.TitleBgActive] = themeDefinition.HeaderActiveColor.Value;
		colors[(int)ImGuiCol.TitleBgCollapsed] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.Border] = themeDefinition.BorderColor.Value;
		colors[(int)ImGuiCol.FrameBg] = themeDefinition.FrameColor.Value;
		colors[(int)ImGuiCol.FrameBgActive] = themeDefinition.FrameActiveColor.Value;
		colors[(int)ImGuiCol.FrameBgHovered] = themeDefinition.FrameHoveredColor.Value;
		colors[(int)ImGuiCol.NavCursor] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.ResizeGrip] = themeDefinition.BorderColor.Value;
		colors[(int)ImGuiCol.ResizeGripActive] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.ResizeGripHovered] = themeDefinition.AccentColor.MultiplySaturation(0.8f).Value;
		colors[(int)ImGuiCol.PlotLines] = themeDefinition.PlotLinesColor.Value;
		colors[(int)ImGuiCol.PlotLinesHovered] = themeDefinition.PlotLinesColor.MultiplyLuminance(1.2f).Value;
		colors[(int)ImGuiCol.PlotHistogram] = themeDefinition.PlotHistogramColor.Value;
		colors[(int)ImGuiCol.PlotHistogramHovered] = themeDefinition.PlotHistogramColor.MultiplyLuminance(1.2f).Value;
		colors[(int)ImGuiCol.ScrollbarGrab] = themeDefinition.ScrollbarColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrabActive] = themeDefinition.ScrollbarActiveColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrabHovered] = themeDefinition.ScrollbarHoveredColor.Value;
		colors[(int)ImGuiCol.WindowBg] = themeDefinition.BackgroundColor.Value;
		colors[(int)ImGuiCol.ChildBg] = themeDefinition.BackgroundColor.Value;
		colors[(int)ImGuiCol.PopupBg] = themeDefinition.BackgroundColor.Value;
	}

	#endregion

	#region Theme Discovery

	/// <summary>
	/// Gets all available palette colors for theming.
	/// </summary>
	public static IReadOnlyList<ThemeInfo> AvailablePaletteColors =>
	[
		new() { Name = "Primary", Description = "Default blue theme", Category = "Basic", Color = Color.Palette.Semantic.Primary },
		new() { Name = "Red", Description = "Vibrant red theme", Category = "Basic", Color = Color.Palette.Basic.Red },
		new() { Name = "Green", Description = "Fresh green theme", Category = "Basic", Color = Color.Palette.Basic.Green },
		new() { Name = "Blue", Description = "Classic blue theme", Category = "Basic", Color = Color.Palette.Basic.Blue },
		new() { Name = "Cyan", Description = "Cool cyan theme", Category = "Basic", Color = Color.Palette.Basic.Cyan },
		new() { Name = "Magenta", Description = "Bold magenta theme", Category = "Basic", Color = Color.Palette.Basic.Magenta },
		new() { Name = "Yellow", Description = "Bright yellow theme", Category = "Basic", Color = Color.Palette.Basic.Yellow },
		new() { Name = "Orange", Description = "Warm orange theme", Category = "Basic", Color = Color.Palette.Basic.Orange },
		new() { Name = "Pink", Description = "Sweet pink theme", Category = "Basic", Color = Color.Palette.Basic.Pink },
		new() { Name = "Purple", Description = "Royal purple theme", Category = "Basic", Color = Color.Palette.Basic.Purple },
		new() { Name = "Dracula", Description = "A dark theme with purple accents", Category = "Dark", Color = Color.Palette.Themes.Dracula },
	];

	/// <summary>
	/// Gets all available complete theme definitions.
	/// </summary>
	public static IReadOnlyList<ThemeDefinitionInfo> AvailableThemeDefinitions =>
	[
		// Light themes
		new() { Name = "Catppuccin Latte", Description = "Light and warm pastel theme", Category = "Light", Definition = CatppuccinLatte },
		new() { Name = "VS Code Light", Description = "The popular light theme from Visual Studio Code", Category = "Light", Definition = VSCodeLight },
		new() { Name = "Gruvbox Light", Description = "Light variant of the retro groove color scheme", Category = "Light", Definition = GruvboxLight },
		new() { Name = "Paper Color Light", Description = "Light variant with cool colors", Category = "Light", Definition = PaperColorLight },
		new() { Name = "Everforest Light", Description = "Light variant of the forest-inspired theme", Category = "Light", Definition = EverforestLight },
		new() { Name = "Solarized Light", Description = "Light variant of the popular Solarized color scheme", Category = "Light", Definition = SolarizedLight },
		new() { Name = "Ayu Light", Description = "Light variant of the modern Ayu theme", Category = "Light", Definition = AyuLight },
		new() { Name = "High Contrast Light", Description = "Light theme optimized for accessibility", Category = "Light", Definition = HighContrastLight },

		// Medium/Mirage themes
		new() { Name = "Ayu Mirage", Description = "Medium contrast variant of Ayu theme", Category = "Medium", Definition = AyuMirage },

		// Dark themes
		new() { Name = "Catppuccin Frappe", Description = "Dark theme with purple accents", Category = "Dark", Definition = CatppuccinFrappe },
		new() { Name = "Catppuccin Macchiato", Description = "Dark theme with soft purple tones", Category = "Dark", Definition = CatppuccinMacchiato },
		new() { Name = "Catppuccin Mocha", Description = "Dark theme with blue accents", Category = "Dark", Definition = CatppuccinMocha },
		new() { Name = "Nord", Description = "A dark theme with cool blue tones inspired by the arctic", Category = "Dark", Definition = Nord },
		new() { Name = "Monokai", Description = "Classic dark theme with bright accents", Category = "Dark", Definition = Monokai },
		new() { Name = "Tokyo Night", Description = "Dark blue theme inspired by Tokyo's night skyline", Category = "Dark", Definition = TokyoNight },
		new() { Name = "Tokyo Night Storm", Description = "Darker variant of Tokyo Night", Category = "Dark", Definition = TokyoNightStorm },
		new() { Name = "Gruvbox Dark", Description = "Retro groove color scheme with warm tones", Category = "Dark", Definition = GruvboxDark },
		new() { Name = "Nightfly", Description = "Dark theme with blue and purple accents", Category = "Dark", Definition = Nightfly },
		new() { Name = "Kanagawa", Description = "Japanese-inspired earthy theme", Category = "Dark", Definition = Kanagawa },
		new() { Name = "Paper Color Dark", Description = "Dark variant with warm colors", Category = "Dark", Definition = PaperColorDark },
		new() { Name = "Dracula", Description = "A dark theme with purple accents and vampire-inspired colors", Category = "Dark", Definition = Dracula },
		new() { Name = "OneDark", Description = "Popular dark theme with balanced colors", Category = "Dark", Definition = OneDark },
		new() { Name = "One Dark Pro", Description = "Enhanced version of the popular One Dark theme", Category = "Dark", Definition = OneDarkPro },
		new() { Name = "Nightfox", Description = "Dark theme with orange accents", Category = "Dark", Definition = Nightfox },
		new() { Name = "Everforest Dark", Description = "Forest-inspired dark green theme", Category = "Dark", Definition = EverforestDark },
		new() { Name = "VS Code Dark", Description = "The popular dark theme from Visual Studio Code", Category = "Dark", Definition = VSCodeDark },
		new() { Name = "Solarized Dark", Description = "Popular color scheme designed for readability", Category = "Dark", Definition = SolarizedDark },
		new() { Name = "Material Darker", Description = "Dark variant of Google's Material Design", Category = "Dark", Definition = MaterialDarker },
		new() { Name = "Material Ocean", Description = "Ocean blue variant of Material Design", Category = "Dark", Definition = MaterialOcean },
		new() { Name = "Material Palenight", Description = "Purple variant of Material Design", Category = "Dark", Definition = MaterialPalenight },
		new() { Name = "Ayu Dark", Description = "Modern dark theme inspired by Rust", Category = "Dark", Definition = AyuDark },
		new() { Name = "Synthwave '84", Description = "Retro neon-inspired theme", Category = "Dark", Definition = Synthwave84 },
		new() { Name = "High Contrast Dark", Description = "Dark theme optimized for accessibility", Category = "Dark", Definition = HighContrastDark },
	];

	#endregion

	#region Scoped Theme Colors

	/// <summary>
	/// Creates a scoped theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance.</returns>
	public static ScopedThemeColor FromColor(ImColor color) => new(color, enabled: true);

	/// <summary>
	/// Creates a scoped disabled theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance with disabled state.</returns>
	public static ScopedThemeColor DisabledFromColor(ImColor color) => new(color, enabled: false);

	#endregion
}
