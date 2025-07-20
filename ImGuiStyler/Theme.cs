// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;

/// <summary>
/// Provides methods and properties to manage and apply themes for ImGui elements.
/// </summary>
public static class Theme
{
	#region Theme Generation Parameters

	private static float NormalLuminanceMult { get; set; } = 0.4f;
	private static float NormalSaturationMult { get; set; } = 0.5f;
	private static float AccentLuminanceMult { get; set; } = 0.7f;
	private static float AccentSaturationMult { get; set; } = 0.8f;
	private static float AccentHoveredLuminanceMult { get; set; } = 1.0f;
	private static float AccentHoveredSaturationMult { get; set; } = 0.9f;
	private static float AccentHueOffset { get; set; } = 0.5f;
	private static float HeaderLuminanceMult { get; set; } = 0.5f;
	private static float HeaderSaturationMult { get; set; } = 0.6f;
	private static float ActiveLuminanceMult { get; set; } = .6f;
	private static float ActiveSaturationMult { get; set; } = .7f;
	private static float HoverLuminanceMult { get; set; } = .7f;
	private static float HoverSaturationMult { get; set; } = .8f;
	private static float DragLuminanceMult { get; set; } = 1.1f;
	private static float BackgroundLuminanceMult { get; set; } = .13f;
	private static float BackgroundSaturationMult { get; set; } = .05f;
	private static float DisabledSaturationMult { get; set; } = .1f;
	private static float BorderLuminanceMult { get; set; } = .7f;

	#endregion

	#region Color Calculation Methods

	/// <summary>
	/// Gets the state color based on whether it is enabled or disabled.
	/// </summary>
	/// <param name="baseColor">The base color.</param>
	/// <param name="enabled">A boolean indicating if the state is enabled.</param>
	/// <returns>The state color.</returns>
	public static ImColor GetStateColor(ImColor baseColor, bool enabled) => enabled ? baseColor : baseColor.MultiplySaturation(DisabledSaturationMult);

	/// <summary>
	/// Gets the normal color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The normal color.</returns>
	public static ImColor GetNormalColor(ImColor stateColor) => stateColor.MultiplyLuminance(NormalLuminanceMult).MultiplySaturation(NormalSaturationMult);

	/// <summary>
	/// Gets the accent color by adjusting the luminance, saturation, and hue of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The accent color.</returns>
	public static ImColor GetAccentColor(ImColor stateColor) => stateColor.MultiplyLuminance(AccentLuminanceMult).MultiplySaturation(AccentSaturationMult).OffsetHue(AccentHueOffset).WithAlpha(1);

	/// <summary>
	/// Gets the accent hovered color by adjusting the luminance, saturation, and hue of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The accent hovered color.</returns>
	public static ImColor GetAccentHoveredColor(ImColor stateColor) => stateColor.MultiplyLuminance(AccentHoveredLuminanceMult).MultiplySaturation(AccentHoveredSaturationMult).OffsetHue(AccentHueOffset).WithAlpha(1);

	/// <summary>
	/// Gets the header color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The header color.</returns>
	public static ImColor GetHeaderColor(ImColor stateColor) => stateColor.MultiplyLuminance(HeaderLuminanceMult).MultiplySaturation(HeaderSaturationMult);

	/// <summary>
	/// Gets the active color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The active color.</returns>
	public static ImColor GetActiveColor(ImColor stateColor) => stateColor.MultiplyLuminance(ActiveLuminanceMult).MultiplySaturation(ActiveSaturationMult);

	/// <summary>
	/// Gets the hovered color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The hovered color.</returns>
	public static ImColor GetHoveredColor(ImColor stateColor) => stateColor.MultiplyLuminance(HoverLuminanceMult).MultiplySaturation(HoverSaturationMult);

	/// <summary>
	/// Gets the drag color by adjusting the luminance of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The drag color.</returns>
	public static ImColor GetDragColor(ImColor stateColor) => stateColor.MultiplyLuminance(DragLuminanceMult);

	/// <summary>
	/// Gets the background color by adjusting the luminance and saturation of the state color.
	/// </summary>
	/// <param name="stateColor">The state color.</param>
	/// <returns>The background color.</returns>
	public static ImColor GetBackgroundColor(ImColor stateColor) => stateColor.MultiplyLuminance(BackgroundLuminanceMult).MultiplySaturation(BackgroundSaturationMult);

	/// <summary>
	/// Gets the text color that contrasts optimally with the background color.
	/// </summary>
	/// <param name="backgroundColor">The background color.</param>
	/// <returns>The text color.</returns>
	public static ImColor GetTextColor(ImColor backgroundColor) => backgroundColor.CalculateOptimalContrastingColor();

	#endregion

	#region Predefined Themes

	/// <summary>
	/// Dracula theme - Dark purple theme with vibrant colors.
	/// Now generated using intelligent color family selection for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Dracula => PaletteGenerator.CreateDraculaTheme();

	/// <summary>
	/// Nord theme - Arctic, north-bluish color theme.
	/// Now generated using intelligent color family selection for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Nord => PaletteGenerator.CreateNordTheme();

	/// <summary>
	/// VS Code Dark theme - The popular dark theme from Visual Studio Code.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition VSCodeDark => PaletteGenerator.CreateVSCodeDarkTheme();

	/// <summary>
	/// One Dark theme - Popular dark theme with balanced colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition OneDark => PaletteGenerator.CreateOneDarkTheme();

	/// <summary>
	/// Gruvbox Dark theme - Retro groove color scheme with dark background.
	/// Now generated using intelligent color family selection for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition GruvboxDark => PaletteGenerator.CreateGruvboxTheme();

	/// <summary>
	/// Catppuccin Latte theme - Light theme with warm colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition CatppuccinLatte => PaletteGenerator.CreateCatppuccinLatteTheme();

	/// <summary>
	/// Catppuccin Frappe theme - Dark theme with warm purple tones.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition CatppuccinFrappe => PaletteGenerator.CreateCatppuccinFrappeTheme();

	/// <summary>
	/// Catppuccin Macchiato theme - Dark theme with soft purple tones.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition CatppuccinMacchiato => PaletteGenerator.CreateCatppuccinMacchiatoTheme();

	/// <summary>
	/// Catppuccin Mocha theme - Dark theme with blue accents.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition CatppuccinMocha => PaletteGenerator.CreateCatppuccinMochaTheme();

	/// <summary>
	/// Monokai theme - Dark theme with vibrant colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Monokai => PaletteGenerator.CreateMonokaiTheme();

	/// <summary>
	/// Tokyo Night theme - Dark theme inspired by Tokyo's night skyline.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition TokyoNight => PaletteGenerator.CreateTokyoNightTheme();

	/// <summary>
	/// Nightfly theme - Dark theme with cool blue tones.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Nightfly => PaletteGenerator.CreateNightflyTheme();

	/// <summary>
	/// Kanagawa theme - Dark theme with traditional Japanese colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Kanagawa => PaletteGenerator.CreateKanagawaTheme();

	/// <summary>
	/// PaperColor Dark theme - Dark variant with warm colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition PaperColorDark => PaletteGenerator.CreatePaperColorDarkTheme();

	/// <summary>
	/// Nightfox theme - Dark theme with blue and orange accents.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Nightfox => PaletteGenerator.CreateNightfoxTheme();

	/// <summary>
	/// Everforest Dark theme - Dark forest theme with green accents.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition EverforestDark => PaletteGenerator.CreateEverforestDarkTheme();

	/// <summary>
	/// VS Code Light theme - Light theme from Visual Studio Code.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition VSCodeLight => PaletteGenerator.CreateVSCodeLightTheme();

	/// <summary>
	/// Gruvbox Light theme - Light variant of the retro groove color scheme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition GruvboxLight => PaletteGenerator.CreateGruvboxLightTheme();

	/// <summary>
	/// Paper Color Light theme - Light variant with cool colors.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition PaperColorLight => PaletteGenerator.CreatePaperColorLightTheme();

	/// <summary>
	/// Everforest Light theme - Light variant of the forest-inspired theme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition EverforestLight => PaletteGenerator.CreateEverforestLightTheme();

	/// <summary>
	/// Tokyo Night Storm theme - Darker variant of Tokyo Night.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition TokyoNightStorm => PaletteGenerator.CreateTokyoNightStormTheme();

	/// <summary>
	/// Solarized Dark theme - Popular color scheme designed for readability.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition SolarizedDark => PaletteGenerator.CreateSolarizedDarkTheme();

	/// <summary>
	/// Solarized Light theme - Light variant of the popular Solarized color scheme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition SolarizedLight => PaletteGenerator.CreateSolarizedLightTheme();

	/// <summary>
	/// Material Darker theme - Dark variant of Google's Material Design.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition MaterialDarker => PaletteGenerator.CreateMaterialDarkerTheme();

	/// <summary>
	/// Material Ocean theme - Ocean blue variant of Material Design.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition MaterialOcean => PaletteGenerator.CreateMaterialOceanTheme();

	/// <summary>
	/// Material Palenight theme - Purple variant of Material Design.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition MaterialPalenight => PaletteGenerator.CreateMaterialPalenightTheme();

	/// <summary>
	/// Ayu Dark theme - Modern dark theme inspired by Rust.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition AyuDark => PaletteGenerator.CreateAyuDarkTheme();

	/// <summary>
	/// Ayu Light theme - Light variant of the modern Ayu theme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition AyuLight => PaletteGenerator.CreateAyuLightTheme();

	/// <summary>
	/// Ayu Mirage theme - Medium contrast variant of Ayu theme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition AyuMirage => PaletteGenerator.CreateAyuMirageTheme();

	/// <summary>
	/// One Dark Pro theme - Enhanced version of the popular One Dark theme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition OneDarkPro => PaletteGenerator.CreateOneDarkProTheme();

	/// <summary>
	/// Synthwave '84 theme - Retro neon-inspired theme.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition Synthwave84 => PaletteGenerator.CreateSynthwave84Theme();

	/// <summary>
	/// High Contrast Dark theme - Dark theme optimized for accessibility.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition HighContrastDark => PaletteGenerator.CreateHighContrastDarkTheme();

	/// <summary>
	/// High Contrast Light theme - Light theme optimized for accessibility.
	/// Now generated using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	public static ThemeDefinition HighContrastLight => PaletteGenerator.CreateHighContrastLightTheme();

	#endregion

	#region Theme Application

	/// <summary>
	/// Applies a simple color-based theme to ImGui.
	/// </summary>
	/// <param name="baseColor">The base color to generate the theme from.</param>
	public static void Apply(ImColor baseColor)
	{
		ImColor normalColor = GetNormalColor(baseColor);
		ImColor accentColor = GetAccentColor(baseColor);
		ImColor accentHoveredColor = GetAccentHoveredColor(baseColor);
		ImColor headerColor = GetHeaderColor(baseColor);
		ImColor hoveredColor = GetHoveredColor(baseColor);
		ImColor activeColor = GetActiveColor(baseColor);
		ImColor backgroundColor = GetBackgroundColor(baseColor);
		ImColor dragColor = GetDragColor(baseColor);
		ImColor textColor = GetTextColor(backgroundColor);
		ImColor borderColor = textColor.MultiplyLuminance(BorderLuminanceMult);

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = textColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = baseColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = textColor.MultiplySaturation(0.5f).Value;
		colors[(int)ImGuiCol.Button] = normalColor.Value;
		colors[(int)ImGuiCol.ButtonActive] = activeColor.Value;
		colors[(int)ImGuiCol.ButtonHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.CheckMark] = textColor.Value;
		colors[(int)ImGuiCol.Header] = headerColor.Value;
		colors[(int)ImGuiCol.HeaderActive] = activeColor.Value;
		colors[(int)ImGuiCol.HeaderHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.SliderGrab] = dragColor.Value;
		colors[(int)ImGuiCol.SliderGrabActive] = baseColor.Value;
		colors[(int)ImGuiCol.Tab] = normalColor.Value;
		colors[(int)ImGuiCol.TabSelected] = activeColor.Value;
		colors[(int)ImGuiCol.TabHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.TitleBg] = normalColor.Value;
		colors[(int)ImGuiCol.TitleBgActive] = activeColor.Value;
		colors[(int)ImGuiCol.TitleBgCollapsed] = normalColor.Value;
		colors[(int)ImGuiCol.Border] = borderColor.Value;
		colors[(int)ImGuiCol.FrameBg] = normalColor.Value;
		colors[(int)ImGuiCol.FrameBgActive] = activeColor.Value;
		colors[(int)ImGuiCol.FrameBgHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.NavCursor] = activeColor.Value;
		colors[(int)ImGuiCol.ResizeGrip] = normalColor.Value;
		colors[(int)ImGuiCol.ResizeGripActive] = activeColor.Value;
		colors[(int)ImGuiCol.ResizeGripHovered] = hoveredColor.Value;
		colors[(int)ImGuiCol.PlotLines] = accentColor.Value;
		colors[(int)ImGuiCol.PlotLinesHovered] = accentHoveredColor.Value;
		colors[(int)ImGuiCol.PlotHistogram] = accentColor.Value;
		colors[(int)ImGuiCol.PlotHistogramHovered] = accentHoveredColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrab] = normalColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.ScrollbarGrabActive] = activeColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.ScrollbarGrabHovered] = hoveredColor.WithSaturation(0).Value;
		colors[(int)ImGuiCol.WindowBg] = backgroundColor.Value;
		colors[(int)ImGuiCol.ChildBg] = backgroundColor.Value;
		colors[(int)ImGuiCol.PopupBg] = backgroundColor.Value;
	}

	/// <summary>
	/// Applies a complete theme definition to ImGui.
	/// </summary>
	/// <param name="themeDefinition">The complete theme definition to apply.</param>
	public static void Apply(ThemeDefinition themeDefinition)
	{
		ArgumentNullException.ThrowIfNull(themeDefinition, nameof(themeDefinition));

		// Use the theme's original text color to maintain authenticity
		ImColor textColor = themeDefinition.TextColor;

		Span<System.Numerics.Vector4> colors = ImGui.GetStyle().Colors;
		colors[(int)ImGuiCol.Text] = textColor.Value;
		colors[(int)ImGuiCol.TextSelectedBg] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.TextDisabled] = textColor.MultiplySaturation(0.5f).Value;
		colors[(int)ImGuiCol.Button] = themeDefinition.ButtonColor.Value;
		colors[(int)ImGuiCol.ButtonActive] = themeDefinition.ButtonActiveColor.Value;
		colors[(int)ImGuiCol.ButtonHovered] = themeDefinition.ButtonHoveredColor.Value;
		colors[(int)ImGuiCol.CheckMark] = themeDefinition.CheckMarkColor.Value;
		colors[(int)ImGuiCol.Header] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.HeaderActive] = themeDefinition.HeaderActiveColor.Value;
		colors[(int)ImGuiCol.HeaderHovered] = themeDefinition.HeaderHoveredColor.Value;
		colors[(int)ImGuiCol.SliderGrab] = themeDefinition.SliderGrabColor.Value;
		colors[(int)ImGuiCol.SliderGrabActive] = themeDefinition.SliderGrabActiveColor.Value;
		colors[(int)ImGuiCol.Tab] = themeDefinition.TabColor.Value;
		colors[(int)ImGuiCol.TabSelected] = themeDefinition.TabActiveColor.Value;
		colors[(int)ImGuiCol.TabHovered] = themeDefinition.TabHoveredColor.Value;
		colors[(int)ImGuiCol.TitleBg] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.TitleBgActive] = themeDefinition.HeaderActiveColor.Value;
		colors[(int)ImGuiCol.TitleBgCollapsed] = themeDefinition.HeaderColor.Value;
		colors[(int)ImGuiCol.Border] = themeDefinition.BorderColor.Value;
		colors[(int)ImGuiCol.FrameBg] = themeDefinition.FrameColor.Value;
		colors[(int)ImGuiCol.FrameBgActive] = themeDefinition.FrameActiveColor.Value;
		colors[(int)ImGuiCol.FrameBgHovered] = themeDefinition.FrameHoveredColor.Value;
		colors[(int)ImGuiCol.NavCursor] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.ResizeGrip] = themeDefinition.BorderColor.Value;
		colors[(int)ImGuiCol.ResizeGripActive] = themeDefinition.AccentColor.Value;
		colors[(int)ImGuiCol.ResizeGripHovered] = themeDefinition.AccentColor.MultiplySaturation(0.8f).Value;
		colors[(int)ImGuiCol.PlotLines] = themeDefinition.PlotLinesColor.Value;
		colors[(int)ImGuiCol.PlotLinesHovered] = themeDefinition.PlotLinesColor.MultiplyLuminance(1.2f).Value;
		colors[(int)ImGuiCol.PlotHistogram] = themeDefinition.PlotHistogramColor.Value;
		colors[(int)ImGuiCol.PlotHistogramHovered] = themeDefinition.PlotHistogramColor.MultiplyLuminance(1.2f).Value;
		colors[(int)ImGuiCol.ScrollbarGrab] = themeDefinition.ScrollbarColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrabActive] = themeDefinition.ScrollbarActiveColor.Value;
		colors[(int)ImGuiCol.ScrollbarGrabHovered] = themeDefinition.ScrollbarHoveredColor.Value;
		colors[(int)ImGuiCol.WindowBg] = themeDefinition.BackgroundColor.Value;
		colors[(int)ImGuiCol.ChildBg] = themeDefinition.BackgroundColor.Value;
		colors[(int)ImGuiCol.PopupBg] = themeDefinition.BackgroundColor.Value;
	}

	#endregion

	#region Theme Discovery

	/// <summary>
	/// Gets all available palette colors for theming.
	/// </summary>
	public static IReadOnlyList<ThemeInfo> AvailablePaletteColors =>
	[
		new() { Name = "Primary", Description = "Default blue theme", Category = "Basic", Color = Color.Palette.Semantic.Primary },
		new() { Name = "Red", Description = "Vibrant red theme", Category = "Basic", Color = Color.Palette.Basic.Red },
		new() { Name = "Green", Description = "Fresh green theme", Category = "Basic", Color = Color.Palette.Basic.Green },
		new() { Name = "Blue", Description = "Classic blue theme", Category = "Basic", Color = Color.Palette.Basic.Blue },
		new() { Name = "Cyan", Description = "Cool cyan theme", Category = "Basic", Color = Color.Palette.Basic.Cyan },
		new() { Name = "Magenta", Description = "Bold magenta theme", Category = "Basic", Color = Color.Palette.Basic.Magenta },
		new() { Name = "Yellow", Description = "Bright yellow theme", Category = "Basic", Color = Color.Palette.Basic.Yellow },
		new() { Name = "Orange", Description = "Warm orange theme", Category = "Basic", Color = Color.Palette.Basic.Orange },
		new() { Name = "Pink", Description = "Sweet pink theme", Category = "Basic", Color = Color.Palette.Basic.Pink },
		new() { Name = "Purple", Description = "Royal purple theme", Category = "Basic", Color = Color.Palette.Basic.Purple },
		new() { Name = "Dracula", Description = "A dark theme with purple accents", Category = "Dark", Color = Color.Palette.Themes.Dracula },
	];

	/// <summary>
	/// Gets all available complete theme definitions.
	/// </summary>
	public static IReadOnlyList<ThemeDefinitionInfo> AvailableThemeDefinitions =>
	[
		// Light themes
		new() { Name = "Catppuccin Latte", Description = "Light and warm pastel theme", Category = "Light", Definition = CatppuccinLatte },
		new() { Name = "VS Code Light", Description = "The popular light theme from Visual Studio Code", Category = "Light", Definition = VSCodeLight },
		new() { Name = "Gruvbox Light", Description = "Light variant of the retro groove color scheme", Category = "Light", Definition = GruvboxLight },
		new() { Name = "Paper Color Light", Description = "Light variant with cool colors", Category = "Light", Definition = PaperColorLight },
		new() { Name = "Everforest Light", Description = "Light variant of the forest-inspired theme", Category = "Light", Definition = EverforestLight },
		new() { Name = "Solarized Light", Description = "Light variant of the popular Solarized color scheme", Category = "Light", Definition = SolarizedLight },
		new() { Name = "Ayu Light", Description = "Light variant of the modern Ayu theme", Category = "Light", Definition = AyuLight },
		new() { Name = "High Contrast Light", Description = "Light theme optimized for accessibility", Category = "Light", Definition = HighContrastLight },

		// Medium/Mirage themes
		new() { Name = "Ayu Mirage", Description = "Medium contrast variant of Ayu theme", Category = "Medium", Definition = AyuMirage },

		// Dark themes
		new() { Name = "Catppuccin Frappe", Description = "Dark theme with purple accents", Category = "Dark", Definition = CatppuccinFrappe },
		new() { Name = "Catppuccin Macchiato", Description = "Dark theme with soft purple tones", Category = "Dark", Definition = CatppuccinMacchiato },
		new() { Name = "Catppuccin Mocha", Description = "Dark theme with blue accents", Category = "Dark", Definition = CatppuccinMocha },
		new() { Name = "Nord", Description = "A dark theme with cool blue tones inspired by the arctic", Category = "Dark", Definition = Nord },
		new() { Name = "Monokai", Description = "Classic dark theme with bright accents", Category = "Dark", Definition = Monokai },
		new() { Name = "Tokyo Night", Description = "Dark blue theme inspired by Tokyo's night skyline", Category = "Dark", Definition = TokyoNight },
		new() { Name = "Tokyo Night Storm", Description = "Darker variant of Tokyo Night", Category = "Dark", Definition = TokyoNightStorm },
		new() { Name = "Gruvbox Dark", Description = "Retro groove color scheme with warm tones", Category = "Dark", Definition = GruvboxDark },
		new() { Name = "Nightfly", Description = "Dark theme with blue and purple accents", Category = "Dark", Definition = Nightfly },
		new() { Name = "Kanagawa", Description = "Japanese-inspired earthy theme", Category = "Dark", Definition = Kanagawa },
		new() { Name = "Paper Color Dark", Description = "Dark variant with warm colors", Category = "Dark", Definition = PaperColorDark },
		new() { Name = "Dracula", Description = "A dark theme with purple accents and vampire-inspired colors", Category = "Dark", Definition = Dracula },
		new() { Name = "OneDark", Description = "Popular dark theme with balanced colors", Category = "Dark", Definition = OneDark },
		new() { Name = "One Dark Pro", Description = "Enhanced version of the popular One Dark theme", Category = "Dark", Definition = OneDarkPro },
		new() { Name = "Nightfox", Description = "Dark theme with blue and orange accents", Category = "Dark", Definition = Nightfox },
		new() { Name = "Everforest Dark", Description = "Dark forest theme with green accents", Category = "Dark", Definition = EverforestDark },
		new() { Name = "VS Code Dark", Description = "The popular dark theme from Visual Studio Code", Category = "Dark", Definition = VSCodeDark },
		new() { Name = "Solarized Dark", Description = "Popular color scheme designed for readability", Category = "Dark", Definition = SolarizedDark },
		new() { Name = "Material Darker", Description = "Dark variant of Google's Material Design", Category = "Dark", Definition = MaterialDarker },
		new() { Name = "Material Ocean", Description = "Ocean blue variant of Material Design", Category = "Dark", Definition = MaterialOcean },
		new() { Name = "Material Palenight", Description = "Purple variant of Material Design", Category = "Dark", Definition = MaterialPalenight },
		new() { Name = "Ayu Dark", Description = "Modern dark theme inspired by Rust", Category = "Dark", Definition = AyuDark },
		new() { Name = "Synthwave '84", Description = "Retro neon-inspired theme", Category = "Dark", Definition = Synthwave84 },
		new() { Name = "High Contrast Dark", Description = "Dark theme optimized for accessibility", Category = "Dark", Definition = HighContrastDark },
	];

	#endregion

	#region Scoped Theme Colors

	/// <summary>
	/// Creates a scoped theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance.</returns>
	public static ScopedThemeColor FromColor(ImColor color) => new(color, enabled: true);

	/// <summary>
	/// Creates a scoped disabled theme color that automatically reverts when disposed.
	/// </summary>
	/// <param name="color">The color to apply to the theme.</param>
	/// <returns>A scoped theme color instance with disabled state.</returns>
	public static ScopedThemeColor DisabledFromColor(ImColor color) => new(color, enabled: false);

	#endregion
}
