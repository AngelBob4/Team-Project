using Events.Cards;
using Events.Main.CharactersBattle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData1
{
    //[SerializeField] private int _hP;
    //private List<CardType> _cardTypeArmorWeaknessList;
    private Bar _hPBar;
    private ColorBar _armorBar;
    private CardType _cardTypeArmorWeakness;
    private bool _isStunned = false;

    public Bar HPBar => _hPBar;
    public ColorBar ArmorBar => _armorBar;
    public bool IsStunned => _isStunned;
    public CardType CardTypeArmorWeakness =>_cardTypeArmorWeakness;

    public EnemyData1(int hP)
    {
        _hPBar = new Bar(hP);
        _isStunned = false;

        _armorBar = new ColorBar();

        _cardTypeArmorWeakness = CardType.Null;
    }

    public int TakeAttack(int damage)
    {
        int _takeDamage = damage;

        if (_armorBar != null && _armorBar.CurrentValue > 0)
        {
            _takeDamage -= _armorBar.CurrentValue;
            _armorBar.ChangeValue(-damage);
        }

        if (_takeDamage > 0)
        {
            _hPBar.ChangeValue(-damage);
            return _takeDamage;
        }
        else
        {
            return 0;
        }
    }

    public void SetArmorValues(int armor, CardType cardTypeArmorWeakness = CardType.Null)
    {
        if (cardTypeArmorWeakness == CardType.Null)
        {
            _armorBar.SetNewValues(armor);
            Debug.Log("   Armor = " + armor);
        }
        else
        {
            _armorBar.SetNewValues(armor, cardTypeArmorWeakness);
            Debug.Log("   Armor " + armor + " Collor " + cardTypeArmorWeakness);
        }
    }

    //public void SetArmorAndWeakness(int armor)
    //{
    //    _cardTypeArmorWeakness = GetRandomCardTypeWeakness();
    //    SetArmorValues(armor, _cardTypeArmorWeakness);
    //
    //    CardType GetRandomCardTypeWeakness()
    //    {
    //        return _cardTypeArmorWeaknessList[UnityEngine.Random.Range(0, _cardTypeArmorWeaknessList.Count)];
    //    }
    //}

    public void RemoveArmor()
    {
        _cardTypeArmorWeakness = CardType.Null;

        _armorBar.ChangeValue(-_armorBar.CurrentValue);
    }
}
