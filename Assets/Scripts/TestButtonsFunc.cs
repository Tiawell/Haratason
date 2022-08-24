using UnityEngine;

public class TestButtonsFunc: MonoBehaviour
{
    public Card _creatureCardPrefab;
    public Card _spellCardPrefab;
    public Card _weaponCardPrefab;
    public CardData[] _cardData;
    public GameObject _canvas;

    private Card _cardPrefab;
    private Vector2 _position;
    private GameObject _card;
    public void CreateCard()
    {
        for(int i = 0; i < _cardData.Length; i++)
        {
            if(_cardData[i].GetCardType() == CardType.TypeList.Spell)
            {
                _cardPrefab = _spellCardPrefab;
            }
            else if (_cardData[i].GetCardType() == CardType.TypeList.Weapon)
            {
                //_cardPrefab = _weaponCardPrefab;
            }
            else
            {
                _cardPrefab = _creatureCardPrefab;
            }
            _card = _cardData[i].CreateCardInstance(_cardPrefab, _canvas);
            _position = _card.transform.position;
            _position.x += i * (_card.GetComponent<RectTransform>().sizeDelta.x + 100);
            _card.transform.position = _position;
        }

    }
}
