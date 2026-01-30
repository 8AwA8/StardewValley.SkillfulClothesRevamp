using System;
using Microsoft.Xna.Framework;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Attributes
{
	// Token: 0x0200005F RID: 95
	public class AttributeRegenParameters : IEffectParameters
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060001FC RID: 508 RVA: 0x000036C6 File Offset: 0x000018C6
		// (set) Token: 0x060001FD RID: 509 RVA: 0x000036CE File Offset: 0x000018CE
		public int SecondsToStandStill { get; set; } = 1;

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001FE RID: 510 RVA: 0x000036D7 File Offset: 0x000018D7
		// (set) Token: 0x060001FF RID: 511 RVA: 0x000036DF File Offset: 0x000018DF
		public int RegenIntervalSeconds { get; set; } = 1;

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000200 RID: 512 RVA: 0x000036E8 File Offset: 0x000018E8
		// (set) Token: 0x06000201 RID: 513 RVA: 0x000036F0 File Offset: 0x000018F0
		public int RegenAmount { get; set; } = 10;

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000202 RID: 514 RVA: 0x000036F9 File Offset: 0x000018F9
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00003701 File Offset: 0x00001901
		public Color GlowColor { get; set; } = Color.Green;

		// Token: 0x06000205 RID: 517 RVA: 0x00003733 File Offset: 0x00001933
		public static AttributeRegenParameters With(Color glowColor, int secondsToStandStill, int regenIntervalSeconds = 1, int regenAmount = 1)
		{
			return new AttributeRegenParameters
			{
				GlowColor = glowColor,
				SecondsToStandStill = secondsToStandStill,
				RegenIntervalSeconds = regenIntervalSeconds,
				RegenAmount = regenAmount
			};
		}
	}
}
