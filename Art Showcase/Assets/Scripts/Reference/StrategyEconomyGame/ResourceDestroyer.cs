using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDestroyer : MonoBehaviour
{
    [SerializeField] Transform parent;
    [SerializeField] float destroyInterval = 6f;
    [SerializeField] int amountOfResourcesToDestroy = 5;

    private float lastTime = 0f;

    private void Update()
    {
        if(Time.time - lastTime >= destroyInterval)
        {
            Debug.Log(destroyInterval + " Seconds have passed, trying to destroy " + amountOfResourcesToDestroy + " Resources!");
            lastTime = Time.time;
          
            if(parent.childCount >= amountOfResourcesToDestroy)
            {
                //Destroy Resources
                for (int i = 0; i < amountOfResourcesToDestroy; i++)
                {
                    Destroy(parent.GetChild(parent.childCount - i - 1).gameObject);
                }

                Debug.Log("Destroyed " + amountOfResourcesToDestroy + " Resources!");
            }
            else
            {
                Debug.Log("Did not find enough Resources!");
            }
        }
    }
}
