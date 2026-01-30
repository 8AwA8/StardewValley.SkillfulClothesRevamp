using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A1 RID: 161
	public class IGBuffParameters : IEffectParameters
	{
		// Token: 0x060003AF RID: 943 RVA: 0x00004BF8 File Offset: 0x00002DF8
		public static IGBuffParameters With(string buffid)
		{
			return new IGBuffParameters
			{
				buffId = buffid
			};
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x00004C06 File Offset: 0x00002E06
		// (set) Token: 0x060003B1 RID: 945 RVA: 0x00004C0E File Offset: 0x00002E0E
		public string buffId { get; set; }
	}
}
