using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : EnemyAI
{
    [SerializeField] private List<CardType> _scurryTypeArmorCards;
    [SerializeField] private int _attackBiteDamage = 3;
    [SerializeField] private int _attackClawDamage = 2;
    [SerializeField] private int _attackClawIgnorArmor = 2;
    [SerializeField] private int _scurryArmor = 3;

    private void Awake()
    {
        _attackList = new List<Action>() { Scurry, AttackBite, AttackClaw };
    }

    //protected override void CastAttack()
    //{
    //    //_player.TakeAttack(_damage);
    //    _attackList[UnityEngine.Random.Range(0, _attackList.Count)]();
    //}

    private void Scurry()
    {
        Debug.Log("Scurry");

        _enemyData.SetArmorValues(_scurryArmor, _scurryTypeArmorCards[UnityEngine.Random.Range(0, _scurryTypeArmorCards.Count)]);
    }

    private void AttackBite()
    {
        Debug.Log("Bite");

        if (AttackDamag(_attackBiteDamage) > 0)
        {
            PlayerToPoison();
        }
    }

    private void AttackClaw()
    {
        Debug.Log("AttackClaw");

        AttackDamag(_attackClawDamage, _attackClawIgnorArmor);
    }
}
