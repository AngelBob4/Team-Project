using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleWolf : EnemyDataBattle
    {
        private readonly int _attackClawDamage = 2;
        private readonly int _attackkBiteDamage = 3;
        private readonly int _attackBiteDamageÑard = 1;

        public EnemyDataBattleWolf()
        {
            _name = "Âîëê";
            _level = 1;
            _hP = 4;

            _attackList = new List<Action>() { AttackClaw, AttackClaw, AttackBite };
        }

        private void AttackClaw()
        {
            Debug.Log(_name + " AttackClaw");

            AttackDamag(_attackClawDamage);
        }

        private void AttackBite()
        {
            Debug.Log(_name + " AttackBite");

            if (AttackDamag(_attackkBiteDamage) > 0)
            {
                AttackDamagDeckCards(_attackBiteDamageÑard);
            }
        }
    }
}
