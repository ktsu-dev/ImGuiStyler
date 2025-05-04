# ImGuiStyler

ImGuiStyler is a utility library designed to simplify and enhance styling in [ImGui](https://github.com/ocornut/imgui). It provides scoped, reusable, and extensible components for aligning content, managing colors, styling text, and applying themes.

## Features

- **Alignment**: Center and align content effortlessly within containers.
- **Scoped Styling**: Utilize scoped style variables for precise UI customizations.
- **Color Management**: Convert and manipulate colors, ensuring optimal contrast.
- **Button Styling**: Create and align buttons with ease.
- **Text Handling**: Define and apply text colors and styles.
- **Theme Support**: Apply cohesive themes to standardize the look and feel of your application.

## Installation

Add the package references in your `.csproj` file:

```xml
<PackageReference Include="ktsu.ImGuiStyler" Version="1.0.36" />
```

## Usage

### Scoped Alignment

```csharp
using ktsu.ImGuiStyler;
using System.Numerics;

// Center content within a region
string text = "Centered Text";
Vector2 textSize = ImGui.CalcTextSize(text);
using (new Alignment.Center(textSize))
{
    ImGui.Text(text);
}
```

### Scoped Styling

```csharp
using ktsu.ImGuiStyler;

using (new ScopedStyleVar(ImGuiStyleVar.FrameRounding, 5.0f))
{
    ImGui.Button("Styled Button");
}
```

### Scoped Color

```csharp
using ktsu.ImGuiStyler;

using (new ScopedColor(ImGuiCol.Text, Color.AmethystPurple))
{
    ImGui.Text("Colored Text");
}
```

### Scoped Themes

```csharp
using ktsu.ImGuiStyler;

using (new ScopedThemeColor(Color.AmethystPurple))
{
    ImGui.Text("Themed Text");
    ImGui.Button("Themed Button");
}
```

## Contributing

Contributions are welcome! If you find a bug or have an idea for a feature, please submit an issue or a pull request.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Contact

For questions or support, please open an issue or contact the maintainer through GitHub.
