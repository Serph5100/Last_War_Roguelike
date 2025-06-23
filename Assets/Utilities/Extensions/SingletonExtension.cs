using UnityEngine;

/// <summary>
/// static instance extension, instead of destroying the new instance
/// it will override the old one, handy for singletons.
/// <param name="T">Type of the MonoBehaviour Class</param>
/// <param name="Instance">Static instance of the MonoBehaviour, example of calling : GameManager.Instance.ExampleMethod()</param>
/// </summary>
public abstract class StaticInstance<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }
    protected virtual void Awake() => Instance = this as T;

    protected virtual void OnApplicationQuit()
    {
        // Clear the instance when the application quits
        Instance = null;
        Destroy(gameObject);
    }
}

/// <summary>
/// basic singleton, destroy any new instance created
/// </summary>
public abstract class Singleton<T> : StaticInstance<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        base.Awake();
    }

}

/// <summary>
/// persistent singleton, is like singleton but it will not be destroyed on scene load
/// </summary>
public abstract class PersistentSingleton<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}