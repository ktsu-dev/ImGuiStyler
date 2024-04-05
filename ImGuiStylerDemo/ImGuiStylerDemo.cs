namespace ktsu.io.ImGuiWidgetsDemo;

using ImGuiNET;
using ktsu.io.ImGuiApp;
using ktsu.io.ImGuiStyler;

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
		Text.Themed("Hello, ImGuiStyler!");
		ImGui.Button("Button");
		bool valueBool = true;
		ImGui.Checkbox("Checkbox", ref valueBool);
		int valueInt = 0;
		ImGui.DragInt("DragInt", ref valueInt);
		string valueString = "test";
		ImGui.InputText("InputText", ref valueString, 128);
		float valueFloat = 0.0f;
		ImGui.SliderFloat("SliderFloat", ref valueFloat, 0.0f, 1.0f);
		ImGui.Text("Text");
		ImGui.TextColored(new System.Numerics.Vector4(1.0f, 0.0f, 0.0f, 1.0f), "TextColored");
		ImGui.TextDisabled("TextDisabled");
		ImGui.TextWrapped("TextWrapped");
		ImGui.LabelText("LabelText", "value");
		ImGui.BulletText("BulletText");
		ImGui.Bullet();
	}

	private void OnMenu()
	{
	}

	private void OnWindowResized()
	{
	}
}
