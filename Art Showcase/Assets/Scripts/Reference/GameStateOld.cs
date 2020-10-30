using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateOld : MonoBehaviour
{
    public delegate void OnPlayEnter();
    public static event OnPlayEnter onPlayEnter;

    public enum GameStates
    {
        //Essential
        Init,
        Play,   //or Ingame
        Failure,
        Quit,

        //Optional
        Menu,
        Intro,
        Warmup,
        Pause,
        Credits,
        Developer,
        ScoreScreen
    }

    //using Unity Singleton Pattern
    public static GameStateOld Instance = null;

    private GameStates currentState = GameStates.Init;
    public GameStates CurrentState
    {
        get
        {
            return currentState;
        }
    }

    private void Awake()
    {
        //using Unity Singleton Pattern
        if (Instance == null)
        {
            Debug.Log("Instance is still null - using this object: " + gameObject.name);
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Debug.Log("GameState Initialised. Current State: " + currentState);
        }
        else
        {
            Debug.LogWarning("Instance is already filled - destroying this object: " + gameObject.name);
            Destroy(gameObject);
        }        
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
            case GameStates.Menu:
                if (SceneManager.GetActiveScene().buildIndex != 0 && (currentState == GameStateOld.GameStates.Init || currentState == GameStateOld.GameStates.Pause || currentState == GameStateOld.GameStates.Play))
                {
                    permissionGranted = true;
                    SceneHandler.LoadMainMenu();
                }
                Debug.Log("State changed to Menu");
                break;

            case GameStates.Credits:
                if(currentState == GameStateOld.GameStates.Menu)
                {
                    permissionGranted = true;
                    Debug.Log("State changed to Credits");
                    SceneHandler.LoadCredits();
                }               
                break;

            case GameStates.Intro:
                if (SceneManager.GetActiveScene().buildIndex != 2)
                {
                    permissionGranted = true;
                    SceneHandler.LoadIntro();
                    Debug.Log("State changed to Intro");
                }
                break;

            case GameStates.Play:
                if(currentState == GameStateOld.GameStates.Menu || currentState == GameStateOld.GameStates.Pause)
                {
                    permissionGranted = true;
                    //Time.timeScale = 1f;
                    onPlayEnter?.Invoke();
                    Debug.Log("State changed to Play");
                }
                break;

            case GameStates.Quit:
                if(currentState == GameStateOld.GameStates.Menu || currentState == GameStateOld.GameStates.Pause)
                {
                    permissionGranted = true;
                    Debug.LogError("Quitting the Game");
                    Application.Quit();
                } 
                break;

            case GameStates.Pause:
                if(currentState == GameStateOld.GameStates.Play)
                {
                    permissionGranted = true;
                    //Time.timeScale = 0f;
                    Debug.Log("State changed to Pause");
                }
                break;

            case GameStates.Developer:
                Debug.LogWarning("You are a Developer, Harry!");
                break;

            case GameStates.ScoreScreen:
                Debug.Log("State changed to Score Screen");
                break;
             case GameStates.Failure:
                permissionGranted = true;
                Debug.Log("FAILURE FAILURE FAILURE!!!");
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
            Debug.LogError("Transition not granted");
        }
    }
}
