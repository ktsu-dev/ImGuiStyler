// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;

using System.Globalization;
using System.Numerics;

using ImGuiNET;

using ktsu.Extensions;
using ktsu.ScopedAction;

/// <summary>
/// Provides methods for creating and manipulating colors in ImGui.
/// </summary>
public static class Color
{
	/// <summary>
	/// Represents the optimal text contrast ratio.
	/// </summary>
	public const float OptimalTextContrastRatio = 4.5f;

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

		var r = byte.Parse(hex.AsSpan(0, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		var g = byte.Parse(hex.AsSpan(2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		var b = byte.Parse(hex.AsSpan(4, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		var a = byte.Parse(hex.AsSpan(6, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);

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
			var q = l < 0.5f ? l * (1f + s) : l + s - (l * s);
			var p = (2f * l) - q;
			r = HueToRGB(p, q, h + (1f / 3f));
			g = HueToRGB(p, q, h);
			b = HueToRGB(p, q, h - (1f / 3f));
		}

		return FromRGBA(r, g, b, a);
	}

	/// <summary>
	/// Converts a hue to an RGB component.
	/// </summary>
	/// <param name="p">The first parameter for the conversion.</param>
	/// <param name="q">The second parameter for the conversion.</param>
	/// <param name="t">The hue value.</param>
	/// <returns>The RGB component value.</returns>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Nah, im good")]
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

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static ImColor Red => FromRGB(255, 0, 0);
	public static ImColor Green => FromRGB(0, 255, 0);
	public static ImColor Blue => FromRGB(0, 0, 255);
	public static ImColor Yellow => FromRGB(255, 255, 0);
	public static ImColor Cyan => FromRGB(0, 255, 255);
	public static ImColor Magenta => FromRGB(255, 0, 255);
	public static ImColor White => FromRGB(255, 255, 255);
	public static ImColor Black => FromRGB(0, 0, 0);
	public static ImColor Gray => FromRGB(128, 128, 128);
	public static ImColor LightGray => FromRGB(192, 192, 192);
	public static ImColor DarkGray => FromRGB(64, 64, 64);
	public static ImColor Transparent => FromRGBA(0, 0, 0, 0);
	public static ImColor Orange => FromRGB(255, 165, 0);
	public static ImColor Purple => FromRGB(128, 0, 128);
	public static ImColor Brown => FromRGB(165, 42, 42);
	public static ImColor Pink => FromRGB(255, 192, 203);
	public static ImColor Gold => FromRGB(255, 215, 0);
	public static ImColor Silver => FromRGB(192, 192, 192);
	public static ImColor Bronze => FromRGB(205, 127, 50);
	public static ImColor Teal => FromRGB(0, 128, 128);
	public static ImColor Olive => FromRGB(128, 128, 0);
	public static ImColor Maroon => FromRGB(128, 0, 0);
	public static ImColor Navy => FromRGB(0, 0, 128);
	public static ImColor Lime => FromRGB(0, 255, 0);
	public static ImColor Indigo => FromRGB(75, 0, 130);
	public static ImColor Turquoise => FromRGB(64, 224, 208);
	public static ImColor Violet => FromRGB(238, 130, 238);
	public static ImColor Beige => FromRGB(245, 245, 220);
	public static ImColor Peach => FromRGB(255, 218, 185);
	public static ImColor Mint => FromRGB(189, 252, 201);
	public static ImColor Lavender => FromRGB(230, 230, 250);
	public static ImColor Coral => FromRGB(255, 127, 80);
	public static ImColor Salmon => FromRGB(250, 128, 114);
	public static ImColor Khaki => FromRGB(240, 230, 140);
	public static ImColor Plum => FromRGB(221, 160, 221);
	public static ImColor GoldMetallic => FromRGB(212, 175, 55);
	public static ImColor SilverMetallic => FromRGB(168, 169, 173);
	public static ImColor BronzeMetallic => FromRGB(205, 127, 50);
	public static ImColor CopperMetallic => FromRGB(184, 115, 51);
	public static ImColor GunmetalMetallic => FromRGB(42, 52, 57);
	public static ImColor Amethyst => FromRGB(153, 102, 204);
	public static ImColor Emerald => FromRGB(80, 200, 120);
	public static ImColor Sapphire => FromRGB(15, 82, 186);
	public static ImColor Ruby => FromRGB(224, 17, 95);
	public static ImColor Diamond => FromRGB(185, 242, 255);
	public static ImColor Pearl => FromRGB(234, 224, 200);
	public static ImColor Onyx => FromRGB(53, 56, 57);
	public static ImColor RubyRed => FromRGB(132, 63, 91);
	public static ImColor SapphireBlue => FromRGB(0, 103, 165);
	public static ImColor EmeraldGreen => FromRGB(0, 153, 68);
	public static ImColor AmethystPurple => FromRGB(153, 102, 204);
	public static ImColor CitrineYellow => FromRGB(228, 208, 10);
	public static ImColor TopazOrange => FromRGB(255, 191, 0);
	public static ImColor AquamarineBlue => FromRGB(0, 191, 255);
	public static ImColor PeridotGreen => FromRGB(153, 204, 0);
	public static ImColor RoseQuartzPink => FromRGB(170, 152, 169);
	public static ImColor SerenityBlue => FromRGB(131, 146, 159);
	public static ImColor MarsalaRed => FromRGB(150, 75, 75);
	public static ImColor RadiantOrchidPurple => FromRGB(191, 85, 156);
	public static ImColor TangerineOrange => FromRGB(242, 133, 0);
	public static ImColor ClassicBlue => FromRGB(0, 133, 202);
	public static ImColor GreeneryGreen => FromRGB(136, 176, 75);
	public static ImColor UltraVioletPurple => FromRGB(95, 75, 139);
	public static ImColor LivingCoral => FromRGB(255, 111, 97);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

	/// <summary>
	/// Provides a palette of predefined colors.
	/// </summary>
	public static class Palette
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public static ImColor Red => FromHex("#ff4a49");
		public static ImColor Green => FromHex("#49ff4a");
		public static ImColor Blue => FromHex("#49a3ff");

		public static ImColor Cyan => FromHex("#49feff");
		public static ImColor Magenta => FromHex("#ff49fe");
		public static ImColor Yellow => FromHex("#ecff49");

		public static ImColor Orange => FromHex("#ffa549");
		public static ImColor Pink => FromHex("#ff49a3");
		public static ImColor Lime => FromHex("#a3ff49");
		public static ImColor Purple => FromHex("#c949ff");
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	}

	/// <summary>
	/// Represents a scoped color change in ImGui.
	/// </summary>
	/// <remarks>
	/// This class ensures that the color change is reverted when the scope ends.
	/// </remarks>
	public class ScopedColor : ScopedAction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScopedColor"/> class with a specified target and color.
		/// </summary>
		/// <param name="target">The ImGui color target to change.</param>
		/// <param name="color">The color to apply to the target.</param>
		public ScopedColor(ImGuiCol target, ImColor color) : base(
		onOpen: () => ImGui.PushStyleColor(target, color.Value),
		onClose: ImGui.PopStyleColor)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScopedColor"/> class with a specified color for the button.
		/// </summary>
		/// <param name="color">The color to apply to the button.</param>
		public ScopedColor(ImColor color)
		{
			ImGui.PushStyleColor(ImGuiCol.Button, color.Value);
			OnClose = ImGui.PopStyleColor;
		}
	}

	/// <summary>
	/// Desaturates the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The amount to desaturate (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted saturation.</returns>
	public static ImColor DesaturateBy(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Y = Math.Clamp(hsla.Y - amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Saturates the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The amount to saturate (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted saturation.</returns>
	public static ImColor SaturateBy(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Y = Math.Clamp(hsla.Y + amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Sets the saturation of the color to a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The new saturation value (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted saturation.</returns>
	public static ImColor WithSaturation(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Y = Math.Clamp(amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Multiplies the saturation of the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The factor to multiply the saturation by.</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted saturation.</returns>
	public static ImColor MultiplySaturation(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Y = Math.Clamp(hsla.Y * amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Offsets the hue of the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The amount to offset the hue by (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted hue.</returns>
	public static ImColor OffsetHue(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.X = (1f + (hsla.X + amount)) % 1f;
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Lightens the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The amount to lighten the color by (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted lightness.</returns>
	public static ImColor LightenBy(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Z = Math.Clamp(hsla.Z + amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Darkens the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The amount to darken the color by (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted lightness.</returns>
	public static ImColor DarkenBy(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Z = Math.Clamp(hsla.Z - amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Sets the luminance of the color to a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The new luminance value (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted luminance.</returns>
	public static ImColor WithLuminance(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Z = Math.Clamp(amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Multiplies the luminance of the color by a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The factor to multiply the luminance by.</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted luminance.</returns>
	public static ImColor MultiplyLuminance(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.Z = Math.Clamp(hsla.Z * amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Sets the alpha of the color to a specified amount.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="amount">The new alpha value (0-1).</param>
	/// <returns>A new <see cref="ImColor"/> object with the adjusted alpha.</returns>
	public static ImColor WithAlpha(this ImColor color, float amount)
	{
		var hsla = color.ToHSLA();
		hsla.W = Math.Clamp(amount, 0, 1);
		return FromHSLA(hsla);
	}

	/// <summary>
	/// Converts the color to grayscale.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <returns>A new <see cref="ImColor"/> object in grayscale.</returns>
	public static ImColor ToGrayscale(this ImColor color) => color.WithSaturation(0);

	/// <summary>
	/// Converts the color to HSLA (Hue, Saturation, Lightness, Alpha) format.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <returns>A <see cref="Vector4"/> representing the color in HSLA format.</returns>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0045:Convert to conditional expression", Justification = "<Pending>")]
	public static Vector4 ToHSLA(this ImColor color)
	{
		var r = color.Value.X;
		var g = color.Value.Y;
		var b = color.Value.Z;
		var a = color.Value.W;

		var max = Math.Max(r, Math.Max(g, b));
		var min = Math.Min(r, Math.Min(g, b));
		float h, s, l = (max + min) / 2f;

		if (max == min)
		{
			h = s = 0;
		}
		else
		{
			var d = max - min;
			s = l > 0.5f ? d / (2f - max - min) : d / (max + min);
			if (max == r)
			{
				h = (g - b) / d;
			}
			else if (max == g)
			{
				h = ((b - r) / d) + 2;
			}
			else
			{
				h = ((r - g) / d) + 4;
			}

			h /= 6;
			if (h < 0)
			{
				h += 1;
			}
		}

		return new Vector4(h, s, l, a);
	}

	/// <summary>
	/// Gets the relative luminance of the color.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <returns>The relative luminance of the color.</returns>
	public static float GetRelativeLuminance(this ImColor color) =>
		(color.Value.X * 0.2126f) + (color.Value.Y * 0.7152f) + (color.Value.Z * 0.0722f);

	/// <summary>
	/// Calculates the contrast ratio of the color over a background color.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <param name="background">The background color.</param>
	/// <returns>The contrast ratio of the color over the background color.</returns>
	public static float GetContrastRatioOver(this ImColor color, ImColor background)
	{
		var relativeLuminance = color.GetRelativeLuminance();
		var backgroundRelativeLuminance = background.GetRelativeLuminance();
		return (backgroundRelativeLuminance + 0.05f) / (relativeLuminance + 0.05f);
	}

	/// <summary>
	/// Calculates the optimal contrasting color for the given color.
	/// </summary>
	/// <param name="color">The original color.</param>
	/// <returns>A new <see cref="ImColor"/> object representing the optimal contrasting color.</returns>
	public static ImColor CalculateOptimalContrastingColor(this ImColor color)
	{
		float bestLuminance = 0;
		var bestDistance = float.MaxValue;
		var steps = 256;
		for (var i = 0; i < steps; i++)
		{
			var l = i / (steps - 1f);
			var candidateColor = color.WithLuminance(l);
			var contrast = 1f / candidateColor.GetContrastRatioOver(color);
			// compare the distance to the target luminance to determine the best contrast
			var distance = Math.Abs(OptimalTextContrastRatio - contrast);
			if (distance < bestDistance)
			{
				bestDistance = distance;
				bestLuminance = l;
			}
		}

		return color.WithLuminance(bestLuminance);
	}
}
