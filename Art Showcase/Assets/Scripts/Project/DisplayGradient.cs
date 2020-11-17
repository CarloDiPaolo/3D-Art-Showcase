using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayGradient : MonoBehaviour
{
    public void ShowGradient(Gradient gradient)
    {
        transform.GetChild(0).gameObject.SetActive(true);

        Texture2D texture = new Texture2D(100, 100);
        transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color color = gradient.Evaluate(x/100f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }

    //For testing
    private void Awake()
    {
        Texture2D texture = new Texture2D(100, 100);
        transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Gradient gradient = new Gradient();
                gradient.SetKeys(new GradientColorKey[]{new GradientColorKey(Color.red, 0f), new GradientColorKey(Color.green, 1f)}, new GradientAlphaKey[] {new GradientAlphaKey(1f, 0f), new GradientAlphaKey(1f, 1f)});
                Color color = gradient.Evaluate(x/100f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
}
