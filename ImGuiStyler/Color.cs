// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using System.Globalization;
using System.Numerics;

using Hexa.NET.ImGui;

using ktsu.Extensions;

/// <summary>
/// Provides methods for creating and manipulating colors in ImGui.
/// </summary>
public static class Color
{
	/// <summary>
	/// Represents the optimal text contrast ratio for accessibility.
	/// </summary>
	public const float OptimalTextContrastRatio = 4.5f;

	#region Color Creation Methods

	/// <summary>
	/// Converts a hexadecimal color string to an <see cref="ImColor"/> object.
	/// </summary>
	/// <param name="hex">The hexadecimal color string in the format #RRGGBB or #RRGGBBAA.</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="hex"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when the <paramref name="hex"/> is not in the correct format.</exception>
	public static ImColor FromHex(string hex)
	{
		ArgumentNullException.ThrowIfNull(hex, nameof(hex));

		if (hex.StartsWithOrdinal("#"))
		{
			hex = hex[1..];
		}

		if (hex.Length == 6)
		{
			hex += "FF";
		}

		if (hex.Length != 8)
		{
			throw new ArgumentException("Hex color must be in the format #RRGGBB or #RRGGBBAA", nameof(hex));
		}

		byte r = byte.Parse(hex.AsSpan(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		byte g = byte.Parse(hex.AsSpan(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		byte b = byte.Parse(hex.AsSpan(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		byte a = byte.Parse(hex.AsSpan(6, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);

		return FromRGBA(r, g, b, a);
	}

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from RGB byte values.
	/// </summary>
	/// <param name="r">The red component value (0-255).</param>
	/// <param name="g">The green component value (0-255).</param>
	/// <param name="b">The blue component value (0-255).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromRGB(byte r, byte g, byte b) => new()
	{
		Value = new Vector4(r / 255f, g / 255f, b / 255f, 1f)
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from RGBA byte values.
	/// </summary>
	/// <param name="r">The red component value (0-255).</param>
	/// <param name="g">The green component value (0-255).</param>
	/// <param name="b">The blue component value (0-255).</param>
	/// <param name="a">The alpha component value (0-255).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromRGBA(byte r, byte g, byte b, byte a) => new()
	{
		Value = new Vector4(r / 255f, g / 255f, b / 255f, a / 255f)
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from RGB float values.
	/// </summary>
	/// <param name="r">The red component value (0-1).</param>
	/// <param name="g">The green component value (0-1).</param>
	/// <param name="b">The blue component value (0-1).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromRGB(float r, float g, float b) => new()
	{
		Value = new Vector4(r, g, b, 1f)
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from RGBA float values.
	/// </summary>
	/// <param name="r">The red component value (0-1).</param>
	/// <param name="g">The green component value (0-1).</param>
	/// <param name="b">The blue component value (0-1).</param>
	/// <param name="a">The alpha component value (0-1).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromRGBA(float r, float g, float b, float a) => new()
	{
		Value = new Vector4(r, g, b, a)
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from a <see cref="Vector3"/>.
	/// </summary>
	/// <param name="vector">The vector containing RGB values.</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromVector(Vector3 vector) => new()
	{
		Value = new Vector4(vector.X, vector.Y, vector.Z, 1f)
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from a <see cref="Vector4"/>.
	/// </summary>
	/// <param name="vector">The vector containing RGBA values.</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromVector(Vector4 vector) => new()
	{
		Value = vector
	};

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from HSL values.
	/// </summary>
	/// <param name="vector">The vector containing HSL values.</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromHSL(Vector3 vector) => FromHSLA(vector.X, vector.Y, vector.Z, 1);

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from HSLA values.
	/// </summary>
	/// <param name="vector">The vector containing HSLA values.</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromHSLA(Vector4 vector) => FromHSLA(vector.X, vector.Y, vector.Z, vector.W);

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from HSL values.
	/// </summary>
	/// <param name="h">The hue component value (0-1).</param>
	/// <param name="s">The saturation component value (0-1).</param>
	/// <param name="l">The lightness component value (0-1).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromHSL(float h, float s, float l) => FromHSLA(h, s, l, 1);

	/// <summary>
	/// Creates an <see cref="ImColor"/> object from HSLA values.
	/// </summary>
	/// <param name="h">The hue component value (0-1).</param>
	/// <param name="s">The saturation component value (0-1).</param>
	/// <param name="l">The lightness component value (0-1).</param>
	/// <param name="a">The alpha component value (0-1).</param>
	/// <returns>An <see cref="ImColor"/> object representing the color.</returns>
	public static ImColor FromHSLA(float h, float s, float l, float a)
	{
		float r, g, b;

		if (s == 0)
		{
			r = g = b = l;
		}
		else
		{
			float q = l < 0.5f ? l * (1f + s) : l + s - (l * s);
			float p = (2f * l) - q;
			r = HueToRGB(p, q, h + (1f / 3f));
			g = HueToRGB(p, q, h);
			b = HueToRGB(p, q, h - (1f / 3f));
		}

		return FromRGBA(r, g, b, a);
	}

	#endregion

	#region Private Helper Methods

	/// <summary>
	/// Converts a hue to an RGB component.
	/// </summary>
	/// <param name="p">The first parameter for the conversion.</param>
	/// <param name="q">The second parameter for the conversion.</param>
	/// <param name="t">The hue value.</param>
	/// <returns>The RGB component value.</returns>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Clarity over brevity")]
	private static float HueToRGB(float p, float q, float t)
	{
		if (t < 0)
		{
			t += 1;
		}

		if (t > 1)
		{
			t -= 1;
		}

		if (t < 1f / 6f)
		{
			return p + ((q - p) * 6f * t);
		}

		if (t < 1f / 2f)
		{
			return q;
		}

		if (t < 2f / 3f)
		{
			return p + ((q - p) * ((2f / 3f) - t) * 6f);
		}

		return p;
	}

	#endregion

	/// <summary>
	/// Comprehensive color palette with organized categories.
	/// </summary>
	public static class Palette
	{
		/// <summary>
		/// Basic primary and secondary colors.
		/// </summary>
		public static class Basic
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor Red => FromHex("#ff4a49");
			public static ImColor Green => FromHex("#49ff4a");
			public static ImColor Blue => FromHex("#49a3ff");
			public static ImColor Yellow => FromHex("#ecff49");
			public static ImColor Cyan => FromHex("#49feff");
			public static ImColor Magenta => FromHex("#ff49fe");
			public static ImColor Orange => FromHex("#ffa549");
			public static ImColor Pink => FromHex("#ff49a3");
			public static ImColor Lime => FromHex("#a3ff49");
			public static ImColor Purple => FromHex("#c949ff");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Neutral colors for backgrounds, borders, and subtle elements.
		/// </summary>
		public static class Neutral
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor White => FromHex("#ffffff");
			public static ImColor Black => FromHex("#000000");
			public static ImColor Gray => FromHex("#808080");
			public static ImColor LightGray => FromHex("#c0c0c0");
			public static ImColor DarkGray => FromHex("#404040");
			public static ImColor Transparent => FromHex("#00000000");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Semantic colors for UI states and meanings.
		/// </summary>
		public static class Semantic
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor Error => Basic.Red;
			public static ImColor Warning => Basic.Yellow;
			public static ImColor Success => Basic.Green;
			public static ImColor Info => Basic.Cyan;
			public static ImColor Primary => Basic.Blue;
			public static ImColor Secondary => Basic.Purple;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Natural and earthy colors.
		/// </summary>
		public static class Natural
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor Brown => FromRGB(165, 42, 42);
			public static ImColor Olive => FromRGB(128, 128, 0);
			public static ImColor Maroon => FromRGB(128, 0, 0);
			public static ImColor Navy => FromRGB(0, 0, 128);
			public static ImColor Teal => FromRGB(0, 128, 128);
			public static ImColor Indigo => FromRGB(75, 0, 130);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Vibrant and colorful shades.
		/// </summary>
		public static class Vibrant
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor Coral => FromRGB(255, 127, 80);
			public static ImColor Salmon => FromRGB(250, 128, 114);
			public static ImColor Turquoise => FromRGB(64, 224, 208);
			public static ImColor Violet => FromRGB(238, 130, 238);
			public static ImColor Gold => FromRGB(255, 215, 0);
			public static ImColor Silver => FromRGB(192, 192, 192);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Soft, pastel colors for gentle UIs.
		/// </summary>
		public static class Pastel
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			public static ImColor Beige => FromRGB(245, 245, 220);
			public static ImColor Peach => FromRGB(255, 218, 185);
			public static ImColor Mint => FromRGB(189, 252, 201);
			public static ImColor Lavender => FromRGB(230, 230, 250);
			public static ImColor Khaki => FromRGB(240, 230, 140);
			public static ImColor Plum => FromRGB(221, 160, 221);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Colors inspired by popular development themes.
		/// </summary>
		public static class Themes
		{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
			// Dark Themes
			public static ImColor Dracula => FromHex("#bd93f9");
			public static ImColor Nord => FromHex("#5e81ac");
			public static ImColor TokyoNight => FromHex("#7aa2f7");
			public static ImColor GruvboxDark => FromHex("#fe8019");
			public static ImColor OneDark => FromHex("#61afef");
			public static ImColor CatppuccinMocha => FromHex("#89b4fa");
			public static ImColor Monokai => FromHex("#f92672");
			public static ImColor Nightfly => FromHex("#82aaff");
			public static ImColor Kanagawa => FromHex("#7e9cd8");
			public static ImColor PaperColorDark => FromHex("#8fbcbb");
			public static ImColor Nightfox => FromHex("#719cd6");
			public static ImColor EverforestDark => FromHex("#a7c080");
			public static ImColor VSCodeDark => FromHex("#0078d4");

			// Light Themes
			public static ImColor VSCodeLight => FromHex("#0078d4");
			public static ImColor GruvboxLight => FromHex("#af3a03");
			public static ImColor PaperColorLight => FromHex("#005f87");
			public static ImColor EverforestLight => FromHex("#8da101");
			public static ImColor CatppuccinLatte => FromHex("#8839ef");

			// Medium Themes
			public static ImColor CatppuccinFrappe => FromHex("#ca9ee6");
			public static ImColor CatppuccinMacchiato => FromHex("#c6a0f6");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		}

		/// <summary>
		/// Gets all available colors organized by category.
		/// </summary>
		public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, ImColor>> AllColors =>
			new Dictionary<string, IReadOnlyDictionary<string, ImColor>>
			{
				[nameof(Basic)] = new Dictionary<string, ImColor>
				{
					[nameof(Basic.Red)] = Basic.Red,
					[nameof(Basic.Green)] = Basic.Green,
					[nameof(Basic.Blue)] = Basic.Blue,
					[nameof(Basic.Yellow)] = Basic.Yellow,
					[nameof(Basic.Cyan)] = Basic.Cyan,
					[nameof(Basic.Magenta)] = Basic.Magenta,
					[nameof(Basic.Orange)] = Basic.Orange,
					[nameof(Basic.Pink)] = Basic.Pink,
					[nameof(Basic.Lime)] = Basic.Lime,
					[nameof(Basic.Purple)] = Basic.Purple,
				},
				[nameof(Neutral)] = new Dictionary<string, ImColor>
				{
					[nameof(Neutral.White)] = Neutral.White,
					[nameof(Neutral.Black)] = Neutral.Black,
					[nameof(Neutral.Gray)] = Neutral.Gray,
					[nameof(Neutral.LightGray)] = Neutral.LightGray,
					[nameof(Neutral.DarkGray)] = Neutral.DarkGray,
					[nameof(Neutral.Transparent)] = Neutral.Transparent,
				},
				[nameof(Semantic)] = new Dictionary<string, ImColor>
				{
					[nameof(Semantic.Error)] = Semantic.Error,
					[nameof(Semantic.Warning)] = Semantic.Warning,
					[nameof(Semantic.Success)] = Semantic.Success,
					[nameof(Semantic.Info)] = Semantic.Info,
					[nameof(Semantic.Primary)] = Semantic.Primary,
					[nameof(Semantic.Secondary)] = Semantic.Secondary,
				},
				[nameof(Natural)] = new Dictionary<string, ImColor>
				{
					[nameof(Natural.Brown)] = Natural.Brown,
					[nameof(Natural.Olive)] = Natural.Olive,
					[nameof(Natural.Maroon)] = Natural.Maroon,
					[nameof(Natural.Navy)] = Natural.Navy,
					[nameof(Natural.Teal)] = Natural.Teal,
					[nameof(Natural.Indigo)] = Natural.Indigo,
				},
				[nameof(Vibrant)] = new Dictionary<string, ImColor>
				{
					[nameof(Vibrant.Coral)] = Vibrant.Coral,
					[nameof(Vibrant.Salmon)] = Vibrant.Salmon,
					[nameof(Vibrant.Turquoise)] = Vibrant.Turquoise,
					[nameof(Vibrant.Violet)] = Vibrant.Violet,
					[nameof(Vibrant.Gold)] = Vibrant.Gold,
					[nameof(Vibrant.Silver)] = Vibrant.Silver,
				},
				[nameof(Pastel)] = new Dictionary<string, ImColor>
				{
					[nameof(Pastel.Beige)] = Pastel.Beige,
					[nameof(Pastel.Peach)] = Pastel.Peach,
					[nameof(Pastel.Mint)] = Pastel.Mint,
					[nameof(Pastel.Lavender)] = Pastel.Lavender,
					[nameof(Pastel.Khaki)] = Pastel.Khaki,
					[nameof(Pastel.Plum)] = Pastel.Plum,
				},
			};
	}
}
