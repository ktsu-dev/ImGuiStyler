namespace ktsu.ImGuiStyler;

using ImGuiNET;
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// Applies the theme colors to the ImGui style.
	/// </summary>
	/// <param name="baseColor">The base color to apply to the theme.</param>
	public static void Apply(ImColor baseColor)
	{
		var normalColor = GetNormalColor(baseColor);
		var accentColor = GetAccentColor(baseColor);
		var accentHoveredColor = GetAccentHoveredColor(baseColor);
		var headerColor = GetHeaderColor(baseColor);
		var hoveredColor = GetHoveredColor(baseColor);
		var activeColor = GetActiveColor(baseColor);
		var backgroundColor = GetBackgroundColor(baseColor);
		var dragColor = GetDragColor(baseColor);
		var controlTextColor = normalColor.CalculateOptimalContrastingColor();
		var nakedTextColor = backgroundColor.CalculateOptimalContrastingColor();
		float controlTextConrast = controlTextColor.GetContrastRatioOver(normalColor);
		float nakedTextConrast = nakedTextColor.GetContrastRatioOver(backgroundColor);
		var textColor = controlTextConrast > nakedTextConrast ? controlTextColor : nakedTextColor;
		var borderColor = nakedTextColor.MultiplyLuminance(BorderLuminanceMult);

		var colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = textColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = baseColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = textColor.Value;
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
		colors[(int)ImGuiCol.NavHighlight] = activeColor.Value;
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
			var stateColor = GetStateColor(baseColor, enabled);
			var normalColor = GetNormalColor(stateColor);
			var accentColor = GetAccentColor(baseColor);
			var accentHoveredColor = GetAccentHoveredColor(baseColor);
			var headerColor = GetHeaderColor(stateColor);
			var hoveredColor = GetHoveredColor(stateColor);
			var activeColor = GetActiveColor(stateColor);
			var backgroundColor = GetBackgroundColor(stateColor);
			var dragColor = GetDragColor(stateColor);
			var controlTextColor = normalColor.CalculateOptimalContrastingColor();
			var nakedTextColor = backgroundColor.CalculateOptimalContrastingColor();
			float controlTextConrast = controlTextColor.GetContrastRatioOver(normalColor);
			float nakedTextConrast = nakedTextColor.GetContrastRatioOver(backgroundColor);
			var textColor = controlTextConrast > nakedTextConrast ? controlTextColor : nakedTextColor;
			var borderColor = nakedTextColor.MultiplyLuminance(BorderLuminanceMult);

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
			PushStyleAndCount(ImGuiCol.NavHighlight, normalColor, ref numStyles);
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
}
