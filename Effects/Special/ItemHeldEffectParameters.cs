using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A4 RID: 164
	public class ItemHeldEffectParameters : IEffectParameters
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060003BA RID: 954 RVA: 0x00004C84 File Offset: 0x00002E84
		// (set) Token: 0x060003BB RID: 955 RVA: 0x00004C8C File Offset: 0x00002E8C
		public string itemId { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00004C95 File Offset: 0x00002E95
		// (set) Token: 0x060003BD RID: 957 RVA: 0x00004C9D File Offset: 0x00002E9D
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060003BE RID: 958 RVA: 0x00004CA6 File Offset: 0x00002EA6
		public static ItemHeldEffectParameters With(string itemId, IEffect actualEffect)
		{
			return new ItemHeldEffectParameters
			{
				itemId = itemId,
				Effect = actualEffect
			};
		}
	}
}
