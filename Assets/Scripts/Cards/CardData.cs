using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CardData : ScriptableObject
{
    public string _name;
    public CardImage _image;
    public CardType _type;
    public CardRarity _rarity;
    public ImageLink _legendaryFrame;
    public HeroClass _heroClass;
    public MinionType _minionType;
    public string _description;
    public StartingValue[] _values;

    public GameObject CreateCardInstance(Card card, GameObject canvas)
    {
        //Это гавно потом уберется отсюдова
        GameObject newCardGO = Instantiate(card.gameObject);
        newCardGO.transform.SetParent(canvas.transform);
        Card newCard = newCardGO.GetComponent<Card>();

        ResourceContainer container = newCardGO.AddComponent<ResourceContainer>();
        container.SetValues(_values);
        newCard.SetImage(_image._image);
        newCard.SetBorder(_heroClass.GetBorder(_type));
        newCard.SetRarity(_rarity._gemImage);
        newCard.SetLegendaryFrame(_legendaryFrame._image);
        newCard.SetName(_name);
        newCard.SetDescription(_description);
        newCard.SetTypeFrame(_minionType._typeFrame._image);
        newCard.SetType(_minionType._name);
        return newCardGO;
    }
}
