using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x02000094 RID: 148
	public class MeleePowerParameters : IEffectParameters
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000352 RID: 850 RVA: 0x000046AC File Offset: 0x000028AC
		// (set) Token: 0x06000353 RID: 851 RVA: 0x000046B4 File Offset: 0x000028B4
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000354 RID: 852 RVA: 0x000046BD File Offset: 0x000028BD
		// (set) Token: 0x06000355 RID: 853 RVA: 0x000046C5 File Offset: 0x000028C5
		public int WeaponID { get; set; }

		// Token: 0x06000356 RID: 854 RVA: 0x000046CE File Offset: 0x000028CE
		public static MeleePowerParameters With(IEffect actualEffect, int weaponid)
		{
			return new MeleePowerParameters
			{
				Effect = actualEffect,
				WeaponID = weaponid
			};
		}
	}
}
