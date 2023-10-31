using System.Collections.Generic;
using UnityEngine;
using Utils;

public class PlantManager : MonoBehaviour
{
    // ╫л╠шео
    List<MaxSlimeData> _maxSlimeDatas = new List<MaxSlimeData>();
    List<JamOutputData> _jamOutputDatas = new List<JamOutputData>();

    CSVManager _csvManager;

    int _maxSlimeLevel;
    int _jamOutputLevel;

    public List<MaxSlimeData> MaxSlimeDatas { get => _maxSlimeDatas; }
    public List<JamOutputData> JamOutputDatas { get => _jamOutputDatas; }
    public int MaxSlimeLevel { get => _maxSlimeLevel; }
    public int JamOutputLevel { get => _jamOutputLevel; }

    public void Init()
    {
        if (_csvManager == null)
            _csvManager = GenericSingleton<CSVManager>.Instance;
        SetPlantData();
    }

    public void LevelUp(EPlantType plantType)
    {
        if (plantType == EPlantType.MaxSlime)
            _maxSlimeLevel++;
        if (plantType == EPlantType.JamOutPut)
            _jamOutputLevel++;
    }

    void SetPlantData()
    {
        _csvManager.ReadPlantLevelData();
    }
}

public enum EPlantType
{
    None,
    MaxSlime,
    JamOutPut,
    Max,
}