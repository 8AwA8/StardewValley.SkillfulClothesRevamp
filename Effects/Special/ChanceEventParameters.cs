using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000BA RID: 186
	public class ChanceEventParameters : IEffectParameters
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000452 RID: 1106 RVA: 0x000052DD File Offset: 0x000034DD
		// (set) Token: 0x06000453 RID: 1107 RVA: 0x000052E5 File Offset: 0x000034E5
		public int Chance { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000454 RID: 1108 RVA: 0x000052EE File Offset: 0x000034EE
		// (set) Token: 0x06000455 RID: 1109 RVA: 0x000052F6 File Offset: 0x000034F6
		public int Code { get; set; }

		// Token: 0x06000456 RID: 1110 RVA: 0x000052FF File Offset: 0x000034FF
		public static ChanceEventParameters With(int chance, int code)
		{
			return new ChanceEventParameters
			{
				Chance = chance,
				Code = code
			};
		}
	}
}
