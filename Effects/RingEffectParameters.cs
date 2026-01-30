using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000040 RID: 64
	public class RingEffectParameters : IEffectParameters
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000157 RID: 343 RVA: 0x00002F90 File Offset: 0x00001190
		// (set) Token: 0x06000158 RID: 344 RVA: 0x00002F98 File Offset: 0x00001198
		public RingType Ring { get; set; }

		// Token: 0x06000159 RID: 345 RVA: 0x00002FA1 File Offset: 0x000011A1
		public static RingEffectParameters With(RingType ring)
		{
			return new RingEffectParameters
			{
				Ring = ring
			};
		}
	}
}
