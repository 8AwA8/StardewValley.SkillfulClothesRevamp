using System;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000041 RID: 65
	internal static class RingTypeExtensions
	{
		// Token: 0x0600015B RID: 347 RVA: 0x00009DF4 File Offset: 0x00007FF4
		public static EffectDescriptionLine GetEffectDescription(this RingType ring)
		{
			if (ring <= RingType.NapalmRing)
			{
				switch (ring)
				{
				case RingType.GlowRing:
					return new EffectDescriptionLine(EffectIcon.Glow, "Glow");
				case (RingType)518:
				case (RingType)519:
					break;
				case RingType.SlimeCharmerRing:
					return new EffectDescriptionLine(EffectIcon.Defense, EffectHelper.ModHelper.Translation.Get("Ring-Slime"));
				case RingType.WarriorRing:
					return new EffectDescriptionLine(EffectIcon.None, "Sometimes become enfused with warrior force after killing");
				case RingType.VampireRing:
					return new EffectDescriptionLine(EffectIcon.None, "Absorb the life of slain enemies");
				case RingType.SavageRing:
					return new EffectDescriptionLine(EffectIcon.None, "Gain enhanced movement after killing enemies");
				case RingType.YobaRing:
					return new EffectDescriptionLine(EffectIcon.Yoba, EffectHelper.ModHelper.Translation.Get("Ring-Yoba"));
				case RingType.SturdyRing:
					return new EffectDescriptionLine(EffectIcon.Immunity, EffectHelper.ModHelper.Translation.Get("Ring-Sturdy"));
				case RingType.BurglarsRing:
					return new EffectDescriptionLine(EffectIcon.Red, EffectHelper.ModHelper.Translation.Get("Ring-Burglar"));
				default:
					if (ring == RingType.NapalmRing)
					{
						return new EffectDescriptionLine(EffectIcon.None, "Monsters explode on death");
					}
					break;
				}
			}
			else
			{
				if (ring == RingType.ThornsRing)
				{
					return new EffectDescriptionLine(EffectIcon.Defense, EffectHelper.ModHelper.Translation.Get("Ring-Thorns"));
				}
				if (ring == RingType.HotJavaRing)
				{
					return new EffectDescriptionLine(EffectIcon.None, "Monsters have a chance to drop delicious coffee");
				}
				if (ring == RingType.SoulSapperRing)
				{
					return new EffectDescriptionLine(EffectIcon.None, "Absorb the energy of slain enemies");
				}
				if (ring == RingType.ProtectiveRing)
				{
					return new EffectDescriptionLine(EffectIcon.Defense, EffectHelper.ModHelper.Translation.Get("Ring-Protective"));
				}
			}
			return new EffectDescriptionLine(EffectIcon.None, EffectHelper.ModHelper.Translation.Get("UnknownR"));
		}
	}
}
