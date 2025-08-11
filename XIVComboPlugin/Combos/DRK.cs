using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class DRK
{
    public const byte JobID = 32;

    public const uint
        HardSlash = 3617,
        Unleash = 3621,
        SyphonStrike = 3623,
        Grit = 3629,
        Souleater = 3632,
        BloodWeapon = 3625,
        SaltedEarth = 3639,
        AbyssalDrain = 3641,
        CarveAndSpit = 3643,
        Quietus = 7391,
        Bloodspiller = 7392,
        FloodOfDarkness = 16466,
        EdgeOfDarkness = 16467,
        StalwartSoul = 16468,
        FloodOfShadow = 16469,
        EdgeOfShadow = 16470,
        LivingShadow = 16472,
        SaltAndDarkness = 25755,
        Shadowbringer = 25757,
        GritRemoval = 32067,
        Delirium = 7390,
        ScarletDelirium = 36928,
        Comeuppance = 36929,
        Torcleaver = 36930,
        Impalement = 36931,
        Disesteem = 36932;

    public static class Buffs
    {
        public const ushort
            BloodWeapon = 742,
            Grit = 743,
            Darkside = 751,
            Delirium = 1972,
            ScarletDelirium = 3836,
            Scorn = 3837;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SyphonStrike = 2,
            Grit = 10,
            Souleater = 26,
            FloodOfDarkness = 30,
            BloodWeapon = 35,
            EdgeOfDarkness = 40,
            StalwartSoul = 40,
            SaltedEarth = 52,
            AbyssalDrain = 56,
            CarveAndSpit = 60,
            Bloodspiller = 62,
            Quietus = 64,
            Delirium = 68,
            Shadow = 74,
            LivingShadow = 80,
            SaltAndDarkness = 86,
            Shadowbringer = 90,
            ScarletDelirium = 96,
            Comeuppance = 96,
            Torcleaver = 96,
            Impalement = 96,
            Disesteem = 100;
    }
}

internal class DarkSouleater : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.Souleater)
        {
            if (IsEnabled(CustomComboPreset.DarkSouleaterCombo))
            {
                if (comboTime > 0)
                {
                    if (lastComboMove == DRK.SyphonStrike && level >= DRK.Levels.Souleater)
                    {                       
                        return DRK.Souleater;
                    }

                    if (lastComboMove == DRK.HardSlash && level >= DRK.Levels.SyphonStrike)
                        return DRK.SyphonStrike;
                }

                return DRK.HardSlash;
            }
        }

        return actionID;
    }
}

internal class DarkStalwartSoul : CustomCombo
{
    protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DarkStalwartSoulCombo;

    protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
    {
        if (actionID == DRK.StalwartSoul)
		{
			if (lastComboMove == DRK.Unleash && level >= DRK.Levels.StalwartSoul)
				return DRK.StalwartSoul;
            return DRK.Unleash;
        }

        return actionID;
    }
}

