using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVCombo.Combos;

internal static class PCT
{
    public const byte JobID = 42;

    public const uint
        FireRedST = 34650,
        AeroGreenST = 34651,
        WaterBlueST = 34652,
        BlizzardCyanST = 34653,
        EarthYellowST = 34654,
        ThunderMagentaST = 34655,

        FireRedAoE = 34656,
        AeroGreenAoE = 34657,
        WaterBlueAoE = 34658,
        BlizzardCyanAoE = 34659,
        EarthYellowAoE = 34660,
        ThunderMagentaAoE = 34661,

        HolyWhite = 34662,
        CometBlack = 34663,
        RainbowDrip = 34688,

        CreatureMotif = 34689,
        PomMotif = 34664,
        WingMotif = 34665,
        ClawMotif = 34666,
        MawMotif = 34667,
        LivingMuse = 35347,
        PomMuse = 34670,
        WingedMuse = 34671,
        ClawedMuse = 34672,
        FangedMuse = 34673,
        MogOftheAges = 34676,
        Retribution = 34677,

        WeaponMotif = 34690,
        HammerMotif = 34668,
        SteelMuse = 35348,
        StrikingMuse = 34674,
        HammerStamp = 34678,
        HammerBrush = 34679,
        PolishingHammer = 34680,

        LandscapeMotif = 34691,
        StarrySkyMotif = 34669,
        ScenicMuse = 35349,
        StarryMuse = 34675,
        StarPrism = 34681,

        SubstractivePalette = 34683,
        Smudge = 34684,
        TemperaCoat = 34685,
        TemperaGrassa = 34686;

    public static class Buffs
    {
        public const ushort
            SubstractivePalette = 3674,
            Aetherhues1 = 3675,
            Aetherhues2 = 3676,
            RainbowReady = 3679,
            HammerReady = 3680,
            StarPrismReady = 3681,
            Hyperfantasia = 3688,
            Inspiration = 3689,
            SubstractiveReady = 3690,
            MonochromeTones = 3691;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            FireRedST = 1,
            AeroGreenST = 5,
            TemperaCoat = 10,
            WaterBlueST = 15,
            Smudge = 20,
            FireRedAoE = 25,
            CreatureMotif = 30,
            PomMotif = 30,
            WingMotif = 30,
            PomMuse = 30,
            WingedMuse = 30,
            MogOftheAges = 30,
            AeroGreenAoE = 35,
            WaterBlueAoE = 45,
            HammerMotif = 50,
            HammerStamp = 50,
            WeaponMotif = 50,
            StrikingMuse = 50,
            SubstractivePalette = 60,
            BlizzardCyan = 60,
            EarthYellow = 60,
            ThunderMagenta = 60,
            ExtraBlizzardCyan = 60,
            ExtraEarthYellow = 60,
            ExtraThunderMagenta = 60,
            StarrySkyMotif = 70,
            LandscapeMotif = 70,
            HolyWhite = 80,
            HammerBrush = 86,
            PolishingHammer = 86,
            TemperaGrassa = 88,
            CometBlack = 90,
            RainbowDrip = 92,
            ClawMotif = 96,
            MawMotif = 96,
            ClawedMuse = 96,
            FangedMuse = 96,
            StarryMuse = 70,
            Retribution = 96,
            StarPrism = 100;
    }

    internal class PictomancerSTCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerSubtractiveSTCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
		{
			if (actionID == FireRedST)
			{
				if (!HasEffect(Buffs.SubstractivePalette))
				{
					return OriginalHook(FireRedST);
				}

				if (HasEffect(Buffs.SubstractivePalette))
				{
					return OriginalHook(BlizzardCyanST);
				}
			}

			return actionID;
		}
    }

    internal class PictomancerAoECombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerSubtractiveAoECombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {

			if (actionID == FireRedAoE)
			{
				if (!HasEffect(Buffs.SubstractivePalette))
				{
					return OriginalHook(FireRedAoE);
				}

				if (HasEffect(Buffs.SubstractivePalette))
				{
					return OriginalHook(BlizzardCyanAoE);
				}
			}

			return actionID;
        }
    }


    internal class PictomancerHolyCometCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerHolyCometCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == HolyWhite)
            {
                if (HasEffect(Buffs.MonochromeTones))
                    return CometBlack;
            }

            return actionID;
        }
    }

    internal class PictomancerCreatureMotifCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PctAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<PCTGauge>();

            if (actionID == CreatureMotif)
            {
                if (IsEnabled(CustomComboPreset.PictomancerCreatureMogCombo) && CanUseAction(OriginalHook(MogOftheAges)))
                {
                    if (gauge.MooglePortraitReady || gauge.MadeenPortraitReady)
                    {
                        if (IsCooldownUsable(MogOftheAges))
                            return OriginalHook(MogOftheAges);
                    }
                }

                if (IsEnabled(CustomComboPreset.PictomancerCreatureMotifCombo))
                {
                    if (actionID == CreatureMotif)
                    {
                        if (OriginalHook(LivingMuse) != LivingMuse)
                            return OriginalHook(LivingMuse);
                    }
                }
            }

            return actionID;
        }
    }

    internal class PictomancerWeaponMotifCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PctAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<PCTGauge>();

            if (actionID == WeaponMotif)
            {
                if (IsEnabled(CustomComboPreset.PictomancerWeaponMotifCombo))
                {
                    if (gauge.WeaponMotifDrawn)
                        return StrikingMuse;
                }

                if (IsEnabled(CustomComboPreset.PictomancerWeaponHammerCombo))
                {
                    if (HasEffect(Buffs.HammerReady))
                    {
                        return OriginalHook(HammerStamp);
                    }
                }
            }

            return actionID;
        }
    }

    internal class PictomancerLandscapeMotifCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PctAny;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            var gauge = GetJobGauge<PCTGauge>();

            if (actionID == LandscapeMotif)
            {
                if (IsEnabled(CustomComboPreset.PictomancerLandscapeMotifCombo))
                {
                    if (IsEnabled(CustomComboPreset.PictomancerLandscapePrismCombo) &&
                        HasEffect(Buffs.StarPrismReady))
                        return OriginalHook(StarPrism);

                    if (gauge.LandscapeMotifDrawn)
                        return OriginalHook(ScenicMuse);
                }
            }

            return actionID;
        }
    }

    internal class PictomancerStarryMuseCombo : CustomCombo
    {
        protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerLandscapePrismCombo;

        protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
        {
            if (actionID == ScenicMuse)
            {
                if (HasEffect(Buffs.StarPrismReady))
                    return OriginalHook(StarPrism);
            }

            return actionID;
        }
    }
}
