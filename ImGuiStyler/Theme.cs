namespace ktsu.io.ImGuiStyler;

using ImGuiNET;
using ktsu.io.ScopedAction;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Theme
{
	public static float NormalLuminance { get; set; } = 0.7f;
	public static float HoverLuminance { get; set; } = 1f;
	public static float ActiveLuminance { get; set; } = .8f;
	public static float FrameLuminance { get; set; } = .6f;
	public static float DisabledSaturation { get; set; } = 0.2f;

	public static class Palette
	{
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
	}

	public class ScopedThemeColor : ScopedAction
	{
		public ScopedThemeColor(ImColor baseColor, bool enabled)
		{
			var stateColor = enabled ? baseColor : baseColor.WithSaturation(DisabledSaturation);
			var normalColor = stateColor.WithLuminance(NormalLuminance);
			var hoveredColor = stateColor.WithLuminance(HoverLuminance);
			var activeColor = stateColor.WithLuminance(ActiveLuminance);
			var textColor = normalColor.CalculateOptimalTextColorForContrast();

			int numStyles = 0;
			PushStyleAndCount(ImGuiCol.Text, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TextSelectedBg, stateColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TextDisabled, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Button, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ButtonActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ButtonHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.CheckMark, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Header, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.HeaderActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.HeaderHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.SliderGrab, stateColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.SliderGrabActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Tab, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TabActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TabHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBg, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBgActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.TitleBgCollapsed, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.Border, textColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBg, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBgActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.FrameBgHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.NavHighlight, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGrip, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGripActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ResizeGripHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotLines, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotLinesHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotHistogram, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.PlotHistogramHovered, hoveredColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrab, normalColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrabActive, activeColor, ref numStyles);
			PushStyleAndCount(ImGuiCol.ScrollbarGrabHovered, hoveredColor, ref numStyles);

			OnClose = () => ImGui.PopStyleColor(numStyles);
		}

		private static void PushStyleAndCount(ImGuiCol style, ImColor color, ref int numStyles)
		{
			ImGui.PushStyleColor(style, color.Value);
			++numStyles;
		}
	}

	public static ScopedThemeColor Color(ImColor color) => new(color, enabled: true);
	public static ScopedThemeColor ColorDisabled(ImColor color) => new(color, enabled: false);
}
