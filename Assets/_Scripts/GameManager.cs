using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public enum GameState{MENU, GAME, PAUSE, END};
    public GameState gameState{get;private set;}

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    private static GameManager _instance;

    private GameManager(){
        gameState = GameState.GAME;
    }

    public static GameManager GetInstance(){
        if(_instance==null){
            _instance = new GameManager();
        }
        return _instance;
    }

    public void changeState(GameState nextState){
        gameState = nextState;
        changeStateDelegate();
    }
}
