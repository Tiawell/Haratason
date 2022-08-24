using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Image _border;
    [SerializeField]
    private Image _frame;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private TextMeshProUGUI _type;

    private CardType.TypeList _cardType;

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    public void SetBorder(Sprite sprite)
    {
        _border.sprite = sprite;
    }
    public void SetFrame(bool isElite, Sprite sprite)
    {
        if (isElite)
        {
            _frame.sprite = sprite;
        }
        else
        {
            _frame.gameObject.SetActive(false);
        }
    }
    public void SetName(string text)
    {
        _name.text = text;
    }
    public void SetDescription(string text)
    {
        _description.text = text;
    }
    public void SetType(CardType.TypeList type)
    {
        _cardType = type;
        if(CardType.TypeTranslate.TryGetValue(type, out string text))
        {
            _type.text = text;
        }
    }
}
