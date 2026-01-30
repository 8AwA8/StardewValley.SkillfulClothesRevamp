using System;
using SkillfulClothes.Effects.SharedParameters;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000063 RID: 99
	internal class IncreaseMaxHealth : ChangeAttributeMaxEffect
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600021E RID: 542 RVA: 0x0000378A File Offset: 0x0000198A
		public override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Health");
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600021F RID: 543 RVA: 0x00003824 File Offset: 0x00001A24
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.MaxHealth;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000037DF File Offset: 0x000019DF
		public IncreaseMaxHealth(AmountEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000037E8 File Offset: 0x000019E8
		public IncreaseMaxHealth(int amount) : base(AmountEffectParameters.With(amount))
		{
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000037A8 File Offset: 0x000019A8
		protected override int GetCurrentValue(Farmer farmer)
		{
			return farmer.health;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000037B8 File Offset: 0x000019B8
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.health = newValue;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000037B0 File Offset: 0x000019B0
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxHealth;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00003827 File Offset: 0x00001A27
		protected override void SetMaxValue(Farmer farmer, int newValue)
		{
			farmer.maxHealth = newValue;
		}
	}
}
