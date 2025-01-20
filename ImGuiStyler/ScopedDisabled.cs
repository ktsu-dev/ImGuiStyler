namespace ktsu.ImGuiStyler;

using ImGuiNET;
using ktsu.ScopedAction;

/// <summary>
/// Represents a scoped disabled action which will set ImGui elements as disabled until the class is disposed.
/// </summary>
public class ScopedDisabled : ScopedAction
{
	// As per the ImGui documentation: Those can be nested but it cannot be
	// used to enable an already disabled section (a single BeginDisabled(true)
	// in the stack is enough to keep everything disabled)
	private static bool EnabledScopedDisabledActive { get; set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="ScopedDisabled"/> class.
	/// </summary>
	/// <param name="enabled">Should the elements within the scope be disabled</param>
	public ScopedDisabled(bool enabled)
	{
		if (EnabledScopedDisabledActive && !enabled)
		{
			throw new ArgumentException("Cannot enable an already disabled section");
		}

		EnabledScopedDisabledActive = enabled;
		ImGui.BeginDisabled(enabled);
		OnClose = ImGui.EndDisabled;
	}
}
