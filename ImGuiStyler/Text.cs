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
		public class ScopedTextColor(ImColor color) : ImGuiStyler.Color.ScopedColor(ImGuiCol.Text, color)
		{
		}
	}

	public static void Centered(string text) =>
		CenteredWithin(text, ImGui.GetContentRegionAvail().X);

	public static void CenteredWithin(string text, float width)
	{
		float textWidth = Math.Min(ImGui.CalcTextSize(text).X, width);
		float cursorPosX = ImGui.GetCursorPosX();
		ImGui.SetCursorPosX(cursorPosX + ((width - textWidth) / 2));
		ImGui.TextUnformatted(text);
	}
}
