// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

using ktsu.ScopedAction;

/// <summary>
/// Provides methods and properties to manage and apply themes for ImGui elements.
/// </summary>
public static class Theme
{
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

	/// <summary>
	/// Represents a complete theme definition with all color properties.
	/// </summary>
	public class ThemeDefinition
	{
		/// <summary>
		/// Gets or sets the primary background color.
		/// </summary>
		public ImColor BackgroundColor { get; set; }

		/// <summary>
		/// Gets or sets the primary text color.
		/// </summary>
		public ImColor TextColor { get; set; }

		/// <summary>
		/// Gets or sets the primary accent color.
		/// </summary>
		public ImColor AccentColor { get; set; }

		/// <summary>
		/// Gets or sets the button background color.
		/// </summary>
		public ImColor ButtonColor { get; set; }

		/// <summary>
		/// Gets or sets the button hover color.
		/// </summary>
		public ImColor ButtonHoveredColor { get; set; }

		/// <summary>
		/// Gets or sets the button active color.
		/// </summary>
		public ImColor ButtonActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the frame background color.
		/// </summary>
		public ImColor FrameColor { get; set; }

		/// <summary>
		/// Gets or sets the frame hover color.
		/// </summary>
		public ImColor FrameHoveredColor { get; set; }

		/// <summary>
		/// Gets or sets the frame active color.
		/// </summary>
		public ImColor FrameActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the header color.
		/// </summary>
		public ImColor HeaderColor { get; set; }

		/// <summary>
		/// Gets or sets the header hover color.
		/// </summary>
		public ImColor HeaderHoveredColor { get; set; }

		/// <summary>
		/// Gets or sets the header active color.
		/// </summary>
		public ImColor HeaderActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the border color.
		/// </summary>
		public ImColor BorderColor { get; set; }

		/// <summary>
		/// Gets or sets the scrollbar color.
		/// </summary>
		public ImColor ScrollbarColor { get; set; }

		/// <summary>
		/// Gets or sets the scrollbar hover color.
		/// </summary>
		public ImColor ScrollbarHoveredColor { get; set; }

		/// <summary>
		/// Gets or sets the scrollbar active color.
		/// </summary>
		public ImColor ScrollbarActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the check mark color.
		/// </summary>
		public ImColor CheckMarkColor { get; set; }

		/// <summary>
		/// Gets or sets the slider grab color.
		/// </summary>
		public ImColor SliderGrabColor { get; set; }

		/// <summary>
		/// Gets or sets the slider grab active color.
		/// </summary>
		public ImColor SliderGrabActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the tab color.
		/// </summary>
		public ImColor TabColor { get; set; }

		/// <summary>
		/// Gets or sets the tab hover color.
		/// </summary>
		public ImColor TabHoveredColor { get; set; }

		/// <summary>
		/// Gets or sets the tab active color.
		/// </summary>
		public ImColor TabActiveColor { get; set; }

		/// <summary>
		/// Gets or sets the plot lines color.
		/// </summary>
		public ImColor PlotLinesColor { get; set; }

		/// <summary>
		/// Gets or sets the plot histogram color.
		/// </summary>
		public ImColor PlotHistogramColor { get; set; }
	}

	/// <summary>
	/// Provides a palette of predefined colors for use in themes.
	/// </summary>
	public static class Palette
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public static ImColor Red { get; set; } = ImGuiStyler.Color.FromHex("#ff4a49");
		public static ImColor Green { get; set; } = ImGuiStyler.Color.FromHex("#49ff4a");
		public static ImColor Blue { get; set; } = ImGuiStyler.Color.FromHex("#49a3ff");

		public static ImColor Cyan { get; set; } = ImGuiStyler.Color.FromHex("#49feff");
		public static ImColor Magenta { get; set; } = ImGuiStyler.Color.FromHex("#ff49fe");
		public static ImColor Yellow { get; set; } = ImGuiStyler.Color.FromHex("#ecff49");

		public static ImColor Orange { get; set; } = ImGuiStyler.Color.FromHex("#ffa549");
		public static ImColor Pink { get; set; } = ImGuiStyler.Color.FromHex("#ff49a3");
		public static ImColor Lime { get; set; } = ImGuiStyler.Color.FromHex("#a3ff49");
		public static ImColor Purple { get; set; } = ImGuiStyler.Color.FromHex("#c949ff");

		public static ImColor White { get; set; } = ImGuiStyler.Color.FromHex("#ffffff");
		public static ImColor Black { get; set; } = ImGuiStyler.Color.FromHex("#000000");
		public static ImColor Gray { get; set; } = ImGuiStyler.Color.FromHex("#808080");
		public static ImColor LightGray { get; set; } = ImGuiStyler.Color.FromHex("#c0c0c0");
		public static ImColor DarkGray { get; set; } = ImGuiStyler.Color.FromHex("#404040");
		public static ImColor Transparent { get; set; } = ImGuiStyler.Color.FromHex("#00000000");

		public static ImColor Normal { get; set; } = Blue;
		public static ImColor Emphasis { get; set; } = Orange;
		public static ImColor Error { get; set; } = Red;
		public static ImColor Warning { get; set; } = Yellow;
		public static ImColor Info { get; set; } = Cyan;
		public static ImColor Success { get; set; } = Green;

		// Popular Themes
		public static ImColor CatppuccinMocha { get; set; } = ImGuiStyler.Color.FromHex("#89b4fa");
		public static ImColor Nord { get; set; } = ImGuiStyler.Color.FromHex("#5e81ac");
		public static ImColor Monokai { get; set; } = ImGuiStyler.Color.FromHex("#f92672");
		public static ImColor TokyoNight { get; set; } = ImGuiStyler.Color.FromHex("#7aa2f7");
		public static ImColor GruvboxDark { get; set; } = ImGuiStyler.Color.FromHex("#fe8019");
		public static ImColor Nightfly { get; set; } = ImGuiStyler.Color.FromHex("#82aaff");
		public static ImColor Kanagawa { get; set; } = ImGuiStyler.Color.FromHex("#7e9cd8");
		public static ImColor PaperColorDark { get; set; } = ImGuiStyler.Color.FromHex("#8fbcbb");
		public static ImColor Dracula { get; set; } = ImGuiStyler.Color.FromHex("#bd93f9");
		public static ImColor OneDark { get; set; } = ImGuiStyler.Color.FromHex("#61afef");
		public static ImColor Nightfox { get; set; } = ImGuiStyler.Color.FromHex("#719cd6");
		public static ImColor Everforest { get; set; } = ImGuiStyler.Color.FromHex("#a7c080");
		public static ImColor VSCodeDark { get; set; } = ImGuiStyler.Color.FromHex("#0078d4");
		public static ImColor VSCodeLight { get; set; } = ImGuiStyler.Color.FromHex("#0078d4");
		public static ImColor GruvboxLight { get; set; } = ImGuiStyler.Color.FromHex("#af3a03");
		public static ImColor PaperColorLight { get; set; } = ImGuiStyler.Color.FromHex("#005f87");
		public static ImColor EverforestLight { get; set; } = ImGuiStyler.Color.FromHex("#8da101");
		public static ImColor EverforestDark { get; set; } = ImGuiStyler.Color.FromHex("#a7c080");
		public static ImColor CatppuccinLatte { get; set; } = ImGuiStyler.Color.FromHex("#8839ef");
		public static ImColor CatppuccinFrappe { get; set; } = ImGuiStyler.Color.FromHex("#ca9ee6");
		public static ImColor CatppuccinMacchiato { get; set; } = ImGuiStyler.Color.FromHex("#c6a0f6");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// Dracula theme - A dark theme with purple accents.
	/// </summary>
	public static ThemeDefinition Dracula => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#282a36"),
		TextColor = ImGuiStyler.Color.FromHex("#f8f8f2"),
		AccentColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		ButtonColor = ImGuiStyler.Color.FromHex("#44475a"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#6272a4"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		FrameColor = ImGuiStyler.Color.FromHex("#44475a"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#6272a4"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		HeaderColor = ImGuiStyler.Color.FromHex("#44475a"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#6272a4"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		BorderColor = ImGuiStyler.Color.FromHex("#6272a4"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#44475a"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#6272a4"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#50fa7b"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#ff79c6"),
		TabColor = ImGuiStyler.Color.FromHex("#44475a"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#6272a4"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#bd93f9"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#8be9fd"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#50fa7b")
	};

	/// <summary>
	/// Nord theme - An arctic, elegant theme.
	/// </summary>
	public static ThemeDefinition Nord => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#2e3440"),
		TextColor = ImGuiStyler.Color.FromHex("#d8dee9"),
		AccentColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		ButtonColor = ImGuiStyler.Color.FromHex("#3b4252"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#434c5e"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		FrameColor = ImGuiStyler.Color.FromHex("#3b4252"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#434c5e"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		HeaderColor = ImGuiStyler.Color.FromHex("#3b4252"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#434c5e"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		BorderColor = ImGuiStyler.Color.FromHex("#4c566a"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#3b4252"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#434c5e"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#a3be8c"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#88c0d0"),
		TabColor = ImGuiStyler.Color.FromHex("#3b4252"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#434c5e"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#5e81ac"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#88c0d0"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#a3be8c")
	};

	/// <summary>
	/// Tokyo Night theme - A dark theme with neon-inspired colors.
	/// </summary>
	public static ThemeDefinition TokyoNight => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#1a1b26"),
		TextColor = ImGuiStyler.Color.FromHex("#c0caf5"),
		AccentColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		ButtonColor = ImGuiStyler.Color.FromHex("#24283b"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#292e42"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		FrameColor = ImGuiStyler.Color.FromHex("#24283b"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#292e42"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		HeaderColor = ImGuiStyler.Color.FromHex("#24283b"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#292e42"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		BorderColor = ImGuiStyler.Color.FromHex("#414868"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#24283b"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#292e42"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#9ece6a"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#bb9af7"),
		TabColor = ImGuiStyler.Color.FromHex("#24283b"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#292e42"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#7aa2f7"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#7dcfff"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#9ece6a")
	};

	/// <summary>
	/// Gruvbox Dark theme - A retro, warm theme.
	/// </summary>
	public static ThemeDefinition GruvboxDark => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#282828"),
		TextColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		AccentColor = ImGuiStyler.Color.FromHex("#fe8019"),
		ButtonColor = ImGuiStyler.Color.FromHex("#3c3836"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#504945"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#fe8019"),
		FrameColor = ImGuiStyler.Color.FromHex("#3c3836"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#504945"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#fe8019"),
		HeaderColor = ImGuiStyler.Color.FromHex("#3c3836"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#504945"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#fe8019"),
		BorderColor = ImGuiStyler.Color.FromHex("#665c54"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#3c3836"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#504945"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#fe8019"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#b8bb26"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#fe8019"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#fabd2f"),
		TabColor = ImGuiStyler.Color.FromHex("#3c3836"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#504945"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#fe8019"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#83a598"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#b8bb26")
	};

	/// <summary>
	/// OneDark theme - Atom's signature dark theme.
	/// </summary>
	public static ThemeDefinition OneDark => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#282c34"),
		TextColor = ImGuiStyler.Color.FromHex("#abb2bf"),
		AccentColor = ImGuiStyler.Color.FromHex("#61afef"),
		ButtonColor = ImGuiStyler.Color.FromHex("#3e4451"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#4b5263"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#61afef"),
		FrameColor = ImGuiStyler.Color.FromHex("#3e4451"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#4b5263"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#61afef"),
		HeaderColor = ImGuiStyler.Color.FromHex("#3e4451"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#4b5263"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#61afef"),
		BorderColor = ImGuiStyler.Color.FromHex("#5c6370"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#3e4451"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#4b5263"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#61afef"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#98c379"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#61afef"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#c678dd"),
		TabColor = ImGuiStyler.Color.FromHex("#3e4451"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#4b5263"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#61afef"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#56b6c2"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#98c379")
	};

	/// <summary>
	/// Catppuccin Mocha theme - A warm, cozy theme.
	/// </summary>
	public static ThemeDefinition CatppuccinMocha => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#1e1e2e"),
		TextColor = ImGuiStyler.Color.FromHex("#cdd6f4"),
		AccentColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		ButtonColor = ImGuiStyler.Color.FromHex("#313244"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#45475a"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		FrameColor = ImGuiStyler.Color.FromHex("#313244"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#45475a"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		HeaderColor = ImGuiStyler.Color.FromHex("#313244"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#45475a"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		BorderColor = ImGuiStyler.Color.FromHex("#6c7086"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#313244"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#45475a"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#a6e3a1"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#cba6f7"),
		TabColor = ImGuiStyler.Color.FromHex("#313244"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#45475a"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#89b4fa"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#89dceb"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#a6e3a1")
	};

	/// <summary>
	/// VSCode Dark theme - Microsoft's default dark theme.
	/// </summary>
	public static ThemeDefinition VSCodeDark => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#1e1e1e"),
		TextColor = ImGuiStyler.Color.FromHex("#cccccc"),
		AccentColor = ImGuiStyler.Color.FromHex("#0078d4"),
		ButtonColor = ImGuiStyler.Color.FromHex("#2d2d30"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#3e3e42"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		FrameColor = ImGuiStyler.Color.FromHex("#2d2d30"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#3e3e42"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		HeaderColor = ImGuiStyler.Color.FromHex("#2d2d30"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#3e3e42"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		BorderColor = ImGuiStyler.Color.FromHex("#464647"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#2d2d30"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#3e3e42"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#608b4e"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#0078d4"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#005a9e"),
		TabColor = ImGuiStyler.Color.FromHex("#2d2d30"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#3e3e42"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#4fc1ff"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#608b4e")
	};

	/// <summary>
	/// VSCode Light theme - Microsoft's default light theme.
	/// </summary>
	public static ThemeDefinition VSCodeLight => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#ffffff"),
		TextColor = ImGuiStyler.Color.FromHex("#000000"),
		AccentColor = ImGuiStyler.Color.FromHex("#0078d4"),
		ButtonColor = ImGuiStyler.Color.FromHex("#f3f3f3"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#e1e1e1"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		FrameColor = ImGuiStyler.Color.FromHex("#f3f3f3"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#e1e1e1"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		HeaderColor = ImGuiStyler.Color.FromHex("#f3f3f3"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#e1e1e1"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		BorderColor = ImGuiStyler.Color.FromHex("#cccccc"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#f3f3f3"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#e1e1e1"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#008000"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#0078d4"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#005a9e"),
		TabColor = ImGuiStyler.Color.FromHex("#f3f3f3"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#e1e1e1"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#0078d4"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#0078d4"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#008000")
	};

	/// <summary>
	/// Gruvbox Light theme - A retro, warm light theme.
	/// </summary>
	public static ThemeDefinition GruvboxLight => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#fbf1c7"),
		TextColor = ImGuiStyler.Color.FromHex("#3c3836"),
		AccentColor = ImGuiStyler.Color.FromHex("#af3a03"),
		ButtonColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#d5c4a1"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#af3a03"),
		FrameColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#d5c4a1"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#af3a03"),
		HeaderColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#d5c4a1"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#af3a03"),
		BorderColor = ImGuiStyler.Color.FromHex("#928374"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#d5c4a1"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#af3a03"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#79740e"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#af3a03"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#b57614"),
		TabColor = ImGuiStyler.Color.FromHex("#ebdbb2"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#d5c4a1"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#af3a03"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#427b58"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#79740e")
	};

	/// <summary>
	/// Monokai theme - A vibrant dark theme with bright highlights.
	/// </summary>
	public static ThemeDefinition Monokai => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#272822"),
		TextColor = ImGuiStyler.Color.FromHex("#f8f8f2"),
		AccentColor = ImGuiStyler.Color.FromHex("#f92672"),
		ButtonColor = ImGuiStyler.Color.FromHex("#383830"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#49483e"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#f92672"),
		FrameColor = ImGuiStyler.Color.FromHex("#383830"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#49483e"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#f92672"),
		HeaderColor = ImGuiStyler.Color.FromHex("#383830"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#49483e"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#f92672"),
		BorderColor = ImGuiStyler.Color.FromHex("#75715e"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#383830"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#49483e"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#f92672"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#a6e22e"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#f92672"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#fd971f"),
		TabColor = ImGuiStyler.Color.FromHex("#383830"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#49483e"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#f92672"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#66d9ef"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#a6e22e")
	};

	/// <summary>
	/// Nightfly theme - A dark theme with blue and purple tones.
	/// </summary>
	public static ThemeDefinition Nightfly => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#011627"),
		TextColor = ImGuiStyler.Color.FromHex("#acb4c2"),
		AccentColor = ImGuiStyler.Color.FromHex("#82aaff"),
		ButtonColor = ImGuiStyler.Color.FromHex("#1d3b53"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#275075"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#82aaff"),
		FrameColor = ImGuiStyler.Color.FromHex("#1d3b53"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#275075"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#82aaff"),
		HeaderColor = ImGuiStyler.Color.FromHex("#1d3b53"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#275075"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#82aaff"),
		BorderColor = ImGuiStyler.Color.FromHex("#5f7e97"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#1d3b53"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#275075"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#82aaff"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#21c7a8"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#82aaff"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#c792ea"),
		TabColor = ImGuiStyler.Color.FromHex("#1d3b53"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#275075"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#82aaff"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#7fdbca"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#21c7a8")
	};

	/// <summary>
	/// Kanagawa theme - A Japanese-inspired dark theme with warm tones.
	/// </summary>
	public static ThemeDefinition Kanagawa => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#1f1f28"),
		TextColor = ImGuiStyler.Color.FromHex("#dcd7ba"),
		AccentColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		ButtonColor = ImGuiStyler.Color.FromHex("#2a2a37"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#363646"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		FrameColor = ImGuiStyler.Color.FromHex("#2a2a37"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#363646"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		HeaderColor = ImGuiStyler.Color.FromHex("#2a2a37"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#363646"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		BorderColor = ImGuiStyler.Color.FromHex("#54546d"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#2a2a37"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#363646"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#98bb6c"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#957fb8"),
		TabColor = ImGuiStyler.Color.FromHex("#2a2a37"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#363646"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#7e9cd8"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#7fb4ca"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#98bb6c")
	};

	/// <summary>
	/// PaperColor Dark theme - A soft dark theme with muted colors.
	/// </summary>
	public static ThemeDefinition PaperColorDark => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#1c1c1c"),
		TextColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		AccentColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		ButtonColor = ImGuiStyler.Color.FromHex("#262626"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#3a3a3a"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		FrameColor = ImGuiStyler.Color.FromHex("#262626"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#3a3a3a"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		HeaderColor = ImGuiStyler.Color.FromHex("#262626"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#3a3a3a"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		BorderColor = ImGuiStyler.Color.FromHex("#4e4e4e"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#262626"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#3a3a3a"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#af8700"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#d75f00"),
		TabColor = ImGuiStyler.Color.FromHex("#262626"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#3a3a3a"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#8fbcbb"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#5f8787"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#af8700")
	};

	/// <summary>
	/// PaperColor Light theme - A clean light theme with soft colors.
	/// </summary>
	public static ThemeDefinition PaperColorLight => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#eeeeee"),
		TextColor = ImGuiStyler.Color.FromHex("#444444"),
		AccentColor = ImGuiStyler.Color.FromHex("#005f87"),
		ButtonColor = ImGuiStyler.Color.FromHex("#e4e4e4"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#005f87"),
		FrameColor = ImGuiStyler.Color.FromHex("#e4e4e4"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#005f87"),
		HeaderColor = ImGuiStyler.Color.FromHex("#e4e4e4"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#005f87"),
		BorderColor = ImGuiStyler.Color.FromHex("#8a8a8a"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#e4e4e4"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#005f87"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#008700"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#005f87"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#d75f00"),
		TabColor = ImGuiStyler.Color.FromHex("#e4e4e4"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#d0d0d0"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#005f87"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#005f87"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#008700")
	};

	/// <summary>
	/// Nightfox theme - A vibrant dark fox-inspired theme.
	/// </summary>
	public static ThemeDefinition Nightfox => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#192330"),
		TextColor = ImGuiStyler.Color.FromHex("#cdcecf"),
		AccentColor = ImGuiStyler.Color.FromHex("#719cd6"),
		ButtonColor = ImGuiStyler.Color.FromHex("#29394f"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#39506d"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#719cd6"),
		FrameColor = ImGuiStyler.Color.FromHex("#29394f"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#39506d"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#719cd6"),
		HeaderColor = ImGuiStyler.Color.FromHex("#29394f"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#39506d"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#719cd6"),
		BorderColor = ImGuiStyler.Color.FromHex("#575860"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#29394f"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#39506d"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#719cd6"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#81b29a"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#719cd6"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#c94f6d"),
		TabColor = ImGuiStyler.Color.FromHex("#29394f"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#39506d"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#719cd6"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#63cdcf"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#81b29a")
	};

	/// <summary>
	/// Everforest Dark theme - A green forest-inspired dark theme.
	/// </summary>
	public static ThemeDefinition EverforestDark => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#2d353b"),
		TextColor = ImGuiStyler.Color.FromHex("#d3c6aa"),
		AccentColor = ImGuiStyler.Color.FromHex("#a7c080"),
		ButtonColor = ImGuiStyler.Color.FromHex("#3d484d"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#4f5b58"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#a7c080"),
		FrameColor = ImGuiStyler.Color.FromHex("#3d484d"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#4f5b58"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#a7c080"),
		HeaderColor = ImGuiStyler.Color.FromHex("#3d484d"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#4f5b58"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#a7c080"),
		BorderColor = ImGuiStyler.Color.FromHex("#7a8478"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#3d484d"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#4f5b58"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#a7c080"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#83c092"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#a7c080"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#dbbc7f"),
		TabColor = ImGuiStyler.Color.FromHex("#3d484d"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#4f5b58"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#a7c080"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#7fbbb3"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#83c092")
	};

	/// <summary>
	/// Everforest Light theme - A green forest-inspired light theme.
	/// </summary>
	public static ThemeDefinition EverforestLight => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#fdf6e3"),
		TextColor = ImGuiStyler.Color.FromHex("#5c6a72"),
		AccentColor = ImGuiStyler.Color.FromHex("#8da101"),
		ButtonColor = ImGuiStyler.Color.FromHex("#f4f0d9"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#efebd4"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#8da101"),
		FrameColor = ImGuiStyler.Color.FromHex("#f4f0d9"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#efebd4"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#8da101"),
		HeaderColor = ImGuiStyler.Color.FromHex("#f4f0d9"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#efebd4"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#8da101"),
		BorderColor = ImGuiStyler.Color.FromHex("#a6b0a0"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#f4f0d9"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#efebd4"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#8da101"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#35a77c"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#8da101"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#dfa000"),
		TabColor = ImGuiStyler.Color.FromHex("#f4f0d9"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#efebd4"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#8da101"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#35a77c"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#8da101")
	};

	/// <summary>
	/// Catppuccin Latte theme - A light, warm, creamy theme.
	/// </summary>
	public static ThemeDefinition CatppuccinLatte => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#eff1f5"),
		TextColor = ImGuiStyler.Color.FromHex("#4c4f69"),
		AccentColor = ImGuiStyler.Color.FromHex("#8839ef"),
		ButtonColor = ImGuiStyler.Color.FromHex("#e6e9ef"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#dce0e8"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#8839ef"),
		FrameColor = ImGuiStyler.Color.FromHex("#e6e9ef"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#dce0e8"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#8839ef"),
		HeaderColor = ImGuiStyler.Color.FromHex("#e6e9ef"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#dce0e8"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#8839ef"),
		BorderColor = ImGuiStyler.Color.FromHex("#acb0be"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#e6e9ef"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#dce0e8"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#8839ef"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#40a02b"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#8839ef"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#ea76cb"),
		TabColor = ImGuiStyler.Color.FromHex("#e6e9ef"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#dce0e8"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#8839ef"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#209fb5"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#40a02b")
	};

	/// <summary>
	/// Catppuccin Frappe theme - A medium-dark, elegant theme.
	/// </summary>
	public static ThemeDefinition CatppuccinFrappe => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#303446"),
		TextColor = ImGuiStyler.Color.FromHex("#c6d0f5"),
		AccentColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		ButtonColor = ImGuiStyler.Color.FromHex("#414559"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#51576d"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		FrameColor = ImGuiStyler.Color.FromHex("#414559"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#51576d"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		HeaderColor = ImGuiStyler.Color.FromHex("#414559"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#51576d"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		BorderColor = ImGuiStyler.Color.FromHex("#737994"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#414559"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#51576d"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#a6d189"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#f5bde6"),
		TabColor = ImGuiStyler.Color.FromHex("#414559"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#51576d"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#ca9ee6"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#81c8be"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#a6d189")
	};

	/// <summary>
	/// Catppuccin Macchiato theme - A darker, sophisticated theme.
	/// </summary>
	public static ThemeDefinition CatppuccinMacchiato => new()
	{
		BackgroundColor = ImGuiStyler.Color.FromHex("#24273a"),
		TextColor = ImGuiStyler.Color.FromHex("#cad3f5"),
		AccentColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		ButtonColor = ImGuiStyler.Color.FromHex("#363a4f"),
		ButtonHoveredColor = ImGuiStyler.Color.FromHex("#494d64"),
		ButtonActiveColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		FrameColor = ImGuiStyler.Color.FromHex("#363a4f"),
		FrameHoveredColor = ImGuiStyler.Color.FromHex("#494d64"),
		FrameActiveColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		HeaderColor = ImGuiStyler.Color.FromHex("#363a4f"),
		HeaderHoveredColor = ImGuiStyler.Color.FromHex("#494d64"),
		HeaderActiveColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		BorderColor = ImGuiStyler.Color.FromHex("#6e738d"),
		ScrollbarColor = ImGuiStyler.Color.FromHex("#363a4f"),
		ScrollbarHoveredColor = ImGuiStyler.Color.FromHex("#494d64"),
		ScrollbarActiveColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		CheckMarkColor = ImGuiStyler.Color.FromHex("#a6da95"),
		SliderGrabColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		SliderGrabActiveColor = ImGuiStyler.Color.FromHex("#f5bde6"),
		TabColor = ImGuiStyler.Color.FromHex("#363a4f"),
		TabHoveredColor = ImGuiStyler.Color.FromHex("#494d64"),
		TabActiveColor = ImGuiStyler.Color.FromHex("#c6a0f6"),
		PlotLinesColor = ImGuiStyler.Color.FromHex("#8bd5ca"),
		PlotHistogramColor = ImGuiStyler.Color.FromHex("#a6da95")
	};

	/// <summary>
	/// Applies the theme colors to the ImGui style.
	/// </summary>
	/// <param name="baseColor">The base color to apply to the theme.</param>
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
		ImColor controlTextColor = normalColor.CalculateOptimalContrastingColor();
		ImColor nakedTextColor = backgroundColor.CalculateOptimalContrastingColor();
		float controlTextContrast = controlTextColor.GetContrastRatioOver(normalColor);
		float nakedTextContrast = nakedTextColor.GetContrastRatioOver(backgroundColor);
		ImColor textColor = controlTextContrast > nakedTextContrast ? controlTextColor : nakedTextColor;
		ImColor borderColor = nakedTextColor.MultiplyLuminance(BorderLuminanceMult);

		// Calculate contrast-corrected text colors for better readability across all widgets
		ImColor activeTabTextColor = activeColor.CalculateOptimalContrastingColor();
		ImColor normalTabTextColor = normalColor.CalculateOptimalContrastingColor();
		ImColor hoveredTabTextColor = hoveredColor.CalculateOptimalContrastingColor();
		ImColor headerTextColor = headerColor.CalculateOptimalContrastingColor();
		ImColor buttonTextColor = normalColor.CalculateOptimalContrastingColor();
		float activeTabContrast = activeTabTextColor.GetContrastRatioOver(activeColor);
		float headerContrast = headerTextColor.GetContrastRatioOver(headerColor);
		float buttonContrast = buttonTextColor.GetContrastRatioOver(normalColor);
		float currentTextOnActiveTab = textColor.GetContrastRatioOver(activeColor);
		// Always prioritize readability - use the best contrast available for active elements
		ImColor bestTextColor = textColor;
		if (activeTabContrast > currentTextOnActiveTab)
		{
			bestTextColor = activeTabTextColor;
		}
		else if (headerContrast > textColor.GetContrastRatioOver(headerColor))
		{
			bestTextColor = headerTextColor;
		}
		else if (buttonContrast > textColor.GetContrastRatioOver(normalColor))
		{
			bestTextColor = buttonTextColor;
		}

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = bestTextColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = baseColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = bestTextColor.MultiplySaturation(0.5f).Value;
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
	/// Applies a complete theme definition to the ImGui style.
	/// </summary>
	/// <param name="themeDefinition">The complete theme definition to apply.</param>
	public static void Apply(ThemeDefinition themeDefinition)
	{
		ArgumentNullException.ThrowIfNull(themeDefinition, nameof(themeDefinition));

		// Calculate contrast-corrected text colors for better readability across all widgets
		ImColor activeTabTextColor = themeDefinition.TabActiveColor.CalculateOptimalContrastingColor();
		ImColor backgroundTextColor = themeDefinition.BackgroundColor.CalculateOptimalContrastingColor();
		ImColor buttonTextColor = themeDefinition.ButtonColor.CalculateOptimalContrastingColor();
		ImColor buttonActiveTextColor = themeDefinition.ButtonActiveColor.CalculateOptimalContrastingColor();
		ImColor frameTextColor = themeDefinition.FrameColor.CalculateOptimalContrastingColor();
		ImColor headerTextColor = themeDefinition.HeaderColor.CalculateOptimalContrastingColor();
		ImColor headerActiveTextColor = themeDefinition.HeaderActiveColor.CalculateOptimalContrastingColor();
		// Choose the best text color based on contrast ratios with various backgrounds
		float activeTabContrast = activeTabTextColor.GetContrastRatioOver(themeDefinition.TabActiveColor);
		float backgroundContrast = backgroundTextColor.GetContrastRatioOver(themeDefinition.BackgroundColor);
		float buttonContrast = buttonTextColor.GetContrastRatioOver(themeDefinition.ButtonColor);
		float buttonActiveContrast = buttonActiveTextColor.GetContrastRatioOver(themeDefinition.ButtonActiveColor);
		float frameContrast = frameTextColor.GetContrastRatioOver(themeDefinition.FrameColor);
		float headerContrast = headerTextColor.GetContrastRatioOver(themeDefinition.HeaderColor);
		float headerActiveContrast = headerActiveTextColor.GetContrastRatioOver(themeDefinition.HeaderActiveColor);
		ImColor bestTextColor = themeDefinition.TextColor;
		float definedTextContrast = bestTextColor.GetContrastRatioOver(themeDefinition.TabActiveColor);
		float definedTextButtonContrast = bestTextColor.GetContrastRatioOver(themeDefinition.ButtonActiveColor);
		float definedTextHeaderContrast = bestTextColor.GetContrastRatioOver(themeDefinition.HeaderActiveColor);
		// Use calculated contrast color if it's significantly better than the defined text color across multiple contexts
		float contrastImprovement = 0.2f;
		if ((activeTabContrast > definedTextContrast + contrastImprovement) ||
			(buttonActiveContrast > definedTextButtonContrast + contrastImprovement) ||
			(headerActiveContrast > definedTextHeaderContrast + contrastImprovement))
		{
			// Choose the color that provides best overall contrast across the most contexts
			if (activeTabContrast >= buttonActiveContrast && activeTabContrast >= headerActiveContrast)
			{
				bestTextColor = activeTabTextColor;
			}
			else if (buttonActiveContrast >= headerActiveContrast)
			{
				bestTextColor = buttonActiveTextColor;
			}
			else
			{
				bestTextColor = headerActiveTextColor;
			}
		}

		// Safety check: ensure active tabs have minimum readability (4.5 contrast ratio)
		float finalTabContrast = bestTextColor.GetContrastRatioOver(themeDefinition.TabActiveColor);
		if (finalTabContrast < 4.5f)
		{
			bestTextColor = activeTabTextColor; // Force use of calculated optimal contrast
		}

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = bestTextColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = bestTextColor.MultiplySaturation(0.5f).Value;
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

	/// <summary>
	/// Represents a scoped action that applies a theme color to ImGui elements.
	/// </summary>
	/// <remarks>
	/// This class is used to temporarily apply a theme color to ImGui elements within a specific scope.
	/// When the scope ends, the previous style is restored.
	/// </remarks>
	public class ScopedThemeColor : ScopedAction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScopedThemeColor"/> class.
		/// Applies a theme color to ImGui elements within a specific scope.
		/// </summary>
		/// <param name="baseColor">The base color to apply to the theme.</param>
		/// <param name="enabled">A boolean indicating if the state is enabled.</param>
		public ScopedThemeColor(ImColor baseColor, bool enabled)
		{
			ImColor stateColor = GetStateColor(baseColor, enabled);
			ImColor normalColor = GetNormalColor(stateColor);
			ImColor accentColor = GetAccentColor(baseColor);
			ImColor accentHoveredColor = GetAccentHoveredColor(baseColor);
			ImColor headerColor = GetHeaderColor(stateColor);
			ImColor hoveredColor = GetHoveredColor(stateColor);
			ImColor activeColor = GetActiveColor(stateColor);
			ImColor backgroundColor = GetBackgroundColor(stateColor);
			ImColor dragColor = GetDragColor(stateColor);
			ImColor controlTextColor = normalColor.CalculateOptimalContrastingColor();
			ImColor nakedTextColor = backgroundColor.CalculateOptimalContrastingColor();
			float controlTextContrast = controlTextColor.GetContrastRatioOver(normalColor);
			float nakedTextContrast = nakedTextColor.GetContrastRatioOver(backgroundColor);
			ImColor textColor = controlTextContrast > nakedTextContrast ? controlTextColor : nakedTextColor;
			ImColor borderColor = nakedTextColor.MultiplyLuminance(BorderLuminanceMult);

			int numStyles = 0;
			PushStyleAndCount(ImGuiCol.Text, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TextSelectedBg, stateColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TextDisabled, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Button, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ButtonActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ButtonHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.CheckMark, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Header, headerColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.HeaderActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.HeaderHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.SliderGrab, stateColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.SliderGrabActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Tab, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TabSelected, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TabHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBg, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBgActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBgCollapsed, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Border, borderColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBg, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBgActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBgHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.NavCursor, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGrip, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGripActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGripHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotLines, accentColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotLinesHovered, accentHoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotHistogram, accentColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotHistogramHovered, accentHoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrab, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrabActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrabHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.WindowBg, backgroundColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ChildBg, backgroundColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PopupBg, backgroundColor, ref numStyles);

			OnClose = () => ImGui.PopStyleColor(numStyles);
		}

		private static void PushStyleAndCount(ImGuiCol style, ImColor color, ref int numStyles)
		{
			ImGui.PushStyleColor(style, color.Value);
			++numStyles;
		}
	}

	/// <summary>
	/// Creates a new instance of the <see cref="ScopedThemeColor"/> class with the specified color and enabled state.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A new instance of the <see cref="ScopedThemeColor"/> class.</returns>
	public static ScopedThemeColor Color(ImColor color) => new(color, enabled: true);
	/// <summary>
	/// Creates a new instance of the <see cref="ScopedThemeColor"/> class with the specified color and disabled state.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A new instance of the <see cref="ScopedThemeColor"/> class with the disabled state.</returns>
	public static ScopedThemeColor ColorDisabled(ImColor color) => new(color, enabled: false);

	/// <summary>
	/// Information about an available theme.
	/// </summary>
	public class ThemeInfo
	{
		/// <summary>
		/// Gets the name of the theme.
		/// </summary>
		public required string Name { get; init; }

		/// <summary>
		/// Gets the description of the theme.
		/// </summary>
		public required string Description { get; init; }

		/// <summary>
		/// Gets the category of the theme (Light, Dark, etc.).
		/// </summary>
		public required string Category { get; init; }

		/// <summary>
		/// Gets the palette color associated with this theme.
		/// </summary>
		public required ImColor Color { get; init; }
	}

	/// <summary>
	/// Information about an available complete theme definition.
	/// </summary>
	public class ThemeDefinitionInfo
	{
		/// <summary>
		/// Gets the name of the theme.
		/// </summary>
		public required string Name { get; init; }

		/// <summary>
		/// Gets the description of the theme.
		/// </summary>
		public required string Description { get; init; }

		/// <summary>
		/// Gets the category of the theme (Light, Dark, etc.).
		/// </summary>
		public required string Category { get; init; }

		/// <summary>
		/// Gets the complete theme definition.
		/// </summary>
		public required ThemeDefinition Definition { get; init; }
	}

	/// <summary>
	/// Gets all available palette colors for theming.
	/// </summary>
	public static IReadOnlyList<ThemeInfo> AvailablePaletteColors =>
	[
		new() { Name = "Normal", Description = "Default blue theme", Category = "Basic", Color = Palette.Normal },
		new() { Name = "Red", Description = "Vibrant red theme", Category = "Basic", Color = Palette.Red },
		new() { Name = "Green", Description = "Fresh green theme", Category = "Basic", Color = Palette.Green },
		new() { Name = "Blue", Description = "Classic blue theme", Category = "Basic", Color = Palette.Blue },
		new() { Name = "Cyan", Description = "Cool cyan theme", Category = "Basic", Color = Palette.Cyan },
		new() { Name = "Magenta", Description = "Bold magenta theme", Category = "Basic", Color = Palette.Magenta },
		new() { Name = "Yellow", Description = "Bright yellow theme", Category = "Basic", Color = Palette.Yellow },
		new() { Name = "Orange", Description = "Warm orange theme", Category = "Basic", Color = Palette.Orange },
		new() { Name = "Pink", Description = "Sweet pink theme", Category = "Basic", Color = Palette.Pink },
		new() { Name = "Lime", Description = "Electric lime theme", Category = "Basic", Color = Palette.Lime },
		new() { Name = "Purple", Description = "Royal purple theme", Category = "Basic", Color = Palette.Purple },
		new() { Name = "White", Description = "Pure white theme", Category = "Basic", Color = Palette.White },
		new() { Name = "Gray", Description = "Neutral gray theme", Category = "Basic", Color = Palette.Gray },
		new() { Name = "Light Gray", Description = "Light gray theme", Category = "Basic", Color = Palette.LightGray },
		new() { Name = "Dark Gray", Description = "Dark gray theme", Category = "Basic", Color = Palette.DarkGray },
		new() { Name = "Dracula", Description = "A dark theme with purple accents and vampire-inspired colors", Category = "Dark", Color = Palette.Dracula },
		new() { Name = "Nord", Description = "An arctic, elegant theme with cool blue tones", Category = "Dark", Color = Palette.Nord },
		new() { Name = "Tokyo Night", Description = "A dark theme with neon-inspired colors from Tokyo", Category = "Dark", Color = Palette.TokyoNight },
		new() { Name = "Gruvbox Dark", Description = "A retro, warm dark theme with earthy colors", Category = "Dark", Color = Palette.GruvboxDark },
		new() { Name = "OneDark", Description = "Atom's signature dark theme with balanced colors", Category = "Dark", Color = Palette.OneDark },
		new() { Name = "Catppuccin Mocha", Description = "A warm, cozy dark theme with soothing colors", Category = "Dark", Color = Palette.CatppuccinMocha },
		new() { Name = "Monokai", Description = "A vibrant dark theme with bright highlights", Category = "Dark", Color = Palette.Monokai },
		new() { Name = "Nightfly", Description = "A dark theme with blue and purple tones", Category = "Dark", Color = Palette.Nightfly },
		new() { Name = "Kanagawa", Description = "A Japanese-inspired dark theme with warm tones", Category = "Dark", Color = Palette.Kanagawa },
		new() { Name = "PaperColor Dark", Description = "A soft dark theme with muted colors", Category = "Dark", Color = Palette.PaperColorDark },
		new() { Name = "Nightfox", Description = "A vibrant dark fox-inspired theme", Category = "Dark", Color = Palette.Nightfox },
		new() { Name = "Everforest", Description = "A green forest-inspired theme", Category = "Dark", Color = Palette.Everforest },
		new() { Name = "Everforest Dark", Description = "A green forest-inspired dark theme", Category = "Dark", Color = Palette.EverforestDark },
		new() { Name = "VSCode Dark", Description = "Microsoft's default dark theme", Category = "Dark", Color = Palette.VSCodeDark },
		new() { Name = "VSCode Light", Description = "Microsoft's clean light theme", Category = "Light", Color = Palette.VSCodeLight },
		new() { Name = "Gruvbox Light", Description = "A retro, warm light theme", Category = "Light", Color = Palette.GruvboxLight },
		new() { Name = "PaperColor Light", Description = "A clean light theme with soft colors", Category = "Light", Color = Palette.PaperColorLight },
		new() { Name = "Everforest Light", Description = "A green forest-inspired light theme", Category = "Light", Color = Palette.EverforestLight },
		new() { Name = "Catppuccin Latte", Description = "A light, warm, creamy theme", Category = "Light", Color = Palette.CatppuccinLatte },
		new() { Name = "Catppuccin Frappe", Description = "A medium-dark, elegant theme", Category = "Medium", Color = Palette.CatppuccinFrappe },
		new() { Name = "Catppuccin Macchiato", Description = "A darker, sophisticated theme", Category = "Dark", Color = Palette.CatppuccinMacchiato },
	];

	/// <summary>
	/// Gets all available complete theme definitions.
	/// </summary>
	public static IReadOnlyList<ThemeDefinitionInfo> AvailableThemeDefinitions =>
	[
		new() { Name = "Dracula", Description = "A dark theme with purple accents and vampire-inspired colors", Category = "Dark", Definition = Dracula },
		new() { Name = "Nord", Description = "An arctic, elegant theme with cool blue tones", Category = "Dark", Definition = Nord },
		new() { Name = "Tokyo Night", Description = "A dark theme with neon-inspired colors from Tokyo", Category = "Dark", Definition = TokyoNight },
		new() { Name = "Gruvbox Dark", Description = "A retro, warm dark theme with earthy colors", Category = "Dark", Definition = GruvboxDark },
		new() { Name = "Gruvbox Light", Description = "A retro, warm light theme", Category = "Light", Definition = GruvboxLight },
		new() { Name = "OneDark", Description = "Atom's signature dark theme with balanced colors", Category = "Dark", Definition = OneDark },
		new() { Name = "Catppuccin Mocha", Description = "A warm, cozy dark theme with soothing colors", Category = "Dark", Definition = CatppuccinMocha },
		new() { Name = "Catppuccin Latte", Description = "A light, warm, creamy theme", Category = "Light", Definition = CatppuccinLatte },
		new() { Name = "Catppuccin Frappe", Description = "A medium-dark, elegant theme", Category = "Medium", Definition = CatppuccinFrappe },
		new() { Name = "Catppuccin Macchiato", Description = "A darker, sophisticated theme", Category = "Dark", Definition = CatppuccinMacchiato },
		new() { Name = "VSCode Dark", Description = "Microsoft's default dark theme", Category = "Dark", Definition = VSCodeDark },
		new() { Name = "VSCode Light", Description = "Microsoft's clean light theme", Category = "Light", Definition = VSCodeLight },
		new() { Name = "Monokai", Description = "A vibrant dark theme with bright highlights", Category = "Dark", Definition = Monokai },
		new() { Name = "Nightfly", Description = "A dark theme with blue and purple tones", Category = "Dark", Definition = Nightfly },
		new() { Name = "Kanagawa", Description = "A Japanese-inspired dark theme with warm tones", Category = "Dark", Definition = Kanagawa },
		new() { Name = "PaperColor Dark", Description = "A soft dark theme with muted colors", Category = "Dark", Definition = PaperColorDark },
		new() { Name = "PaperColor Light", Description = "A clean light theme with soft colors", Category = "Light", Definition = PaperColorLight },
		new() { Name = "Nightfox", Description = "A vibrant dark fox-inspired theme", Category = "Dark", Definition = Nightfox },
		new() { Name = "Everforest Dark", Description = "A green forest-inspired dark theme", Category = "Dark", Definition = EverforestDark },
		new() { Name = "Everforest Light", Description = "A green forest-inspired light theme", Category = "Light", Definition = EverforestLight },
	];
}
