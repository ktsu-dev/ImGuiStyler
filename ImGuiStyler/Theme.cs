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
		PlotLinesColor = ThemeSources.Gruvbox.FadedBlue,
		PlotHistogramColor = ThemeSources.Gruvbox.FadedAqua
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
		BackgroundColor = ThemeSources.CatppuccinMacchiato.Base.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		TextColor = ThemeSources.CatppuccinMacchiato.Text,
		AccentColor = ThemeSources.CatppuccinMacchiato.Mauve,
		ButtonColor = ThemeSources.CatppuccinMacchiato.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		ButtonHoveredColor = ThemeSources.CatppuccinMacchiato.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		ButtonActiveColor = ThemeSources.CatppuccinMacchiato.Mauve,
		FrameColor = ThemeSources.CatppuccinMacchiato.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		FrameHoveredColor = ThemeSources.CatppuccinMacchiato.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		FrameActiveColor = ThemeSources.CatppuccinMacchiato.Mauve,
		HeaderColor = ThemeSources.CatppuccinMacchiato.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		HeaderHoveredColor = ThemeSources.CatppuccinMacchiato.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		HeaderActiveColor = ThemeSources.CatppuccinMacchiato.Mauve,
		BorderColor = ThemeSources.CatppuccinMacchiato.Surface1,
		ScrollbarColor = ThemeSources.CatppuccinMacchiato.Surface0,
		ScrollbarHoveredColor = ThemeSources.CatppuccinMacchiato.Surface1,
		ScrollbarActiveColor = ThemeSources.CatppuccinMacchiato.Mauve,
		CheckMarkColor = ThemeSources.CatppuccinMacchiato.Mauve,
		SliderGrabColor = ThemeSources.CatppuccinMacchiato.Mauve,
		SliderGrabActiveColor = ThemeSources.CatppuccinMacchiato.Mauve,
		TabColor = ThemeSources.CatppuccinMacchiato.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		TabHoveredColor = ThemeSources.CatppuccinMacchiato.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		TabActiveColor = ThemeSources.CatppuccinMacchiato.Mauve.AdjustForSufficientContrast(ThemeSources.CatppuccinMacchiato.Text),
		PlotLinesColor = ThemeSources.CatppuccinMacchiato.Blue,
		PlotHistogramColor = ThemeSources.CatppuccinMacchiato.Green
	};

	/// <summary>
	/// Catppuccin Mocha theme - Dark theme with blue accents.
	/// Uses authentic Catppuccin color palette with semantic naming and proper color hierarchy.
	/// </summary>
	public static ThemeDefinition CatppuccinMocha => new()
	{
		BackgroundColor = ThemeSources.CatppuccinMocha.Base.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		TextColor = ThemeSources.CatppuccinMocha.Text,
		AccentColor = ThemeSources.CatppuccinMocha.Blue,
		ButtonColor = ThemeSources.CatppuccinMocha.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		ButtonHoveredColor = ThemeSources.CatppuccinMocha.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		ButtonActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		FrameColor = ThemeSources.CatppuccinMocha.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		FrameHoveredColor = ThemeSources.CatppuccinMocha.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		FrameActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		HeaderColor = ThemeSources.CatppuccinMocha.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		HeaderHoveredColor = ThemeSources.CatppuccinMocha.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		HeaderActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		BorderColor = ThemeSources.CatppuccinMocha.Surface1,
		ScrollbarColor = ThemeSources.CatppuccinMocha.Surface0,
		ScrollbarHoveredColor = ThemeSources.CatppuccinMocha.Surface1,
		ScrollbarActiveColor = ThemeSources.CatppuccinMocha.Surface0,
		CheckMarkColor = ThemeSources.CatppuccinMocha.Blue,
		SliderGrabColor = ThemeSources.CatppuccinMocha.Blue,
		SliderGrabActiveColor = ThemeSources.CatppuccinMocha.Blue,
		TabColor = ThemeSources.CatppuccinMocha.Surface0.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		TabHoveredColor = ThemeSources.CatppuccinMocha.Surface1.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
		TabActiveColor = ThemeSources.CatppuccinMocha.Blue.AdjustForSufficientContrast(ThemeSources.CatppuccinMocha.Text),
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
		BackgroundColor = ThemeSources.TokyoNight.Bg.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TextColor = ThemeSources.TokyoNight.Fg,
		AccentColor = ThemeSources.TokyoNight.Blue,
		ButtonColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		ButtonHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		ButtonActiveColor = ThemeSources.TokyoNight.Blue,
		FrameColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		FrameHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		FrameActiveColor = ThemeSources.TokyoNight.Blue,
		HeaderColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		HeaderHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		HeaderActiveColor = ThemeSources.TokyoNight.Blue,
		BorderColor = ThemeSources.TokyoNight.Comment,
		ScrollbarColor = ThemeSources.TokyoNight.BgHighlight,
		ScrollbarHoveredColor = ThemeSources.TokyoNight.Dark3,
		ScrollbarActiveColor = ThemeSources.TokyoNight.Blue,
		CheckMarkColor = ThemeSources.TokyoNight.Green,
		SliderGrabColor = ThemeSources.TokyoNight.Blue,
		SliderGrabActiveColor = ThemeSources.TokyoNight.Purple,
		TabColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TabHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TabActiveColor = ThemeSources.TokyoNight.Blue.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		PlotLinesColor = ThemeSources.TokyoNight.Cyan,
		PlotHistogramColor = ThemeSources.TokyoNight.Red
	};

	/// <summary>
	/// Nightfly theme - Dark theme with blue and purple accents.
	/// </summary>
	public static ThemeDefinition Nightfly => new()
	{
		BackgroundColor = ThemeSources.Nightfly.Background.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		TextColor = ThemeSources.Nightfly.Foreground,
		AccentColor = ThemeSources.Nightfly.Blue,
		ButtonColor = ThemeSources.Nightfly.Selection.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		ButtonHoveredColor = ThemeSources.Nightfly.Surface.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		ButtonActiveColor = ThemeSources.Nightfly.Blue,
		FrameColor = ThemeSources.Nightfly.Selection.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		FrameHoveredColor = ThemeSources.Nightfly.Surface.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		FrameActiveColor = ThemeSources.Nightfly.Blue,
		HeaderColor = ThemeSources.Nightfly.Selection.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		HeaderHoveredColor = ThemeSources.Nightfly.Surface.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		HeaderActiveColor = ThemeSources.Nightfly.Blue,
		BorderColor = ThemeSources.Nightfly.Border,
		ScrollbarColor = ThemeSources.Nightfly.Selection,
		ScrollbarHoveredColor = ThemeSources.Nightfly.Surface,
		ScrollbarActiveColor = ThemeSources.Nightfly.Blue,
		CheckMarkColor = ThemeSources.Nightfly.Cyan,
		SliderGrabColor = ThemeSources.Nightfly.Blue,
		SliderGrabActiveColor = ThemeSources.Nightfly.Purple,
		TabColor = ThemeSources.Nightfly.Selection.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		TabHoveredColor = ThemeSources.Nightfly.Surface.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		TabActiveColor = ThemeSources.Nightfly.Blue.AdjustForSufficientContrast(ThemeSources.Nightfly.Foreground),
		PlotLinesColor = ThemeSources.Nightfly.Green,
		PlotHistogramColor = ThemeSources.Nightfly.Red
	};

	/// <summary>
	/// Kanagawa theme - Japanese-inspired earthy theme.
	/// </summary>
	public static ThemeDefinition Kanagawa => new()
	{
		BackgroundColor = ThemeSources.Kanagawa.Background.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		TextColor = ThemeSources.Kanagawa.Foreground,
		AccentColor = ThemeSources.Kanagawa.CrystalBlue,
		ButtonColor = ThemeSources.Kanagawa.Selection.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		ButtonHoveredColor = ThemeSources.Kanagawa.Surface.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		ButtonActiveColor = ThemeSources.Kanagawa.CrystalBlue,
		FrameColor = ThemeSources.Kanagawa.Selection.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		FrameHoveredColor = ThemeSources.Kanagawa.Surface.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		FrameActiveColor = ThemeSources.Kanagawa.CrystalBlue,
		HeaderColor = ThemeSources.Kanagawa.Selection.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		HeaderHoveredColor = ThemeSources.Kanagawa.Surface.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		HeaderActiveColor = ThemeSources.Kanagawa.CrystalBlue,
		BorderColor = ThemeSources.Kanagawa.Border,
		ScrollbarColor = ThemeSources.Kanagawa.Selection,
		ScrollbarHoveredColor = ThemeSources.Kanagawa.Surface,
		ScrollbarActiveColor = ThemeSources.Kanagawa.CrystalBlue,
		CheckMarkColor = ThemeSources.Kanagawa.AutumnGreen,
		SliderGrabColor = ThemeSources.Kanagawa.CrystalBlue,
		SliderGrabActiveColor = ThemeSources.Kanagawa.SpringViolet,
		TabColor = ThemeSources.Kanagawa.Selection.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		TabHoveredColor = ThemeSources.Kanagawa.Surface.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		TabActiveColor = ThemeSources.Kanagawa.CrystalBlue.AdjustForSufficientContrast(ThemeSources.Kanagawa.Foreground),
		PlotLinesColor = ThemeSources.Kanagawa.WaveAqua,
		PlotHistogramColor = ThemeSources.Kanagawa.SurimihanaOrange
	};

	/// <summary>
	/// Paper Color Dark theme - Dark variant with warm colors.
	/// </summary>
	public static ThemeDefinition PaperColorDark => new()
	{
		BackgroundColor = ThemeSources.PaperColor.Dark.Background.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		TextColor = ThemeSources.PaperColor.Dark.Foreground,
		AccentColor = ThemeSources.PaperColor.Dark.Cyan,
		ButtonColor = ThemeSources.PaperColor.Dark.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		ButtonHoveredColor = ThemeSources.PaperColor.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		ButtonActiveColor = ThemeSources.PaperColor.Dark.Cyan,
		FrameColor = ThemeSources.PaperColor.Dark.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		FrameHoveredColor = ThemeSources.PaperColor.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		FrameActiveColor = ThemeSources.PaperColor.Dark.Cyan,
		HeaderColor = ThemeSources.PaperColor.Dark.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		HeaderHoveredColor = ThemeSources.PaperColor.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		HeaderActiveColor = ThemeSources.PaperColor.Dark.Cyan,
		BorderColor = ThemeSources.PaperColor.Dark.Border,
		ScrollbarColor = ThemeSources.PaperColor.Dark.Surface,
		ScrollbarHoveredColor = ThemeSources.PaperColor.Dark.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.PaperColor.Dark.Cyan,
		CheckMarkColor = ThemeSources.PaperColor.Dark.Magenta,
		SliderGrabColor = ThemeSources.PaperColor.Dark.Cyan,
		SliderGrabActiveColor = ThemeSources.PaperColor.Dark.Blue,
		TabColor = ThemeSources.PaperColor.Dark.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		TabHoveredColor = ThemeSources.PaperColor.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		TabActiveColor = ThemeSources.PaperColor.Dark.Cyan.AdjustForSufficientContrast(ThemeSources.PaperColor.Dark.Foreground),
		PlotLinesColor = ThemeSources.PaperColor.Dark.Orange,
		PlotHistogramColor = ThemeSources.PaperColor.Dark.Green
	};

	/// <summary>
	/// Nightfox theme - Dark theme with orange accents.
	/// </summary>
	public static ThemeDefinition Nightfox => new()
	{
		BackgroundColor = ThemeSources.Nightfox.Background.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		TextColor = ThemeSources.Nightfox.Foreground,
		AccentColor = ThemeSources.Nightfox.Blue,
		ButtonColor = ThemeSources.Nightfox.Selection.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		ButtonHoveredColor = ThemeSources.Nightfox.Surface.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		ButtonActiveColor = ThemeSources.Nightfox.Blue,
		FrameColor = ThemeSources.Nightfox.Selection.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		FrameHoveredColor = ThemeSources.Nightfox.Surface.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		FrameActiveColor = ThemeSources.Nightfox.Blue,
		HeaderColor = ThemeSources.Nightfox.Selection.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		HeaderHoveredColor = ThemeSources.Nightfox.Surface.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		HeaderActiveColor = ThemeSources.Nightfox.Blue,
		BorderColor = ThemeSources.Nightfox.Border,
		ScrollbarColor = ThemeSources.Nightfox.Selection,
		ScrollbarHoveredColor = ThemeSources.Nightfox.Surface,
		ScrollbarActiveColor = ThemeSources.Nightfox.Blue,
		CheckMarkColor = ThemeSources.Nightfox.Green,
		SliderGrabColor = ThemeSources.Nightfox.Blue,
		SliderGrabActiveColor = ThemeSources.Nightfox.BlueDark,
		TabColor = ThemeSources.Nightfox.Selection.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		TabHoveredColor = ThemeSources.Nightfox.Surface.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		TabActiveColor = ThemeSources.Nightfox.Blue.AdjustForSufficientContrast(ThemeSources.Nightfox.Foreground),
		PlotLinesColor = ThemeSources.Nightfox.Orange,
		PlotHistogramColor = ThemeSources.Nightfox.Red
	};

	/// <summary>
	/// Everforest Dark theme - Forest-inspired dark green theme.
	/// </summary>
	public static ThemeDefinition EverforestDark => new()
	{
		BackgroundColor = ThemeSources.Everforest.Dark.Bg0.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		TextColor = ThemeSources.Everforest.Dark.Fg,
		AccentColor = ThemeSources.Everforest.Dark.Purple,
		ButtonColor = ThemeSources.Everforest.Dark.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		ButtonHoveredColor = ThemeSources.Everforest.Dark.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		ButtonActiveColor = ThemeSources.Everforest.Dark.Purple,
		FrameColor = ThemeSources.Everforest.Dark.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		FrameHoveredColor = ThemeSources.Everforest.Dark.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		FrameActiveColor = ThemeSources.Everforest.Dark.Purple,
		HeaderColor = ThemeSources.Everforest.Dark.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		HeaderHoveredColor = ThemeSources.Everforest.Dark.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		HeaderActiveColor = ThemeSources.Everforest.Dark.Purple,
		BorderColor = ThemeSources.Everforest.Dark.Bg3,
		ScrollbarColor = ThemeSources.Everforest.Dark.Bg2,
		ScrollbarHoveredColor = ThemeSources.Everforest.Dark.Bg3,
		ScrollbarActiveColor = ThemeSources.Everforest.Dark.Purple,
		CheckMarkColor = ThemeSources.Everforest.Dark.Green,
		SliderGrabColor = ThemeSources.Everforest.Dark.Purple,
		SliderGrabActiveColor = ThemeSources.Everforest.Dark.Yellow,
		TabColor = ThemeSources.Everforest.Dark.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		TabHoveredColor = ThemeSources.Everforest.Dark.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		TabActiveColor = ThemeSources.Everforest.Dark.Purple.AdjustForSufficientContrast(ThemeSources.Everforest.Dark.Fg),
		PlotLinesColor = ThemeSources.Everforest.Dark.Aqua,
		PlotHistogramColor = ThemeSources.Everforest.Dark.Red
	};

	/// <summary>
	/// VS Code Light theme - The popular light theme from Visual Studio Code.
	/// Uses authentic VS Code color palette with semantic naming.
	/// </summary>
	public static ThemeDefinition VSCodeLight => new()
	{
		BackgroundColor = ThemeSources.VSCode.Light.Background.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		TextColor = ThemeSources.VSCode.Light.Foreground,
		AccentColor = ThemeSources.VSCode.Light.AccentBlue,
		ButtonColor = ThemeSources.VSCode.Light.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		ButtonHoveredColor = ThemeSources.VSCode.Light.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		ButtonActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		FrameColor = ThemeSources.VSCode.Light.InputBackground.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		FrameHoveredColor = ThemeSources.VSCode.Light.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		FrameActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		HeaderColor = ThemeSources.VSCode.Light.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		HeaderHoveredColor = ThemeSources.VSCode.Light.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		HeaderActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		BorderColor = ThemeSources.VSCode.Light.Border,
		ScrollbarColor = ThemeSources.VSCode.Light.Button,
		ScrollbarHoveredColor = ThemeSources.VSCode.Light.ButtonHover,
		ScrollbarActiveColor = ThemeSources.VSCode.Light.AccentBlue,
		CheckMarkColor = ThemeSources.VSCode.Light.AccentGreen,
		SliderGrabColor = ThemeSources.VSCode.Light.AccentBlue,
		SliderGrabActiveColor = ThemeSources.VSCode.Light.AccentBlueBright,
		TabColor = ThemeSources.VSCode.Light.Button.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		TabHoveredColor = ThemeSources.VSCode.Light.ButtonHover.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		TabActiveColor = ThemeSources.VSCode.Light.AccentBlue.AdjustForSufficientContrast(ThemeSources.VSCode.Light.Foreground),
		PlotLinesColor = ThemeSources.VSCode.Light.AccentPurple,
		PlotHistogramColor = ThemeSources.VSCode.Light.AccentTeal
	};

	/// <summary>
	/// Gruvbox Light theme - Light variant of the retro groove color scheme.
	/// </summary>
	public static ThemeDefinition GruvboxLight => new()
	{
		BackgroundColor = ThemeSources.Gruvbox.Light0.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		TextColor = ThemeSources.Gruvbox.Dark1,
		AccentColor = ThemeSources.Gruvbox.BrightOrange,
		ButtonColor = ThemeSources.Gruvbox.Light1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		ButtonHoveredColor = ThemeSources.Gruvbox.Light2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		ButtonActiveColor = ThemeSources.Gruvbox.BrightOrange,
		FrameColor = ThemeSources.Gruvbox.Light1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		FrameHoveredColor = ThemeSources.Gruvbox.Light2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		FrameActiveColor = ThemeSources.Gruvbox.BrightOrange,
		HeaderColor = ThemeSources.Gruvbox.Light1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		HeaderHoveredColor = ThemeSources.Gruvbox.Light2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		HeaderActiveColor = ThemeSources.Gruvbox.BrightOrange,
		BorderColor = ThemeSources.Gruvbox.Light2,
		ScrollbarColor = ThemeSources.Gruvbox.Light1,
		ScrollbarHoveredColor = ThemeSources.Gruvbox.Light2,
		ScrollbarActiveColor = ThemeSources.Gruvbox.BrightOrange,
		CheckMarkColor = ThemeSources.Gruvbox.BrightGreen,
		SliderGrabColor = ThemeSources.Gruvbox.BrightOrange,
		SliderGrabActiveColor = ThemeSources.Gruvbox.BrightYellow,
		TabColor = ThemeSources.Gruvbox.Light1.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		TabHoveredColor = ThemeSources.Gruvbox.Light2.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		TabActiveColor = ThemeSources.Gruvbox.BrightOrange.AdjustForSufficientContrast(ThemeSources.Gruvbox.Dark1),
		PlotLinesColor = ThemeSources.Gruvbox.FadedBlue,
		PlotHistogramColor = ThemeSources.Gruvbox.FadedAqua
	};

	/// <summary>
	/// Paper Color Light theme - Light variant with cool colors.
	/// </summary>
	public static ThemeDefinition PaperColorLight => new()
	{
		BackgroundColor = ThemeSources.PaperColor.Light.Background.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		TextColor = ThemeSources.PaperColor.Light.Foreground,
		AccentColor = ThemeSources.PaperColor.Light.Cyan,
		ButtonColor = ThemeSources.PaperColor.Light.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		ButtonHoveredColor = ThemeSources.PaperColor.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		ButtonActiveColor = ThemeSources.PaperColor.Light.Cyan,
		FrameColor = ThemeSources.PaperColor.Light.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		FrameHoveredColor = ThemeSources.PaperColor.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		FrameActiveColor = ThemeSources.PaperColor.Light.Cyan,
		HeaderColor = ThemeSources.PaperColor.Light.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		HeaderHoveredColor = ThemeSources.PaperColor.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		HeaderActiveColor = ThemeSources.PaperColor.Light.Cyan,
		BorderColor = ThemeSources.PaperColor.Light.Border,
		ScrollbarColor = ThemeSources.PaperColor.Light.Surface,
		ScrollbarHoveredColor = ThemeSources.PaperColor.Light.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.PaperColor.Light.Cyan,
		CheckMarkColor = ThemeSources.PaperColor.Light.Magenta,
		SliderGrabColor = ThemeSources.PaperColor.Light.Cyan,
		SliderGrabActiveColor = ThemeSources.PaperColor.Light.Blue,
		TabColor = ThemeSources.PaperColor.Light.Surface.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		TabHoveredColor = ThemeSources.PaperColor.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		TabActiveColor = ThemeSources.PaperColor.Light.Cyan.AdjustForSufficientContrast(ThemeSources.PaperColor.Light.Foreground),
		PlotLinesColor = ThemeSources.PaperColor.Light.Orange,
		PlotHistogramColor = ThemeSources.PaperColor.Light.Green
	};

	/// <summary>
	/// Everforest Light theme - Light variant of the forest-inspired theme.
	/// </summary>
	public static ThemeDefinition EverforestLight => new()
	{
		BackgroundColor = ThemeSources.Everforest.Light.Bg0.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		TextColor = ThemeSources.Everforest.Light.Fg,
		AccentColor = ThemeSources.Everforest.Light.Purple,
		ButtonColor = ThemeSources.Everforest.Light.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		ButtonHoveredColor = ThemeSources.Everforest.Light.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		ButtonActiveColor = ThemeSources.Everforest.Light.Purple,
		FrameColor = ThemeSources.Everforest.Light.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		FrameHoveredColor = ThemeSources.Everforest.Light.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		FrameActiveColor = ThemeSources.Everforest.Light.Purple,
		HeaderColor = ThemeSources.Everforest.Light.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		HeaderHoveredColor = ThemeSources.Everforest.Light.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		HeaderActiveColor = ThemeSources.Everforest.Light.Purple,
		BorderColor = ThemeSources.Everforest.Light.Bg3,
		ScrollbarColor = ThemeSources.Everforest.Light.Bg2,
		ScrollbarHoveredColor = ThemeSources.Everforest.Light.Bg3,
		ScrollbarActiveColor = ThemeSources.Everforest.Light.Purple,
		CheckMarkColor = ThemeSources.Everforest.Light.Green,
		SliderGrabColor = ThemeSources.Everforest.Light.Purple,
		SliderGrabActiveColor = ThemeSources.Everforest.Light.Yellow,
		TabColor = ThemeSources.Everforest.Light.Bg1.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		TabHoveredColor = ThemeSources.Everforest.Light.Bg2.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		TabActiveColor = ThemeSources.Everforest.Light.Purple.AdjustForSufficientContrast(ThemeSources.Everforest.Light.Fg),
		PlotLinesColor = ThemeSources.Everforest.Light.Aqua,
		PlotHistogramColor = ThemeSources.Everforest.Light.Red
	};

	/// <summary>
	/// Tokyo Night Storm theme - Darker variant of Tokyo Night.
	/// </summary>
	public static ThemeDefinition TokyoNightStorm => new()
	{
		BackgroundColor = ThemeSources.TokyoNight.BgDark.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TextColor = ThemeSources.TokyoNight.Fg,
		AccentColor = ThemeSources.TokyoNight.Blue,
		ButtonColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		ButtonHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		ButtonActiveColor = ThemeSources.TokyoNight.Blue,
		FrameColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		FrameHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		FrameActiveColor = ThemeSources.TokyoNight.Blue,
		HeaderColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		HeaderHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		HeaderActiveColor = ThemeSources.TokyoNight.Blue,
		BorderColor = ThemeSources.TokyoNight.FgGutter,
		ScrollbarColor = ThemeSources.TokyoNight.BgHighlight,
		ScrollbarHoveredColor = ThemeSources.TokyoNight.Dark3,
		ScrollbarActiveColor = ThemeSources.TokyoNight.Blue,
		CheckMarkColor = ThemeSources.TokyoNight.Green,
		SliderGrabColor = ThemeSources.TokyoNight.Blue,
		SliderGrabActiveColor = ThemeSources.TokyoNight.Blue0,
		TabColor = ThemeSources.TokyoNight.BgHighlight.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TabHoveredColor = ThemeSources.TokyoNight.Dark3.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		TabActiveColor = ThemeSources.TokyoNight.Blue.AdjustForSufficientContrast(ThemeSources.TokyoNight.Fg),
		PlotLinesColor = ThemeSources.TokyoNight.Cyan,
		PlotHistogramColor = ThemeSources.TokyoNight.Purple
	};

	/// <summary>
	/// Solarized Dark theme - Popular color scheme designed for readability.
	/// </summary>
	public static ThemeDefinition SolarizedDark => new()
	{
		BackgroundColor = ThemeSources.Solarized.Base03.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		TextColor = ThemeSources.Solarized.Base0,
		AccentColor = ThemeSources.Solarized.Blue,
		ButtonColor = ThemeSources.Solarized.Base02.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		ButtonHoveredColor = ThemeSources.Solarized.Base01.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		ButtonActiveColor = ThemeSources.Solarized.Blue,
		FrameColor = ThemeSources.Solarized.Base02.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		FrameHoveredColor = ThemeSources.Solarized.Base01.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		FrameActiveColor = ThemeSources.Solarized.Blue,
		HeaderColor = ThemeSources.Solarized.Base02.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		HeaderHoveredColor = ThemeSources.Solarized.Base01.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		HeaderActiveColor = ThemeSources.Solarized.Blue,
		BorderColor = ThemeSources.Solarized.Base01,
		ScrollbarColor = ThemeSources.Solarized.Base02,
		ScrollbarHoveredColor = ThemeSources.Solarized.Base01,
		ScrollbarActiveColor = ThemeSources.Solarized.Blue,
		CheckMarkColor = ThemeSources.Solarized.Green,
		SliderGrabColor = ThemeSources.Solarized.Blue,
		SliderGrabActiveColor = ThemeSources.Solarized.Cyan,
		TabColor = ThemeSources.Solarized.Base02.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		TabHoveredColor = ThemeSources.Solarized.Base01.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		TabActiveColor = ThemeSources.Solarized.Blue.AdjustForSufficientContrast(ThemeSources.Solarized.Base0),
		PlotLinesColor = ThemeSources.Solarized.Orange,
		PlotHistogramColor = ThemeSources.Solarized.Red
	};

	/// <summary>
	/// Solarized Light theme - Light variant of the popular Solarized color scheme.
	/// </summary>
	public static ThemeDefinition SolarizedLight => new()
	{
		BackgroundColor = ThemeSources.Solarized.Base3.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		TextColor = ThemeSources.Solarized.Base00,
		AccentColor = ThemeSources.Solarized.Blue,
		ButtonColor = ThemeSources.Solarized.Base2.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		ButtonHoveredColor = ThemeSources.Solarized.Base1.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		ButtonActiveColor = ThemeSources.Solarized.Blue,
		FrameColor = ThemeSources.Solarized.Base2.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		FrameHoveredColor = ThemeSources.Solarized.Base1.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		FrameActiveColor = ThemeSources.Solarized.Blue,
		HeaderColor = ThemeSources.Solarized.Base2.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		HeaderHoveredColor = ThemeSources.Solarized.Base1.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		HeaderActiveColor = ThemeSources.Solarized.Blue,
		BorderColor = ThemeSources.Solarized.Base1,
		ScrollbarColor = ThemeSources.Solarized.Base2,
		ScrollbarHoveredColor = ThemeSources.Solarized.Base1,
		ScrollbarActiveColor = ThemeSources.Solarized.Blue,
		CheckMarkColor = ThemeSources.Solarized.Green,
		SliderGrabColor = ThemeSources.Solarized.Blue,
		SliderGrabActiveColor = ThemeSources.Solarized.Cyan,
		TabColor = ThemeSources.Solarized.Base2.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		TabHoveredColor = ThemeSources.Solarized.Base1.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		TabActiveColor = ThemeSources.Solarized.Blue.AdjustForSufficientContrast(ThemeSources.Solarized.Base00),
		PlotLinesColor = ThemeSources.Solarized.Orange,
		PlotHistogramColor = ThemeSources.Solarized.Red
	};

	/// <summary>
	/// Material Darker theme - Dark variant of Google's Material Design.
	/// </summary>
	public static ThemeDefinition MaterialDarker => new()
	{
		BackgroundColor = ThemeSources.Material.Darker.Background.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		TextColor = ThemeSources.Material.Darker.OnBackground,
		AccentColor = ThemeSources.Material.Darker.Primary,
		ButtonColor = ThemeSources.Material.Darker.Surface.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		ButtonHoveredColor = ThemeSources.Material.Darker.Card.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		ButtonActiveColor = ThemeSources.Material.Darker.Primary,
		FrameColor = ThemeSources.Material.Darker.Surface.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		FrameHoveredColor = ThemeSources.Material.Darker.Card.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		FrameActiveColor = ThemeSources.Material.Darker.Primary,
		HeaderColor = ThemeSources.Material.Darker.Surface.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		HeaderHoveredColor = ThemeSources.Material.Darker.Card.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		HeaderActiveColor = ThemeSources.Material.Darker.Primary,
		BorderColor = ThemeSources.Material.Darker.Surface,
		ScrollbarColor = ThemeSources.Material.Darker.Surface,
		ScrollbarHoveredColor = ThemeSources.Material.Darker.Card,
		ScrollbarActiveColor = ThemeSources.Material.Darker.Primary,
		CheckMarkColor = ThemeSources.Material.Darker.Success,
		SliderGrabColor = ThemeSources.Material.Darker.Primary,
		SliderGrabActiveColor = ThemeSources.Material.Darker.Secondary,
		TabColor = ThemeSources.Material.Darker.Surface.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		TabHoveredColor = ThemeSources.Material.Darker.Card.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		TabActiveColor = ThemeSources.Material.Darker.Primary.AdjustForSufficientContrast(ThemeSources.Material.Darker.OnBackground),
		PlotLinesColor = ThemeSources.Material.Darker.Info,
		PlotHistogramColor = ThemeSources.Material.Darker.Accent
	};

	/// <summary>
	/// Material Ocean theme - Ocean blue variant of Material Design.
	/// </summary>
	public static ThemeDefinition MaterialOcean => new()
	{
		BackgroundColor = ThemeSources.Material.Ocean.Background.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		TextColor = ThemeSources.Material.Ocean.OnBackground,
		AccentColor = ThemeSources.Material.Ocean.Primary,
		ButtonColor = ThemeSources.Material.Ocean.Surface.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		ButtonHoveredColor = ThemeSources.Material.Ocean.Card.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		ButtonActiveColor = ThemeSources.Material.Ocean.Primary,
		FrameColor = ThemeSources.Material.Ocean.Surface.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		FrameHoveredColor = ThemeSources.Material.Ocean.Card.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		FrameActiveColor = ThemeSources.Material.Ocean.Primary,
		HeaderColor = ThemeSources.Material.Ocean.Surface.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		HeaderHoveredColor = ThemeSources.Material.Ocean.Card.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		HeaderActiveColor = ThemeSources.Material.Ocean.Primary,
		BorderColor = ThemeSources.Material.Ocean.Surface,
		ScrollbarColor = ThemeSources.Material.Ocean.Surface,
		ScrollbarHoveredColor = ThemeSources.Material.Ocean.Card,
		ScrollbarActiveColor = ThemeSources.Material.Ocean.Primary,
		CheckMarkColor = ThemeSources.Material.Ocean.Success,
		SliderGrabColor = ThemeSources.Material.Ocean.Primary,
		SliderGrabActiveColor = ThemeSources.Material.Ocean.Secondary,
		TabColor = ThemeSources.Material.Ocean.Surface.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		TabHoveredColor = ThemeSources.Material.Ocean.Card.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		TabActiveColor = ThemeSources.Material.Ocean.Primary.AdjustForSufficientContrast(ThemeSources.Material.Ocean.OnBackground),
		PlotLinesColor = ThemeSources.Material.Ocean.Info,
		PlotHistogramColor = ThemeSources.Material.Ocean.Accent
	};

	/// <summary>
	/// Material Palenight theme - Purple variant of Material Design.
	/// </summary>
	public static ThemeDefinition MaterialPalenight => new()
	{
		BackgroundColor = ThemeSources.Material.Palenight.Background.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		TextColor = ThemeSources.Material.Palenight.OnBackground,
		AccentColor = ThemeSources.Material.Palenight.Primary,
		ButtonColor = ThemeSources.Material.Palenight.Surface.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		ButtonHoveredColor = ThemeSources.Material.Palenight.Card.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		ButtonActiveColor = ThemeSources.Material.Palenight.Primary,
		FrameColor = ThemeSources.Material.Palenight.Surface.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		FrameHoveredColor = ThemeSources.Material.Palenight.Card.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		FrameActiveColor = ThemeSources.Material.Palenight.Primary,
		HeaderColor = ThemeSources.Material.Palenight.Surface.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		HeaderHoveredColor = ThemeSources.Material.Palenight.Card.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		HeaderActiveColor = ThemeSources.Material.Palenight.Primary,
		BorderColor = ThemeSources.Material.Palenight.Surface,
		ScrollbarColor = ThemeSources.Material.Palenight.Surface,
		ScrollbarHoveredColor = ThemeSources.Material.Palenight.Card,
		ScrollbarActiveColor = ThemeSources.Material.Palenight.Primary,
		CheckMarkColor = ThemeSources.Material.Palenight.Success,
		SliderGrabColor = ThemeSources.Material.Palenight.Primary,
		SliderGrabActiveColor = ThemeSources.Material.Palenight.Secondary,
		TabColor = ThemeSources.Material.Palenight.Surface.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		TabHoveredColor = ThemeSources.Material.Palenight.Card.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		TabActiveColor = ThemeSources.Material.Palenight.Primary.AdjustForSufficientContrast(ThemeSources.Material.Palenight.OnBackground),
		PlotLinesColor = ThemeSources.Material.Palenight.Info,
		PlotHistogramColor = ThemeSources.Material.Palenight.Accent
	};

	/// <summary>
	/// Ayu Dark theme - Modern dark theme inspired by Rust.
	/// </summary>
	public static ThemeDefinition AyuDark => new()
	{
		BackgroundColor = ThemeSources.Ayu.Dark.Background.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		TextColor = ThemeSources.Ayu.Dark.Foreground,
		AccentColor = ThemeSources.Ayu.Dark.Cyan,
		ButtonColor = ThemeSources.Ayu.Dark.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		ButtonHoveredColor = ThemeSources.Ayu.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		ButtonActiveColor = ThemeSources.Ayu.Dark.Cyan,
		FrameColor = ThemeSources.Ayu.Dark.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		FrameHoveredColor = ThemeSources.Ayu.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		FrameActiveColor = ThemeSources.Ayu.Dark.Cyan,
		HeaderColor = ThemeSources.Ayu.Dark.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		HeaderHoveredColor = ThemeSources.Ayu.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		HeaderActiveColor = ThemeSources.Ayu.Dark.Cyan,
		BorderColor = ThemeSources.Ayu.Dark.Border,
		ScrollbarColor = ThemeSources.Ayu.Dark.Surface,
		ScrollbarHoveredColor = ThemeSources.Ayu.Dark.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.Ayu.Dark.Cyan,
		CheckMarkColor = ThemeSources.Ayu.Dark.Green,
		SliderGrabColor = ThemeSources.Ayu.Dark.Cyan,
		SliderGrabActiveColor = ThemeSources.Ayu.Dark.Yellow,
		TabColor = ThemeSources.Ayu.Dark.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		TabHoveredColor = ThemeSources.Ayu.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		TabActiveColor = ThemeSources.Ayu.Dark.Cyan.AdjustForSufficientContrast(ThemeSources.Ayu.Dark.Foreground),
		PlotLinesColor = ThemeSources.Ayu.Dark.Aqua,
		PlotHistogramColor = ThemeSources.Ayu.Dark.Pink
	};

	/// <summary>
	/// Ayu Light theme - Light variant of the modern Ayu theme.
	/// </summary>
	public static ThemeDefinition AyuLight => new()
	{
		BackgroundColor = ThemeSources.Ayu.Light.Background.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		TextColor = ThemeSources.Ayu.Light.Foreground,
		AccentColor = ThemeSources.Ayu.Light.Cyan,
		ButtonColor = ThemeSources.Ayu.Light.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		ButtonHoveredColor = ThemeSources.Ayu.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		ButtonActiveColor = ThemeSources.Ayu.Light.Cyan,
		FrameColor = ThemeSources.Ayu.Light.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		FrameHoveredColor = ThemeSources.Ayu.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		FrameActiveColor = ThemeSources.Ayu.Light.Cyan,
		HeaderColor = ThemeSources.Ayu.Light.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		HeaderHoveredColor = ThemeSources.Ayu.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		HeaderActiveColor = ThemeSources.Ayu.Light.Cyan,
		BorderColor = ThemeSources.Ayu.Light.Border,
		ScrollbarColor = ThemeSources.Ayu.Light.Surface,
		ScrollbarHoveredColor = ThemeSources.Ayu.Light.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.Ayu.Light.Cyan,
		CheckMarkColor = ThemeSources.Ayu.Light.Green,
		SliderGrabColor = ThemeSources.Ayu.Light.Cyan,
		SliderGrabActiveColor = ThemeSources.Ayu.Light.Yellow,
		TabColor = ThemeSources.Ayu.Light.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		TabHoveredColor = ThemeSources.Ayu.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		TabActiveColor = ThemeSources.Ayu.Light.Cyan.AdjustForSufficientContrast(ThemeSources.Ayu.Light.Foreground),
		PlotLinesColor = ThemeSources.Ayu.Light.Aqua,
		PlotHistogramColor = ThemeSources.Ayu.Light.Pink
	};

	/// <summary>
	/// Ayu Mirage theme - Medium contrast variant of Ayu theme.
	/// </summary>
	public static ThemeDefinition AyuMirage => new()
	{
		BackgroundColor = ThemeSources.Ayu.Mirage.Background.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		TextColor = ThemeSources.Ayu.Mirage.Foreground,
		AccentColor = ThemeSources.Ayu.Mirage.Cyan,
		ButtonColor = ThemeSources.Ayu.Mirage.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		ButtonHoveredColor = ThemeSources.Ayu.Mirage.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		ButtonActiveColor = ThemeSources.Ayu.Mirage.Cyan,
		FrameColor = ThemeSources.Ayu.Mirage.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		FrameHoveredColor = ThemeSources.Ayu.Mirage.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		FrameActiveColor = ThemeSources.Ayu.Mirage.Cyan,
		HeaderColor = ThemeSources.Ayu.Mirage.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		HeaderHoveredColor = ThemeSources.Ayu.Mirage.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		HeaderActiveColor = ThemeSources.Ayu.Mirage.Cyan,
		BorderColor = ThemeSources.Ayu.Mirage.Border,
		ScrollbarColor = ThemeSources.Ayu.Mirage.Surface,
		ScrollbarHoveredColor = ThemeSources.Ayu.Mirage.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.Ayu.Mirage.Cyan,
		CheckMarkColor = ThemeSources.Ayu.Mirage.Green,
		SliderGrabColor = ThemeSources.Ayu.Mirage.Cyan,
		SliderGrabActiveColor = ThemeSources.Ayu.Mirage.Yellow,
		TabColor = ThemeSources.Ayu.Mirage.Surface.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		TabHoveredColor = ThemeSources.Ayu.Mirage.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		TabActiveColor = ThemeSources.Ayu.Mirage.Cyan.AdjustForSufficientContrast(ThemeSources.Ayu.Mirage.Foreground),
		PlotLinesColor = ThemeSources.Ayu.Mirage.Aqua,
		PlotHistogramColor = ThemeSources.Ayu.Mirage.Pink
	};

	/// <summary>
	/// One Dark Pro theme - Enhanced version of the popular One Dark theme.
	/// </summary>
	public static ThemeDefinition OneDarkPro => new()
	{
		BackgroundColor = ThemeSources.OneDarkPro.Background.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		TextColor = ThemeSources.OneDarkPro.Foreground,
		AccentColor = ThemeSources.OneDarkPro.Blue,
		ButtonColor = ThemeSources.OneDarkPro.Selection.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		ButtonHoveredColor = ThemeSources.OneDarkPro.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		ButtonActiveColor = ThemeSources.OneDarkPro.Blue,
		FrameColor = ThemeSources.OneDarkPro.Selection.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		FrameHoveredColor = ThemeSources.OneDarkPro.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		FrameActiveColor = ThemeSources.OneDarkPro.Blue,
		HeaderColor = ThemeSources.OneDarkPro.Selection.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		HeaderHoveredColor = ThemeSources.OneDarkPro.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		HeaderActiveColor = ThemeSources.OneDarkPro.Blue,
		BorderColor = ThemeSources.OneDarkPro.BackgroundLight,
		ScrollbarColor = ThemeSources.OneDarkPro.Selection,
		ScrollbarHoveredColor = ThemeSources.OneDarkPro.BackgroundLight,
		ScrollbarActiveColor = ThemeSources.OneDarkPro.Blue,
		CheckMarkColor = ThemeSources.OneDarkPro.Green,
		SliderGrabColor = ThemeSources.OneDarkPro.Blue,
		SliderGrabActiveColor = ThemeSources.OneDarkPro.Cyan,
		TabColor = ThemeSources.OneDarkPro.Selection.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		TabHoveredColor = ThemeSources.OneDarkPro.BackgroundLight.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		TabActiveColor = ThemeSources.OneDarkPro.Blue.AdjustForSufficientContrast(ThemeSources.OneDarkPro.Foreground),
		PlotLinesColor = ThemeSources.OneDarkPro.Purple,
		PlotHistogramColor = ThemeSources.OneDarkPro.Red
	};

	/// <summary>
	/// Synthwave '84 theme - Retro neon-inspired theme.
	/// </summary>
	public static ThemeDefinition Synthwave84 => new()
	{
		BackgroundColor = ThemeSources.Synthwave84.Background.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		TextColor = ThemeSources.Synthwave84.Text,
		AccentColor = ThemeSources.Synthwave84.NeonPink,
		ButtonColor = ThemeSources.Synthwave84.Surface.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		ButtonHoveredColor = ThemeSources.Synthwave84.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		ButtonActiveColor = ThemeSources.Synthwave84.NeonPink,
		FrameColor = ThemeSources.Synthwave84.Surface.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		FrameHoveredColor = ThemeSources.Synthwave84.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		FrameActiveColor = ThemeSources.Synthwave84.NeonPink,
		HeaderColor = ThemeSources.Synthwave84.Surface.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		HeaderHoveredColor = ThemeSources.Synthwave84.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		HeaderActiveColor = ThemeSources.Synthwave84.NeonPink,
		BorderColor = ThemeSources.Synthwave84.TextSecondary,
		ScrollbarColor = ThemeSources.Synthwave84.Surface,
		ScrollbarHoveredColor = ThemeSources.Synthwave84.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.Synthwave84.NeonPink,
		CheckMarkColor = ThemeSources.Synthwave84.NeonGreen,
		SliderGrabColor = ThemeSources.Synthwave84.NeonPink,
		SliderGrabActiveColor = ThemeSources.Synthwave84.NeonYellow,
		TabColor = ThemeSources.Synthwave84.Surface.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		TabHoveredColor = ThemeSources.Synthwave84.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		TabActiveColor = ThemeSources.Synthwave84.NeonPink.AdjustForSufficientContrast(ThemeSources.Synthwave84.Text),
		PlotLinesColor = ThemeSources.Synthwave84.NeonCyan,
		PlotHistogramColor = ThemeSources.Synthwave84.NeonRed
	};

	/// <summary>
	/// High Contrast Dark theme - Dark theme optimized for accessibility.
	/// </summary>
	public static ThemeDefinition HighContrastDark => new()
	{
		BackgroundColor = ThemeSources.HighContrast.Dark.Background.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		TextColor = ThemeSources.HighContrast.Dark.Foreground,
		AccentColor = ThemeSources.HighContrast.Dark.Primary,
		ButtonColor = ThemeSources.HighContrast.Dark.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		ButtonHoveredColor = ThemeSources.HighContrast.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		ButtonActiveColor = ThemeSources.HighContrast.Dark.Primary,
		FrameColor = ThemeSources.HighContrast.Dark.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		FrameHoveredColor = ThemeSources.HighContrast.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		FrameActiveColor = ThemeSources.HighContrast.Dark.Primary,
		HeaderColor = ThemeSources.HighContrast.Dark.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		HeaderHoveredColor = ThemeSources.HighContrast.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		HeaderActiveColor = ThemeSources.HighContrast.Dark.Primary,
		BorderColor = ThemeSources.HighContrast.Dark.Border,
		ScrollbarColor = ThemeSources.HighContrast.Dark.Surface,
		ScrollbarHoveredColor = ThemeSources.HighContrast.Dark.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.HighContrast.Dark.Primary,
		CheckMarkColor = ThemeSources.HighContrast.Dark.Icon,
		SliderGrabColor = ThemeSources.HighContrast.Dark.Primary,
		SliderGrabActiveColor = ThemeSources.HighContrast.Dark.Secondary,
		TabColor = ThemeSources.HighContrast.Dark.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		TabHoveredColor = ThemeSources.HighContrast.Dark.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		TabActiveColor = ThemeSources.HighContrast.Dark.Primary.AdjustForSufficientContrast(ThemeSources.HighContrast.Dark.Foreground),
		PlotLinesColor = ThemeSources.HighContrast.Dark.OnSurface,
		PlotHistogramColor = ThemeSources.HighContrast.Dark.OnPrimary
	};

	/// <summary>
	/// High Contrast Light theme - Light theme optimized for accessibility.
	/// </summary>
	public static ThemeDefinition HighContrastLight => new()
	{
		BackgroundColor = ThemeSources.HighContrast.Light.Background.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		TextColor = ThemeSources.HighContrast.Light.Foreground,
		AccentColor = ThemeSources.HighContrast.Light.Primary,
		ButtonColor = ThemeSources.HighContrast.Light.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		ButtonHoveredColor = ThemeSources.HighContrast.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		ButtonActiveColor = ThemeSources.HighContrast.Light.Primary,
		FrameColor = ThemeSources.HighContrast.Light.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		FrameHoveredColor = ThemeSources.HighContrast.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		FrameActiveColor = ThemeSources.HighContrast.Light.Primary,
		HeaderColor = ThemeSources.HighContrast.Light.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		HeaderHoveredColor = ThemeSources.HighContrast.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		HeaderActiveColor = ThemeSources.HighContrast.Light.Primary,
		BorderColor = ThemeSources.HighContrast.Light.Border,
		ScrollbarColor = ThemeSources.HighContrast.Light.Surface,
		ScrollbarHoveredColor = ThemeSources.HighContrast.Light.SurfaceElevated,
		ScrollbarActiveColor = ThemeSources.HighContrast.Light.Primary,
		CheckMarkColor = ThemeSources.HighContrast.Light.Icon,
		SliderGrabColor = ThemeSources.HighContrast.Light.Primary,
		SliderGrabActiveColor = ThemeSources.HighContrast.Light.Secondary,
		TabColor = ThemeSources.HighContrast.Light.Surface.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		TabHoveredColor = ThemeSources.HighContrast.Light.SurfaceElevated.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		TabActiveColor = ThemeSources.HighContrast.Light.Primary.AdjustForSufficientContrast(ThemeSources.HighContrast.Light.Foreground),
		PlotLinesColor = ThemeSources.HighContrast.Light.OnSurface,
		PlotHistogramColor = ThemeSources.HighContrast.Light.OnPrimary
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
