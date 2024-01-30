using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SlimeManager : MonoBehaviour
{
    // ╫л╠шео
    List<Slime> _slimes = new List<Slime>();
    List<SlimeData> _slimeDatas = new List<SlimeData>();
    List<bool> _slimeUnlocks = new List<bool>();

    RuntimeAnimatorController[] _levelAnimatorControllers;

    SlimeFactoryManager _slimeFactoryManager;
    CSVManager _csvManager;
    AudioClipManager _audioClipManager;

    public List<Slime> Slimes { get => _slimes; }
    public List<SlimeData> SlimeDatas { get => _slimeDatas; }
    public List<bool> SlimeUnlocks { get => _slimeUnlocks; }

    public RuntimeAnimatorController[] LevelAnimatorControllers { get => _levelAnimatorControllers; }

    public void Init()
    {
        _slimeFactoryManager = GenericSingleton<SlimeFactoryManager>.Instance;
        _csvManager = GenericSingleton<CSVManager>.Instance;
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        SetSlimeData();
    }

    void SetSlimeData()
    {
        _csvManager.ReadSlimeData();
    }
    
    public async void LoadAnimatorControllerAsset()
    {
        AddressableManager addressableManager = GenericSingleton<AddressableManager>.Instance;
        _levelAnimatorControllers = new RuntimeAnimatorController[3];
        for (int i = 0; i < _levelAnimatorControllers.Length; i++)
            _levelAnimatorControllers[i] = await addressableManager.GetAddressableAsset<RuntimeAnimatorController>($"Level{i + 1}");
    }


    public void UnlockSlime(int index)
    {
        _slimeUnlocks[index] = true;
        _audioClipManager.PlaySFXSound(ESFXSoundType.Unlock);
        _csvManager.WriteData();
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

    public void CreateSlime(ESlimeType slimeType)
    {
        Vector3 position = GenericSingleton<RepositionManager>.Instance.Reposition();
        Slime slime = _slimeFactoryManager.MakeSlime(slimeType, position);
        slime.Init();
        AddSlime(slime);
        _audioClipManager.PlaySFXSound(ESFXSoundType.Buy);
        _csvManager.WriteData();
    }

    public void AddSlime(Slime slime)
    {
        _slimes.Add(slime);
    }

    public void SellSlime(Slime slime)
    {
        GenericSingleton<NoticeManager>.Instance.HideMessage();
        _slimes.Remove(slime);
        _audioClipManager.PlaySFXSound(ESFXSoundType.Sell);
        _csvManager.WriteData();
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
    Angel,
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