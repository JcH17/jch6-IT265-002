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

    public PlayerStats playerStats;



    void DrawCrownCard(){
        Debug.Log("Drawing crown card..");
        DrawCardFromDeck(crownCards, GetComponent<PlayerStats>());
    }

    void DrawWisdomCard(){
        Debug.Log("Drawing wisdom card..");
        DrawCardFromDeck(wisdomCards, GetComponent<PlayerStats>());
    }

    void DrawCrisisCard(){
        Debug.Log("Drawing crisis card..");
        DrawCardFromDeck(crisisCards, GetComponent<PlayerStats>());
    }

    void DrawRegularCard(){
        Debug.Log("Drawing regular card..");
        DrawCardFromDeck(regularCards, GetComponent<PlayerStats>());
    }

    void DrawWealthCard(){
        Debug.Log("Drawing wealth card..");
        //DrawCardFromDeck(wealthCards, GetComponent<PlayerStats>());
        CardData newWealthCard = wealthCards[Random.Range(0, wealthCards.Count)];
        PlayerStats player = GetComponent<PlayerStats>();
        cardManager.ShowCard(newWealthCard, player);
    }

    void DrawCardFromDeck(List<CardData> deck, PlayerStats player){
        if(deck.Count > 0 && cardManager != null){
            CardData card = deck[Random.Range(0, deck.Count)];
            cardManager.ShowCard(card, player);
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

    public void EarnTaxGold(){
        if(playerStats != null){
            //playerStats.AddGold(100);
            Debug.Log("Collecting gold from your peasants. +100 gold");
            int bonus = playerStats.GetTaxBonus();
            playerStats.AddGold(100 + bonus);
        }
    }
    


    // Start is called before the first frame update
    void Start()
    {
        if(cardManager == null){
            cardManager = FindObjectOfType<CardManager>();
        }
        if(playerStats == null){
            playerStats = GetComponent<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
