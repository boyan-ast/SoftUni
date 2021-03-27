using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int firePotionWeight = 5;
        public FirePotion() : base(firePotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health -= 20;
            //TODO: Decrease character health with 20
            //TODO: If health <= 0 character isAlive -> false
        }
    }
}
