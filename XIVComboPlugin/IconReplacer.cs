using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dalamud.Hooking;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.Game;
using XIVCombo.Combos;

namespace XIVCombo;

/// <summary>
/// This class facilitates the icon replacing.
/// </summary>
internal sealed class IconReplacer : IDisposable
{
    private readonly unsafe ActionManager* ClientStructActionManager;
    private readonly List<CustomCombo> CustomCombos;
    private readonly Hook<IsIconReplaceableDelegate> IsIconReplaceableHook;
    private readonly Hook<GetIconDelegate> GetIconHook;

    private IntPtr ActionManager = IntPtr.Zero;

    /// <summary>
    /// Initializes a new instance of the <see cref="IconReplacer"/> class.
    /// </summary>
    public unsafe IconReplacer(IGameInteropProvider gameInteropProvider)
    {
        ClientStructActionManager = FFXIVClientStructs.FFXIV.Client.Game.ActionManager.Instance();

        CustomCombos = Assembly.GetAssembly(typeof(CustomCombo))!.GetTypes()
            .Where(t => !t.IsAbstract && IsDescendant(t, typeof(CustomCombo)))
            .Select(t => Activator.CreateInstance(t))
            .Cast<CustomCombo>()
            .ToList();

        GetIconHook = gameInteropProvider.HookFromAddress<GetIconDelegate>(FFXIVClientStructs.FFXIV.Client.Game.ActionManager.Addresses.GetAdjustedActionId.Value, GetIconDetour);
        IsIconReplaceableHook = gameInteropProvider.HookFromAddress<IsIconReplaceableDelegate>(Service.Address.IsActionIdReplaceable, IsIconReplaceableDetour);

        GetIconHook.Enable();
        IsIconReplaceableHook.Enable();
    }

    /// <summary>
    /// Gets bool determining if action is greyed out or not.
    /// </summary>
    /// <param name="actionId">Action ID.</param>
    /// <param name="targetId">Target ID.</param>
    /// <returns>A bool value of whether the action can be used or not.</returns>
    internal unsafe bool CanUseAction(uint actionId, uint targetId = 0xE000_0000)
    {
        return ClientStructActionManager->GetActionStatus(ActionType.Action, actionId, targetId, false, true) == 0;
    }

    private static bool IsDescendant(Type clazz, Type ancestor)
    {
        if (clazz.BaseType == null) return false;
        if (clazz.BaseType == ancestor) return true;
        return IsDescendant(clazz.BaseType, ancestor);
    }

    private delegate ulong IsIconReplaceableDelegate(uint actionId);

    private delegate uint GetIconDelegate(IntPtr actionManager, uint actionId);

    /// <inheritdoc/>
    public void Dispose()
    {
        GetIconHook.Dispose();
        IsIconReplaceableHook.Dispose();
    }

    /// <summary>
    /// Calls the original hook.
    /// </summary>
    /// <param name="actionId">Action ID.</param>
    /// <returns>The result from the hook.</returns>
    internal uint OriginalHook(uint actionId)
        => GetIconHook.Original(ActionManager, actionId);

    private unsafe uint GetIconDetour(IntPtr actionManager, uint actionId)
    {
        ActionManager = actionManager;

        try
        {
            if (!Dalamud.Utility.ThreadSafety.IsMainThread)
                return OriginalHook(actionId);
            
            if (Service.ObjectTable.LocalPlayer == null)
                return OriginalHook(actionId);

            var lastComboMove = *(uint*)Service.Address.LastComboMove;
            var comboTime = *(float*)Service.Address.ComboTimer;
            var level = Service.ObjectTable.LocalPlayer?.Level ?? 0;

            foreach (var combo in CustomCombos)
            {
                if (combo.TryInvoke(actionId, level, lastComboMove, comboTime, out var newActionId))
                    return newActionId;
            }

            return OriginalHook(actionId);
        }
        catch (Exception ex)
        {
            Service.PluginLog.Error(ex, "Don't crash the game");
            return OriginalHook(actionId);
        }
    }

    private ulong IsIconReplaceableDetour(uint actionId) => 1;
}
