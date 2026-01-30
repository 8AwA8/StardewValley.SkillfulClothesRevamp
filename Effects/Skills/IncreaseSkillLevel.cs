using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Types;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005A RID: 90
	internal class IncreaseSkillLevel : ChangeSkillEffect<IncreaseSkillLevelParameters>
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000BB8C File Offset: 0x00009D8C
		public override string SkillName
		{
			get
			{
				if (EffectHelper.ModHelper.Translation.Get("Skills-" + base.Parameters.Skill.ToString()).HasValue())
				{
					return EffectHelper.ModHelper.Translation.Get("Skills-" + base.Parameters.Skill.ToString());
				}
				return base.Parameters.Skill.ToString();
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000BC24 File Offset: 0x00009E24
		protected override EffectIcon Icon
		{
			get
			{
				IncreaseSkillLevelParameters parameters = base.Parameters;
				if (parameters == null)
				{
					return EffectIcon.None;
				}
				return parameters.Skill.GetIcon();
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000BC48 File Offset: 0x00009E48
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			switch (base.Parameters.Skill)
			{
			case Skill.Farming:
				targetEffects.FarmingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Fishing:
				targetEffects.FishingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Foraging:
				targetEffects.ForagingLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Mining:
				targetEffects.MiningLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Combat:
				targetEffects.CombatLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.Luck:
				targetEffects.LuckLevel.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
				return;
			case Skill.CustomLuck:
				return;
			case Skill.Cooking:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.spacechase0.Cooking", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.YACS:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.moonslime.Cooking", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.Travelling:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.Achtuur.Travelling", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.Socializing:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.drbirbdev.Socializing", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.Binning:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.drbirbdev.Binning", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.Archaeology:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.moonslime.Archaeology", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			case Skill.Theiving:
				this.thisBuff.customFields.Add("spacechase0.SpaceCore.SkillBuff.moonslime.Spooky", ((float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f)).ToString());
				return;
			default:
				return;
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00003605 File Offset: 0x00001805
		public IncreaseSkillLevel(IncreaseSkillLevelParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000360E File Offset: 0x0000180E
		public IncreaseSkillLevel(Skill skill, int amount) : base(IncreaseSkillLevelParameters.With(skill, amount))
		{
		}
	}
}
