namespace ktsu.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

public static class Alignment
{
	public static void Center(float contentWidth) =>
	CenterWithin(contentWidth, ImGui.GetContentRegionAvail().X);

	public static void CenterWithin(float contentWidth, float maxWidth)
	{
		float clippedWidth = Math.Min(contentWidth, maxWidth);
		var cursorPos = ImGui.GetCursorScreenPos();
		ImGui.SetCursorScreenPos(cursorPos + new Vector2((maxWidth - clippedWidth) / 2, 0));
	}
}
