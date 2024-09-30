namespace ktsu.ImGuiWidgetsDemo;

using System.Numerics;
using ImGuiNET;
using ktsu.ImGuiApp;
using ktsu.ImGuiStyler;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
internal class ImGuiStylerDemo
{
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
		bool valueBool = true;
		ImGui.Checkbox("Checkbox", ref valueBool);
		int valueInt = 0;
		ImGui.DragInt("DragInt", ref valueInt);
		string valueString = "test";
		ImGui.InputText("InputText", ref valueString, 128);
		float valueFloat = 0.0f;
		ImGui.SliderFloat("SliderFloat", ref valueFloat, 0.0f, 1.0f);
		ImGui.ProgressBar(0.95f, new(300, 0));
		ImGui.Text("Text");
		ImGui.TextColored(new System.Numerics.Vector4(1.0f, 0.0f, 0.0f, 1.0f), "TextColored");
		ImGui.TextDisabled("TextDisabled");
		ImGui.TextWrapped("TextWrapped");
		ImGui.LabelText("LabelText", "value");
		ImGui.BulletText("BulletText");
		ImGui.Bullet();
		string textToCenter = "Centered Text";
		float textWidth = ImGui.CalcTextSize(textToCenter).X;
		Alignment.Center(textWidth);
		ImGui.TextUnformatted(textToCenter);

		ImGui.BeginChild("Child", new(100, 100), ImGuiChildFlags.Border);
		string textToCenterLong = "Loooooooooong Centered Text";
		float textWidthLong = ImGui.CalcTextSize(textToCenterLong).X;
		Alignment.Center(textWidthLong);
		ImGui.TextUnformatted(textToCenterLong);
		ImGui.EndChild();

		var cursorPos = ImGui.GetCursorScreenPos();
		var boxSize = new Vector2(300, 300);
		ImGui.GetWindowDrawList().AddRectFilled(cursorPos, cursorPos + boxSize, 0xFF666666);

		string centeredLabel = "Centered";
		var labelSize = ImGui.CalcTextSize(centeredLabel);

		Alignment.CenterWithin(labelSize, boxSize);
		ImGui.TextUnformatted(centeredLabel);
	}

	private void OnMenu()
	{
	}

	private void OnWindowResized()
	{
	}
}
