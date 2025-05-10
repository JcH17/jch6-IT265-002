using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public GameObject[] diceSides;
    public float rollSpeed = 0.05f;
    public float rollDuration = 5.0f;
    private bool isRolling = false;
    public int rolledValue = 0;
    //public PlayerMovement player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollDiceFor(PlayerMovement player){
        if(!isRolling){
            StartCoroutine(RollDice(player));
        }
    }

    IEnumerator RollDice(PlayerMovement player){
        isRolling = true;

        float elapsedTime = 0f;
        int currentIndex = 0;

        while(elapsedTime < rollDuration){
            ShowSide(currentIndex);
            currentIndex = (currentIndex + 1) % diceSides.Length;
            elapsedTime += rollSpeed;
            yield return new WaitForSeconds(rollSpeed);
        }

        int result = Random.Range(0, diceSides.Length);
        ShowSide(result);

        rolledValue = result + 1;
        Debug.Log("Player rolled a: " + (rolledValue));

        if(player != null){
            player.MoveSpaces(rolledValue);
        }
        isRolling = false;

    }

    void ShowSide(int index){
        for(int i = 0; i < diceSides.Length; i++){
            diceSides[i].SetActive(i == index);
        }
    }
}
