using System;
using System.Collections.Generic;
using SkillfulClothes.Types;

namespace SkillfulClothes.Effects
{
	// Token: 0x02000042 RID: 66
	internal abstract class SingleEffect<TParameters> : CustomizableEffect<TParameters> where TParameters : IEffectParameters, new()
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00002FAF File Offset: 0x000011AF
		public override List<EffectDescriptionLine> EffectDescription
		{
			get
			{
				if (this.effectDescription == null)
				{
					this.effectDescription = new List<EffectDescriptionLine>
					{
						this.GenerateEffectDescription()
					};
				}
				return this.effectDescription;
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00002FD6 File Offset: 0x000011D6
		public SingleEffect(TParameters parameters) : base(parameters)
		{
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00002FDF File Offset: 0x000011DF
		public override void ReloadParameters()
		{
			base.ReloadParameters();
			this.effectDescription = new List<EffectDescriptionLine>
			{
				this.GenerateEffectDescription()
			};
		}

		// Token: 0x0600015F RID: 351
		protected abstract EffectDescriptionLine GenerateEffectDescription();

		// Token: 0x0400021B RID: 539
		private List<EffectDescriptionLine> effectDescription;
	}
}
