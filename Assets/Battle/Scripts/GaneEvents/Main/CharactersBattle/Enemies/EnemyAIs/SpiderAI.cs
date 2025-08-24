using Events.Cards;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAI : EnemyAI
{
    [SerializeField] private List<CardType> _scurryTypeArmorCards;
    [SerializeField] private int _attackDamageDack = 1;
    [SerializeField] private int _attackDamageHand = 2;
    [SerializeField] private int _attackByDrawingOutLivesDamage = 2;
    [SerializeField] private int _attackByDrawingOutLivesIgnorArmor = 2;
    [SerializeField] private int _regenerationByDrawingOutLives = 3;
    [SerializeField] private int _armor = 2;

    private void Awake()
    {
        _attackList = new List<Action>() { AttackScare, AttackScare, AttackDrawingOutLives };
    }

    private void AttackScare()
    {
        Debug.Log("Scare");

        AttackDamagCards(_attackDamageHand, _attackDamageDack);
    }

    private void AttackDrawingOutLives()
    {
        Debug.Log("AttackDrawingOutLives");

        if (AttackDamag(_attackByDrawingOutLivesDamage, _attackByDrawingOutLivesIgnorArmor) > 0)
        {
            AttackDamagCards(_attackDamageHand, _attackDamageDack);
            RegenerationHP(_regenerationByDrawingOutLives);
        }
    }

    protected override void EndOfAttack()
    {
        _enemyData.ArmorBar.SetValues(_armor);
    }
}
