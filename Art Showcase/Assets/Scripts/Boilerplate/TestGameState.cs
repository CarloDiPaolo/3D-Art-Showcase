using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameState : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //Try to change to the state we are already in.
        //This should show a warning in the console.
        GameState.Instance.TryChangeState(GameState.GameStates.Init);

        //Testing all Valid Transitions (of diagramm in class)
        //1. Init to Menu
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
        //2. menu to Credits
        GameState.Instance.TryChangeState(GameState.GameStates.Credits);
        //3. Credits to Menu
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
        //4. Menu to Play
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        //5. Play to Pause
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);
        //6. Pause to Menu
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);


        //impossible Transitions
        //A. Pause to Credits
        GameState.Instance.TryChangeState(GameState.GameStates.Credits);
        //B.Credits to Init
        GameState.Instance.TryChangeState(GameState.GameStates.Init);
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
        //C. Menu to Pause
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);
        //D. Pause to Init
        GameState.Instance.TryChangeState(GameState.GameStates.Init);
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        //C. Play to Credits
        GameState.Instance.TryChangeState(GameState.GameStates.Credits);

        //one more possible (cannot test Main Menu to Quit cause Quit is a dead end)
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);
        //7. Pause to Play
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);
        //8. Pause to Quit
        GameState.Instance.TryChangeState(GameState.GameStates.Quit);

    }
}
