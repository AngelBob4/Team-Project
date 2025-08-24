using Events.Cards;
using Events.Main.CharactersBattle;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    protected EnemyData1 _enemyData;
    protected Enemy1 _enemy;
    protected PlayerBattle _player;
    //protected bool _isRemoveArmorOfTurn = true;
    protected List<Action> _attackList;

    private Action _curretAttack;
    private Action _newAttack;
    private int _repeatsRandomAttack = 2;

    //public bool IsRemoveArmorOfTurn => _isRemoveArmorOfTurn;

    public void Init(Enemy1 enemy, EnemyData1 enemyData)
    {
        _enemyData = enemyData;
        _enemy = enemy;
    }

    public void Attack(PlayerBattle player)
    {
        _player = player;

        Debug.Log("--------------------START-ATTACK--------------------");

        if (_enemyData.IsStunned == false)
        {
            CastAttack();
        }

        Debug.Log("---------------------END-ATTACK---------------------");

        EndOfAttack();
    }

    protected virtual void CastAttack()
    {
        if (_attackList == null || _attackList.Count == 0)
        {
            throw new System.NotImplementedException();
        }

        _curretAttack = GetNewAttack();
        _curretAttack();

        Action GetNewAttack()
        {
            for(int i = 0; i < _repeatsRandomAttack; i++)
            {
                _newAttack = _attackList[UnityEngine.Random.Range(0, _attackList.Count)];

                if(_newAttack != _curretAttack)
                {
                    break;
                }
            }

            return _newAttack;
        }
    }

    protected virtual void EndOfAttack()
    {
        if (_enemyData.ArmorBar != null)
        {
            _enemyData.RemoveArmor();
        }
    }

    protected void AttackDamagCards(int hand, int deck)
    {
        _player.TakeDamageCards(hand, deck);
        Debug.Log("   DamageHandCard " + hand);
        Debug.Log("   DamageDeckCard " + deck);
    }

    protected int AttackDamag(int damage, int ignoringArmor = 0)
    {
        if (ignoringArmor == 0)
        {
            Debug.Log("   Damage " + damage);
            return _player.TakeAttack(damage);
        }
        else
        {
            if (ignoringArmor > 0)
            {
                Debug.Log("   Damage " + damage + " (IgnoringArmor " + ignoringArmor + ")");
                _player.CharacterBattleData.ArmorBar.ChangeValue(-ignoringArmor);
            }
            else
            {
                Debug.Log("   Damage " + damage + " (AllIgnoringArmor)");
                _player.CharacterBattleData.ArmorBar.SetValueDefault();
            }

            return _player.TakeAttack(damage);
        }
    }

    protected void PlayerToPoison()
    {
        _player.ToPoison();
        Debug.Log("   Отравление");
    }

    protected void RegenerationHP(int hp, bool isValidationCheck = true)
    {
        _enemyData.HPBar.ChangeValue(hp, isValidationCheck);
        Debug.Log("   Regeneration " + hp);
    }

    protected void MoveAnimation(AnimationType animationType)
    {
        _enemy.MoveAnimation(animationType);
    }
}
