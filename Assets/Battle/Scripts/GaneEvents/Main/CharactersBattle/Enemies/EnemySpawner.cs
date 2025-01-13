using Events.Main.CharactersBattle.Enemies.EnemyData;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Main.CharactersBattle.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyDataBattle> _enemies;
        
        private List<EnemyDataBattle> _currentListEnemy;
        private Dictionary<int, List<EnemyDataBattle>> EnemiesByLevel = new Dictionary<int, List<EnemyDataBattle>>();

        private void Awake()
        {
            foreach (EnemyDataBattle enemy in _enemies)
            {
                if (EnemiesByLevel.ContainsKey(enemy.Lavel))
                {
                    EnemiesByLevel[enemy.Lavel].Add(enemy);
                }
                else
                {
                    EnemiesByLevel.Add(enemy.Lavel, new List<EnemyDataBattle>());
                    EnemiesByLevel[enemy.Lavel].Add(enemy);
                }
            }
        }

        public EnemyDataBattle GetNewEnemyData(int level)
        {
            _currentListEnemy = GetCorrectListEnemy(level);

            return _currentListEnemy[UnityEngine.Random.Range(0, _currentListEnemy.Count)];
        }

        private List<EnemyDataBattle> GetCorrectListEnemy(int level)
        {
            while (level > 0)
            {
                if (EnemiesByLevel.ContainsKey(level))
                {
                    return EnemiesByLevel[level];
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
