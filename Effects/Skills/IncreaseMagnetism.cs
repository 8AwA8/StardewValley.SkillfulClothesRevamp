using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007E RID: 126
	internal class IncreaseMagnetism : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060002CF RID: 719 RVA: 0x00003EED File Offset: 0x000020ED
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.TreasureChest;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00003EF1 File Offset: 0x000020F1
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Mag");
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000D900 File Offset: 0x0000BB00
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.MagneticRadius.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) * 64f;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseMagnetism(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseMagnetism(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
