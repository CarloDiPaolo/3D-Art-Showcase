using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameMenus : MonoBehaviour
{
    [SerializeField] GameObject showButton;
    [SerializeField] GameObject inputWindow;

    private void Start()
    {
        if(showButton != null && inputWindow != null)
        {
            Show();   
        }       
    }

    public void Hide()
    {
        inputWindow.SetActive(false);
        showButton.SetActive(true);
    }

    public void Show()
    {
        inputWindow.SetActive(true);
        showButton.SetActive(false);
    }

    public void LoadMainMenu()
    {
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
    }

    public void Quit()
    {
        GameState.Instance.TryChangeState(GameState.GameStates.Quit);
    }

    public void NextLevel()
    {
        SceneHandler.LoadNextScene();
    }
}
