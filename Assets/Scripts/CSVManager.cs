using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using Utils;

public class CSVManager : MonoBehaviour
{
    // 싱글턴
    SlimeManager _slimeManager;
    PlantManager _plantManager;
    SoundManager _soundManager;

    string _soundDataFilePath;

    void Start()
    {
        CreateSoundDataFilePath();
    }

    void CreateSoundDataFilePath()
    {
        string soundDataFileName = "SoundDataFile.csv";
        _soundDataFilePath = Application.persistentDataPath + soundDataFileName;
    }

    bool CheckDataFile(string filePath)
    {
        if (File.Exists(filePath))
            return true;
        return false;
    }

    string[] BaseReadData(string filePath)
    {
        if (!CheckDataFile(filePath))
            return null;
        else
        {
            string source;
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string[] lines;
                source = streamReader.ReadToEnd();
                lines = Regex.Split(source, @"\r\n|\n\r|\n|\r");
                string[] header = Regex.Split(lines[0], ",");
                string[] value = Regex.Split(lines[1], ",");

                return value;
            }
        }
    }

    string[] BaseReadOnlyData(TextAsset readData)
    {
        string[] data = null;
        using (StringReader stringReader = new StringReader(readData.text))
        {
            string baseData = stringReader.ReadToEnd();
            data = baseData.Split("\r\n");
        }
        if (data.Length < 2)
            return null;
        return data;
    }

    void BaseWriteData(List<string[]> datas, string filePath)
    {
        string delimiter = ",";
        string[][] outputs = datas.ToArray();

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < outputs.Length; i++)
        {
            stringBuilder.AppendLine(string.Join(delimiter, outputs[i]));
        }
        using (StreamWriter outStream = File.CreateText(filePath))
            outStream.Write(stringBuilder);
    }

    public void ReadSoundData()
    {
        if (_soundManager == null)
            _soundManager = GenericSingleton<SoundManager>.Instance;
        if (_soundDataFilePath == null)
            CreateSoundDataFilePath();

        string[] value = BaseReadData(_soundDataFilePath);
        if (value != null)
        {
            _soundManager.BgmSound = float.Parse(value[0]);
            _soundManager.SFXSound = float.Parse(value[1]);
        }
        else
        {
            _soundManager.BgmSound = 0.5f;
            _soundManager.SFXSound = 0.5f;
        }
    }

    public void ReadSlimeData()
    {
        if (_slimeManager == null)
            _slimeManager = GenericSingleton<SlimeManager>.Instance;

        TextAsset slimeDatas = Resources.Load("Datas/SlimeData") as TextAsset;
        string[] data = BaseReadOnlyData(slimeDatas);
        for (int i = 1; i<data.Length; i++)
        {
            var values = data[i].Split(",");
            if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                continue;

            SlimeData temp = new SlimeData();

            temp.Index = int.Parse(values[0]);
            temp.Name = $"{values[1]} 슬라임";
            temp.Sprite = Resources.Load($"Prefabs/Sprite/Slime/{values[2]}") as Sprite;
            temp.Jam = int.Parse(values[3]);
            temp.Gold = int.Parse(values[4]);

            _slimeManager.SlimeDatas.Add(temp);
        }
    }

    public void ReadPlantLevelData()
    {
        if (_plantManager == null)
            _plantManager = GenericSingleton<PlantManager>.Instance;

        TextAsset plantDatas = Resources.Load("Datas/PlantLevelData") as TextAsset;
        string[] data = BaseReadOnlyData(plantDatas);

        for (int i = 1; i < data.Length; i++)
        {
            var values = data[i].Split(",");
            if (values.Length == 0 || string.IsNullOrEmpty(values[0]))
                continue;

            MaxSlimeData maxSlimeData = new MaxSlimeData();
            JamOutputData jamOutputData = new JamOutputData();

            maxSlimeData.MaxSlime = int.Parse(values[1]);
            maxSlimeData.MaxSlimeGold = int.Parse(values[2]);

            jamOutputData.JamOutput = int.Parse(values[3]);
            jamOutputData.JamOutputGold = int.Parse(values[4]);

            _plantManager.MaxSlimeDatas.Add(maxSlimeData);
            _plantManager.JamOutputDatas.Add(jamOutputData);
        }
    }

    public void WriteSoundData()
    {
        List<string[]> datas = new List<string[]>();

        string[] header = new string[] { "BGMVolume", "SFXVolume" };
        datas.Add(header);
        string[] value = new string[] { _soundManager.BgmSound.ToString(), _soundManager.SFXSound.ToString() };
        datas.Add(value);

        BaseWriteData(datas, _soundDataFilePath);
    }
}