using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] Camera sceneCamera;
    [SerializeField] GameObject brushContainer;
    [SerializeField] Material baseMaterial;
    [SerializeField] GameObject brushPrefab;
    public RenderTexture canvasTexture;
    int brushCounter=0; //Increases every brush instantiated
    Vector3 uvWorldPosition;

    bool flag = true;

    private void Start()
    {
        MergeTexture();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.LogWarning("Fire");

            if(HitTestUVPosition(ref uvWorldPosition))
            {
                Debug.LogWarning("Hit, " + uvWorldPosition);
            }
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            MergeTexture();
        }
    }

    bool HitTestUVPosition(ref Vector3 uvWorldPosition)
    {
    Debug.LogWarning("Going into test");
    RaycastHit hit;
    Vector3 mousePos= Input.mousePosition;
    Vector3 cursorPos = new Vector3 (mousePos.x, mousePos.y, 0.0f);
    Debug.LogWarning(cursorPos);
    Ray cursorRay = sceneCamera.ScreenPointToRay (cursorPos);
    if (Physics.Raycast(cursorRay,out hit,2000))
    {
        MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
            {
                Debug.LogWarning("no mesh collider hit");
            return false; 
            }

        Debug.LogWarning("Ray " + cursorRay);
        Vector2 pixelUV = new Vector2(hit.textureCoord.x,hit.textureCoord.y);
        uvWorldPosition.x=pixelUV.x;
        uvWorldPosition.y=pixelUV.y;
        uvWorldPosition.z=0.0f;

        GameObject brush = Instantiate(brushPrefab);
        
        brush.transform.position = uvWorldPosition;
        brush.transform.parent = brushContainer.transform;
        brushCounter++;
    
        return true;
    }
    else
    { 
        Debug.LogWarning("Hit nothing");
        return false;
    }
 }

void MergeTexture()
{ 
  RenderTexture.active = canvasTexture;
  int width=canvasTexture.width;
  int height=canvasTexture.height;
  Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
  tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);
  tex.Apply ();
  RenderTexture.active = null;
  baseMaterial.mainTexture =tex; //Put the painted texture as the base
  
  foreach(Transform child in brushContainer.transform) 
  {//Clear brushes
    Debug.LogWarning("Cleaning");
    Destroy(child.gameObject);
  }
  brushCounter=0; //Reset how many brushes in the scene
}
}
