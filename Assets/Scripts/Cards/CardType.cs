using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardType : MonoBehaviour
{
    public enum TypeList
    {
        None, Spell, Weapon, Murloc, Dragon
    }
    public static readonly Dictionary<TypeList, string> TypeTranslate = new()
    {
        [TypeList.Murloc] = "Мурлок",
        [TypeList.Dragon] = "Дракон"
    };
}
