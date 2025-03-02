using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleRat : EnemyDataBattle
    {
        private readonly int _attackClawDamage = 1;
        private readonly int _armor = 3;

        public EnemyDataBattleRat()
        {
            _name = "Крыса";
            _level = 1;
            _hP = 3;
            _armorBar = new ColorBar();

            _attackList = new List<Action>() { Evade, AttackClaw };
            _cardTypeArmorWeaknessList = new List<CardType>() { CardType.Yellow, CardType.Purple, CardType.Blue };
        }

        public override void Attack(PlayerBattle player, bool isRemoveArmor = true)
        {
            RemoveArmor();

            base.Attack(player);
        }

        private void Evade()
        {
            Debug.Log(_name + " Evade");

            SetArmorAndWeakness(_armor);
        }

        private void AttackClaw()
        {
            Debug.Log(_name + " AttackClaw");

            if (AttackDamag(_attackClawDamage) > 0)
            {
                PlayerToPoison();
            }
        }
    }
}