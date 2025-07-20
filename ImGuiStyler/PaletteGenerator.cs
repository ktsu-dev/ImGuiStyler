// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using Hexa.NET.ImGui;
using ktsu.ImGuiStyler.ThemeSources;

/// <summary>
/// Unified palette generator that provides both simple theme creation methods and sophisticated
/// relationship-based palette generation, combining optimal contrast with authentic color preservation.
/// </summary>
/// <param name="relationships">The color family relationships defining the rendering constraints.</param>
/// <param name="preferredColors">Optional dictionary of preferred authentic colors to stay close to.</param>
public class PaletteGenerator(IEnumerable<ColorFamilyRelationship> relationships, Dictionary<string, ImColor>? preferredColors = null)
{
	private readonly List<ColorFamilyRelationship> relationships = [.. relationships];
	private readonly Dictionary<string, ImColor> preferredColors = preferredColors ?? [];

	/// <summary>
	/// Generates an optimal palette that satisfies all contrast relationships while staying as close
	/// as possible to the preferred authentic colors.
	/// </summary>
	/// <returns>An optimal palette containing the selected colors and quality metrics.</returns>
	public OptimalPalette GeneratePalette()
	{
		Dictionary<string, ImColor> paletteColors = [];
		List<OptimalColorPair> pairResults = [];
		List<string> warnings = [];

		float totalQualityScore = 0f;
		int processedRelationships = 0;

		// Process each relationship to find optimal color pairs
		foreach (ColorFamilyRelationship relationship in relationships)
		{
			// Look for preferred colors that match this relationship
			ImColor? preferredFg = FindPreferredColor(relationship.ForegroundFamily);
			ImColor? preferredBg = FindPreferredColor(relationship.BackgroundFamily);

			// Find the optimal pair for this relationship
			OptimalColorPair pair = relationship.FindOptimalPair(preferredFg, preferredBg);
			pairResults.Add(pair);

			// Store colors using family names as keys
			string fgKey = relationship.ForegroundFamily.Name;
			string bgKey = relationship.BackgroundFamily.Name;

			// Only update if this is a better quality result or first occurrence
			if (!paletteColors.ContainsKey(fgKey) || pair.QualityScore > GetPairQuality(paletteColors.GetValueOrDefault(fgKey), pair.Background, relationship))
			{
				paletteColors[fgKey] = pair.Foreground;
			}

			if (!paletteColors.ContainsKey(bgKey) || pair.QualityScore > GetPairQuality(pair.Foreground, paletteColors.GetValueOrDefault(bgKey), relationship))
			{
				paletteColors[bgKey] = pair.Background;
			}

			// Track quality metrics
			totalQualityScore += pair.QualityScore;
			processedRelationships++;

			// Add warnings if contrast is not optimal
			if (pair.ContrastRatio < relationship.PreferredContrast)
			{
				warnings.Add($"{fgKey}/{bgKey}: Contrast {pair.ContrastRatio:F2} is below preferred {relationship.PreferredContrast:F2}");
			}
		}

		float averageQuality = processedRelationships > 0 ? totalQualityScore / processedRelationships : 0f;

		return new OptimalPalette(paletteColors, pairResults, averageQuality, warnings);
	}

	/// <summary>
	/// Generates a theme definition from the optimal palette using standard UI element mapping.
	/// </summary>
	/// <param name="textColorKey">The key for the main text color in the palette.</param>
	/// <param name="backgroundColorKey">The key for the main background color in the palette.</param>
	/// <param name="accentColorKey">The key for the accent color in the palette.</param>
	/// <returns>A complete theme definition ready for use.</returns>
	public ThemeDefinition GenerateThemeDefinition(string textColorKey = "Text", string backgroundColorKey = "Background", string accentColorKey = "Accent")
	{
		OptimalPalette palette = GeneratePalette();
		return CreateThemeFromPalette(palette, textColorKey, backgroundColorKey, accentColorKey);
	}

	#region Static Theme Generation Methods

	/// <summary>
	/// Creates a Dracula theme using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	/// <returns>An optimized Dracula theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateDraculaTheme()
	{
		// Define color family relationships for Dracula theme
		List<ColorFamilyRelationship> relationships = [
			// Text must have excellent contrast over all backgrounds
			new(ThemeSwatches.Dracula.Text, ThemeSwatches.Dracula.Backgrounds, 4.5f, 7.0f),

			// Accents need good visibility over backgrounds
			new(ThemeSwatches.Dracula.Accents, ThemeSwatches.Dracula.Backgrounds, 3.0f, 4.5f),

			// Text must be readable over neutral UI surfaces
			new(ThemeSwatches.Dracula.Text, ThemeSwatches.Dracula.Neutrals, 4.5f, 7.0f),

			// Accents should stand out over neutral surfaces
			new(ThemeSwatches.Dracula.Accents, ThemeSwatches.Dracula.Neutrals, 3.0f, 4.5f)
		];

		// Preferred authentic colors to preserve theme identity
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Dracula.Foreground,
			["Background"] = Dracula.Background,
			["Accent"] = Dracula.Purple,
			["Neutral"] = Dracula.CurrentLine
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Nord theme using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	/// <returns>An optimized Nord theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateNordTheme()
	{
		// Define color family relationships for Nord theme
		List<ColorFamilyRelationship> relationships = [
			// Text must have excellent contrast over polar night backgrounds
			new(ThemeSwatches.Nord.Text, ThemeSwatches.Nord.Backgrounds, 4.5f, 7.0f),

			// Frost accents need good visibility over backgrounds
			new(ThemeSwatches.Nord.Accents, ThemeSwatches.Nord.Backgrounds, 3.0f, 4.5f),

			// Aurora colors should pop over backgrounds
			new(ThemeSwatches.Nord.Aurora, ThemeSwatches.Nord.Backgrounds, 3.0f, 4.5f),

			// Text must be readable over neutral surfaces
			new(ThemeSwatches.Nord.Text, ThemeSwatches.Nord.Neutrals, 4.5f, 7.0f),

			// Frost accents should work well over neutrals
			new(ThemeSwatches.Nord.Accents, ThemeSwatches.Nord.Neutrals, 3.0f, 4.5f)
		];

		// Preferred authentic Nord colors
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Nord.Nord4,
			["Background"] = Nord.Nord0,
			["Accent"] = Nord.Nord10,
			["Neutral"] = Nord.Nord1,
			["Aurora"] = Nord.Nord14
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Gruvbox theme using intelligent color family relationships for optimal contrast and authenticity.
	/// </summary>
	/// <returns>An optimized Gruvbox theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateGruvboxTheme()
	{
		// Define color family relationships for Gruvbox theme
		List<ColorFamilyRelationship> relationships = [
			// Text must have excellent contrast over dark backgrounds
			new(ThemeSwatches.Gruvbox.Text, ThemeSwatches.Gruvbox.Backgrounds, 4.5f, 7.0f),

			// Bright accents need strong visibility over backgrounds
			new(ThemeSwatches.Gruvbox.BrightAccents, ThemeSwatches.Gruvbox.Backgrounds, 3.0f, 4.5f),

			// Neutral accents should work over backgrounds
			new(ThemeSwatches.Gruvbox.NeutralAccents, ThemeSwatches.Gruvbox.Backgrounds, 3.0f, 4.5f),

			// Text must be readable over neutral surfaces
			new(ThemeSwatches.Gruvbox.Text, ThemeSwatches.Gruvbox.Neutrals, 4.5f, 7.0f),

			// Bright accents should stand out over neutrals
			new(ThemeSwatches.Gruvbox.BrightAccents, ThemeSwatches.Gruvbox.Neutrals, 3.0f, 4.5f)
				];

		// Preferred authentic Gruvbox colors
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Gruvbox.Light1,
			["Background"] = Gruvbox.Dark0,
			["Accent"] = Gruvbox.BrightOrange,
			["Neutral"] = Gruvbox.Dark1,
			["BrightAccent"] = Gruvbox.BrightBlue
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "BrightAccent");
	}

	/// <summary>
	/// Creates a VSCode Dark theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized VSCode Dark theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateVSCodeDarkTheme()
	{
		// Define color family relationships for VSCode Dark theme
		List<ColorFamilyRelationship> relationships = [
			// Text must have excellent contrast over backgrounds
			new(ThemeSwatches.VSCode.Dark.Text, ThemeSwatches.VSCode.Dark.Backgrounds, 4.5f, 7.0f),

			// Accents need good visibility over backgrounds
			new(ThemeSwatches.VSCode.Dark.Accents, ThemeSwatches.VSCode.Dark.Backgrounds, 3.0f, 4.5f),

			// Text must be readable over neutral surfaces
			new(ThemeSwatches.VSCode.Dark.Text, ThemeSwatches.VSCode.Dark.Neutrals, 4.5f, 7.0f),

			// Accents should work over neutrals
			new(ThemeSwatches.VSCode.Dark.Accents, ThemeSwatches.VSCode.Dark.Neutrals, 3.0f, 4.5f)
		];

		// Preferred authentic VSCode colors
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = VSCode.Dark.Foreground,
			["Background"] = VSCode.Dark.Background,
			["Accent"] = VSCode.Dark.AccentBlue,
			["Neutral"] = VSCode.Dark.Button
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates an OneDark theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized OneDark theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateOneDarkTheme()
	{
		// Define color family relationships for OneDark theme
		List<ColorFamilyRelationship> relationships = [
			// Text must have excellent contrast over backgrounds
			new(ThemeSwatches.OneDark.Text, ThemeSwatches.OneDark.Backgrounds, 4.5f, 7.0f),

			// Accents need good visibility over backgrounds
			new(ThemeSwatches.OneDark.Accents, ThemeSwatches.OneDark.Backgrounds, 3.0f, 4.5f),

			// Text must be readable over neutral surfaces
			new(ThemeSwatches.OneDark.Text, ThemeSwatches.OneDark.Neutrals, 4.5f, 7.0f),

			// Accents should work over neutrals
			new(ThemeSwatches.OneDark.Accents, ThemeSwatches.OneDark.Neutrals, 3.0f, 4.5f)
		];

		// Preferred authentic OneDark colors
		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = OneDark.Foreground,
			["Background"] = OneDark.Background,
			["Accent"] = OneDark.Blue,
			["Neutral"] = OneDark.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Catppuccin Latte theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Catppuccin Latte theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateCatppuccinLatteTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Catppuccin.Latte.Text, ThemeSwatches.Catppuccin.Latte.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Latte.Accents, ThemeSwatches.Catppuccin.Latte.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Catppuccin.Latte.Text, ThemeSwatches.Catppuccin.Latte.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Latte.Accents, ThemeSwatches.Catppuccin.Latte.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = CatppuccinLatte.Text,
			["Background"] = CatppuccinLatte.Base,
			["Accent"] = CatppuccinLatte.Mauve,
			["Neutral"] = CatppuccinLatte.Surface0
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Catppuccin Frappe theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Catppuccin Frappe theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateCatppuccinFrappeTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Catppuccin.Frappe.Text, ThemeSwatches.Catppuccin.Frappe.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Frappe.Accents, ThemeSwatches.Catppuccin.Frappe.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Catppuccin.Frappe.Text, ThemeSwatches.Catppuccin.Frappe.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Frappe.Accents, ThemeSwatches.Catppuccin.Frappe.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = CatppuccinFrappe.Text,
			["Background"] = CatppuccinFrappe.Base,
			["Accent"] = CatppuccinFrappe.Mauve,
			["Neutral"] = CatppuccinFrappe.Surface0
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Catppuccin Macchiato theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Catppuccin Macchiato theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateCatppuccinMacchiatoTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Catppuccin.Macchiato.Text, ThemeSwatches.Catppuccin.Macchiato.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Macchiato.Accents, ThemeSwatches.Catppuccin.Macchiato.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Catppuccin.Macchiato.Text, ThemeSwatches.Catppuccin.Macchiato.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Macchiato.Accents, ThemeSwatches.Catppuccin.Macchiato.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = CatppuccinMacchiato.Text,
			["Background"] = CatppuccinMacchiato.Base,
			["Accent"] = CatppuccinMacchiato.Mauve,
			["Neutral"] = CatppuccinMacchiato.Surface0
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Catppuccin Mocha theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Catppuccin Mocha theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateCatppuccinMochaTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Catppuccin.Mocha.Text, ThemeSwatches.Catppuccin.Mocha.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Mocha.Accents, ThemeSwatches.Catppuccin.Mocha.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Catppuccin.Mocha.Text, ThemeSwatches.Catppuccin.Mocha.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Catppuccin.Mocha.Accents, ThemeSwatches.Catppuccin.Mocha.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = CatppuccinMocha.Text,
			["Background"] = CatppuccinMocha.Base,
			["Accent"] = CatppuccinMocha.Blue,
			["Neutral"] = CatppuccinMocha.Surface0
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Monokai theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Monokai theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateMonokaiTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Monokai.Text, ThemeSwatches.Monokai.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Monokai.Accents, ThemeSwatches.Monokai.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Monokai.Text, ThemeSwatches.Monokai.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Monokai.Accents, ThemeSwatches.Monokai.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Monokai.Foreground,
			["Background"] = Monokai.Background,
			["Accent"] = Monokai.Pink,
			["Neutral"] = Monokai.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Tokyo Night theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Tokyo Night theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateTokyoNightTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.TokyoNight.Text, ThemeSwatches.TokyoNight.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.TokyoNight.Accents, ThemeSwatches.TokyoNight.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.TokyoNight.Text, ThemeSwatches.TokyoNight.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.TokyoNight.Accents, ThemeSwatches.TokyoNight.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = TokyoNight.Fg,
			["Background"] = TokyoNight.Bg,
			["Accent"] = TokyoNight.Blue,
			["Neutral"] = TokyoNight.BgHighlight
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Nightfly theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Nightfly theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateNightflyTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Nightfly.Text, ThemeSwatches.Nightfly.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Nightfly.Accents, ThemeSwatches.Nightfly.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Nightfly.Text, ThemeSwatches.Nightfly.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Nightfly.Accents, ThemeSwatches.Nightfly.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Nightfly.Foreground,
			["Background"] = Nightfly.Background,
			["Accent"] = Nightfly.Blue,
			["Neutral"] = Nightfly.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Kanagawa theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Kanagawa theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateKanagawaTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Kanagawa.Text, ThemeSwatches.Kanagawa.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Kanagawa.Accents, ThemeSwatches.Kanagawa.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Kanagawa.Text, ThemeSwatches.Kanagawa.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Kanagawa.Accents, ThemeSwatches.Kanagawa.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Kanagawa.Foreground,
			["Background"] = Kanagawa.Background,
			["Accent"] = Kanagawa.CrystalBlue,
			["Neutral"] = Kanagawa.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a PaperColor Dark theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized PaperColor Dark theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreatePaperColorDarkTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.PaperColor.Dark.Text, ThemeSwatches.PaperColor.Dark.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.PaperColor.Dark.Accents, ThemeSwatches.PaperColor.Dark.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.PaperColor.Dark.Text, ThemeSwatches.PaperColor.Dark.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.PaperColor.Dark.Accents, ThemeSwatches.PaperColor.Dark.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = PaperColor.Dark.Foreground,
			["Background"] = PaperColor.Dark.Background,
			["Accent"] = PaperColor.Dark.Blue,
			["Neutral"] = PaperColor.Dark.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a PaperColor Light theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized PaperColor Light theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreatePaperColorLightTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.PaperColor.Light.Text, ThemeSwatches.PaperColor.Light.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.PaperColor.Light.Accents, ThemeSwatches.PaperColor.Light.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.PaperColor.Light.Text, ThemeSwatches.PaperColor.Light.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.PaperColor.Light.Accents, ThemeSwatches.PaperColor.Light.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = PaperColor.Light.Foreground,
			["Background"] = PaperColor.Light.Background,
			["Accent"] = PaperColor.Light.Blue,
			["Neutral"] = PaperColor.Light.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a Nightfox theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized Nightfox theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateNightfoxTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.Nightfox.Text, ThemeSwatches.Nightfox.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.Nightfox.Accents, ThemeSwatches.Nightfox.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.Nightfox.Text, ThemeSwatches.Nightfox.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.Nightfox.Accents, ThemeSwatches.Nightfox.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = Nightfox.Foreground,
			["Background"] = Nightfox.Background,
			["Accent"] = Nightfox.Blue,
			["Neutral"] = Nightfox.Selection
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	/// <summary>
	/// Creates a VSCode Light theme using intelligent color family relationships.
	/// </summary>
	/// <returns>An optimized VSCode Light theme definition using relationship-based palette generation.</returns>
	public static ThemeDefinition CreateVSCodeLightTheme()
	{
		List<ColorFamilyRelationship> relationships = [
			new(ThemeSwatches.VSCode.Light.Text, ThemeSwatches.VSCode.Light.Backgrounds, 4.5f, 7.0f),
			new(ThemeSwatches.VSCode.Light.Accents, ThemeSwatches.VSCode.Light.Backgrounds, 3.0f, 4.5f),
			new(ThemeSwatches.VSCode.Light.Text, ThemeSwatches.VSCode.Light.Neutrals, 4.5f, 7.0f),
			new(ThemeSwatches.VSCode.Light.Accents, ThemeSwatches.VSCode.Light.Neutrals, 3.0f, 4.5f)
		];

		Dictionary<string, ImColor> preferredColors = new()
		{
			["Text"] = VSCode.Light.Foreground,
			["Background"] = VSCode.Light.Background,
			["Accent"] = VSCode.Light.AccentBlue,
			["Neutral"] = VSCode.Light.Button
		};

		PaletteGenerator generator = new(relationships, preferredColors);
		return generator.GenerateThemeDefinition("Text", "Background", "Accent");
	}

	#endregion

	#region Private Helper Methods

	/// <summary>
	/// Finds a preferred color that matches a color family's characteristics.
	/// </summary>
	/// <param name="family">The color family to match against.</param>
	/// <returns>The preferred color if found, null otherwise.</returns>
	private ImColor? FindPreferredColor(ColorFamily family)
	{
		if (preferredColors.TryGetValue(family.Name, out ImColor color))
		{
			return color;
		}

		// Try to find a color by partial name matching
		foreach (KeyValuePair<string, ImColor> kvp in preferredColors)
		{
			if (family.Name.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase) ||
				kvp.Key.Contains(family.Name, StringComparison.OrdinalIgnoreCase))
			{
				return kvp.Value;
			}
		}

		return null;
	}

	/// <summary>
	/// Calculates the quality score for a color pair within a relationship context.
	/// </summary>
	private static float GetPairQuality(ImColor foreground, ImColor background, ColorFamilyRelationship relationship)
	{
		float contrast = foreground.GetContrastRatioOver(background);
		float contrastScore = Math.Min(contrast / relationship.PreferredContrast, 1.0f);

		return contrastScore * 100f; // Simple quality metric
	}

	/// <summary>
	/// Creates a sophisticated theme definition from an optimal palette using intelligent color mapping.
	/// </summary>
	private static ThemeDefinition CreateThemeFromPalette(OptimalPalette palette, string textColorKey, string backgroundColorKey, string accentColorKey)
	{
		// Get core colors from palette using smart key lookup
		ImColor textColor = FindColorByKey(palette, textColorKey) ?? Color.FromRGB(255, 255, 255);
		ImColor backgroundColor = FindColorByKey(palette, backgroundColorKey) ?? Color.FromRGB(0, 0, 0);
		ImColor accentColor = FindColorByKey(palette, accentColorKey) ?? Color.FromRGB(100, 150, 255);

		// Find a suitable neutral/surface color from the palette
		// Look for colors that aren't the main text, background, or accent colors
		ImColor neutralColor = backgroundColor.AdjustForSufficientContrast(textColor);

		// Try to find a better neutral color from palette if possible
		foreach (ImColor color in palette.Colors.Values)
		{
			if (textColor.GetContrastRatioOver(color) >= 4.5f &&
				color.GetColorDistance(textColor) > 0.2f &&
				color.GetColorDistance(backgroundColor) > 0.1f &&
				color.GetColorDistance(accentColor) > 0.1f)
			{
				neutralColor = color;
				break;
			}
		}

		// Create hover variants with more pronounced visual feedback
		ImColor buttonHoverColor = neutralColor.MultiplyLuminance(neutralColor.GetRelativeLuminance() < 0.5f ? 1.4f : 0.7f);
		ImColor scrollbarHoverColor = accentColor.MultiplyLuminance(0.9f);
		ImColor sliderActiveColor = accentColor.MultiplySaturation(1.1f);

		// Ensure hover states are sufficiently distinct and maintain good contrast
		// Use a limited retry approach to avoid infinite loops
		int maxRetries = 3;
		int retries = 0;
		while (neutralColor.GetColorDistance(buttonHoverColor) < 0.05f && retries < maxRetries)
		{
			buttonHoverColor = neutralColor.GetRelativeLuminance() < 0.5f ?
				buttonHoverColor.MultiplyLuminance(1.3f) : buttonHoverColor.MultiplyLuminance(0.75f);
			retries++;
		}

		// If still not distinct enough, try a different approach
		if (neutralColor.GetColorDistance(buttonHoverColor) < 0.05f)
		{
			// Use hue shift as fallback for distinctiveness
			buttonHoverColor = neutralColor.OffsetHue(15f);

			// If still not distinct enough after hue shift, try a more aggressive luminance change
			if (neutralColor.GetColorDistance(buttonHoverColor) < 0.05f)
			{
				buttonHoverColor = neutralColor.GetRelativeLuminance() < 0.5f ?
					neutralColor.MultiplyLuminance(2.0f) : neutralColor.MultiplyLuminance(0.5f);
			}
		}

		// Final check - ensure minimum distinctiveness for tests
		if (neutralColor.GetColorDistance(buttonHoverColor) < 0.04f)
		{
			// Last resort: adjust saturation as well
			buttonHoverColor = buttonHoverColor.MultiplySaturation(1.5f);
		}

		// Ensure button hover still has good contrast with text
		if (textColor.GetContrastRatioOver(buttonHoverColor) < 4.5f)
		{
			buttonHoverColor = buttonHoverColor.AdjustForSufficientContrast(textColor);
		}

		// Create a tab active color that ensures good contrast with text
		// Use a version of accent color adjusted for sufficient text contrast
		ImColor tabActiveColor = accentColor.AdjustForSufficientContrast(textColor);

		// If tab active color is too similar to accent, create a darker/lighter variant
		if (tabActiveColor.GetColorDistance(accentColor) < 0.1f)
		{
			tabActiveColor = accentColor.GetRelativeLuminance() < 0.5f ?
				accentColor.MultiplyLuminance(1.4f) : accentColor.MultiplyLuminance(0.7f);
			tabActiveColor = tabActiveColor.AdjustForSufficientContrast(textColor);
		}

		// Ensure accent color itself has good background contrast
		if (accentColor.GetContrastRatioOver(backgroundColor) < 3.0f)
		{
			accentColor = accentColor.AdjustForSufficientContrast(backgroundColor, 3.0f);
		}

		// Create plot colors that are distinct from accent but still harmonious
		ImColor plotLinesColor = accentColor.GetContrastRatioOver(backgroundColor) >= 3.0f ?
			accentColor : accentColor.AdjustForSufficientContrast(backgroundColor, 3.0f);
		ImColor plotHistogramColor = plotLinesColor.OffsetHue(30f);

		// Ensure plot histogram has sufficient contrast
		if (plotHistogramColor.GetContrastRatioOver(backgroundColor) < 3.0f)
		{
			plotHistogramColor = plotHistogramColor.AdjustForSufficientContrast(backgroundColor, 3.0f);
		}

		return new ThemeDefinition
		{
			BackgroundColor = backgroundColor,
			TextColor = textColor,
			AccentColor = accentColor,

			ButtonColor = neutralColor,
			ButtonHoveredColor = buttonHoverColor,
			ButtonActiveColor = tabActiveColor, // Use the same logic as tab active for consistency

			FrameColor = neutralColor,
			FrameHoveredColor = buttonHoverColor,
			FrameActiveColor = tabActiveColor,

			HeaderColor = neutralColor,
			HeaderHoveredColor = buttonHoverColor,
			HeaderActiveColor = tabActiveColor,

			BorderColor = textColor.WithAlpha(0.3f), // Subtle border
			ScrollbarColor = neutralColor,
			ScrollbarHoveredColor = scrollbarHoverColor,
			ScrollbarActiveColor = accentColor,

			CheckMarkColor = plotLinesColor, // Use plot lines color which has good contrast
			SliderGrabColor = accentColor,
			SliderGrabActiveColor = sliderActiveColor,

			TabColor = neutralColor,
			TabHoveredColor = buttonHoverColor,
			TabActiveColor = tabActiveColor,

			PlotLinesColor = plotLinesColor,
			PlotHistogramColor = plotHistogramColor
		};
	}

	/// <summary>
	/// Finds a color in the palette by its key name, allowing for partial matches.
	/// </summary>
	/// <param name="palette">The optimal palette to search.</param>
	/// <param name="keyName">The name of the color family to find.</param>
	/// <returns>The optimal color if found, null otherwise.</returns>
	private static ImColor? FindColorByKey(OptimalPalette palette, string keyName)
	{
		// Try exact match first
		if (palette.Colors.TryGetValue(keyName, out ImColor color))
		{
			return color;
		}

		// Try partial matches (e.g., "Text" -> "TextColor")
		foreach (KeyValuePair<string, ImColor> kvp in palette.Colors)
		{
			if (kvp.Key.Contains(keyName, StringComparison.OrdinalIgnoreCase) ||
				keyName.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
			{
				return kvp.Value;
			}
		}

		return null;
	}

	#endregion
}

/// <summary>
/// Represents an optimal color palette generated from color family relationships.
/// </summary>
/// <param name="colors">Dictionary of color family names to optimal colors.</param>
/// <param name="colorPairs">List of all optimal color pairs found during generation.</param>
/// <param name="averageQuality">Average quality score across all color relationships.</param>
/// <param name="warnings">List of warnings about contrast or quality issues.</param>
public class OptimalPalette(Dictionary<string, ImColor> colors, IReadOnlyList<OptimalColorPair> colorPairs,
	float averageQuality, IReadOnlyList<string> warnings)
{
	/// <summary>Gets the dictionary of optimal colors keyed by color family name.</summary>
	public Dictionary<string, ImColor> Colors { get; } = colors;

	/// <summary>Gets all optimal color pairs found during palette generation.</summary>
	public IReadOnlyList<OptimalColorPair> ColorPairs { get; } = colorPairs;

	/// <summary>Gets the average quality score across all color relationships.</summary>
	public float AverageQuality { get; } = averageQuality;

	/// <summary>Gets warnings about contrast or quality issues in the generated palette.</summary>
	public IReadOnlyList<string> Warnings { get; } = warnings;

	/// <summary>Gets whether this palette meets all minimum contrast requirements.</summary>
	public bool MeetsAllMinimumContrast => ColorPairs.All(p => p.MeetsMinimumContrast);

	/// <summary>Gets whether this palette meets all preferred contrast requirements.</summary>
	public bool MeetsAllPreferredContrast => ColorPairs.All(p => p.MeetsPreferredContrast);

	/// <summary>Gets the percentage of color pairs that meet preferred contrast.</summary>
	public float PreferredContrastPercentage =>
		ColorPairs.Count > 0 ? ColorPairs.Count(p => p.MeetsPreferredContrast) / (float)ColorPairs.Count * 100f : 100f;

	/// <summary>
	/// Gets a color by family name, or returns a default color if not found.
	/// </summary>
	/// <param name="familyName">The name of the color family.</param>
	/// <param name="defaultColor">Default color to return if not found.</param>
	/// <returns>The optimal color for the family, or the default color.</returns>
	public ImColor GetColor(string familyName, ImColor? defaultColor = null) =>
		Colors.TryGetValue(familyName, out ImColor color) ? color : defaultColor ?? Color.FromHex("#FF00FF");

	/// <summary>Returns a string representation of this palette's quality metrics.</summary>
	public override string ToString() =>
		$"OptimalPalette: Quality {AverageQuality:F1}, " +
		$"Preferred Contrast {PreferredContrastPercentage:F0}%, " +
		$"Colors: {Colors.Count}, Warnings: {Warnings.Count}";
}
