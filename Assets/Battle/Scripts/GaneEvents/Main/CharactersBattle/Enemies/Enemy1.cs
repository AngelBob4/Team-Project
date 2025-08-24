using Events.Animation;
using Events.Cards;
using Events.Main.CharactersBattle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(EnemyAI))]
public class Enemy1 : MonoBehaviour
{
    [SerializeField] private int _lavel;
    [SerializeField] private int _hP;
    
    private Animator _animation;
    private EnemyAI _enemyAI;
    private EnemyData1 _enemyData;
    private int _takeDamage;

    private string _animatorAttack = "AttackTrigger";
    private string _animatorSpecialAttack = "SpecialATrigger";
    private string _animatorTakeAttack = "TalkTrigger";
    private string _animatorJump = "JumpTrigger";

    public EnemyData1 EnemyData => _enemyData;
    public bool IsLive => _enemyData.HPBar.CurrentValue <= 0;
    public int Lavel => _lavel;

    public void Awake()
    {
        _enemyData = new EnemyData1(_hP);
        _animation = GetComponent<Animator>();
        _enemyAI = GetComponent<EnemyAI>();
        _enemyAI.Init(this, _enemyData);
    }

    public int TakeAttack(int damage, List<CardType> cardTypesList = null)
    {
        if (_enemyData.ArmorBar != null && _enemyData.CardTypeArmorWeakness != CardType.Null && cardTypesList != null)
        {
            foreach (CardType cardType in cardTypesList)
            {
                if (cardType == _enemyData.CardTypeArmorWeakness)
                {
                    _enemyData.RemoveArmor();
                }
            }
        }

        _takeDamage = _enemyData.TakeAttack(damage);

        if (_takeDamage > 0)
        {
            MoveAnimation(AnimationType.TakeAttack);
        }

        return _enemyData.TakeAttack(damage);
    }

    public void Attack(PlayerBattle player)
    {
        _animation.SetTrigger(_animatorAttack);
        _enemyAI.Attack(player);
    }

    public void StartTurn()
    {
        //if (_enemyAI.IsRemoveArmorOfTurn && _enemyData.ArmorBar != null)
        //{
        //    _enemyData.RemoveArmor();
        //}
    }

    public void MoveAnimation(AnimationType animationType)
    {
       switch(animationType)
        {
            case AnimationType.Attack:
                Debug.Log("Animation Attack");
                _animation.SetTrigger(_animatorAttack);
                break;
                
            case AnimationType.SpecialAttack:
                Debug.Log("Animation SpecialAttack");
                _animation.SetTrigger(_animatorSpecialAttack);
                break;

            case AnimationType.TakeAttack:
                Debug.Log("Animation TakeAttack");
                _animation.SetTrigger(_animatorTakeAttack);
                break;
            
            case AnimationType.Jump:
                Debug.Log("Animation Jump");
                _animation.SetTrigger(_animatorJump);
                break;
        }
    }
}
