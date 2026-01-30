using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000087 RID: 135
	public class NapalmParameters : IEffectParameters
	{
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00004238 File Offset: 0x00002438
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00004240 File Offset: 0x00002440
		public int ExtraDamage { get; set; }

		// Token: 0x06000306 RID: 774 RVA: 0x00004249 File Offset: 0x00002449
		public static NapalmParameters With(int damage)
		{
			return new NapalmParameters
			{
				ExtraDamage = damage
			};
		}
	}
}
