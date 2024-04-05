namespace ktsu.io.ImGuiStyler;

using ImGuiNET;
using ktsu.io.ScopedAction;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
