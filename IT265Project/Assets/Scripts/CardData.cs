using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "CardDeck")]
public class CardData : ScriptableObject
{
    public string cardTitle;

    [TextArea]
    public string description;

    public string choice1Text;
    public string choice2Text;
    public Color cardColor = Color.white;

}
