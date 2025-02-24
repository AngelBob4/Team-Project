using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies.EnemyData
{
    public class EnemyDataBattleSpirit : EnemyDataBattle
    {
        private readonly int _attackScareDamageDard = 2;
        private readonly int _attackByDrawingOutLivesDamage = 1;
        private readonly int _regenerationByDrawingOutLives = 2;
        private readonly int _regenerationInRound = 1;

        public EnemyDataBattleSpirit()
        {
            _name = "Äóõ";
            _level = 1;
            _hP = 4;

            _attackList = new List<Action>() { AttackScare, AttackDrawingOutLives };
        }

        public override void StartRound()
        {
            base.StartRound();

            if (_hPBar.CurrentValue < _hPBar.MaxValue)
            {
                Debug.Log("   RegenerationInRound: ");
                RegenerationHP(_regenerationInRound);
            }
        }

        private void AttackScare()
        {
            Debug.Log(_name + " AttackScare");

            AttackDamagDeckCards(_attackScareDamageDard);
        }

        private void AttackDrawingOutLives()
        {
            Debug.Log(_name + " AttackDrawingOutLives");

            if (AttackDamag(_attackByDrawingOutLivesDamage) > 0)
            {
                AttackDamagDeckCards(_attackScareDamageDard);
                RegenerationHP(_regenerationByDrawingOutLives, false);
            }
        }
    }
}
