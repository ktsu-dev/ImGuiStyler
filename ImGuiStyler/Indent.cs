namespace ktsu.ImGuiStyler;

using ImGuiNET;
using ktsu.ScopedAction;

public static class Indent
{
	public static ScopedIndent ByDefault() => new();
	public static ScopedIndentBy By(float width) => new(width);

	public class ScopedIndent : ScopedAction
	{
		public ScopedIndent() : base(ImGui.Indent, ImGui.Unindent) { }
	}

	public class ScopedIndentBy : ScopedStyleVar
	{
		public ScopedIndentBy(float width) : base(ImGuiStyleVar.IndentSpacing, width)
		{
			ImGui.Indent(width);
			var onClose = OnClose;
			OnClose = () =>
			{
				ImGui.Unindent(width);
				onClose?.Invoke();
			};
		}
	}
}
