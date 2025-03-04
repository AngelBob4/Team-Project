using Events.Main.CharactersBattle.Enemies.EnemyData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        private List<EnemyDataBattle> _enemies;
        private List<EnemyDataBattle> _bossList;
        private List<EnemyDataBattle> _currentListEnemy;
        private Dictionary<int, List<EnemyDataBattle>> _enemiesByLevel = new Dictionary<int, List<EnemyDataBattle>>();

        private void Awake()
        {
            _enemies = new List<EnemyDataBattle>()
            {
                new EnemyDataBattleRat(),
                new EnemyDataBattleSpirit(),
                new EnemyDataBattleWolf(),

                new EnemyDataBattleCannibal(),
                new EnemyDataBattleRobber(),
                new EnemyDataBattleGhost(),

                new EnemyDataBattleOgre(),
                new EnemyDataBattleSectarian(),
                new EnemyDataBattleStryga(),
            }
            ;

            _bossList = new List<EnemyDataBattle>()
            {
                new EnemyDataBattleWerewolf(),
                new EnemyDataBattleVampire(),
                new EnemyDataBattleBeetle(),
            }
           ;

            foreach (EnemyDataBattle enemy in _enemies)
            {
                if (_enemiesByLevel.ContainsKey(enemy.Lavel))
                {
                    _enemiesByLevel[enemy.Lavel].Add(enemy);
                }
                else
                {
                    _enemiesByLevel.Add(enemy.Lavel, new List<EnemyDataBattle>());
                    _enemiesByLevel[enemy.Lavel].Add(enemy);
                }
            }
        }

        public EnemyDataBattle GetNewEnemyData(int level)
        {
            _currentListEnemy = GetCorrectListEnemy(level);

            return _currentListEnemy[UnityEngine.Random.Range(0, _currentListEnemy.Count)];
        }

        public EnemyDataBattle GetNewBossData()
        {
            return _bossList[UnityEngine.Random.Range(0, _bossList.Count)];
        }

        private List<EnemyDataBattle> GetCorrectListEnemy(int level)
        {
            while (level > 0)
            {
                if (_enemiesByLevel.ContainsKey(level))
                {
                    return _enemiesByLevel[level];
                }
                else
                {
                    level--;
                }
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}