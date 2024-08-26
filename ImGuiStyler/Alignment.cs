namespace ktsu.io.ImGuiStyler;

using ImGuiNET;

public static class Alignment
{
	public static void Center(float contentWidth) =>
	CenterWithin(contentWidth, ImGui.GetContentRegionAvail().X);

	public static void CenterWithin(float contentWidth, float maxWidth)
	{
		float clippedWidth = Math.Min(contentWidth, maxWidth);
		float cursorPosX = ImGui.GetCursorPosX();
		ImGui.SetCursorPosX(cursorPosX + ((maxWidth - clippedWidth) / 2));
	}
}
