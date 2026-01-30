using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000AB RID: 171
	public class SetBonusDescParameters : IEffectParameters
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x00004F05 File Offset: 0x00003105
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x00004F0D File Offset: 0x0000310D
		public string setBonus { get; set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x00004F16 File Offset: 0x00003116
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x00004F1E File Offset: 0x0000311E
		public string iconName { get; set; }

		// Token: 0x060003F1 RID: 1009 RVA: 0x00004F3A File Offset: 0x0000313A
		public static SetBonusDescParameters With(string setBonus, string iconName, IEffect actualEffect)
		{
			return new SetBonusDescParameters
			{
				setBonus = setBonus,
				iconName = iconName,
				Effect = actualEffect
			};
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x00004F56 File Offset: 0x00003156
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x00004F5E File Offset: 0x0000315E
		public IEffect Effect { get; set; } = new NullEffect();
	}
}
