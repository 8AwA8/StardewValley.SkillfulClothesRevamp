using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008E RID: 142
	public class SappingParameters : IEffectParameters
	{
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00004496 File Offset: 0x00002696
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000449E File Offset: 0x0000269E
		public int Chance { get; set; }

		// Token: 0x06000331 RID: 817 RVA: 0x000044A7 File Offset: 0x000026A7
		public static SappingParameters With(int chance)
		{
			return new SappingParameters
			{
				Chance = chance
			};
		}
	}
}
