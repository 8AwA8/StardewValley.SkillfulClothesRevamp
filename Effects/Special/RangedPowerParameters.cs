using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000083 RID: 131
	public class RangedPowerParameters : IEffectParameters
	{
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060002EB RID: 747 RVA: 0x00004094 File Offset: 0x00002294
		// (set) Token: 0x060002EC RID: 748 RVA: 0x0000409C File Offset: 0x0000229C
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060002ED RID: 749 RVA: 0x000040A5 File Offset: 0x000022A5
		public static RangedPowerParameters With(IEffect actualEffect)
		{
			return new RangedPowerParameters
			{
				Effect = actualEffect
			};
		}
	}
}
