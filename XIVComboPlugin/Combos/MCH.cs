using System;
using System.Collections.Generic;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class MCH
{
    public const byte JobID = 31;

    public const uint
        // Single target
        CleanShot = 2873,
        HeatedCleanShot = 7413,
        SplitShot = 2866,
        HeatedSplitShot = 7411,
        SlugShot = 2868,
        HeatedSlugshot = 7412,
        // Charges
        GaussRound = 2874,
        Ricochet = 2890,
        DoubleCheck = 36979,
        Checkmate = 36980,
        // AoE
        SpreadShot = 2870,
        AutoCrossbow = 16497,
        Scattergun = 25786,
        // Rook
        RookAutoturret = 2864,
        RookOverdrive = 7415,
        AutomatonQueen = 16501,
        QueenOverdrive = 16502,
        // Other
        Wildfire = 2878,
        Detonator = 16766,
        Hypercharge = 17209,
        BarrelStabilizer = 7414,
        HeatBlast = 7410,
        BlazingShot = 36978,
        HotShot = 2872,
        Drill = 16498,
        Bioblaster = 16499,
        AirAnchor = 16500,
        Chainsaw = 25788,
        Excavator = 36981,
        FullMetal = 36982;

    public static class Buffs
    {
        public const ushort
            Overheat = 2688,
            HyperchargeReady = 3864,
            ExcavatorReady = 3865,
            FullMetalPrepared = 3866;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SlugShot = 2,
            HotShot = 4, 
            GaussRound = 15,
            CleanShot = 26,
            Hypercharge = 30,
            HeatBlast = 35,
            RookOverdrive = 40,
            Wildfire = 45,
            Ricochet = 50,
            AutoCrossbow = 52,
            HeatedSplitShot = 54,
            Drill = 58,
            HeatedSlugshot = 60,
            HeatedCleanShot = 64,
            BarrelStabilizer = 66,
            BlazingShot = 68,
            ChargedActionMastery = 74,
            AirAnchor = 76,
            QueenOverdrive = 80,
            Chainsaw = 90,
            DoubleCheck = 92,
            CheckMate = 92,
            Excavator = 96,
            FullMetal = 100;
    }
}

internal class MachinistCleanShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistMainCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.CleanShot || actionID == MCH.HeatedCleanShot)
        {
            if (comboTime > 0)
            {
                if (lastComboMove == MCH.SlugShot && level >= MCH.Levels.CleanShot)
                    // Heated
                    return OriginalHook(MCH.CleanShot);

                if (lastComboMove == MCH.SplitShot && level >= MCH.Levels.SlugShot)
                    // Heated
                    return OriginalHook(MCH.SlugShot);
            }

            // Heated
            return OriginalHook(MCH.SplitShot);
        }

        return actionID;
    }
}

internal class MachinistSpreadShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistSpreadShotFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.SpreadShot || actionID == MCH.Scattergun)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (level >= MCH.Levels.AutoCrossbow && gauge.IsOverheated)
                return MCH.AutoCrossbow;
        }

        return actionID;
    }
}

internal class MachinistHyperchargeCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.MachinistHypercomboFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == MCH.Hypercharge)
        {
            var gauge = GetJobGauge<MCHGauge>();

            if (level >= MCH.Levels.HeatBlast && gauge.IsOverheated)
                return OriginalHook(MCH.HeatBlast);
        }

        return actionID;
    }
}

internal class MachinistCooldownSkillsCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.MachinistCooldownSkillsFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (actionId != MCH.Drill) return actionId;

        List<RecastInfo> recastInfo = [];
        if (level >= MCH.Levels.HotShot) recastInfo.Add(GetRecastInfo(level < MCH.Levels.AirAnchor ? MCH.HotShot : MCH.AirAnchor));
        if (level >= MCH.Levels.Drill) recastInfo.Add(GetRecastInfo(MCH.Drill));
        if (level >= MCH.Levels.Chainsaw) recastInfo.Add(GetRecastInfo(MCH.Chainsaw));
        if (HasEffect(MCH.Buffs.ExcavatorReady)) recastInfo.Add(GetRecastInfo(MCH.Excavator));

        recastInfo.Sort((x, y) => x.RecastRemaining.CompareTo(y.RecastRemaining));
        return recastInfo[0].ActionId;
    }
}

internal class MachinistOffGGlobalSingleButtonCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.MachinistOffGGlobalSingleButtonFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        HashSet<uint> skills = [MCH.GaussRound, MCH.Ricochet, MCH.DoubleCheck, MCH.Checkmate];
        if (!skills.Contains(actionId)) return actionId;

        RecastInfo[] recastInfo;
        if (level < MCH.Levels.CheckMate)
        {
            recastInfo =
            [
                GetRecastInfo(MCH.GaussRound),
                GetRecastInfo(MCH.Ricochet)
            ];
        }
        else
        {
            recastInfo =
            [
                GetRecastInfo(MCH.DoubleCheck),
                GetRecastInfo(MCH.Checkmate)
            ];
        }

        Array.Sort(recastInfo, (x, y) => y.Charges.CompareTo(x.Charges));
        
        var gauge = GetJobGauge<MCHGauge>();
        if (!gauge.IsOverheated) return recastInfo[0].ActionId;
        
        var recastDetail = GetRecastGroupInfo(57);
        var recastRemaining = recastDetail.Total - recastDetail.Elapsed;
        if (recastRemaining < 0.5) return level < MCH.Levels.BlazingShot ? MCH.HeatBlast : MCH.BlazingShot;

        return recastInfo[0].ActionId;
    }
}