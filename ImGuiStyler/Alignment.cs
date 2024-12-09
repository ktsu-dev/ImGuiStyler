namespace ktsu.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

public static class Alignment
{
	public static void Center(Vector2 contentSize, Action contentDrawDelegate) => CenterWithin(contentSize, new Vector2(ImGui.GetContentRegionAvail().X, contentSize.Y), contentDrawDelegate);

	public static void CenterWithin(Vector2 contentSize, Vector2 containerSize, Action contentDrawDelegate)
	{
		// NOTE: This implementation does NOT work with ImGui.SameLine().
		// ImGui.Dummy() will update CursorPos and CursorPosPrevLine correctly,
		// but anything that happens in contentDrawDelegate will overwrite that.
		// Putting ImGui.Dummy() at the end of this function will work, but that
		// will cause the Dummy() component to render over the content and capture
		// clicks, hovers etc. As ImGui.NET doesn't expose imgui_internal.h
		// there isn't much we can do to solve this
		var cursorStartPos = ImGui.GetCursorScreenPos();
		ImGui.Dummy(containerSize);
		var cursorEndPos = ImGui.GetCursorScreenPos();
		var clippedsize = new Vector2(Math.Min(contentSize.X, containerSize.X), Math.Min(contentSize.Y, containerSize.Y));
		var ofset = (containerSize - clippedsize) / 2;
		ImGui.SetCursorScreenPos(cursorStartPos + ofset);
		contentDrawDelegate();
		ImGui.SetCursorScreenPos(cursorEndPos);
	}
}
