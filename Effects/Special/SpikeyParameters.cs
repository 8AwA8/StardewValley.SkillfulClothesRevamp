using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000085 RID: 133
	public class SpikeyParameters : IEffectParameters
	{
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x00004166 File Offset: 0x00002366
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x0000416E File Offset: 0x0000236E
		public int ExtraDamage { get; set; }

		// Token: 0x060002FA RID: 762 RVA: 0x00004177 File Offset: 0x00002377
		public static SpikeyParameters With(int damage)
		{
			return new SpikeyParameters
			{
				ExtraDamage = damage
			};
		}
	}
}
