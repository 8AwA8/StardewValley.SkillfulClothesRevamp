using System;
using SkillfulClothes.Effects;

namespace SkillfulClothes.Configuration
{
	// Token: 0x02000067 RID: 103
	public class CustomEffectItemDefinition
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000231 RID: 561 RVA: 0x000038A8 File Offset: 0x00001AA8
		public string ItemIdentifier { get; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000232 RID: 562 RVA: 0x000038B0 File Offset: 0x00001AB0
		public IEffect Effect { get; }

		// Token: 0x06000233 RID: 563 RVA: 0x000038B8 File Offset: 0x00001AB8
		public CustomEffectItemDefinition(string id, IEffect effect)
		{
			this.ItemIdentifier = id;
			this.Effect = effect;
		}
	}
}
