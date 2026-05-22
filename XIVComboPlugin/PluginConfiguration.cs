using System;
using System.Collections.Generic;
using System.Linq;

using Dalamud.Configuration;
using Dalamud.Utility;
using Newtonsoft.Json;
using XIVCombo.Attributes;
using XIVCombo.Combos;
using XIVCombo.Interface;

namespace XIVCombo;

/// <summary>
/// Plugin configuration.
/// </summary>
[Serializable]
public class PluginConfiguration : IPluginConfiguration
{
    private static readonly Dictionary<CustomComboPreset, CustomComboPreset[]> ConflictingCombos;
    private static readonly Dictionary<CustomComboPreset, CustomComboPreset?> ParentCombos;  // child: parent

    static PluginConfiguration()
    {

        ConflictingCombos = Enum.GetValues<CustomComboPreset>()
            .Distinct() // Prevent ArgumentExceptions from adding the same int twice, should not be seen anymore
            .ToDictionary(
                preset => preset,
                preset => preset.GetAttribute<ConflictingCombosAttribute>()?.ConflictingPresets ?? Array.Empty<CustomComboPreset>());

        ParentCombos = Enum.GetValues<CustomComboPreset>()
            .Distinct() // Prevent ArgumentExceptions from adding the same int twice, should not be seen anymore
            .ToDictionary(
                preset => preset,
                preset => preset.GetAttribute<ParentComboAttribute>()?.ParentPreset);
    }

    /// <summary>
    /// Gets or sets the configuration version.
    /// </summary>
    public int Version { get; set; } = 5;

    /// <summary>
    /// Gets or sets the collection of enabled combos.
    /// </summary>
    [JsonProperty("EnabledActionsV5")]
    public HashSet<CustomComboPreset> EnabledActions { get; set; } = new();

    /// <summary>
    /// Gets or sets the first time pop-up bool.
    /// </summary>
    public bool OneTimePopUp { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to enable the plugin or not.
    /// </summary>
    [JsonProperty("Plugin")]
    public bool EnablePlugin { get; set; } = true;

	/// <summary>
	/// Gets or sets a value indicating whether to allow and display he default theme.
	/// </summary>
	[JsonProperty("Theme")]
	public bool EnableTheme { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating which is the current tab.
    /// </summary>
    [JsonProperty("Tab")]
    public string CurrentJobTab { get; set; } = "Paladin";

    /// <summary>
    /// Gets or sets a value indicating whether the plugin automatically changes to the current job upon opening the GUI.
    /// </summary>
    public bool AutoJobChange { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to hide the Ko-Fi link.
    /// </summary>
    public bool HideKofi { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to hide the children of a feature if it is disabled.
    /// </summary>
    public bool HideChildren { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to hide the icons of a feature.
    /// </summary>
    public bool HideIcons { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to increase the icons of the jobs on the sidebar or not.
    /// </summary>
    public bool BigJobIcons { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether increase the icons featured in the combo lists or not.
    /// </summary>
    public bool BigComboIcons { get; set; } = false;

    /// <summary>
    /// Save the configuration to disk.
    /// </summary>
    public void Save()
        => Service.Interface.SavePluginConfig(this);

    /// <summary>
    /// Gets a value indicating whether a preset is enabled.
    /// </summary>
    /// <param name="preset">Preset to check.</param>
    /// <returns>The boolean representation.</returns>
    public bool IsEnabled(CustomComboPreset preset)
        => EnabledActions.Contains(preset);

    /// <summary>
    /// Gets an array of conflicting combo presets.
    /// </summary>
    /// <param name="preset">Preset to check.</param>
    /// <returns>The conflicting presets.</returns>
    public CustomComboPreset[] GetConflicts(CustomComboPreset preset)
        => ConflictingCombos[preset];

    /// <summary>
    /// Gets the parent combo preset if it exists, or null.
    /// </summary>
    /// <param name="preset">Preset to check.</param>
    /// <returns>The parent preset.</returns>
    public CustomComboPreset? GetParent(CustomComboPreset preset)
        => ParentCombos[preset];
}
