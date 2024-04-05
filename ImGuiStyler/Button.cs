namespace ktsu.io.ImGuiStyler;

using System.Numerics;
using ImGuiNET;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Button
{
	public static class Alignment
	{
		public static ScopedButtonAlignment Left() => new(new(0f, 0.5f));
		public static ScopedButtonAlignment Center() => new(new(0.5f, 0.5f));
		public class ScopedButtonAlignment : ScopedStyleVar
		{
			public ScopedButtonAlignment(Vector2 vector) : base(ImGuiStyleVar.ButtonTextAlign, vector) { }
		}
	}
}
