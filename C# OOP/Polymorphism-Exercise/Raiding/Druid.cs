using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        private readonly string heroType;
        public Druid(string name) 
            : base(name)
        {
            this.heroType = this.GetType().Name;
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return $"{this.heroType} - {this.Name} healed for {this.Power}";
        }
    }
}
