using System;
using System.Collections.Generic;
using FFXIVClientStructs.FFXIV.Client.Game;

namespace XIVCombo.Combos;

/// <summary>
/// 
/// </summary>
internal static class DOH
{
    public interface IDOHJob
    {
        public uint BasicSynthesis { get; }
        public uint BasicTouch { get; }
        public uint StandardTouch { get; }
        public uint AdvancedTouch { get; }
        public uint PreciseTouch { get; }
        public uint Groundwork { get; }
        public uint IntensiveSynthesis { get; }
        public uint CarefulSynthesis { get; }
    }

    public class CRP : IDOHJob
    {
        public uint BasicSynthesis => 100001;
        public uint BasicTouch => 100002;
        public uint MastersMend => 100003;
        public uint StandardTouch => 100004;
        public uint Observe => 100010;
        public uint PreciseTouch => 100128;
        public uint CarefulSynthesis => 100203;
        public uint PrudentTouch => 100227;
        public uint TrainedEye => 100283;
        public uint PreparatoryTouch => 100299;
        public uint IntensiveSynthesis => 100315;
        public uint DelicateSynthesis => 100323;
        public uint ByregotsBlessing => 100339;
        public uint HastyTouch => 100355;
        public uint RapidSynthesis => 100363;
        public uint TricksoftheTrade => 100371;
        public uint MuscleMemory => 100379;
        public uint Reflect => 100387;
        public uint CarefulObservation => 100395;
        public uint Groundwork => 100403;
        public uint AdvancedTouch => 100411;
        public uint HeartandSoul => 100419;
        public uint PrudentSynthesis => 100427;
        public uint TrainedFinesse => 100435;
        public uint RefinedTouch => 100443;
        public uint QuickInnovation => 100459;
        public uint ImmaculateMend => 100467;
        public uint TrainedPerfection => 100475;
    }

    public class BSM : IDOHJob
    {
        public uint BasicSynthesis => 100015;
        public uint BasicTouch => 100016;
        public uint MastersMend => 100017;
        public uint StandardTouch => 100018;
        public uint Observe => 100023;
        public uint PreciseTouch => 100129;
        public uint CarefulSynthesis => 100204;
        public uint PrudentTouch => 100228;
        public uint TrainedEye => 100284;
        public uint PreparatoryTouch => 100300;
        public uint IntensiveSynthesis => 100316;
        public uint DelicateSynthesis => 100324;
        public uint ByregotsBlessing => 100340;
        public uint HastyTouch => 100356;
        public uint RapidSynthesis => 100364;
        public uint TricksoftheTrade => 100372;
        public uint MuscleMemory => 100380;
        public uint Reflect => 100388;
        public uint CarefulObservation => 100396;
        public uint Groundwork => 100404;
        public uint AdvancedTouch => 100412;
        public uint HeartandSoul => 100420;
        public uint PrudentSynthesis => 100428;
        public uint TrainedFinesse => 100436;
        public uint RefinedTouch => 100444;
        public uint QuickInnovation => 100460;
        public uint ImmaculateMend => 100468;
        public uint TrainedPerfection => 100476;
    }

    public class ARM : IDOHJob
    {
        public uint BasicSynthesis => 100030;
        public uint BasicTouch => 100031;
        public uint MastersMend => 100032;
        public uint StandardTouch => 100034;
        public uint Observe => 100040;
        public uint PreciseTouch => 100130;
        public uint CarefulSynthesis => 100205;
        public uint PrudentTouch => 100229;
        public uint TrainedEye => 100285;
        public uint PreparatoryTouch => 100301;
        public uint IntensiveSynthesis => 100317;
        public uint DelicateSynthesis => 100325;
        public uint ByregotsBlessing => 100341;
        public uint HastyTouch => 100357;
        public uint RapidSynthesis => 100365;
        public uint TricksoftheTrade => 100373;
        public uint MuscleMemory => 100381;
        public uint Reflect => 100389;
        public uint CarefulObservation => 100397;
        public uint Groundwork => 100405;
        public uint AdvancedTouch => 100413;
        public uint HeartandSoul => 100421;
        public uint PrudentSynthesis => 100429;
        public uint TrainedFinesse => 100437;
        public uint RefinedTouch => 100445;
        public uint QuickInnovation => 100461;
        public uint ImmaculateMend => 100469;
        public uint TrainedPerfection => 100477;
    }

    public class LTW : IDOHJob
    {
        public uint BasicSynthesis => 100045;
        public uint BasicTouch => 100046;
        public uint MastersMend => 100047;
        public uint StandardTouch => 100048;
        public uint Observe => 100053;
        public uint PreciseTouch => 100132;
        public uint CarefulSynthesis => 100207;
        public uint PrudentTouch => 100231;
        public uint TrainedEye => 100287;
        public uint PreparatoryTouch => 100303;
        public uint IntensiveSynthesis => 100319;
        public uint DelicateSynthesis => 100327;
        public uint ByregotsBlessing => 100343;
        public uint HastyTouch => 100359;
        public uint RapidSynthesis => 100367;
        public uint TricksoftheTrade => 100375;
        public uint MuscleMemory => 100383;
        public uint Reflect => 100391;
        public uint CarefulObservation => 100399;
        public uint Groundwork => 100407;
        public uint AdvancedTouch => 100415;
        public uint HeartandSoul => 100423;
        public uint PrudentSynthesis => 100431;
        public uint TrainedFinesse => 100439;
        public uint RefinedTouch => 100447;
        public uint QuickInnovation => 100463;
        public uint ImmaculateMend => 100471;
        public uint TrainedPerfection => 100479;
    }

    public class WVR : IDOHJob
    {
        public uint BasicSynthesis => 100060;
        public uint BasicTouch => 100061;
        public uint MastersMend => 100062;
        public uint StandardTouch => 100064;
        public uint Observe => 100070;
        public uint PreciseTouch => 100133;
        public uint CarefulSynthesis => 100208;
        public uint PrudentTouch => 100232;
        public uint TrainedEye => 100288;
        public uint PreparatoryTouch => 100304;
        public uint IntensiveSynthesis => 100320;
        public uint DelicateSynthesis => 100328;
        public uint ByregotsBlessing => 100344;
        public uint HastyTouch => 100360;
        public uint RapidSynthesis => 100368;
        public uint TricksoftheTrade => 100376;
        public uint MuscleMemory => 100384;
        public uint Reflect => 100392;
        public uint CarefulObservation => 100400;
        public uint Groundwork => 100408;
        public uint AdvancedTouch => 100416;
        public uint HeartandSoul => 100424;
        public uint PrudentSynthesis => 100432;
        public uint TrainedFinesse => 100440;
        public uint RefinedTouch => 100448;
        public uint QuickInnovation => 100464;
        public uint ImmaculateMend => 100472;
        public uint TrainedPerfection => 100480;
    }

    public class GSM : IDOHJob
    {
        public uint BasicSynthesis => 100075;
        public uint BasicTouch => 100076;
        public uint MastersMend => 100077;
        public uint StandardTouch => 100078;
        public uint Observe => 100082;
        public uint PreciseTouch => 100131;
        public uint CarefulSynthesis => 100206;
        public uint PrudentTouch => 100230;
        public uint TrainedEye => 100286;
        public uint PreparatoryTouch => 100302;
        public uint IntensiveSynthesis => 100318;
        public uint DelicateSynthesis => 100326;
        public uint ByregotsBlessing => 100342;
        public uint HastyTouch => 100358;
        public uint RapidSynthesis => 100366;
        public uint TricksoftheTrade => 100374;
        public uint MuscleMemory => 100382;
        public uint Reflect => 100390;
        public uint CarefulObservation => 100398;
        public uint Groundwork => 100406;
        public uint AdvancedTouch => 100414;
        public uint HeartandSoul => 100422;
        public uint PrudentSynthesis => 100430;
        public uint TrainedFinesse => 100438;
        public uint RefinedTouch => 100446;
        public uint QuickInnovation => 100462;
        public uint ImmaculateMend => 100470;
        public uint TrainedPerfection => 100478;
    }

    public class ALC : IDOHJob
    {
        public uint BasicSynthesis => 100090;
        public uint BasicTouch => 100091;
        public uint MastersMend => 100092;
        public uint StandardTouch => 100093;
        public uint Observe => 100099;
        public uint PreciseTouch => 100134;
        public uint CarefulSynthesis => 100209;
        public uint PrudentTouch => 100233;
        public uint TrainedEye => 100289;
        public uint PreparatoryTouch => 100305;
        public uint IntensiveSynthesis => 100321;
        public uint DelicateSynthesis => 100329;
        public uint ByregotsBlessing => 100345;
        public uint HastyTouch => 100361;
        public uint RapidSynthesis => 100369;
        public uint TricksoftheTrade => 100377;
        public uint MuscleMemory => 100385;
        public uint Reflect => 100393;
        public uint CarefulObservation => 100401;
        public uint Groundwork => 100409;
        public uint AdvancedTouch => 100417;
        public uint HeartandSoul => 100425;
        public uint PrudentSynthesis => 100433;
        public uint TrainedFinesse => 100441;
        public uint RefinedTouch => 100449;
        public uint QuickInnovation => 100465;
        public uint ImmaculateMend => 100473;
        public uint TrainedPerfection => 100481;
    }

    public class CUL : IDOHJob
    {
        public uint BasicSynthesis => 100105;
        public uint BasicTouch => 100106;
        public uint MastersMend => 100107;
        public uint StandardTouch => 100109;
        public uint Observe => 100113;
        public uint PreciseTouch => 100135;
        public uint CarefulSynthesis => 100210;
        public uint PrudentTouch => 100234;
        public uint TrainedEye => 100290;
        public uint PreparatoryTouch => 100306;
        public uint IntensiveSynthesis => 100322;
        public uint DelicateSynthesis => 100330;
        public uint ByregotsBlessing => 100346;
        public uint HastyTouch => 100362;
        public uint RapidSynthesis => 100370;
        public uint TricksoftheTrade => 100378;
        public uint MuscleMemory => 100386;
        public uint Reflect => 100394;
        public uint CarefulObservation => 100402;
        public uint Groundwork => 100410;
        public uint AdvancedTouch => 100418;
        public uint HeartandSoul => 100426;
        public uint PrudentSynthesis => 100434;
        public uint TrainedFinesse => 100442;
        public uint RefinedTouch => 100450;
        public uint QuickInnovation => 100466;
        public uint ImmaculateMend => 100474;
        public uint TrainedPerfection => 100482;
    }


    public static Dictionary<uint, IDOHJob> Jobs = new()
    {
        { 8, new CRP() },
        { 9, new BSM() },
        { 10, new ARM() },
        { 12, new LTW() },
        { 11, new GSM() },
        { 13, new WVR() },
        { 14, new ALC() },
        { 15, new CUL() },
    };

    public const byte ClassID = 0;
    public const byte JobID = 50;

    public static class Buffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            Placeholder = 0;
    }
}

internal class DOHTouchCombo : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DOHDummy;
    // protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DOHTouchFeature;

    protected override unsafe uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        
        if (LocalPlayer is null) return actionID;
        if (!DOH.Jobs.TryGetValue(LocalPlayer.ClassJob.RowId, out var job)) return actionID;
        if (actionID != job.AdvancedTouch) return actionID;

        var canUse = ActionManager.Instance()->GetActionStatus(ActionType.CraftAction, job.PreciseTouch) == 0;
        if (canUse) return job.PreciseTouch;

        var lastComboMove2 = *(uint*)Service.Address.LastComboMove2;
        if (lastComboMove2 == job.BasicTouch) return job.StandardTouch;
        if (lastComboMove2 == job.StandardTouch) return job.AdvancedTouch;

        return job.BasicTouch;
    
    }
}

internal class DOHIntensiveProc : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DOHDummy;
    // protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DOHIntensiveProc;

    protected override unsafe uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        try
        {
            if (LocalPlayer is null) return actionID;
            if (!DOH.Jobs.TryGetValue(LocalPlayer.ClassJob.RowId, out var job)) return actionID;
            if (actionID != job.CarefulSynthesis && actionID != job.Groundwork) return actionID;

            var canUse = ActionManager.Instance()->GetActionStatus(ActionType.CraftAction, job.IntensiveSynthesis) == 0;
            return canUse ? job.IntensiveSynthesis : actionID;
        }
        catch (Exception e)
        {
            Service.PluginLog.Error($"{e}");
            return actionID;
        }
    }
}
