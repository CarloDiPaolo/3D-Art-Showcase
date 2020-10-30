using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehaviour : MonoBehaviour
{
    private float startY;
    bool goingUp = false;

    [SerializeField] float floatingDistance = 0.2f;
    [SerializeField] float floatingSpeed = 1f;

    private void Start()
    {
        startY = gameObject.transform.position.y;
    }

    private void Update()
    {
        if (goingUp)
        {
            if (gameObject.transform.position.y < startY + floatingDistance)
            {
                gameObject.transform.position += Vector3.up * Time.deltaTime * floatingSpeed;
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if (gameObject.transform.position.y > startY - floatingDistance)
            {
                gameObject.transform.position -= Vector3.up * Time.deltaTime * floatingSpeed;
            }
            else
            {
                goingUp = true;
            }
        }
    }
}