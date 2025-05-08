using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteractionManager : MonoBehaviour
{
    public Tiles tileType;



    void DrawCrownCard(){
        Debug.Log("Drawing crown card..");
        //game logic here
    }

    void DrawWisdomCard(){
        Debug.Log("Drawing wisdom card..");
        //game logic here
    }

    void DrawCrisisCard(){
        Debug.Log("Drawing crisis card..");
        //game logic here
    }

    void DrawRegularCard(){
        Debug.Log("Drawing regular card..");
        //game logic here
    }

    void DrawWealthCard(){
        Debug.Log("Drawing wealth card..");
        //game logic here
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
                DrawCrownCard();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
