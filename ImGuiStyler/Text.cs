namespace ktsu.ImGuiStyler;
using ImGuiNET;

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
}
