namespace ktsu.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

public static class Alignment
{
	public static void Center(Vector2 contentSize, Action contentDrawDelegate) => CenterWithin(contentSize, new Vector2(ImGui.GetContentRegionAvail().X, contentSize.Y), contentDrawDelegate);

	public static void CenterWithin(Vector2 contentSize, Vector2 containerSize, Action contentDrawDelegate)
	{
		// We need to manipulate the cursor a lot to support the layout of this widget and
		// integrate with the layout methods of ImGui (eg. SameLine). Because contentDrawDelegate
		// is called after the Dummy() it means that CursorPosPrevLine is set to an unexpected value
		// so we "abuse" setting the cursor and calling NewLine to force CursorPosPrevLine to be what we need.

		// - Draw a Dummy to progress the cursor to the end of the container and leave it
		//   on a new line. We need this position for later
		// - Move the cursor to the start of where the content will draw
		// - Move the cursor to the top right of the container
		// - Call NewLine() from the top right of the container so that the previous line
		//   position is stored from where the new line started. This allows SameLine() to
		//   work as it will take the current cursor position and revert it to where it was
		//   when NewLine() was called
		// - Move the cursor to where the Dummy progressed it. Any new widgets will be drawn
		//   on that new line.
		var cursorContainerTopLeft = ImGui.GetCursorScreenPos();
		ImGui.Dummy(containerSize);
		var cursorAfterDummy = ImGui.GetCursorScreenPos();
		var clippedsize = new Vector2(Math.Min(contentSize.X, containerSize.X), Math.Min(contentSize.Y, containerSize.Y));
		var offset = (containerSize - clippedsize) / 2;
		var cursorContentStart = cursorContainerTopLeft + offset;
		ImGui.SetCursorScreenPos(cursorContentStart);
		contentDrawDelegate();
		ImGui.SetCursorScreenPos(cursorContainerTopLeft + new Vector2(containerSize.X, 0f));
		ImGui.NewLine();
		ImGui.SetCursorScreenPos(cursorAfterDummy);
	}
}
