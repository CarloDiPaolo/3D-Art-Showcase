using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] float scrollingSpeed = -0.07f; // Speed of the movement

    Vector3 lastMousePos;
    bool lastMidPressed;


    private void LateUpdate ()
    {

        var midPressed = Input.GetMouseButton(2);

        if (midPressed && lastMidPressed)
        {
            transform.position += (Input.mousePosition - lastMousePos) * scrollingSpeed;
        }

        lastMidPressed = midPressed;
        lastMousePos = Input.mousePosition;
    }
}
