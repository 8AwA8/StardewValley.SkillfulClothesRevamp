using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;
using StardewValley.Locations;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000079 RID: 121
	internal class IncreaseStats : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00003E5B File Offset: 0x0000205B
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Glow;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00003E5F File Offset: 0x0000205F
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-DSS");
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000D614 File Offset: 0x0000B814
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			MineShaft mineShaft = Game1.currentLocation as MineShaft;
			if (mineShaft != null && mineShaft.mineLevel < 121 && mineShaft.mineLevel < 10000)
			{
				targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)mineShaft.mineLevel / 25f;
				targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)mineShaft.mineLevel / 50f;
				return;
			}
			if (mineShaft != null && mineShaft.mineLevel > 120 && mineShaft.mineLevel < 10000)
			{
				targetEffects.Attack.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)(mineShaft.mineLevel - 120) / 25f;
				targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * (float)(mineShaft.mineLevel - 120) / 50f;
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseStats(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseStats(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
