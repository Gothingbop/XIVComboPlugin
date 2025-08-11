namespace XIVCombo.Combos;

internal static class PLD
{
    public const byte ClassID = 1;
    public const byte JobID = 19;

    public const uint
        // Single Target
        FastBlade = 9,
        RiotBlade = 15,
        RageOfHalone = 21,
        RoyalAuthority = 3539,
        HolySpirit = 7384,
        Atonement = 16460,
        Supplication = 36918,
        Sepulchre = 36919,

        // AoE
        TotalEclipse = 7381,
        Prominence = 16457,
        HolyCircle = 16458,

        // oGCDs
        CircleOfScorn = 23,
        SpiritsWithin = 29,
        Expiacion = 25747,

        // Confiteor combo
        Confiteor = 16459,
        BladeOfFaith = 25748,
        BladeOfTruth = 25749,
        BladeOfValor = 25750,
        BladeOfHonor = 36922,

        // Cooldowns
        FightOrFlight = 20,
        Requiescat = 7383,
        Imperator = 36921,
        GoringBlade = 3538,

        // Utility
        ShieldBash = 16,
        ShieldLob = 24,
        IronWill = 28,
        IronWillRemoval = 32065,
        Clemency = 3541;

    public static class Buffs
    {
        public const ushort
            FightOrFlight = 76,
            IronWill = 79,
            Requiescat = 1368,
            DivineMight = 2673,
            GoringBladeReady = 3847,
            AtonementReady = 1902,
            SupplicationReady = 3827,
            SepulchreReady = 3828,
            ConfiteorReady = 3019,
            BladeOfHonorReady = 3831;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            FightOrFlight = 2,
            RiotBlade = 4,
            IronWill = 10,
            ShieldBash = 10,
            SpiritsWithin = 30,
            RageOfHalone = 26,
            Prominence = 40,
            CircleOfScorn = 50,
            GoringBlade = 54,
            RoyalAuthority = 60,
            HolySpirit = 64, // Also includes Divine Magic Mastery, halving MP costs
            Requiescat = 68,
            HolyCircle = 72,
            Atonement = 76, // Also includes Supplication and Sepulchre
            Confiteor = 80,
            Expiacion = 86,
            BladeOfFaith = 90,
            Imperator = 96,
            BladeOfHonor = 100;
    }
}

internal class PaladinRoyalAuthority : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.RageOfHalone || actionID == PLD.RoyalAuthority)
        {
            if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityCombo))
            {
                if (lastComboMove == PLD.RiotBlade && level >= PLD.Levels.RageOfHalone)
                    return OriginalHook(PLD.RageOfHalone);

                if (lastComboMove == PLD.FastBlade && level >= PLD.Levels.RiotBlade)
                    return PLD.RiotBlade;

                return PLD.FastBlade;
            }
        }

        return actionID;
    }
}

internal class PaladinProminence : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Prominence)
        {
            if (IsEnabled(CustomComboPreset.PaladinProminenceCombo))
            {
                if (lastComboMove == PLD.TotalEclipse && level >= PLD.Levels.Prominence)
                    return PLD.Prominence;

                return PLD.TotalEclipse;
            }
        }

        return actionID;
    }
}

internal class PaladinRequiescat : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PldAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == PLD.Requiescat || actionID == PLD.Imperator)
        {
            var requiescat = GetCooldown(PLD.Requiescat);

            if (level >= PLD.Levels.Confiteor && IsEnabled(CustomComboPreset.PaladinRequiescatConfiteorFeature))
            {
                if (HasEffect(PLD.Buffs.BladeOfHonorReady))
                    return PLD.BladeOfHonor;

                var original = OriginalHook(PLD.Confiteor);
                if (original != PLD.Confiteor)
                    return original;

                if (HasEffect(PLD.Buffs.ConfiteorReady))
                    return PLD.Confiteor;
            }

            // This captures any remaining charges of Requiescat after the Confiteor combo above, which only happens
            // when the player is under the level for the full 4-part Confiteor combo (level 90), or if they somehow
            // break the combo.
            if (IsEnabled(CustomComboPreset.PaladinRequiescatConfiteorFeature) &&
                level >= PLD.Levels.Requiescat && HasEffect(PLD.Buffs.Requiescat))
                return PLD.HolySpirit;
        }

        return actionID;
    }
}



internal class PaladinHolySpiritConfiteorCombo : PaladinCombo
{
    protected internal override CustomComboPreset Preset => CustomComboPreset.PaladinHolySpiritConfiteorFeature;

    protected override uint Invoke(uint actionId, uint lastComboMove, float comboTime, byte level)
    {
        if (actionId is not (PLD.HolySpirit or PLD.HolyCircle)) return actionId;
        
        var original = OriginalHook(PLD.Confiteor);
        
        if (original != PLD.Confiteor)
            return original;
        
        if (HasEffect(PLD.Buffs.ConfiteorReady) && level >= PLD.Levels.Confiteor)
            return PLD.Confiteor;
        
        if (level >= PLD.Levels.Requiescat && HasEffect(PLD.Buffs.Requiescat))
            return actionId;

        return actionId;
    }
}