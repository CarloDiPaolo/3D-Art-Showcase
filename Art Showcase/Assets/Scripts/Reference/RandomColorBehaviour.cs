using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorBehaviour : MonoBehaviour
{
    SpriteRenderer[] spritesToChange;

    void Start()
    {
        spritesToChange = GetComponentsInChildren<SpriteRenderer>();

        Color randomColor = Color.HSVToRGB(Random.value,1,1);

        for (int i = 0; i < spritesToChange.Length; i++)
        {
            spritesToChange[i].color = randomColor;
        }
    }
}