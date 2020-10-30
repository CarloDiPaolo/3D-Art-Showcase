using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    [SerializeField] int startWood, startSteel, startFood, startStone, startGold;

    private int currentWood, currentSteel, currentFood, currentStone, currentGold;
    private Transform woodParent, steelParent, foodParent, stoneParent, goldParent;

    public enum Resources
    {
        Wood,
        Steel,
        Food,
        Stone,
        Gold
    }

    private void Start()
    {
        SetParents();
        SetStartAmounts();
    }

    public void AddResources(int woodAmount, int steelAmount, int foodAmount, int stoneAmount, int goldAmount)
    {
        AddResource(Resources.Wood, woodAmount);
        AddResource(Resources.Steel, steelAmount);
        AddResource(Resources.Food, foodAmount);
        AddResource(Resources.Stone, stoneAmount);
        AddResource(Resources.Gold, goldAmount);
    }

    private void AddResource(Resources resource, int amount)
    {

        Transform parent = null;
        int yOffset = 0;

        switch (resource)
        {
            case Resources.Wood:
                currentWood += amount;
                parent = woodParent;
                yOffset = 0;
                break;
            case Resources.Steel:
                currentSteel += amount;
                parent = steelParent;
                yOffset = 2;
                break;
            case Resources.Food:
                currentFood += amount;
                parent = foodParent;
                yOffset = 4;
                break;
            case Resources.Stone:
                currentStone += amount;
                parent = stoneParent;
                yOffset = 6;
                break;
            case Resources.Gold:
                currentGold += amount;
                parent = goldParent;
                yOffset = 8;
                break;
            default:
                Debug.LogError("Resource does not exist");
                break;
        }

        for (int i = 0; i < amount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position += new Vector3(parent.childCount,yOffset, 0);
            cube.transform.parent = parent;
        }      
    }

    
    public bool TrySubtractResource(Resources resource, int amount)
    {
        Transform parent = null;

        switch (resource)
        {
            case Resources.Wood:
                if(currentWood - amount >= 0)
                {
                    currentWood -= amount;
                    parent = woodParent;

                    RemoveCubesFrom(parent, amount);
                    return true;
                }
                break;
            case Resources.Steel:
                if(currentSteel - amount >= 0)
                {
                    currentSteel -= amount;
                    parent = steelParent;

                    RemoveCubesFrom(parent, amount);
                    return true;
                }
                break;
            case Resources.Food:
                if(currentFood - amount >= 0)
                {
                    currentFood -= amount;
                    parent = foodParent;

                    RemoveCubesFrom(parent, amount);
                    return true;
                }
                break;
            case Resources.Stone:
                if(currentStone - amount >= 0)
                {
                    currentStone -= amount;
                    parent = stoneParent;

                    RemoveCubesFrom(parent, amount);
                    return true;
                }
                break;
            case Resources.Gold:
                if(currentGold - amount >= 0)
                {
                    currentGold -= amount;
                    parent = goldParent;

                    RemoveCubesFrom(parent, amount);
                    return true;
                }
                break;
            default:
                Debug.LogError("Resource does not exist");
                break;
        }

        return false;
    }

    private void RemoveCubesFrom(Transform parent, int amount)
    {  
        //Destroy Resources
        for (int i = 0; i < amount; i++)
        {
            Destroy(parent.GetChild(parent.childCount - i - 1).gameObject);
        }
    }

    private void SetParents()
    {
        woodParent = new GameObject().transform;
        woodParent.gameObject.name = "Wood Holder";

        steelParent = new GameObject().transform;
        steelParent.gameObject.name = "Steel Holder";
        
        foodParent = new GameObject().transform;
        foodParent.gameObject.name = "Food Holder";

        stoneParent = new GameObject().transform;
        stoneParent.gameObject.name = "Stone Holder";

        goldParent = new GameObject().transform;
        goldParent.gameObject.name = "Gold Holder";
    }

    private void SetStartAmounts()
    {
        AddResources(startWood, startSteel, startFood, startStone, startGold);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10,10,200,200), "Wood: " + currentWood + "  Steel: " + currentSteel + "  Food: " + currentFood + "  Stone: " + currentStone + "  Gold: " + currentGold);
    }
}