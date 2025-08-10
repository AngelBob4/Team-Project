using Events.Main.CharactersBattle.Enemies.EnemyData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Enemy1> _enemies;
        [SerializeField] private List<Enemy> _enemiesLVL4;
        [SerializeField] private List<Enemy> _enemiesLVL7;
        
        //private List<EnemyDataBattle> _enemies;
        //private List<EnemyDataBattle> _bossList;
        private List<Enemy1> _currentListEnemy;
        private Dictionary<int, List<Enemy1>> _enemiesByLevel = new Dictionary<int, List<Enemy1>>();

        private void Awake()
        {
            //_enemies = new List<Enemy>()
            //{
            //    new EnemyDataBattleRat(),
            //    //new EnemyDataBattleSpirit(),
            //    //new EnemyDataBattleWolf(),
            //
            //    new EnemyDataBattleCannibal(),
            //    new EnemyDataBattleRobber(),
            //    new EnemyDataBattleGhost(),
            //
            //    new EnemyDataBattleOgre(),
            //    new EnemyDataBattleSectarian(),
            //    new EnemyDataBattleStryga(),
            //}
            //;
            //
            //_bossList = new List<EnemyDataBattle>()
            //{
            //    new EnemyDataBattleWerewolf(),
            //    new EnemyDataBattleVampire(),
            //    new EnemyDataBattleBeetle(),
            //}
            //
            //
            foreach (Enemy1 enemy in _enemies)
            {
                if (_enemiesByLevel.ContainsKey(enemy.Lavel) == false)
                {
                    _enemiesByLevel.Add(enemy.Lavel, new List<Enemy1>());
                    //_enemiesByLevel[enemy.Lavel].Add(enemy);
                }
                //else
                //{
                //    _enemiesByLevel.Add(enemy.Lavel, new List<Enemy1>());
                //    _enemiesByLevel[enemy.Lavel].Add(enemy);
                //}

                _enemiesByLevel[enemy.Lavel].Add(enemy);
            }
        }

        public Enemy1 GetNewEnemyData(int level)
        {
            _currentListEnemy = GetCorrectListEnemy(level);

            return _currentListEnemy[UnityEngine.Random.Range(0, _currentListEnemy.Count)];
        }

        //public EnemyDataBattle GetNewBossData()
        //{
        //    return _bossList[UnityEngine.Random.Range(0, _bossList.Count)];
        //}

        private List<Enemy1> GetCorrectListEnemy(int level)
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