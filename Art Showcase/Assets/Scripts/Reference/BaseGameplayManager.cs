using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameplayManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState.Instance.CurrentState == GameState.GameStates.Ingame)
            {
                Pause();
            }
            else if (GameState.Instance.CurrentState == GameState.GameStates.Pause)
            {
                Unpause();
            }
        }

        if (GameState.Instance.CurrentState == GameState.GameStates.Ingame)
        {
            //Insert Gameplay here
        }
    }

    private void Pause()
    {
        GameState.Instance.TryChangeState(GameState.GameStates.Pause);
        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        GameState.Instance.TryChangeState(GameState.GameStates.Ingame);
        pauseMenu.SetActive(false);
    }
}
