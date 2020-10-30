using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveSeconds : MonoBehaviour
{
    private float lastTime = 0f;
    int cubeIndex = 0;

    private void Update()
    {
        if(Time.time - lastTime >= 5f)
        {
            Debug.Log("Five Seconds have passed, spawning Cube");
            lastTime = Time.time;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position += new Vector3(cubeIndex,0,0);
            cubeIndex++;
        }
    }
}