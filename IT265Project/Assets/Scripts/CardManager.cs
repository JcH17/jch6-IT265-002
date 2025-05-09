using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{

    public GameObject cardPanel;
    public GameObject noResourcePanel;
    public TMP_Text noResourceText;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Button option1Button;
    public Button option2Button;

    public Image cardBackgroundColor;

    private CardData currentCard;
    private PlayerStats currentPlayer;

    public void ShowCard(CardData card, PlayerStats player){
        currentCard = card;
        currentPlayer = player;

        titleText.text = card.cardTitle;
        descriptionText.text = card.description;
        option1Button.GetComponentInChildren<TMP_Text>().text = card.choice1Text;
        option2Button.GetComponentInChildren<TMP_Text>().text = card.choice2Text;
        if(cardBackgroundColor != null){
            cardBackgroundColor.color = card.cardColor;
        }

        cardPanel.SetActive(true);

        option1Button.onClick.RemoveAllListeners();
        option2Button.onClick.RemoveAllListeners();

        option1Button.onClick.AddListener(() => {
            Debug.Log("Option 1 selected");
            /*if(currentPlayer != null){
                currentPlayer.AddCrown(currentCard.choice1Effect.crownChange);
                currentPlayer.AddWisdom(currentCard.choice1Effect.wisdomChange);
                currentPlayer.AddGold(currentCard.choice1Effect.goldChange);
            }*/
            if(!CanAfforCardEffect(card.choice1Effect)){
                ShowInsufficientResourcesMessage();
                return;
            }

            ApplyCardEffect(card.choice1Effect);

            /*currentPlayer.SpendGold(card.choice1Effect.goldChange);
            currentPlayer.SpendCrown(card.choice1Effect.crownChange);
            currentPlayer.SpendWisdom(card.choice1Effect.wisdomChange);
            */

            //bool canAfford = player.SpendGold(-card.choice1Effect.goldChange) && player.SpendCrown(-card.choice1Effect.crownChange) && player.SpendWisdom(-card.choice1Effect.wisdomChange);
           /* if(!canAfford){
                Debug.Log("Not enough resources to purchase wealth card");
                return;
            }*/
            if(card.isWealthCard){
                if(player.activeWealthCard != null){
                    Debug.Log("Replacing {player.activeWealthCard.cardTitle} with + {card.cardTitle}");
                } else{
                    Debug.Log("Obtain {card.cardTitle}");
                }
                currentPlayer.activeWealthCard = card;
            }
            CloseCard();
        });

        option2Button.onClick.AddListener(() => {
            Debug.Log("Option 2 selected");
            if(!CanAfforCardEffect(card.choice2Effect)){
                ShowInsufficientResourcesMessage();
                return;
            }
            /*if(currentPlayer != null){
                currentPlayer.AddCrown(currentCard.choice2Effect.crownChange);
                currentPlayer.AddWisdom(currentCard.choice2Effect.wisdomChange);
                currentPlayer.AddGold(currentCard.choice2Effect.goldChange);
            }*/
            ApplyCardEffect(card.choice2Effect);
            CloseCard();
        });
    }

    private void ApplyCardEffect(CardEffect effect){
        if(effect.goldChange > 0){
            currentPlayer.AddGold(effect.goldChange);
        } else if(effect.goldChange < 0){
            currentPlayer.SpendGold(-effect.goldChange);
        }

        if(effect.crownChange > 0){
            currentPlayer.AddCrown(effect.crownChange);
        } else if(effect.crownChange < 0){
            currentPlayer.SpendCrown(-effect.crownChange);
        }

        if(effect.wisdomChange > 0){
            currentPlayer.AddWisdom(effect.wisdomChange);
        } else if(effect.wisdomChange < 0){
            currentPlayer.SpendWisdom(-effect.wisdomChange);
        }
    }

    private bool CanAfforCardEffect(CardEffect effect){
        if(effect.goldChange < 0 && currentPlayer.gold < -effect.goldChange){
            return false;
        }
        if(effect.crownChange < 0 && currentPlayer.crown < -effect.crownChange){
            return false;
        }
        if(effect.wisdomChange < 0 && currentPlayer.wisdom < -effect.wisdomChange){
            return false;
        }
        return true;
    }

    public void ShowInsufficientResourcesMessage(){
        if(noResourcePanel != null){
            noResourcePanel.SetActive(true);
            Invoke(nameof(HideInsufficientResourcesMessage), 2f);
        }
    }

    private void HideInsufficientResourcesMessage(){
        noResourcePanel.SetActive(false);
    }

    public void CloseCard(){
        cardPanel.SetActive(false);
        currentCard = null;
        currentPlayer = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
