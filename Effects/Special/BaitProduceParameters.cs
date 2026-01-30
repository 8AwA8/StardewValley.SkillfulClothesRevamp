using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200008B RID: 139
	public class BaitProduceParameters : IEffectParameters
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0000437E File Offset: 0x0000257E
		// (set) Token: 0x0600031F RID: 799 RVA: 0x00004386 File Offset: 0x00002586
		public int Steps { get; set; }

		// Token: 0x06000320 RID: 800 RVA: 0x0000438F File Offset: 0x0000258F
		public static BaitProduceParameters With(int steps)
		{
			return new BaitProduceParameters
			{
				Steps = steps
			};
		}
	}
}
