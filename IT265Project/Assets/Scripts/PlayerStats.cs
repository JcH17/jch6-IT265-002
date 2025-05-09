using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public TMP_Text goldText;
    public int gold = 0;
    public TMP_Text crownText;
    public int crown = 0;
    public TMP_Text wisdomText;
    public int wisdom = 0;
    public CardData activeWealthCard;
    //public CardData activePolicyCard;
    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerStats();
        
    }
    private void UpdatePlayerStats(){
        if(crownText != null){
            crownText.text = "Crown: " + crown;
        }
        if(wisdomText != null){
            wisdomText.text = "Wisdom: " + wisdom;
        }
        if(goldText != null){
            goldText.text = "Gold: " + gold;
        }
    }

    public void AddCrown(int amount){
        crown += amount;
        UpdatePlayerStats();
    }
    public void AddWisdom(int amount){
        wisdom += amount;
        UpdatePlayerStats();
    }

    public void AddGold(int amount){
        gold += amount;
        UpdatePlayerStats();
    }
    public bool SpendCrown(int amount){
        if(crown >= amount){
            crown -= amount;
            UpdatePlayerStats();
            //should add ui to show they have insuffcient gold
            return true;
        }
        return false;
    }
    public bool SpendWisdom(int amount){
        if(wisdom >= amount){
            wisdom -= amount;
            UpdatePlayerStats();
            //should add ui to show they have insuffcient gold
            return true;
        }
        return false;
    }
    public bool SpendGold(int amount){
        if(gold >= amount){
            gold -= amount;
            UpdatePlayerStats();
            //should add ui to show they have insuffcient gold
            return true;
        }
        return false;
    }

    public int GetTaxBonus(){
        return activeWealthCard != null ? activeWealthCard.choice1Effect.bonusTaxAmount : 0;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
