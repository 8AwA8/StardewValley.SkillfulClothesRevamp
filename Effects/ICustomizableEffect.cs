using System;

namespace SkillfulClothes.Effects
{
	// Token: 0x0200003B RID: 59
	public interface ICustomizableEffect : IEffect
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000145 RID: 325
		Type ParameterType { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000146 RID: 326
		// (set) Token: 0x06000147 RID: 327
		object ParameterObject { get; set; }

		// Token: 0x06000148 RID: 328
		void ReloadParameters();
	}
}
