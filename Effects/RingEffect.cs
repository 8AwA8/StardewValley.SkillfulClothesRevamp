using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003E RID: 62
	internal class RingEffect : SingleEffect<RingEffectParameters>
	{
		// Token: 0x06000152 RID: 338 RVA: 0x00002F67 File Offset: 0x00001167
		public RingEffect(RingEffectParameters parameters) : base(parameters)
		{
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00002F70 File Offset: 0x00001170
		public RingEffect(RingType ring) : base(RingEffectParameters.With(ring))
		{
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00002F7E File Offset: 0x0000117E
		protected override EffectDescriptionLine GenerateEffectDescription()
		{
			return base.Parameters.Ring.GetEffectDescription();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00002EB0 File Offset: 0x000010B0
		public override void Apply(Item sourceItem, EffectChangeReason reason)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00002EB0 File Offset: 0x000010B0
		public override void Remove(Item sourceItem, EffectChangeReason reason)
		{
		}
	}
}
