namespace ktsu.io.ImGuiStyler;

using System.Numerics;
using ImGuiNET;
using ktsu.io.ScopedAction;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class ScopedStyleVar : ScopedAction
{
	public ScopedStyleVar(ImGuiStyleVar target, Vector2 vector)
	{
		ImGui.PushStyleVar(target, vector);
		OnClose = ImGui.PopStyleVar;
	}

	public ScopedStyleVar(ImGuiStyleVar target, float scalar)
	{
		ImGui.PushStyleVar(target, scalar);
		OnClose = ImGui.PopStyleVar;
	}
}
