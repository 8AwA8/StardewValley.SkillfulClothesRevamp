﻿using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillfulClothes.Effects.Skills
{
    class IncreaseDefense : ChangeSkillEffect
    {
        protected override EffectIcon Icon => EffectIcon.Defense;

        public override string SkillName => "Defense";        

        protected override void ChangeCurrentLevel(Farmer farmer, int amount) => farmer.resilience += amount;

        public IncreaseDefense(int amount)
            : base(amount)
        {
            // --
        }
    }
}
