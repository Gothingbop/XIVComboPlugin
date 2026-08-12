using System.Collections.Generic;
using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using Lumina.Extensions;

namespace XIVCombo.Combos;

internal static class BRD
{
    public const byte ClassID = 5;
    public const byte JobID = 23;

    public const uint
        HeavyShot = 97,
        StraightShot = 98,
        VenomousBite = 100,
        RagingStrikes = 101,
        QuickNock = 106,
        Barrage = 107,
        Bloodletter = 110,
        Windbite = 113,
        MagesBallad = 114,
        ArmysPaeon = 116,
        RainOfDeath = 117,
        BattleVoice = 118,
        EmpyrealArrow = 3558,
        WanderersMinuet = 3559,
        IronJaws = 3560,
        Sidewinder = 3562,
        PitchPerfect = 7404,
        CausticBite = 7406,
        Stormbite = 7407,
        RefulgentArrow = 7409,
        BurstShot = 16495,
        ApexArrow = 16496,
        Shadowbite = 16494,
        Ladonsbite = 25783,
        BlastArrow = 25784,
        RadiantFinale = 25785,
        WideVolley = 36974,
        HeartbreakShot = 36975,
        ResonantArrow = 36976,
        RadiantEncore = 36977;

    public static class Buffs
    {
        public const ushort
            StraightShotReady = 122,
            Barrage = 128,
            WanderersMinuet = 2009,
            BlastShotReady = 2692,
            ShadowbiteReady = 3002,
            HawksEye = 3861,
            ResonantArrowReady = 3862,
            RadiantEncoreReady = 3863;
    }

    public static class Debuffs
    {
        public const ushort
            VenomousBite = 124,
            Windbite = 129,
            CausticBite = 1200,
            Stormbite = 1201;
    }

    public static class Levels
    {
        public const byte
            StraightShot = 2,
            RagingStrikes = 4,
            VenomousBite = 6,
            Bloodletter = 12,
            WideVolley = 25,
            MagesBallad = 30,
            Windbite = 30,
            Barrage = 38,
            ArmysPaeon = 40,
            RainOfDeath = 45,
            BattleVoice = 50,
            WanderersMinuet = 52,
            PitchPerfect = 52,
            EmpyrealArrow = 54,
            IronJaws = 56,
            Sidewinder = 60,
            BiteUpgrade = 64,
            RefulgentArrow = 70,
            Shadowbite = 72,
            BurstShot = 76,
            ApexArrow = 80,
            Ladonsbite = 82,
            BlastShot = 86,
            RadiantFinale = 90,
            HeartbreakShot = 92,
            ResonantArrow = 96,
            RadiantEncore = 100;
    }
}

internal class BardHeavyShot : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardStraightShotUpgradeFeature;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == BRD.HeavyShot || actionID == BRD.BurstShot)
        {
            if (level >= BRD.Levels.StraightShot && (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage)))
                // Refulgent Arrow
                return OriginalHook(BRD.StraightShot);
        }

        return actionID;
    }
}

internal class BardQuickNock : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (actionId is not (BRD.QuickNock or BRD.Ladonsbite)) return actionId;

        if (!IsEnabled(CustomComboPreset.BardShadowbiteFeature) || level < BRD.Levels.WideVolley) return actionId;

        if (HasEffect(BRD.Buffs.HawksEye) || HasEffect(BRD.Buffs.Barrage))
            return OriginalHook(BRD.WideVolley);

        return actionId;
    }
}

internal class BardDotCombine : CustomCombo
{
    private static HashSet<uint> _actions =
    [
        BRD.Windbite,
        BRD.Stormbite,
        BRD.VenomousBite,
        BRD.CausticBite,
        BRD.IronJaws
    ];

    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.BardDotCombineFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (!_actions.Contains(actionId)) return actionId;

        if (level < BRD.Levels.BiteUpgrade)
        {
            if (level >= BRD.Levels.Windbite && !TargetHasEffect(BRD.Debuffs.Windbite))
                return OriginalHook(BRD.Windbite);

            if (!TargetHasEffect(BRD.Debuffs.VenomousBite))
                return OriginalHook(BRD.VenomousBite);
        }
        else
        {
            if (!TargetHasEffect(BRD.Debuffs.Stormbite))
                return OriginalHook(BRD.Stormbite);

            if (!TargetHasEffect(BRD.Debuffs.CausticBite))
                return OriginalHook(BRD.CausticBite);
        }

        if (level >= BRD.Levels.IronJaws)
            return OriginalHook(BRD.IronJaws);

        return OriginalHook(BRD.Windbite);
    }
}

internal class BardOgcdCombine : CustomCombo
{
    private static readonly HashSet<uint> ActionIds =
    [
        BRD.Bloodletter,
        BRD.HeartbreakShot,
        BRD.EmpyrealArrow,
        BRD.Sidewinder,
    ];

    protected internal override CustomComboPreset Preset => CustomComboPreset.BardAoeOgcdCombineFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (!ActionIds.Contains(actionId)) return actionId;
        
        var gauge = Service.JobGauges.Get<BRDGauge>();
        
        if (gauge.Song is Song.WanderersMinuet &&
            (gauge.Repertoire >= 3 || gauge is { Repertoire: >= 1, SongTimer: < 5000 }))
            return BRD.PitchPerfect;
        
        var recastInfo = new List<RecastInfo>();

        if (level >= BRD.Levels.Bloodletter)
            recastInfo.Add(GetRecastInfo(BRD.Bloodletter));

        if (level >= BRD.Levels.EmpyrealArrow)
            recastInfo.Add(GetRecastInfo(BRD.EmpyrealArrow));

        if (level >= BRD.Levels.Sidewinder)
            recastInfo.Add(GetRecastInfo(BRD.Sidewinder));

        recastInfo.Sort((x, y) => x.RecastRemaining.CompareTo(y.RecastRemaining));

        return recastInfo.FirstOrNull()?.ActionId ?? actionId;
    }
}

internal class BardAoEOgcdCombine : CustomCombo
{
    private static readonly HashSet<uint> ActionIds =
    [
        BRD.RainOfDeath,
        BRD.EmpyrealArrow,
        BRD.Sidewinder,
    ];

    protected internal override CustomComboPreset Preset => CustomComboPreset.BardOgcdCombineFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (!ActionIds.Contains(actionId)) return actionId;
        
        var gauge = Service.JobGauges.Get<BRDGauge>();
        
        if (gauge.Song is Song.WanderersMinuet &&
            (gauge.Repertoire >= 3 || gauge is { Repertoire: >= 1, SongTimer: < 5000 }))
            return BRD.PitchPerfect;
        
        var recastInfo = new List<RecastInfo>();

        if (level >= BRD.Levels.RainOfDeath)
            recastInfo.Add(GetRecastInfo(BRD.RainOfDeath));

        if (level >= BRD.Levels.EmpyrealArrow)
            recastInfo.Add(GetRecastInfo(BRD.EmpyrealArrow));

        if (level >= BRD.Levels.Sidewinder)
            recastInfo.Add(GetRecastInfo(BRD.Sidewinder));

        recastInfo.Sort((x, y) => x.RecastRemaining.CompareTo(y.RecastRemaining));

        return recastInfo.FirstOrNull()?.ActionId ?? actionId;
    }
}