using System;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000036 RID: 54
	public class EffectDescriptionLine
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00002EC5 File Offset: 0x000010C5
		public EffectIcon Icon { get; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00002ECD File Offset: 0x000010CD
		public string Text { get; }

		// Token: 0x06000139 RID: 313 RVA: 0x00002ED5 File Offset: 0x000010D5
		public EffectDescriptionLine(EffectIcon icon, string text)
		{
			this.Icon = icon;
			this.Text = text;
		}
	}
}
