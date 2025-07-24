using Events.Cards;
using Events.Main.CharactersBattle.Enemies.EnemyData;
using Events.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class EnemyManager: MonoBehaviour
    {
        [SerializeField] private CharacterView _enamyView;
        [SerializeField] private ColorForCardTypeView _colorForCardTypeView;
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private TMP_Text _name;

        public event Action Died;
        
        private EnemyDataBattle _enemyData;

        public EnemyDataBattle EnemyData => _enemyData;

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }

        public void InitNewEnemy(int level)
        {
            InitNewEnemy(_spawner.GetNewEnemyData(level));
        }

        public void InitNewBossEnemy()
        {
            InitNewEnemy(_spawner.GetNewBossData());
        }

        public void InitNewEnemy(EnemyDataBattle enemyData)
        {
            Unsubscribe();
            _enemyData = enemyData;
            Subscribe();

            _enemyData.NewInitValue();

            _enamyView.SetCharacter(_enemyData);
            _colorForCardTypeView.SetColorForCardType(_enemyData.ArmorBar);

            _name.text = _enemyData.Name;

            _enemyData.StartRound();
        }

        public void Attack(PlayerBattle player)
        {
            _enemyData.Attack(player);
        }

        public void TakeAttack(int damage, List<CardType> cardTypesList = null)
        {
            _enemyData.TakeAttack(damage, cardTypesList);

            _enemyData.CheckAlive();
        }

        public void KillEnemy()
        {
            TakeAttack(_enemyData.HPBar.CurrentValue);
        }

        private void Subscribe()
        {
            if (_enemyData != null)
            {
                _enemyData.Died += Died;
            }
        }

        private void Unsubscribe()
        {
            if (_enemyData != null)
            {
                _enemyData.Died -= Died;
            }
        }
    }
}