using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x02000057 RID: 87
	internal class IncreaseDefense : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00003584 File Offset: 0x00001784
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Defense;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x00003587 File Offset: 0x00001787
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Defense");
			}
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x0000B774 File Offset: 0x00009974
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Defense.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001D3 RID: 467 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseDefense(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseDefense(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
