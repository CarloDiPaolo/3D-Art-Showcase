using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : Singleton<CameraBehaviour>
{
    private Camera cam = null;
    private Animator anim = null;

    public Animator Anim { get => anim; private set => anim = value; }

    private void Start()
    {
        cam = this.GetComponent<Camera>();
        anim = this.GetComponent<Animator>();
    }

    public bool TryChangeCameraPosition()
    {
        Debug.Log("Trying to change Camera Position");

        if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "PositionA")
        {
            Debug.Log("a to b");
            anim.SetTrigger("ChangePos");
            return true;
        }
        else if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "PositionB")
        {
            Debug.Log("b to a");
            anim.SetTrigger("ChangePos");
            return true;
        }
        else
        {
            Debug.Log("In Transition");
            return false;
        }
    }
}
