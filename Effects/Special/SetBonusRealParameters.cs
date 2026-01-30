using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects.Special
{
	// Token: 0x020000A8 RID: 168
	public class SetBonusRealParameters : IEffectParameters
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00004DBF File Offset: 0x00002FBF
		// (set) Token: 0x060003D0 RID: 976 RVA: 0x00004DC7 File Offset: 0x00002FC7
		public string hat { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x00004DD0 File Offset: 0x00002FD0
		// (set) Token: 0x060003D2 RID: 978 RVA: 0x00004DD8 File Offset: 0x00002FD8
		public string shirt { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x00004DE1 File Offset: 0x00002FE1
		// (set) Token: 0x060003D4 RID: 980 RVA: 0x00004DE9 File Offset: 0x00002FE9
		public string pants { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x00004DF2 File Offset: 0x00002FF2
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x00004DFA File Offset: 0x00002FFA
		public IEffect Effect { get; set; } = new NullEffect();

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00004E16 File Offset: 0x00003016
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00004E1E File Offset: 0x0000301E
		public string setBonus { get; set; }

		// Token: 0x060003DA RID: 986 RVA: 0x00004E27 File Offset: 0x00003027
		public static SetBonusRealParameters With(string hat, string shirt, string pants, string setBonus, string iconName, IEffect actualEffect)
		{
			return new SetBonusRealParameters
			{
				hat = hat,
				shirt = shirt,
				pants = pants,
				setBonus = setBonus,
				iconName = iconName,
				Effect = actualEffect
			};
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00004E5A File Offset: 0x0000305A
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00004E62 File Offset: 0x00003062
		public string iconName { get; set; }
	}
}
