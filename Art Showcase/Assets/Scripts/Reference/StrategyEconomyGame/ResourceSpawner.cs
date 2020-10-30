using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] float spawnInterval = 1f;

    private float lastTime = 0f;

    private void Update()
    {
        if(Time.time - lastTime >= spawnInterval)
        {
            Debug.Log(spawnInterval + " Seconds have passed, spawning Resource");
            lastTime = Time.time;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(parent.childCount,0,0);
            cube.transform.parent = parent;
        }
    }
}
