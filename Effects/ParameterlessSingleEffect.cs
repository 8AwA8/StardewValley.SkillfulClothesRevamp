using System;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000043 RID: 67
	internal abstract class ParameterlessSingleEffect : CustomizableEffect<NoEffectParameters>
	{
		// Token: 0x06000160 RID: 352 RVA: 0x00002FFE File Offset: 0x000011FE
		public ParameterlessSingleEffect() : base(NoEffectParameters.Default)
		{
		}
	}
}
