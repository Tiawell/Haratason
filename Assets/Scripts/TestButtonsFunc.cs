using UnityEngine;

public class TestButtonsFunc: MonoBehaviour
{
    public Card _minionCardPrefab;
    public Card _spellCardPrefab;
    public Card _weaponCardPrefab;

    public CardType _minion;
    public CardType _spell;
    public CardType _weapon;

    public CardData[] _cardData;
    public GameObject _canvas;

    private Card _cardPrefab;
    private Vector2 _position;
    private GameObject _card;
    public void CreateCard()
    {
        for(int i = 0; i < _cardData.Length; i++)
        {
            if (_cardData[i]._type == _minion)
            {
                _cardPrefab = _minionCardPrefab;
            }
            else if(_cardData[i]._type == _spell)
            {
                _cardPrefab = _spellCardPrefab;
            }
            else if (_cardData[i]._type == _weapon)
            {
                _cardPrefab = _weaponCardPrefab;
            }

            _card = _cardData[i].CreateCardInstance(_cardPrefab, _canvas);
            RectTransform transform = _card.GetComponent<RectTransform>();
            _position = new Vector2(200, 500);
            _position.x += i * (transform.sizeDelta.x * transform.localScale.x + 100);
            _card.transform.position = _position;
        }
    }
}
