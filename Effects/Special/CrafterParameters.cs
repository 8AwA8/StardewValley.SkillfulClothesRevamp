using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000098 RID: 152
	public class CrafterParameters : IEffectParameters
	{
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600036F RID: 879 RVA: 0x0000488C File Offset: 0x00002A8C
		// (set) Token: 0x06000370 RID: 880 RVA: 0x00004894 File Offset: 0x00002A94
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x06000371 RID: 881 RVA: 0x0000489D File Offset: 0x00002A9D
		public static CrafterParameters With(IEffect actualEffect)
		{
			return new CrafterParameters
			{
				Effect = actualEffect
			};
		}
	}
}
