using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x0200009C RID: 156
	public class NPCEffectParameters : IEffectParameters
	{
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000384 RID: 900 RVA: 0x000049D5 File Offset: 0x00002BD5
		// (set) Token: 0x06000385 RID: 901 RVA: 0x000049DD File Offset: 0x00002BDD
		public string NPC { get; set; }

		// Token: 0x06000386 RID: 902 RVA: 0x000049E6 File Offset: 0x00002BE6
		public static NPCEffectParameters With(string NPC, int amount, int type)
		{
			return new NPCEffectParameters
			{
				NPC = NPC,
				amount = amount,
				type = type
			};
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000387 RID: 903 RVA: 0x00004A02 File Offset: 0x00002C02
		// (set) Token: 0x06000388 RID: 904 RVA: 0x00004A0A File Offset: 0x00002C0A
		public int amount { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00004A13 File Offset: 0x00002C13
		// (set) Token: 0x0600038A RID: 906 RVA: 0x00004A1B File Offset: 0x00002C1B
		public int type { get; set; }
	}
}
