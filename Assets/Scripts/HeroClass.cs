using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HeroClass : ScriptableObject
{
    [Serializable]
    private class Border
    {
        public CardType _type;
        public Sprite _border;
    }
    private Sprite _border;
    [SerializeField]
    private List<Border> _normalBorders = new();
    [SerializeField]
    private List<Border> _goldenBorders = new();
    public Sprite GetBorder(CardType type)
    {
        foreach (var border in _normalBorders)
            if (border._type == type)
                _border =  border._border;
        return _border;
    }
    public Sprite GetGoldenBorder(CardType type)
    {
        foreach (var border in _goldenBorders)
            if (border._type == type)
                _border = border._border;
        return _border;
    }
}
