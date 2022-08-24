using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card Data", order = 1)]
public class CardData : ScriptableObject
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _description;
    [SerializeField]
    private CardType.TypeList _type;
    [SerializeField]
    private Sprite _image;
    [SerializeField]
    private Sprite _border;
    [SerializeField]
    private bool _isElite;
    [SerializeField]
    private Sprite _frame;
    [SerializeField]
    private StartingValue[] _values;

    public CardType.TypeList GetCardType()
    {
        return _type;
    }

    public GameObject CreateCardInstance(Card card, GameObject canvas)
    {
        //Это всё гавно потом уберется отсюдова
        GameObject newCardGO = Instantiate(card.gameObject);
        newCardGO.transform.SetParent(canvas.transform);
        Card newCard = newCardGO.GetComponent<Card>();

        ResourceContainer container = newCardGO.AddComponent<ResourceContainer>();
        container.SetValues(_values);
        newCard.SetName(_name);
        newCard.SetDescription(_description);
        newCard.SetType(_type);
        newCard.SetImage(_image);
        newCard.SetBorder(_border);
        newCard.SetFrame(_isElite, _frame);
        return newCardGO;
    }
}
