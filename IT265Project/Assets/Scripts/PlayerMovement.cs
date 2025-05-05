using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Tiles currentTile;
    public float moveSpeed = 6f;
    private bool isMoving = false;
    private Vector3 targetPosition;

    private Queue<Tiles> tileQueue = new Queue<Tiles>();

    public GameObject decisionPanel;
    public Button leftButton;
    public Button rightButton;
    private Tiles leftPathTile;
    private Tiles rightPathTile;
    private int remainingMoves = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(currentTile != null){
            transform.position = currentTile.transform.position;
        }

        if(decisionPanel != null){
            decisionPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            MoveToTarget();
            //return;
        }

        //jch6 movement test with spacebar
        /*if(Input.GetKeyDown(KeyCode.Space)){
            if(currentTile.nextTiles.Count > 0){
                Tiles nextTile = currentTile.nextTiles[0];//jch6 will go with whatever is the first option
                targetPosition = nextTile.transform.position;
                currentTile = nextTile;
                isMoving = true;
            }
        }*/
    }

    public void MoveSpaces(int spaces){
        /*Tiles tile = currentTile;

        for(int i = 0; i < spaces; i++){
            if(tile.nextTiles.Count > 0){
                tile = tile.nextTiles[0];
                tileQueue.Enqueue(tile);
            }
            else{
                break;
            }
        }
        
        if(tileQueue.Count > 0){
            MoveToNextTile();
        }*/

        remainingMoves = spaces;
        MoveForward();
    }

    void MoveForward(){
        if (remainingMoves <= 0)
            return;

        if (currentTile.nextTiles.Count == 1){
            Tiles nextTile = currentTile.nextTiles[0];
            tileQueue.Enqueue(nextTile);
            currentTile = nextTile;
            remainingMoves--;
            MoveToNextTile();
        }
        else if (currentTile.nextTiles.Count == 2){
            leftPathTile = currentTile.nextTiles[0];
            rightPathTile = currentTile.nextTiles[1];
            ShowDecisionPanel();
        }
        else{
            Debug.Log("No path forward or unsupported path split.");
        }
    }

    void ShowDecisionPanel(){
        decisionPanel.SetActive(true);
        leftButton.onClick.RemoveAllListeners();
        rightButton.onClick.RemoveAllListeners();
        leftButton.onClick.AddListener(() => ChoosePath(leftPathTile));
        rightButton.onClick.AddListener(() => ChoosePath(rightPathTile));
    }

    void ChoosePath(Tiles chosenTile){
        decisionPanel.SetActive(false);
        tileQueue.Enqueue(chosenTile);
        currentTile = chosenTile;
        remainingMoves--;
        MoveToNextTile();
    }

    void MoveToNextTile(){
        if(tileQueue.Count == 0) 
        return;
        Tiles next = tileQueue.Dequeue();
        targetPosition = next.transform.position;
        //currentTile = next;
        isMoving = true;
    }

    void MoveToTarget(){
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.01f){
            transform.position = targetPosition;
            isMoving = false;

            /*if(tileQueue.Count > 0){
                MoveToNextTile();
            }*/

            MoveForward();
        }
    }
}
