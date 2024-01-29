using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Utils;

public class ReadData
{
    AddressableManager _addressableManager;

    SlimeData _slimeData;
    MaxSlimeData _maxSlimeData;
    JamOutputData _jamOutputData;

    bool CheckData(string filePath)
    {
        if (File.Exists(filePath))
            return true;
        return false;
    }

    void BaseReadData(out string[] data, string path)
    {
        if (!CheckData(path))
            data = null;
        else
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                List<string>dataList = new List<string>();

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    dataList.Add(line);
                }
                data = dataList.ToArray();
            }
        }
    }

    void BaseReadOnlyData(out string[] data, TextAsset readData)
    {
        using (StringReader stringReader = new StringReader(readData.text))
        {
            string baseData = stringReader.ReadToEnd();
            data = baseData.Split("\r\n");
        }
        if (data.Length < 2)
            data = null;
    }

    Slime CreateSaveSlime(string[] value)
    {
        SlimeFactoryManager factoryManager = GenericSingleton<SlimeFactoryManager>.Instance;
        ESlimeType slimeType = (ESlimeType)Enum.Parse(typeof(ESlimeType), value[1]);

        float x = float.Parse(value[4]);
        float y = float.Parse(value[5]);
        float z = float.Parse(value[6]);
        Vector3 position = new Vector3(x, y, z);

        Slime slime = factoryManager.MakeSlime(slimeType, position);
        return slime;
    }

    public void ReadSlimeData(SlimeManager slimeManager, string dataPath)
    {
        string[] data;
        BaseReadData(out data, dataPath);
        if (data != null)
        {
            for (int i = 1; i < data.Length; i++)
            {
                var values = data[i].Split(",");
                Slime slime = CreateSaveSlime(values);

                slime.Level = int.Parse(values[2]);
                slime.EXP = float.Parse(values[3]);
                slime.IsSaveSlime = true;
                slime.Init();
                slimeManager.AddSlime(slime);
            }
        }
    }

    public void ReadSlimeUnlockData(SlimeManager slimeManager, string dataPath)
    {
        string[] data;
        BaseReadData(out data, dataPath);
        for (int i = 0; i < slimeManager.SlimeDatas.Count; i++)
            slimeManager.SlimeUnlocks.Add(false);

        if (data != null)
        {
            for (int i = 1; i < data.Length; i++)
            {
                var values = data[i].Split(",");
                slimeManager.SlimeUnlocks[i - 1] = Convert.ToBoolean(values[1]);
            }
        }
    }

    public void ReadPlantLevelData(PlantManager plantManager, string dataPath)
    {
        string[] data;
        BaseReadData(out data, dataPath);
        if (data != null)
        {
            var values = data[1].Split(",");

            plantManager.MaxSlimeLevel = int.Parse(values[0]);
            plantManager.JamOutputLevel = int.Parse(values[1]);
        }
        else
        {
            plantManager.MaxSlimeLevel = 0;
            plantManager.JamOutputLevel = 0;
        }
    }

    public void ReadGameData(GameManager gameManager, string dataPath)
    {
        string[] data;
        BaseReadData(out data, dataPath);
        if (data != null)
        {
            var values = data[1].Split(",");

            gameManager.Jam = int.Parse(values[0]);
            gameManager.Gold = int.Parse(values[1]);
        }
        else
        {
            gameManager.Jam = 100;
            gameManager.Gold = 200;
        }
    }

    public void ReadSoundData(SoundManager soundManager, string dataPath)
    {
        string[] data;
        BaseReadData(out data, dataPath);
        if (data != null)
        {
            var values = data[1].Split(",");

            soundManager.BgmSound = float.Parse(values[0]);
            soundManager.SFXSound = float.Parse(values[1]);
        }
        else
        {
            soundManager.BgmSound = 0.5f;
            soundManager.SFXSound = 0.5f;
        }
    }

    public async void ReadSlimeInfoData(SlimeManager slimeManager)
    {
        if (_addressableManager == null)
            _addressableManager = GenericSingleton<AddressableManager>.Instance;
        TextAsset slimeDatas = await _addressableManager.GetAddressableAsset<TextAsset>("SlimeInfoData");
        string[] data;
        BaseReadOnlyData(out data, slimeDatas);
        for (int i = 1; i < data.Length; i++)
        {
            var values = data[i].Split(",");
            if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                continue;

            _slimeData.Index = int.Parse(values[0]);
            _slimeData.Name = $"{values[1]} ½½¶óÀÓ";
            _slimeData.Jam = int.Parse(values[2]);
            _slimeData.Gold = int.Parse(values[3]);

            slimeManager.SlimeDatas.Add(_slimeData);
        }
    }

    public async void ReadPlantData(PlantManager plantManager)
    {
        if (_addressableManager == null)
            _addressableManager = GenericSingleton<AddressableManager>.Instance;
        TextAsset plantDatas = await _addressableManager.GetAddressableAsset<TextAsset>("PlantLevelData");
        string[] data;
        BaseReadOnlyData(out data, plantDatas);

        for (int i = 1; i < data.Length; i++)
        {
            var values = data[i].Split(",");
            if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                continue;

            _maxSlimeData.MaxSlime = int.Parse(values[1]);
            _maxSlimeData.MaxSlimeGold = int.Parse(values[2]);

            _jamOutputData.JamOutput = int.Parse(values[3]);
            _jamOutputData.JamOutputGold = int.Parse(values[4]);

            plantManager.MaxSlimeDatas.Add(_maxSlimeData);
            plantManager.JamOutputDatas.Add(_jamOutputData);
        }
    }
}