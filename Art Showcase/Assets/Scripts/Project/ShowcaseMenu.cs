using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseMenu : MonoBehaviour
{
    private bool open = true;
    [SerializeField] GameObject menuParent;

    private void Start()
    {
        if(menuParent == null)
        {
            Debug.LogError("MenuParent not set in ShowcaseMenu!");
        }
        else
        {
            menuParent.SetActive(false);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(CameraBehaviour.Instance.TryChangeCameraPosition())
            {
                menuParent.SetActive(true);
            }
        }
    }
}
