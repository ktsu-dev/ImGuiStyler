// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiWidgetsDemo;

using System.Numerics;

using Hexa.NET.ImGui;

using ktsu.ImGuiApp;
using ktsu.ImGuiStyler;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
internal class ImGuiStylerDemo
{
	private static bool valueBool = true;
	private static int valueInt;
	private static string valueString = "test";
	private static float valueFloat;

	private static void Main(string[] args)
	{
		ImGuiStylerDemo demo = new();
		ImGuiApp.Start(new()
		{
			Title = "ImGuiStyler Demo",
			OnAppMenu = demo.OnMenu,
			OnMoveOrResize = demo.OnWindowResized,
			OnRender = demo.OnTick,
			OnStart = demo.OnStart,
			SaveIniSettings = false,
		});
	}

	private void OnStart() => Theme.Apply(Theme.Palette.Normal);

	private void OnTick(float dt)
	{
		ImGui.TextUnformatted("Hello, ImGuiStyler!");
		ImGui.Button("Button");
		ImGui.Checkbox("Checkbox", ref valueBool);
		ImGui.DragInt("DragInt", ref valueInt);
		ImGui.InputText("InputText", ref valueString, 128);
		ImGui.SliderFloat("SliderFloat", ref valueFloat, 0.0f, 1.0f);
		ImGui.ProgressBar(0.95f, new Vector2(300, 0));
		ImGui.Text("Text");
		ImGui.TextColored(new Vector4(1.0f, 0.0f, 0.0f, 1.0f), "TextColored");
		ImGui.TextDisabled("TextDisabled");
		ImGui.TextWrapped("TextWrapped");
		ImGui.LabelText("LabelText", "value");
		ImGui.BulletText("BulletText");
		ImGui.Bullet();
		string textToCenter = "Centered Text";
		Vector2 textSize = ImGui.CalcTextSize(textToCenter);
		using (new Alignment.Center(textSize))
		{
			ImGui.TextUnformatted(textToCenter);
		}

		ImGui.BeginChild("Child", new(100, 100), ImGuiChildFlags.Borders);
		string textToCenterLong = "Loooooooooong Centered Text";
		Vector2 longTextSize = ImGui.CalcTextSize(textToCenterLong);
		using (new Alignment.Center(longTextSize))
		{
			ImGui.TextUnformatted(textToCenterLong);
		}

		ImGui.EndChild();

		Vector2 boxSize = new(300, 300);
		string centeredLabel = "Centered";
		Vector2 labelSize = ImGui.CalcTextSize(centeredLabel);

		Vector2 box1CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box1CursorPos, box1CursorPos + boxSize, 0xFF444444);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		Vector2 box2CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box2CursorPos, box2CursorPos + boxSize, 0xFF666666);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		ImGui.SameLine();
		Vector2 box3CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box3CursorPos, box3CursorPos + boxSize, 0xFF888888);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		Vector2 box4CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box4CursorPos, box4CursorPos + boxSize, 0xFFAAAAAA);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}
	}

	private void OnMenu()
	{
	}

	private void OnWindowResized()
	{
	}
}
