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
    public bool isMyTurn = false;
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

        if(!isMyTurn){
            return;
        }
    }
    
    public bool IsMyTurn(){
        return isMyTurn;
    }

    public void EnableTurn(bool value){
        isMyTurn = value;
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
        currentTile = next;
        
        if(next.tileType == TileType.Tax){
            TileInteractionManager tileInteraction = GetComponent<TileInteractionManager>();
            if(tileInteraction != null){
                tileInteraction.EarnTaxGold();
            }
        }

        targetPosition = next.transform.position;
        //currentTile = next;
        isMoving = true;
    }

    void MoveToTarget(){
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPosition) < 0.01f){
            transform.position = targetPosition;
            isMoving = false;

            if(currentTile.tileType == TileType.Finish){
                Debug.Log("A player has finished the game");
                isMyTurn = false;

                FindObjectOfType<PlayerManager>().MarkPlayerAsFinished(this);
                return;
            }

            /*TileInteractionManager tileInteractionHandler = GetComponent<TileInteractionManager>();
            if(tileInteractionHandler != null && currentTile != null){
                tileInteractionHandler.TileInteraction(currentTile);
            }*/

            if(remainingMoves > 0 || tileQueue.Count > 0){
                MoveForward();
            } else {
                TileInteractionManager tileInteractionHandler = GetComponent<TileInteractionManager>();
                if(tileInteractionHandler != null && currentTile != null){
                    tileInteractionHandler.TileInteraction(currentTile);
                }

                if(currentTile.tileType == TileType.Tax){
                    FindObjectOfType<PlayerManager>().EndTurn();
                }
            }

            //MoveForward();
        }
    }
}
