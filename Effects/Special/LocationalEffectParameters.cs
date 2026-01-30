using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200004D RID: 77
	public class LocationalEffectParameters : IEffectParameters
	{
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000194 RID: 404 RVA: 0x000032AF File Offset: 0x000014AF
		// (set) Token: 0x06000195 RID: 405 RVA: 0x000032B7 File Offset: 0x000014B7
		public LocationGroup Location { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000196 RID: 406 RVA: 0x000032C0 File Offset: 0x000014C0
		// (set) Token: 0x06000197 RID: 407 RVA: 0x000032C8 File Offset: 0x000014C8
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000198 RID: 408 RVA: 0x000032D1 File Offset: 0x000014D1
		public static LocationalEffectParameters With(LocationGroup location, IEffect actualEffect)
		{
			return new LocationalEffectParameters
			{
				Location = location,
				Effect = actualEffect
			};
		}
	}
}
