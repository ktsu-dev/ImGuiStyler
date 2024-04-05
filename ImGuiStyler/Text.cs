namespace ktsu.io.ImGuiStyler;

using ImGuiNET;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Text
{
	public static class Color
	{
		public static class Definitions
		{
			public static ImColor Normal { get; set; } = ImGuiStyler.Color.White;
			public static ImColor Error { get; set; } = ImGuiStyler.Color.Red;
			public static ImColor Warning { get; set; } = ImGuiStyler.Color.Yellow;
			public static ImColor Info { get; set; } = ImGuiStyler.Color.Cyan;
			public static ImColor Success { get; set; } = ImGuiStyler.Color.Green;
		}
		public static ScopedTextColor Normal() => new(Definitions.Normal);
		public static ScopedTextColor Error() => new(Definitions.Error);
		public static ScopedTextColor Warning() => new(Definitions.Warning);
		public static ScopedTextColor Info() => new(Definitions.Info);
		public static ScopedTextColor Success() => new(Definitions.Success);
		public class ScopedTextColor : ImGuiStyler.Color.ScopedColor
		{
			public ScopedTextColor(ImColor color) : base(ImGuiCol.Text, color) { }
		}
	}

	public static void PrintWithTheme(string text)
	{
		var backgroundColor = ImGuiStyler.Color.FromVector(ImGui.GetStyle().Colors[(int)ImGuiCol.WindowBg]);
		var textColor = backgroundColor.CalculateOptimalTextColorForContrast();
		ImGui.PushStyleColor(ImGuiCol.Text, ImGui.GetColorU32(textColor.Value));
		ImGui.TextUnformatted(text);
		ImGui.PopStyleColor();
	}
}
