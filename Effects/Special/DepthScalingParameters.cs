using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000075 RID: 117
	public class DepthScalingParameters : IEffectParameters
	{
		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00003D21 File Offset: 0x00001F21
		// (set) Token: 0x0600029E RID: 670 RVA: 0x00003D29 File Offset: 0x00001F29
		public int recursiveFloors { get; set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00003D32 File Offset: 0x00001F32
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00003D3A File Offset: 0x00001F3A
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x060002A2 RID: 674 RVA: 0x00003D56 File Offset: 0x00001F56
		public static DepthScalingParameters With(int floors, IEffect actualEffect)
		{
			return new DepthScalingParameters
			{
				recursiveFloors = floors,
				Effect = actualEffect
			};
		}
	}
}
