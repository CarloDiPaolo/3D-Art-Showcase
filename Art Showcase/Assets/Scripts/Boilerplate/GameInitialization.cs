using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialization : MonoBehaviour
{
    void Start()
    {
        GameState.Instance.TryChangeState(GameState.GameStates.Menu);
    }
}
