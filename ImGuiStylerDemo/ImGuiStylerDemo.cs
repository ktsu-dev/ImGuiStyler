namespace ktsu.ImGuiWidgetsDemo;

using System.Numerics;

using ImGuiNET;

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
		ImGuiStylerDemo imGuiWidgetsDemo = new();
		ImGuiApp.Start(nameof(ImGuiStylerDemo), new ImGuiAppWindowState(), imGuiWidgetsDemo.OnStart, imGuiWidgetsDemo.OnTick, imGuiWidgetsDemo.OnMenu, imGuiWidgetsDemo.OnWindowResized);
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
		ImGui.ProgressBar(0.95f, new(300, 0));
		ImGui.Text("Text");
		ImGui.TextColored(new Vector4(1.0f, 0.0f, 0.0f, 1.0f), "TextColored");
		ImGui.TextDisabled("TextDisabled");
		ImGui.TextWrapped("TextWrapped");
		ImGui.LabelText("LabelText", "value");
		ImGui.BulletText("BulletText");
		ImGui.Bullet();
		string textToCenter = "Centered Text";
		var textSize = ImGui.CalcTextSize(textToCenter);
		using (new Alignment.Center(textSize))
		{
			ImGui.TextUnformatted(textToCenter);
		}

		ImGui.BeginChild("Child", new(100, 100), ImGuiChildFlags.Borders);
		string textToCenterLong = "Loooooooooong Centered Text";
		var longTextSize = ImGui.CalcTextSize(textToCenterLong);
		using (new Alignment.Center(longTextSize))
		{
			ImGui.TextUnformatted(textToCenterLong);
		}

		ImGui.EndChild();

		var boxSize = new Vector2(300, 300);
		string centeredLabel = "Centered";
		var labelSize = ImGui.CalcTextSize(centeredLabel);

		var box1CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box1CursorPos, box1CursorPos + boxSize, 0xFF444444);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		var box2CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box2CursorPos, box2CursorPos + boxSize, 0xFF666666);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		ImGui.SameLine();
		var box3CursorPos = ImGui.GetCursorScreenPos();
		ImGui.GetWindowDrawList().AddRectFilled(box3CursorPos, box3CursorPos + boxSize, 0xFF888888);
		using (new Alignment.CenterWithin(labelSize, boxSize))
		{
			ImGui.TextUnformatted(centeredLabel);
		}

		var box4CursorPos = ImGui.GetCursorScreenPos();
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
