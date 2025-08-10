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
    [SerializeField] private List<CardType> _cardTypeArmorWeaknessList;
    
    private Animator _animation;
    private EnemyAI _enemyAI;
    private EnemyData1 _enemyData;


    public EnemyData1 EnemyData => _enemyData;
    public bool IsLive => _enemyData.HPBar.CurrentValue <= 0;
    public int Lavel => _lavel;

    public void Awake()
    {
        _enemyData = new EnemyData1(_hP, _cardTypeArmorWeaknessList);

        _animation = GetComponent<Animator>();
        _enemyAI = GetComponent<EnemyAI>();
        _enemyAI.SetEnemyData(_enemyData);
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

        return _enemyData.TakeAttack(damage);
    }

    public void Attack(PlayerBattle player)
    {
        _enemyAI.Attack(player);
    }

    public void StartTurn()
    {
        if (_enemyAI.IsRemoveArmorOfTurn && _enemyData.ArmorBar != null)
        {
            _enemyData.RemoveArmor();
        }
    }
}
