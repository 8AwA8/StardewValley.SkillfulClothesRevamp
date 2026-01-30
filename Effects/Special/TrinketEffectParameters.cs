using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000B2 RID: 178
	public class TrinketEffectParameters : IEffectParameters
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x00004FD9 File Offset: 0x000031D9
		public static TrinketEffectParameters With(int Trinket)
		{
			return new TrinketEffectParameters
			{
				Trinket = Trinket
			};
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x00004FE7 File Offset: 0x000031E7
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x00004FEF File Offset: 0x000031EF
		public int Trinket { get; set; }
	}
}
