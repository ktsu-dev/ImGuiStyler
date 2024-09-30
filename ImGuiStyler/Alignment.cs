namespace ktsu.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

public static class Alignment
{
	public static void Center(float contentWidth) =>
	CenterWithin(contentWidth, ImGui.GetContentRegionAvail().X);

	public static void Center(Vector2 contentSize) =>
	CenterWithin(contentSize, ImGui.GetContentRegionAvail());

	public static void CenterWithin(float contentWidth, float containerWidth)
	{
		float clippedWidth = Math.Min(contentWidth, containerWidth);
		var cursorPos = ImGui.GetCursorScreenPos();
		ImGui.Dummy(new Vector2(containerWidth, 0));
		ImGui.SetCursorScreenPos(cursorPos + new Vector2((containerWidth - clippedWidth) / 2, 0));
	}

	public static void CenterWithin(Vector2 contentSize, Vector2 containerSize)
	{
		var clippedsize = new Vector2(Math.Min(contentSize.X, containerSize.X), Math.Min(contentSize.Y, containerSize.Y));
		var cursorPos = ImGui.GetCursorScreenPos();
		ImGui.Dummy(containerSize);
		var ofset = (containerSize - clippedsize) / 2;
		ImGui.SetCursorScreenPos(cursorPos + ofset);
	}
}
