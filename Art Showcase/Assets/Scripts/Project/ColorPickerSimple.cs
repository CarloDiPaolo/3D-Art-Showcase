using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerSimple : MonoBehaviour
{
    [SerializeField] Image colorDisplay;
    [SerializeField] Renderer targetObject;

    private float r = 1f;
    private float g = 1f;
    private float b = 1f;
    private float a = 1f;

    private Color currentColor;

    private void Start()
    {
        SetColor();
    }

    public void Init(float windowPosition, Renderer target)
    {
        targetObject = target;
    }

    public void SetR(float r)
    {
        this.r = r;
        SetColor();
    }

    public void SetG(float g)
    {
        this.g = g;
        SetColor();
    }

    public void SetB(float b)
    {
        this.b = b;
        SetColor();
    }

    public void SetA(float a)
    {
        this.a = a;
        SetColor();
    }

    private void SetColor()
    {
        currentColor = new Color(r,g,b,a);
        colorDisplay.color = currentColor;

        //for Testing
        SetColorToObject();
    }

    public Color GetPickedColor()
    {
        return currentColor;
    }

    //FOR TESTING
    private void SetColorToObject()
    {
        targetObject.material.color = currentColor;
    }
}
