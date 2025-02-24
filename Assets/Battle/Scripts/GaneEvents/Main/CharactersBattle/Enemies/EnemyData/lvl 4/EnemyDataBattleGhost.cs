using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleGhost : EnemyDataBattle
    {
        private readonly int _maxTakeDamageInRound = 2;
        private readonly int _attackByDrawingOutLivesDamage = 2;

        private int _currentDamage;

        public EnemyDataBattleGhost()
        {
            _name = "Призрак";
            _level = 4;
            _hP = 5;

            _attackList = new List<Action>() { AttackDrawingOutLives };
        }

        public override int TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            if(damage > _maxTakeDamageInRound)
            {
                damage = _maxTakeDamageInRound;
            }

            return base.TakeAttack(damage, cardTypesList);
        }

        private void AttackDrawingOutLives()
        {
            Debug.Log(_name + " AttackDrawingOutLives");

            _currentDamage = AttackDamag(_attackByDrawingOutLivesDamage);

            if (_currentDamage > 0)
            {
                AttackDamagDeckCards(_currentDamage);
                RegenerationHP(_currentDamage);
            }
        }
    }
}
