using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SlimeManager : MonoBehaviour
{
    // 싱글턴
    List<SlimeData> _slimeDatas = new List<SlimeData>();
    List<bool> _slimeUnlocks = new List<bool>();
    
    RuntimeAnimatorController[] _levelAnimatorControllers;

    public List<SlimeData> SlimeDatas { get => _slimeDatas; }
    public List<bool> SlimeUnlocks { get => _slimeUnlocks; }

    public RuntimeAnimatorController[] LevelAnimatorControllers { get => _levelAnimatorControllers; }

    CSVManager _csvManager;

    public void Init()
    {
        _csvManager = GenericSingleton<CSVManager>.Instance;
        SetSlimeData();
        SetAnimatorController();
    }

    void SetAnimatorController()
    {
        _levelAnimatorControllers = new RuntimeAnimatorController[3];
        for (int i = 0; i < _levelAnimatorControllers.Length; i++)
            _levelAnimatorControllers[i] = Resources.Load($"Prefabs/Slime/Animator/Level{i + 1}") as RuntimeAnimatorController;
    }

    void SetSlimeData()
    {
        _csvManager.ReadSlimeData();
        // csv파일 읽기 만약 csv파일이 없으면 다 false
        for (int i = 0; i < _slimeDatas.Count; i++)
            _slimeUnlocks.Add(false);
    }

    public void UnlockSlime(int index)
    {
        _slimeUnlocks[index] = true;
        // 파일 쓰기 
    }
}

public enum ESlimeType
{
    None,
    Normal,
    Rock,
    Bear,
    Mummy,
    Jelly,
    Worm,
    Art,
    Cook,
    Pudding,
    Angle,
    Devil,
    King,
    Unicorn,
    Cyborg,
    Shark,
    Sushi,
    Diamond,
    Earth,
    Max,
}