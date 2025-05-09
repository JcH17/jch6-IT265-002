using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteractionManager : MonoBehaviour
{
    public Tiles tileType;

    public CardManager cardManager;

    public List<CardData> crownCards;
    public List<CardData> wisdomCards;
    public List<CardData> crisisCards;
    public List<CardData> regularCards;
    public List<CardData> wealthCards;



    void DrawCrownCard(){
        Debug.Log("Drawing crown card..");
        DrawCardFromDeck(crownCards);
    }

    void DrawWisdomCard(){
        Debug.Log("Drawing wisdom card..");
        DrawCardFromDeck(wisdomCards);
    }

    void DrawCrisisCard(){
        Debug.Log("Drawing crisis card..");
        DrawCardFromDeck(crisisCards);
    }

    void DrawRegularCard(){
        Debug.Log("Drawing regular card..");
        DrawCardFromDeck(regularCards);
    }

    void DrawWealthCard(){
        Debug.Log("Drawing wealth card..");
        DrawCardFromDeck(wealthCards);
    }

    void DrawCardFromDeck(List<CardData> deck){
        if(deck.Count > 0 && cardManager != null){
            CardData card = deck[Random.Range(0, deck.Count)];
            cardManager.ShowCard(card);
        }
    }

    public void TileInteraction(Tiles tile){
        switch(tile.tileType){
            case TileType.Tax:
                Debug.Log("You landed on a tax tile. Gain +X gold");
                break;

            case TileType.Regular:
                Debug.Log("You landed on a tax regular tile.");
                DrawRegularCard();
                break;

            case TileType.Crown:
                Debug.Log("You landed on a crown tile.");
                DrawCrownCard();
                break;

            case TileType.Wisdom:
                Debug.Log("You landed on a wisdom tile.");
                DrawWisdomCard();
                break;

            case TileType.Crisis:
                Debug.Log("You landed on a crisis tile.");
                DrawCrisisCard();
                break;

            case TileType.Wealth:
                Debug.Log("You landed on a wealth tile");
                DrawWealthCard();
                break;
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {
        if(cardManager == null){
            cardManager = FindObjectOfType<CardManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
