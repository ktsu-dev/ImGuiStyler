namespace ktsu.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

public static class Alignment
{
	public static void Center(Vector2 contentSize, Action contentDrawDelegate) => CenterWithin(contentSize, new Vector2(ImGui.GetContentRegionAvail().X, contentSize.Y), contentDrawDelegate);

	public static void CenterWithin(Vector2 contentSize, Vector2 containerSize, Action contentDrawDelegate)
	{
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
