using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000070 RID: 112
	public class WeatherEffectParameters : IEffectParameters
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000283 RID: 643 RVA: 0x00003BA3 File Offset: 0x00001DA3
		// (set) Token: 0x06000284 RID: 644 RVA: 0x00003BAB File Offset: 0x00001DAB
		public WeatherGroup Weather { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000285 RID: 645 RVA: 0x00003BB4 File Offset: 0x00001DB4
		// (set) Token: 0x06000286 RID: 646 RVA: 0x00003BBC File Offset: 0x00001DBC
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000287 RID: 647 RVA: 0x00003BC5 File Offset: 0x00001DC5
		public static WeatherEffectParameters With(WeatherGroup weather, IEffect actualEffect)
		{
			return new WeatherEffectParameters
			{
				Weather = weather,
				Effect = actualEffect
			};
		}
	}
}
