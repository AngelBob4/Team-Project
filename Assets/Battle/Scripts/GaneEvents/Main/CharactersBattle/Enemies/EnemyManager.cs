using Events.Cards;
using Events.Main.CharactersBattle.Enemies.EnemyData;
using Events.Main.Events.Dialog;
using Events.View;
using Runner.NonPlayerCharacters;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Events.Main.CharactersBattle.Enemies
{
    public class EnemyManager: MonoBehaviour
    {
        [SerializeField] private Transform _enamyTransform;
        [SerializeField] private CharacterView _enamyView;
        [SerializeField] private ColorForCardTypeView _armorColorBarView;
        [SerializeField] private EnemySpawner _spawner;
        //[SerializeField] private TMP_Text _name;

        public event Action Died;
        
        private Enemy1 _enemy;

        public Enemy1 EnemyData => _enemy;

        public void InitNewEnemy(int level)
        {
            InitNewEnemy(_spawner.GetNewEnemyData(level));
        }

        public void InitNewBossEnemy()
        {
           // InitNewEnemy(_spawner.GetNewBossData());
        }

        public void InitNewEnemy(Enemy1 enemy)
        {
            _enemy = Instantiate(enemy, _enamyTransform);

            _enamyView.SetBars(_enemy.EnemyData.HPBar, _enemy.EnemyData.ArmorBar);
            _armorColorBarView.SetColorForCardType(_enemy.EnemyData.ArmorBar);
        }

        public void Attack(PlayerBattle player)
        {
            _enemy.Attack(player);
        }

        public void TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _enemy.TakeAttack(damage, cardTypesList);
        }

        public void KillEnemy()
        {
            Died?.Invoke();
        }
    }
}