﻿using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillfulClothes.Effects
{
    abstract class SingleEffect : IEffect
    {
        List<EffectDescriptionLine> effectDescription;
        public List<EffectDescriptionLine> EffectDescription
        {
            get
            {
                if (effectDescription == null)
                {
                    effectDescription = new List<EffectDescriptionLine>() { GenerateEffectDescription() };
                }

                return effectDescription;
            }
        }        

        public abstract void Apply(Farmer farmer);

        public abstract void Remove(Farmer farmer);

        protected abstract EffectDescriptionLine GenerateEffectDescription();        
    }
}
