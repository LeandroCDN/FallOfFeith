using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    winGame,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager sharedIntance;
    
    public GameState currentGameState = GameState.menu;

    public int collectableChocolats = 0;

    private void Awake()
    {
        if(sharedIntance == null)
        {
            sharedIntance = this;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        SetGameState(GameState.menu);
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && currentGameState != GameState.inGame)
        {
            StartGame();
        }

    }


    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }



    private void SetGameState(GameState newGameState)
    {
        if(newGameState == GameState.menu)
        {

            MenuManager.sharedInstance.ShowMainMenu();
            //Todo hacer menus
        }else if(newGameState == GameState.inGame)
        {
            LevelManager.sharedInstance.RemoveAllLevelBlocks();
            LevelManager.sharedInstance.GenerateInitialBlocks();
            MenuManager.sharedInstance.HideMainMenu();
            PlayerMovements.sharedInstance.startGame();
            //Todo, scene for the play  game
        }else if(newGameState == GameState.gameOver)
        {
            MenuManager.sharedInstance.ShowGameOverMenu();

            //Todo menu de game over
        }else if(newGameState == GameState.winGame)
        {
            //todo Win game scene

        }
        this.currentGameState = newGameState;
    }
}
