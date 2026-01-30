using System;
using SkillfulClothes.Configuration;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;
using StardewValley.Buffs;

namespace SkillfulClothes.Effects.Skills
{
	// Token: 0x0200005C RID: 92
	internal class IncreaseSpeed : ChangeSkillEffect<AmountEffectParameters>
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000364B File Offset: 0x0000184B
		protected override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Speed;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001EA RID: 490 RVA: 0x0000364F File Offset: 0x0000184F
		public override string SkillName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Skills-Speed");
			}
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0000C060 File Offset: 0x0000A260
		protected override void UpdateEffects(Farmer farmer, BuffEffects targetEffects)
		{
			targetEffects.Speed.Value = (float)base.Parameters.Amount * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().OneToOneSpeed ? 1f : 0.75f) * (EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().LessImpactfulClothes ? EffectHelper.ModHelper.ReadConfig<SkillfulClothesConfig>().TypicalClothesMultiple : 1f);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x0000356D File Offset: 0x0000176D
		public IncreaseSpeed(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00003576 File Offset: 0x00001776
		public IncreaseSpeed(int amount) : base(AmountEffectParameters.With(amount))
		{
		}
	}
}
