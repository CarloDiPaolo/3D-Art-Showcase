using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPickerSimple : Singleton<ColorPickerSimple>
{
    [SerializeField] Image colorDisplay;
    [SerializeField] Renderer targetObject;
    [SerializeField] List<Slider> colorSliders;
    [SerializeField] DisplayGradient gradientDisplay;
    
    private RectTransform uiTransform;
    private Renderer target;
    private ParticleSystem particleSystemTarget;

    private float r = 1f;
    private float g = 1f;
    private float b = 1f;
    private float a = 1f;

    private Color currentColor;
    private ParticleSystem.ColorOverLifetimeModule colorModule;


    private void Start()
    {
        uiTransform = transform.GetChild(0).GetComponent<RectTransform>();
        Close();
    }

    public void Open(Vector2 windowPosition, Renderer target)
    {
        this.target = target;

        uiTransform.anchoredPosition = new Vector3(windowPosition.x, windowPosition.y, uiTransform.position.z);
        DisplayTargetsColor();
        uiTransform.gameObject.SetActive(true);
    }

    public void Open(Vector2 windowPosition, ParticleSystem target)
    {
        this.target = null;
        particleSystemTarget = target;

        uiTransform.anchoredPosition = new Vector3(windowPosition.x, windowPosition.y, uiTransform.position.z);
        DisplayTargetsColor();
        uiTransform.gameObject.SetActive(true);
        colorModule = particleSystemTarget.colorOverLifetime;
        Gradient gradient = colorModule.color.gradient;
        gradientDisplay.ShowGradient(gradient);
    }

    public void Close()
    {
        uiTransform.gameObject.SetActive(false);
        gradientDisplay.transform.GetChild(0).gameObject.SetActive(false);
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
        //SetColorToObject();

        SetColorToTarget();
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

    private void SetColorToTarget()
    {
        if(target != null)
        {
            target.material.color = currentColor;
        }
        else
        {
            colorModule = particleSystemTarget.colorOverLifetime;
            Gradient gradient = colorModule.color.gradient;
            gradient.colorKeys[0] = new GradientColorKey(Color.red, 0f);

            gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(currentColor, 0.0f), gradient.colorKeys[1] },
            new GradientAlphaKey[] { gradient.alphaKeys[0], gradient.alphaKeys[1] }
            );

            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);

            gradientDisplay.ShowGradient(gradient);
        }
    }

    private void DisplayTargetsColor()
    {
        Color targetColor = Color.white;

        if(target != null)
        {
            targetColor = target.material.color;
        }
        else
        {
            colorModule = particleSystemTarget.colorOverLifetime;
            Gradient gradient = colorModule.color.gradient;
            targetColor = gradient.colorKeys[0].color;
            Debug.LogError(targetColor);

            gradientDisplay.ShowGradient(gradient);
        }

        colorDisplay.color = targetColor;
        colorSliders[0].value = targetColor.r;
        colorSliders[1].value = targetColor.g;
        colorSliders[2].value = targetColor.b;
        colorSliders[3].value = targetColor.a;
    }
}
