using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance { get => GetInstance(); }

    [Header("Singleton")]
    [SerializeField] protected bool dontDestroyOnLoad = false;
    protected bool overrideAutospawn = false;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;

            Debug.Log(typeof(T) + " initialized.");

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Debug.Log("Found second instance of " + typeof(T) + ", destroying this object: " + gameObject.name);

            if (dontDestroyOnLoad)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            Debug.LogWarning("Destroying Singleton for " + typeof(T));
        }
    }

    public static T GetInstance()
    {
        if (instance == null)
        {
            Debug.LogWarning(typeof(T).ToString() + " instance not defined, generating automatic one.");
            var go = new GameObject("_AUTO_" + typeof(T).ToString() + "_Instance");
            var gs = go.AddComponent<T>();
            go.hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor;
            instance = gs;
        }

        return instance;
    }

    public static void TrySetInstance(T requestedInstance)
    {
        if(instance == null)
        {
            instance = requestedInstance;
        }
        else
        {
            Debug.LogError("Setting Instance was Requested but there already exists one in " + instance.gameObject.name);
        }
    }

    public static bool ExistingInstance()
    {
        if(instance != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}