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
    private Image _rarity;
    [SerializeField]
    private Image _legendaryFrame;
    [SerializeField]
    private TextMeshProUGUI _name;
    [SerializeField]
    private TextMeshProUGUI _description;
    [SerializeField]
    private Image _typeFrame;
    [SerializeField]
    private TextMeshProUGUI _type;

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    public void SetBorder(Sprite sprite)
    {
        _border.sprite = sprite;
    }
    public void SetRarity(Sprite sprite)
    {
        _rarity.sprite = sprite;
    }
    public void SetLegendaryFrame(Sprite sprite)
    {
        _legendaryFrame.sprite = sprite;
    }
    public void SetName(string text)
    {
        _name.text = text;
    }
    public void SetDescription(string text)
    {
        _description.text = text;
    }
    public void SetTypeFrame(Sprite sprite)
    {
        _typeFrame.sprite = sprite;
    }
    public void SetType(string text)
    {
        _type.text = text;
    }
}
