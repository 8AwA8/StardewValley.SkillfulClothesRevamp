using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000C1 RID: 193
	public class ItemProduceParameters : IEffectParameters
	{
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000473 RID: 1139 RVA: 0x00005425 File Offset: 0x00003625
		// (set) Token: 0x06000474 RID: 1140 RVA: 0x0000542D File Offset: 0x0000362D
		public int Steps { get; set; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x00005436 File Offset: 0x00003636
		// (set) Token: 0x06000476 RID: 1142 RVA: 0x0000543E File Offset: 0x0000363E
		public string displayName { get; set; }

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00005447 File Offset: 0x00003647
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x0000544F File Offset: 0x0000364F
		public string qId { get; set; }

		// Token: 0x06000479 RID: 1145 RVA: 0x00005458 File Offset: 0x00003658
		public static ItemProduceParameters With(int steps, string displayName, string qId)
		{
			return new ItemProduceParameters
			{
				Steps = steps,
				displayName = displayName,
				qId = qId
			};
		}
	}
}
