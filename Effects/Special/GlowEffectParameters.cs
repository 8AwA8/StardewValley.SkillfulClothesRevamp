using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000049 RID: 73
	public class GlowEffectParameters : IEffectParameters
	{
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x0600017F RID: 383 RVA: 0x00003132 File Offset: 0x00001332
		// (set) Token: 0x06000180 RID: 384 RVA: 0x0000313A File Offset: 0x0000133A
		public float Radius { get; set; } = 5f;

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000181 RID: 385 RVA: 0x00003143 File Offset: 0x00001343
		// (set) Token: 0x06000182 RID: 386 RVA: 0x0000314B File Offset: 0x0000134B
		public Color Color { get; set; } = new Color(0, 30, 150);

		// Token: 0x06000183 RID: 387 RVA: 0x00003154 File Offset: 0x00001354
		public static GlowEffectParameters With(float radius, Color? color = null)
		{
			if (color == null)
			{
				color = new Color?(new Color(0, 30, 150));
			}
			return new GlowEffectParameters
			{
				Radius = radius,
				Color = color.Value
			};
		}
	}
}
