using UnityEngine;

/// <summary>
/// BattleSceneInitializer is responsible for initializing the battle scene.
/// allowing you to initialize the scene in sequences.
/// </summary>
public class BattleSceneInitializer : MonoBehaviour
{
    [SerializeField] private InputController inputController;

    private void Start()
    {
        inputController.Initialize();
    }
}
