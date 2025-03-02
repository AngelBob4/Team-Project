using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleStryga : EnemyDataBattle
    {
        private readonly int _attackClawDamage = 4;
        private readonly int _attackClawIgnoringArmor = 2;
        private readonly int _attackkBiteDamage = 6;
        private readonly int _attackBiteIgnoringArmor = 1;
        private readonly int _attackBiteDamage—ard = -2;
        private readonly int _attackBiteRegenerationHP = 2;

        public EnemyDataBattleStryga()
        {
            _name = "—Ú˚„‡";
            _level = 7;
            _hP = 15;

            _attackList = new List<Action>() { AttackClaw, AttackClaw, AttackBite };
        }

        private void AttackClaw()
        {
            Debug.Log(_name + " AttackClaw");

            if(AttackDamag(_attackClawDamage, _attackClawIgnoringArmor) > 0)
            {
                PlayerToPoison();
            }
        }

        private void AttackBite()
        {
            Debug.Log(_name + " AttackBite");

            if (AttackDamag(_attackkBiteDamage, _attackBiteIgnoringArmor) > 0)
            {
                AttackDamagDeckCards(_attackBiteDamage—ard);
                PlayerToPoison();
                RegenerationHP(_attackBiteRegenerationHP);
            }
        }
    }
}