using System;
using SkillfulClothes.Types;
using StardewValley;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000051 RID: 81
	public class SeasonalEffectParameters : IEffectParameters
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x00003475 File Offset: 0x00001675
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x0000347D File Offset: 0x0000167D
		public Season Season { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00003486 File Offset: 0x00001686
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0000348E File Offset: 0x0000168E
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060001B5 RID: 437 RVA: 0x00003497 File Offset: 0x00001697
		public static SeasonalEffectParameters With(Season season, IEffect actualEffect)
		{
			return new SeasonalEffectParameters
			{
				Season = season,
				Effect = actualEffect
			};
		}
	}
}
