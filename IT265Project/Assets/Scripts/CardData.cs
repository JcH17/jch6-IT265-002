using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardEffect{
    public int crownChange;
    public int wisdomChange;
    public int goldChange;
    public int bonusTaxAmount;
}
[CreateAssetMenu(fileName = "NewCard", menuName = "CardDeck")]
public class CardData : ScriptableObject
{
    public string cardTitle;

    [TextArea]
    public string description;

    public string choice1Text;
    public CardEffect choice1Effect;
    public string choice2Text;
    public CardEffect choice2Effect;
    public Color cardColor = Color.white;
    public bool isWealthCard = false;
    //public bool isPolicyCard = false;

}
