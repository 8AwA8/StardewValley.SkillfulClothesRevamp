using System;
using SkillfulClothes.Effects;
using StardewValley;

namespace SkillfulClothes.Types
{
	// Token: 0x02000031 RID: 49
	public static class SkilLExtensions
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00009088 File Offset: 0x00007288
		public static EffectIcon GetIcon(this Skill skill)
		{
			switch (skill)
			{
			case Skill.Farming:
				return EffectIcon.SkillFarming;
			case Skill.Fishing:
				return EffectIcon.SkillFishing;
			case Skill.Foraging:
				return EffectIcon.SkillForaging;
			case Skill.Mining:
				return EffectIcon.SkillMining;
			case Skill.Combat:
				return EffectIcon.SkillCombat;
			case Skill.Luck:
				return EffectIcon.SkillLuck;
			case Skill.Cooking:
				return EffectIcon.Stardrop;
			case Skill.YACS:
				return EffectIcon.Stardrop;
			case Skill.Travelling:
				return EffectIcon.Speed;
			case Skill.Socializing:
				return EffectIcon.Heart;
			case Skill.Binning:
				return EffectIcon.SkillLuck;
			case Skill.Archaeology:
				return EffectIcon.SkillMining;
			case Skill.Theiving:
				return EffectIcon.SaveFromDeath;
			}
			return EffectIcon.None;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00009100 File Offset: 0x00007300
		public static int GetCurrentLevel(this Skill skill)
		{
			switch (skill)
			{
			case Skill.Farming:
				return Game1.player.FarmingLevel;
			case Skill.Fishing:
				return Game1.player.FishingLevel;
			case Skill.Foraging:
				return Game1.player.ForagingLevel;
			case Skill.Mining:
				return Game1.player.MiningLevel;
			case Skill.Combat:
				return Game1.player.CombatLevel;
			default:
				return 0;
			}
		}
	}
}
