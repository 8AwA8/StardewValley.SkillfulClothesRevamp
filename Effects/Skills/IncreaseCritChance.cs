using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007A RID: 122
	internal class IncreaseCritChance : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002BB RID: 699 RVA: 0x00003E7A File Offset: 0x0000207A
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.CriticalHitRate;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00003E7D File Offset: 0x0000207D
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-CritC");
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000D7B0 File Offset: 0x0000B9B0
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.CriticalChanceMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseCritChance(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002BF RID: 703 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseCritChance(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
