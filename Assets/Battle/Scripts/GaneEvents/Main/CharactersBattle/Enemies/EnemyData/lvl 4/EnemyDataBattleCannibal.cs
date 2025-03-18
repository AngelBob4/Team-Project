using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleCannibal : EnemyDataBattle
    {
        private readonly int _attackClubDamageHP = 2;
        private readonly int _attackClubDamageCard = 2;
        private readonly int _attackClawDamage = 3;

        public EnemyDataBattleCannibal()
        {
            _name = "Канибал";
            _level = 4;
            _hP = 10;

            _attackList = new List<Action>() { AttackClub, AttackClaw };
        }

        private void AttackClub()
        {
            Debug.Log("Cannibal AttackClub");

            if (AttackDamag(_attackClubDamageHP) > 0)
            {
                AttackDamagCards(0, _attackClubDamageCard);
            }
        }

        private void AttackClaw()
        {
            Debug.Log("Cannibal AttackClaw");

            if (AttackDamag(_attackClawDamage) > 0)
            {
                PlayerToPoison();
            }
        }
    }
}
