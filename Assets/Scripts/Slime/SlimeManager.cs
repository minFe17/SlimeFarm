using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    // ╫л╠шео
    RuntimeAnimatorController[] _levelAnimatorControllers;

    public RuntimeAnimatorController[] LevelAnimatorControllers { get => _levelAnimatorControllers; }

    public void Init( )
    {
        SetAnimatorController();
    }

    void SetAnimatorController()
    {
        _levelAnimatorControllers = new RuntimeAnimatorController[3];
        for (int i = 0; i < _levelAnimatorControllers.Length; i++)
            _levelAnimatorControllers[i] = Resources.Load($"Prefabs/Slime/Animator/Level{i + 1}") as RuntimeAnimatorController;
    }
}

public enum ESlimeType
{
    None,
    Normal,
    Max,
}