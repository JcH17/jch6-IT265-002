using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{

    public GameObject cardPanel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Button option1Button;
    public Button option2Button;

    public Image cardBackgroundColor;

    private CardData currentCard;

    public void ShowCard(CardData card){
        currentCard = card;

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
            CloseCard();
        });

        option2Button.onClick.AddListener(() => {
            Debug.Log("Option 2 selected");
            CloseCard();
        });
    }

    public void CloseCard(){
        cardPanel.SetActive(false);
        currentCard = null;
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
