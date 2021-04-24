﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            //if (this.Name == character.Name)
            //{
            //    throw new InvalidOperationException("Cannot attack self!");
            //}

            character.Health += this.AbilityPoints;

            if (character.Health > character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }
    }
}