using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009E RID: 158
	public class TimeEffectParameters : IEffectParameters
	{
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000394 RID: 916 RVA: 0x00004AB8 File Offset: 0x00002CB8
		// (set) Token: 0x06000395 RID: 917 RVA: 0x00004AC0 File Offset: 0x00002CC0
		public int timeStart { get; set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000396 RID: 918 RVA: 0x00004AC9 File Offset: 0x00002CC9
		// (set) Token: 0x06000397 RID: 919 RVA: 0x00004AD1 File Offset: 0x00002CD1
		public int timeEnd { get; set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000398 RID: 920 RVA: 0x00004ADA File Offset: 0x00002CDA
		// (set) Token: 0x06000399 RID: 921 RVA: 0x00004AE2 File Offset: 0x00002CE2
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x0600039A RID: 922 RVA: 0x00004AEB File Offset: 0x00002CEB
		public static TimeEffectParameters With(int timeStart, int timeEnd, IEffect actualEffect)
		{
			return new TimeEffectParameters
			{
				timeStart = timeStart,
				timeEnd = timeEnd,
				Effect = actualEffect
			};
		}
	}
}
