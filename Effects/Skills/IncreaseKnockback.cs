using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200007D RID: 125
	internal class IncreaseKnockback : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002CA RID: 714 RVA: 0x00003ECE File Offset: 0x000020CE
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Animal_Cow;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060002CB RID: 715 RVA: 0x00003ED2 File Offset: 0x000020D2
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-KB");
			}
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000D8AC File Offset: 0x0000BAAC
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.KnockbackMultiplier.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f) / 100f;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseKnockback(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseKnockback(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
