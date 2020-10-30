using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehaviour : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] bool rotateLeft = true;

    private void Update()
    {
        Vector3 direction;

        if(rotateLeft)
        {
            direction = Vector3.forward;
        }
        else
        {
            direction = -Vector3.forward;
        }
        transform.Rotate(direction, rotationSpeed);
    }
}
