using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

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
    public GameObject endGameStatsPanel;
    public GameObject restartGamePanel;
    public GameObject[] playerFinalStatPanels;

    private List<PlayerMovement> players = new List<PlayerMovement>();
    private List<PlayerMovement> finishedPlayers = new List<PlayerMovement>();
    private int playersFinished = 0;
    private int currentPlayerIndex = 0;
    private int totalPlayers;

    public void MarkPlayerAsFinished(PlayerMovement player){
        finishedPlayers.Add(player);
        playersFinished++;
        if(playersFinished >= totalPlayers){
            ShowEndGameStats();
        } else{
            EndTurn();
        }
    }

    void ShowEndGameStats(){
        endGameStatsPanel.SetActive(true);
        restartGamePanel.SetActive(true);

        List<int> crownScores = new();
        List<int> wisdomScores = new();
        List<int> goldScores = new();
        List<int> wealthScores = new();
        List<int> totalScores = new();

        int highestCrown = 0, highestWisdom = 0, highestGold = 0, highestWealth = 0, highestTotal = 0;
        
        int winnerIndex = -1;
        for(int i = 0; i < players.Count; i++){
            PlayerStats stats = players[i].GetComponent<PlayerStats>();
            GameObject panel = playerFinalStatPanels[i];

            int crown = stats.crown;
            int wisdom = stats.wisdom;
            int gold = stats.gold;
            int wealth = stats.activeWealthCard != null ? 1 : 0;
            int loan = stats.churchLoansTaken;
            
            
            int crownPoints = crown * 50;
            int wisdomPoints = wisdom * 50;
            int goldPoints = gold;
            int wealthPoints = wealth * 100;
            int loanPenalty = loan * 600;

            string title = "";
            int titleBonus = 0;

            crownScores.Add(crownPoints);
            wisdomScores.Add(wisdomPoints);
            goldScores.Add(goldPoints);
            wealthScores.Add(wealthPoints);

            TMP_Text titleText = panel.transform.Find("TitleText").GetComponent<TMP_Text>();
            TMP_Text winnerText = panel.transform.Find("WinnerText").GetComponent<TMP_Text>();
            TMP_Text totalText = panel.transform.Find("TotalPointsScore").GetComponent<TMP_Text>();

            panel.transform.Find("CrownPointsScore").GetComponent<TMP_Text>().text = $"Crown: {crown}";
            panel.transform.Find("WisdomPointsScore").GetComponent<TMP_Text>().text = $"Wisdom: {wisdom}";
            panel.transform.Find("WealthPointsScore").GetComponent<TMP_Text>().text = $"Wealth: {wealth}";
            panel.transform.Find("GoldPointsScore").GetComponent<TMP_Text>().text = $"Gold: {gold}";
            panel.transform.Find("LoanPenaltyScore").GetComponent<TMP_Text>().text = $"Loan: -{loanPenalty}";


            if(crownPoints >= crownScores.Max()){
                title += "Tyrant ";
            }

            if(wisdomPoints >= wisdomScores.Max()){
                title += "Wise ";
            }

            if(goldPoints >= goldScores.Max()){
                title += "Rich ";
            }

            if(!string.IsNullOrEmpty(title)){
                title = title.TrimEnd() + " Ruler";
            }

            int titleCount = title.Split(' ').Length / 2;
            titleBonus = titleCount >= 2 ? 100 : (titleCount == 1 ? 50 : 0);

            

            int total = crownPoints + wisdomPoints + goldPoints + wealthPoints + titleBonus - loanPenalty;
            totalScores.Add(total);
            totalText.text = $"Total: {total}";
            titleText.text = title;
            winnerText.gameObject.SetActive(false);

            if(total > highestTotal){
                highestTotal = total;
                winnerIndex = i;
            }
        }
        if(winnerIndex != -1){
            playerFinalStatPanels[winnerIndex].transform.Find("WinnerText").gameObject.SetActive(true);
        }
    }

    public void RestartGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
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
        if(finishedPlayers.Contains(players[index])){
            EndTurn();
            return;
        }
        
        Debug.Log($"Player {index + 1}'s turn");
        players[index].EnableTurn(true);

        if(playerTurnText != null){
            playerTurnText.text = $"Player {index + 1} Turn";
        }

        DiceManager dice = FindObjectOfType<DiceManager>();
       // dice.RollDiceFor(players[index]);
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
        
        if(currentPlayer != null && currentPlayer.isMyTurn && !diceManager.IsRolling){
            diceManager.RollDiceFor(currentPlayer);
        }
       } 
    }
}
