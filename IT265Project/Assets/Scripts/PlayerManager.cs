using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerTokenPrefab;
    public GameObject playerCountPanel;
    public Transform startTile;
    public GameObject[] resourcePanels;
    public TMP_Text[] playerNumberTexts;
    public DiceManager diceManager;
    public TMP_Text playerTurnText;
    public GameObject decisionPanel;
    public Button leftButton;
    public Button rightButton;

    private List<PlayerMovement> players = new List<PlayerMovement>();
    private int currentPlayerIndex = 0;
    private int totalPlayers;

    public void SelectPlayerCount(int count){
        totalPlayers = Mathf.Clamp(count, 2, 4);
        playerCountPanel.SetActive(false);
        SpawnPlayers();
        StartPlayerTurn(0);
    }

    void SpawnPlayers(){
        Color[] playerColors = new Color[]{
            Color.cyan,
            new Color(1f, 0.5f, 0f),
            Color.gray,
            Color.white
        };

        for(int i = 0; i < totalPlayers; i++){
            GameObject token = Instantiate(playerTokenPrefab, startTile.position, Quaternion.identity);
            PlayerMovement move = token.GetComponent<PlayerMovement>();
            PlayerStats stats = token.GetComponent<PlayerStats>();
            players.Add(move);
            move.decisionPanel = decisionPanel;
            move.leftButton = leftButton;
            move.rightButton = rightButton;
            SpriteRenderer renderer = token.GetComponent<SpriteRenderer>();
            
            if(renderer != null){
                renderer.color = playerColors[i];
            }

            resourcePanels[i].SetActive(true);
            playerNumberTexts[i].text = $"Player {i + 1}";
            stats.AssignPanel(resourcePanels[i]);

            move.currentTile = startTile.GetComponent<Tiles>();
        }
    }
    
    void StartPlayerTurn(int index){
        Debug.Log($"Player {index + 1}'s turn");
        players[index].EnableTurn(true);

        if(playerTurnText != null){
            playerTurnText.text = $"Player {index + 1} Turn";
        }

        DiceManager dice = FindObjectOfType<DiceManager>();
        dice.RollDiceFor(players[index]);
    }
    
    public void EndTurn(){
        currentPlayerIndex = (currentPlayerIndex + 1) % totalPlayers;
        StartPlayerTurn(currentPlayerIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        if(playerTurnText != null){
            playerTurnText.text = "Waiting for players..";
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)){
        PlayerMovement currentPlayer = players[currentPlayerIndex];
        
        if(currentPlayer != null && currentPlayer.isMyTurn){
            diceManager.RollDiceFor(currentPlayer);
        }
       } 
    }
}
