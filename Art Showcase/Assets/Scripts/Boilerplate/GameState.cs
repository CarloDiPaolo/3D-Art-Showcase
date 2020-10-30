using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : Singleton<GameState>
{
    public static event System.Action onPlayEnter;

    public enum GameStates
    {
        //Essential
        Init,
        Ingame,
        Failure,
        Quit,
        Pause,
        Menu,
        Intro,              
        Credits,
        Developer,
        Transition
    }

    private GameStates currentState = GameStates.Init;
    public GameStates CurrentState
    {
        get
        {
            return currentState;
        }
    }

    private void Start()
    {
            Debug.Log("GameState Initialised. Current State: " + currentState);
    }

    /// <summary>
    /// Try to change the current GameState to a requested Game State
    /// </summary>
    /// <param name="requestedState"></param>
    public void TryChangeState(GameStates requestedState)
    {
        Debug.Log("Trying to change GameState from " + CurrentState.ToString() + " to " + requestedState.ToString());


        if (requestedState == CurrentState)
        {
            Debug.LogWarning("Already in State " + requestedState.ToString() + ", no action");
            return;
        }
       
       bool permissionGranted = false;


        switch (requestedState)
        {
            case GameStates.Init:
                permissionGranted = true;
                Debug.Log("State now Init");
            break;

            case GameStates.Menu:
                if (currentState == GameStates.Init || currentState == GameStates.Pause || currentState == GameStates.Ingame || currentState == GameStates.Credits)
                {
                    permissionGranted = true;
                    if(SceneManager.GetActiveScene().buildIndex != 1)
                    {
                        SceneHandler.LoadMainMenu();
                        Debug.Log("Loading Main Menu Scene");
                    }
                    
                    Debug.Log("State changed to Menu");
                }              
                break;

            case GameStates.Credits:
                if(currentState == GameStates.Menu)
                {
                    permissionGranted = true;
                    Debug.Log("State changed to Credits");
                    SceneHandler.LoadCredits();
                }
                break;

            case GameStates.Intro:
                if (SceneManager.GetActiveScene().buildIndex != 2 && CurrentState == GameStates.Menu)
                {
                    permissionGranted = true;
                    SceneHandler.LoadIntro();
                    Debug.Log("State changed to Intro");
                }
                break;

            case GameStates.Ingame:
                if(currentState == GameStates.Menu || currentState == GameStates.Transition || currentState == GameStates.Pause || (SceneManager.GetActiveScene().buildIndex != 2 && currentState == GameStates.Init))
                {
                    permissionGranted = true;
                    //Time.timeScale = 1f;
                    onPlayEnter?.Invoke();
                    Debug.Log("State changed to Ingame");
                }
                break;

            case GameStates.Quit:
                if(currentState == GameStates.Menu || currentState == GameStates.Pause)
                {
                    permissionGranted = true;
                    Debug.LogError("Quitting the Game");
                    Application.Quit();
                } 
                break;

            case GameStates.Developer:
                permissionGranted = true;
                Debug.LogWarning("You are a Developer, Harry!");
                break;

            case GameStates.Pause:
                if(currentState == GameStates.Ingame)
                {
                    permissionGranted = true;
                    //Time.timeScale = 0f;
                    Debug.Log("State changed to Pause");
                }
                break;

            case GameStates.Failure:
                permissionGranted = true;
                Debug.Log("FAILURE FAILURE FAILURE!!!");
                break;

            case GameStates.Transition:
                if(currentState == GameStates.Ingame || currentState == GameStates.Init)
                {
                    permissionGranted = true;
                    Debug.Log("Now in Transition");
                }              
                break;

            default:
                Debug.LogError("Requested Game State doesn't exist!");
                break;
        }

        if(permissionGranted)
        {
            currentState = requestedState;
            Debug.Log("Permission was granted.");
        }
        else
        {
            Debug.LogError("Transition Permission not granted");
        }
    }
}
