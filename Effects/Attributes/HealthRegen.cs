using System;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x02000061 RID: 97
	internal class HealthRegen : AttributeRegenEffect
	{
		// Token: 0x06000210 RID: 528 RVA: 0x00003775 File Offset: 0x00001975
		public HealthRegen() : base(AttributeRegenParameters.With(Color.Red, 5, 1, 1))
		{
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000378A File Offset: 0x0000198A
		protected override string AttributeName
		{
			get
			{
				return EffectHelper.ModHelper.Translation.Get("Attribute-Health");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000037A5 File Offset: 0x000019A5
		public override EffectIcon Icon
		{
			get
			{
				return EffectIcon.Health;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000037A8 File Offset: 0x000019A8
		protected override int GetCurrentValue(Farmer farmer)
		{
			return farmer.health;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000037B0 File Offset: 0x000019B0
		protected override int GetMaxValue(Farmer farmer)
		{
			return farmer.maxHealth;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000037B8 File Offset: 0x000019B8
		protected override void SetCurrentValue(Farmer farmer, int newValue)
		{
			farmer.health = newValue;
		}
	}
}
