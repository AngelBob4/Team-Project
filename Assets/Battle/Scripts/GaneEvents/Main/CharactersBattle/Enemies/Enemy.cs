using Events.Main.CharactersBattle.Enemies.EnemyData;
using Events.View;
using System;
using TMPro;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class Enemy : CharacterBattle
    {
        [SerializeField] private CharacterView _enamyView;
        [SerializeField] private EnemySpawner _spawner;
        [SerializeField] private TMP_Text _name;

        private EnemyDataBattle _enemyData;

        public override event Action Died;

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

        public void InitNewEnemy(EnemyDataBattle enemyData)
        {
            Unsubscribe();
            _enemyData = enemyData;
            Subscribe();

            _enemyData.NewInitValue();
            _hPBar = _enemyData.HP;
            _armorBar = _enemyData.Armor;

            _enamyView.SetCharacter(this);

            _name.text = _enemyData.Name;
        }

        public override void Attack(ICharacter character)
        {
            _enemyData.Attack(character);
        }

        public override void TakeAttack(int damage)
        {
            if (_enemyData.IsDefaultTakeAttack)
            {
                DefaultTakeAttack(damage);
            }
            else
            {
                _enemyData.TakeAttack(damage);
            }

            _enemyData.CheckAlive();
        }

        public override void StartRound()
        {
            _enemyData.StartRound();
        }

        public void KillEnemy()
        {
            TakeAttack(_enemyData.HP.CurrentValue);
        }

        protected override void DefaultTakeDamage(int damage)
        {
            _hPBar.ChangeValue(-damage);
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
