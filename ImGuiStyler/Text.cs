// Copyright (c) ktsu.dev
// All rights reserved.
// Licensed under the MIT license.

namespace ktsu.ImGuiStyler;
using Hexa.NET.ImGui;

/// <summary>
/// Provides functionality for managing text in ImGui.
/// </summary>
public static class Text
{
	/// <summary>
	/// Provides functionality for managing text colors in ImGui.
	/// </summary>
	public static class Color
	{
		/// <summary>
		/// Contains predefined color definitions for text.
		/// </summary>
		public static class Definitions
		{
			/// <summary>
			/// Gets or sets the normal text color.
			/// </summary>
			public static ImColor Normal { get; set; } = ImGuiStyler.Color.White;

			/// <summary>
			/// Gets or sets the error text color.
			/// </summary>
			public static ImColor Error { get; set; } = ImGuiStyler.Color.Red;

			/// <summary>
			/// Gets or sets the warning text color.
			/// </summary>
			public static ImColor Warning { get; set; } = ImGuiStyler.Color.Yellow;

			/// <summary>
			/// Gets or sets the info text color.
			/// </summary>
			public static ImColor Info { get; set; } = ImGuiStyler.Color.Cyan;

			/// <summary>
			/// Gets or sets the success text color.
			/// </summary>
			public static ImColor Success { get; set; } = ImGuiStyler.Color.Green;
		}

		/// <summary>
		/// Applies the normal text color within a scoped block.
		/// </summary>
		/// <returns>A <see cref="ScopedTextColor"/> instance that reverts the color when disposed.</returns>
		public static ScopedTextColor Normal() => new(Definitions.Normal);

		/// <summary>
		/// Applies the error text color within a scoped block.
		/// </summary>
		/// <returns>A <see cref="ScopedTextColor"/> instance that reverts the color when disposed.</returns>
		public static ScopedTextColor Error() => new(Definitions.Error);

		/// <summary>
		/// Applies the warning text color within a scoped block.
		/// </summary>
		/// <returns>A <see cref="ScopedTextColor"/> instance that reverts the color when disposed.</returns>
		public static ScopedTextColor Warning() => new(Definitions.Warning);

		/// <summary>
		/// Applies the info text color within a scoped block.
		/// </summary>
		/// <returns>A <see cref="ScopedTextColor"/> instance that reverts the color when disposed.</returns>
		public static ScopedTextColor Info() => new(Definitions.Info);

		/// <summary>
		/// Applies the success text color within a scoped block.
		/// </summary>
		/// <returns>A <see cref="ScopedTextColor"/> instance that reverts the color when disposed.</returns>
		public static ScopedTextColor Success() => new(Definitions.Success);

		/// <summary>
		/// Represents a scoped text color change in ImGui.
		/// </summary>
		/// <param name="color">The color to apply to the text.</param>
		public class ScopedTextColor(ImColor color) : ImGuiStyler.Color.ScopedColor(ImGuiCol.Text, color)
		{
		}
	}
}
