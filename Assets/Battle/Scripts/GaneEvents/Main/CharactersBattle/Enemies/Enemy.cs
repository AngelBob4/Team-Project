using Events.Main.CharactersBattle.Enemies.EnemyData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator _animation;
    [SerializeField] private EnamyType _enamyType;
    
    private EnemyDataBattle _enemyDataBattle;

    public EnemyDataBattle EnemyDataBattle => _enemyDataBattle;

    public void Init()
    {
        switch (_enamyType)
        {
            case EnamyType.Rat:
                _enemyDataBattle = new EnemyDataBattleRat(); 
                break;

            case EnamyType.Spirit:
                _enemyDataBattle = new EnemyDataBattleSpirit();
                break;

            case EnamyType.Wolf:
                _enemyDataBattle = new EnemyDataBattleWolf();
                break;

            case EnamyType.Cannibal:
                _enemyDataBattle = new EnemyDataBattleCannibal();
                break;

            case EnamyType.Ghost:
                _enemyDataBattle = new EnemyDataBattleGhost();
                break;

            case EnamyType.Robber:
                _enemyDataBattle = new EnemyDataBattleRobber();
                break;

            case EnamyType.Ogre:
                _enemyDataBattle = new EnemyDataBattleOgre();
                break;

            case EnamyType.Sectarian:
                _enemyDataBattle = new EnemyDataBattleSectarian();
                break;

            case EnamyType.Stryga:
                _enemyDataBattle = new EnemyDataBattleStryga();
                break;

            case EnamyType.Beetle:
                _enemyDataBattle = new EnemyDataBattleBeetle();
                break;

            case EnamyType.Vampire:
                _enemyDataBattle = new EnemyDataBattleVampire();
                break;

            case EnamyType.Werewolf:
                _enemyDataBattle = new EnemyDataBattleWerewolf();
                break;
        }
    }
}
