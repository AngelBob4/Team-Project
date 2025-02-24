using Events.Cards;
using Events.Main.CharactersBattle.Enemies.EnemyData;
using Events.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class Enemy: MonoBehaviour
    {
        [SerializeField] private CharacterView _enamyView;
        [SerializeField] private ColorForCardTypeView _colorForCardTypeView;
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private TMP_Text _name;

        public event Action Died;
        
        private EnemyDataBattle _enemyData;
        //private bool _isAtack = false;

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

            //return _isAtack;
        }

        //public override void StartRound()
        //{
        //    _enemyData.StartRound();
        //}

        public void KillEnemy()
        {
            TakeAttack(_enemyData.HPBar.CurrentValue);
        }

        //protected override void DefaultTakeDamage(int damage)
        //{
        //    _hPBar.ChangeValue(-damage);
        //}

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
