using UnityEngine;
using Utils;

public class CSVManager : MonoBehaviour
{
    // ╫л╠шео
    WriteData _writeData = new WriteData();
    ReadData _readData = new ReadData();

    SlimeManager _slimeManager;
    PlantManager _plantManager;
    GameManager _gameManager;
    SoundManager _soundManager;

    string _slimeDataPath;
    string _slimeUnlockDataPath;
    string _plantDataPath;
    string _gameDataPath;
    string _soundDataPath;

    public void Init()
    {
        SetManager();
        CreateDataPath();
        ReadOnlyData();
    }

    void SetManager()
    {
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _plantManager = GenericSingleton<PlantManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _soundManager = GenericSingleton<SoundManager>.Instance;
    }

    void CreateDataPath()
    {
        _slimeDataPath = CreateDataPath("SlimeData.csv");
        _slimeUnlockDataPath = CreateDataPath("SlimeUnlockData.csv");
        _plantDataPath = CreateDataPath("PlantData.csv");
        _gameDataPath = CreateDataPath("GameData.csv");
        _soundDataPath = CreateDataPath("SoundData.csv");
    }

    string CreateDataPath(string dataName)
    {
        return Application.persistentDataPath + dataName;
    }

    void ReadOnlyData()
    {
        _readData.ReadSlimeInfoData(_slimeManager);
        _readData.ReadPlantData(_plantManager);
    }

    public void ReadSlimeData()
    {
        _readData.ReadSlimeUnlockData(_slimeManager, _slimeUnlockDataPath);
        _readData.ReadSlimeData(_slimeManager, _slimeDataPath);
    }

    public void ReadPlantData()
    {
        _readData.ReadPlantLevelData(_plantManager, _plantDataPath);
    }

    public void ReadGameData()
    {
        _readData.ReadGameData(_gameManager, _gameDataPath);
    }

    public void ReadSoundData()
    {
        _readData.ReadSoundData(_soundManager, _soundDataPath);
    }

    public void WriteData()
    {
        _writeData.WriteSlimeData(_slimeManager, _slimeDataPath);
        _writeData.WriteSlimeUnlockData(_slimeManager, _slimeUnlockDataPath);
        _writeData.WritePlantLevelData(_plantManager, _plantDataPath);
        _writeData.WriteGameData(_gameManager, _gameDataPath);
    }

    public void WriteSoundData()
    {
        _writeData.WriteSoundData(_soundManager, _soundDataPath);
    }
}