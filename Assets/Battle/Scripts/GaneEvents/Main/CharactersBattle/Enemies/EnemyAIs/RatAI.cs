using System;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : EnemyAI
{
    private readonly int _attackClawDamage = 1;
    private readonly int _armor = 3;

    private void Awake()
    {
        _attackList = new List<Action>() { Evade, AttackClaw };
    }

    //protected override void CastAttack()
    //{
    //    //_player.TakeAttack(_damage);
    //    _attackList[UnityEngine.Random.Range(0, _attackList.Count)]();
    //}

    private void Evade()
    {
        Debug.Log("Evade");

        _enemyData.SetArmorAndWeakness(_armor);
    }

    private void AttackClaw()
    {
        Debug.Log("AttackClaw");

        AttackDamagCards(3, 1);

        if (AttackDamag(_attackClawDamage) > 0)
        {
            PlayerToPoison();
        }
    }
}
