using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeButtonColor : MonoBehaviour
{
    Image buttonImage;

    private float lastTime = 0f;

    [SerializeField] float changeTime = 5f;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.color = Color.HSVToRGB(Random.value,1,1);
    }

    private void Update()
    {
        if(Time.time - lastTime >= changeTime)
        {
            lastTime = Time.time;

            buttonImage.color = Color.HSVToRGB(Random.value,1,1);
        }
    }
}