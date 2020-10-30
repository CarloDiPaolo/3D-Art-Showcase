using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseMenu : MonoBehaviour
{
    [SerializeField] GameObject menuParent;
    [SerializeField] GameObject characterObject;
    [SerializeField] ColorPickerSimple colorPicker;

    private bool open = true;
    private float delay = 0f;


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
            if(delay == 0f)
            {
                AnimationClip[] clips = CameraBehaviour.Instance.Anim.runtimeAnimatorController.animationClips;
                foreach(AnimationClip clip in clips)
                {
                    if(clip.name == "Transition")
                    {
                        delay = clip.length;
                    }
                }
            }

            if(CameraBehaviour.Instance.TryChangeCameraPosition())
            {
                if(menuParent.activeSelf)
                {
                    ToggleMenuVisibility();
                }
                else
                {
                    Invoke("ToggleMenuVisibility", delay - 0.01f);
                }
            }
        }
    }

    private void ToggleMenuVisibility()
    {
        menuParent.SetActive(!menuParent.activeInHierarchy);
        colorPicker.gameObject.SetActive(false);
    }

    public void RandomizeColor()
    {
        Renderer rend = characterObject.GetComponent<Renderer>();
        Material mat = rend.material;
        mat.color = Color.HSVToRGB(Random.value,1,1);
        rend.material = mat;
    }

    public void RandomizeRotation()
    {
        characterObject.transform.rotation = Quaternion.Euler(new Vector3(characterObject.transform.rotation.eulerAngles.x, Random.Range(0, 360), characterObject.transform.rotation.eulerAngles.z));
    }

    public void OpenColorPicker()
    {
        colorPicker.gameObject.SetActive(true);
        colorPicker.Init(Vector2.zero, characterObject.GetComponent<Renderer>());
    }
}
