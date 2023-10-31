using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SlimeManager : MonoBehaviour
{
    // �̱���
    List<Slime> _slimes = new List<Slime>();
    List<GameObject> _slimePrefabs = new List<GameObject>();
    List<SlimeData> _slimeDatas = new List<SlimeData>();
    List<bool> _slimeUnlocks = new List<bool>();

    RuntimeAnimatorController[] _levelAnimatorControllers;

    public List<Slime> Slimes { get => _slimes; }
    public List<SlimeData> SlimeDatas { get => _slimeDatas; }
    public List<bool> SlimeUnlocks { get => _slimeUnlocks; }

    public RuntimeAnimatorController[] LevelAnimatorControllers { get => _levelAnimatorControllers; }

    CSVManager _csvManager;

    public void Init()
    {
        _csvManager = GenericSingleton<CSVManager>.Instance;
        SetSlime(); //���丮 ���������� ���?
        SetSlimeData();
        SetAnimatorController();
        //���� �б�
    }

    void SetSlime()
    {
        for (int i = 0; i < (int)ESlimeType.Max; i++)
        {
            _slimePrefabs.Add(Resources.Load($"Prefabs/Slime/{((ESlimeType)i).ToString()} Slime") as GameObject);
        }
    }

    void SetSlimeData()
    {
        _csvManager.ReadSlimeData();
        // csv���� �б� ���� csv������ ������ �� false
        for (int i = 0; i < _slimeDatas.Count; i++)
            _slimeUnlocks.Add(false);
    }

    void SetAnimatorController()
    {
        _levelAnimatorControllers = new RuntimeAnimatorController[3];
        for (int i = 0; i < _levelAnimatorControllers.Length; i++)
            _levelAnimatorControllers[i] = Resources.Load($"Prefabs/Slime/Animator/Level{i + 1}") as RuntimeAnimatorController;
    }

    public void UnlockSlime(int index)
    {
        _slimeUnlocks[index] = true;
        // ���� ���� 
    }

    public bool CalculteMaxSlime()
    {
        PlantManager plantManager = GenericSingleton<PlantManager>.Instance;
        int maxSlimeLevel = plantManager.MaxSlimeLevel;
        int maxSlime = plantManager.MaxSlimeDatas[maxSlimeLevel].MaxSlime;
        if (_slimes.Count < maxSlime)
            return false;
        else
            return true;
    }

    public void CreateSlime(int index)
    {
        Vector3 position = GenericSingleton<RepositionManager>.Instance.Reposition();
        GameObject temp = Instantiate(_slimePrefabs[index], position, Quaternion.identity);
        Slime slime = temp.GetComponent<Slime>();
        _slimes.Add(slime);
        // csv���� ����
    }

    public void SellSlime(Slime slime)
    {
        _slimes.Remove(slime);
        // csv���� ����
    }
}

public enum ESlimeType
{
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
    Robot,
    Shark,
    Sushi,
    Diamond,
    Earth,
    Max,
}