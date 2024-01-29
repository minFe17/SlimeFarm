using System.Collections.Generic;
using System.IO;
using System.Text;

public class WriteData
{
    List<string[]> _datas = new List<string[]>();
    List<string> _valueList = new List<string>();
    StringBuilder _stringBuilder;

    void BaseWriteData(string dataPath)
    {
        string delimiter = ",";
        string[][] outputs = _datas.ToArray();

        if (_stringBuilder == null)
            _stringBuilder = new StringBuilder();
        _stringBuilder.Clear();
        for (int i = 0; i < outputs.Length; i++)
        {
            _stringBuilder.AppendLine(string.Join(delimiter, outputs[i]));
        }
        using (StreamWriter outStream = File.CreateText(dataPath))
            outStream.Write(_stringBuilder);
    }

    void AddSlimeData(out string[] value, int index, Slime slime)
    {
        _valueList.Clear();

        _valueList.Add((index + 1).ToString());
        _valueList.Add(slime.SlimeType.ToString());
        _valueList.Add(slime.Level.ToString());
        _valueList.Add(slime.EXP.ToString());
        _valueList.Add((slime.transform.position.x).ToString());
        _valueList.Add((slime.transform.position.y).ToString());
        _valueList.Add((slime.transform.position.z).ToString());

        value = _valueList.ToArray();
    }

    public void WriteSlimeData(SlimeManager slimeManager, string dataPath)
    {
        _datas.Clear();
        List<Slime> slimes = slimeManager.Slimes;
        string[] header = { "Index", "SlimeType", "Level", "EXP", "PositonX", "PostionY", "PositionZ" };
        _datas.Add(header);
        for (int i = 0; i < slimes.Count; i++)
        {
            string[] data;
            AddSlimeData(out data, i, slimes[i]);
            _datas.Add(data);
        }

        BaseWriteData(dataPath);
    }

    public void WriteSlimeUnlockData(SlimeManager slimeManager, string dataPath)
    {
        _datas.Clear();

        string[] header = { "Index", "Unlock" };
        _datas.Add(header);
        for (int i = 0; i < slimeManager.SlimeUnlocks.Count; i++)
        {
            string[] value = { (i + 1).ToString(), slimeManager.SlimeUnlocks[i].ToString() };
            _datas.Add(value);
        }

        BaseWriteData(dataPath);
    }

    public void WritePlantLevelData(PlantManager plantManager, string dataPath)
    {
        _datas.Clear();

        string[] header = { "MaxSlimeLevel", "JamOutputLevel" };
        _datas.Add(header);
        string[] value = { plantManager.MaxSlimeLevel.ToString(), plantManager.JamOutputLevel.ToString() };
        _datas.Add(value);

        BaseWriteData(dataPath);
    }

    public void WriteGameData(GameManager gameManager, string dataPath)
    {
        _datas.Clear();

        string[] header = { "Jam", "Gold" };
        _datas.Add(header);
        string[] value = { gameManager.Jam.ToString(), gameManager.Gold.ToString() };
        _datas.Add(value);

        BaseWriteData(dataPath);
    }

    public void WriteSoundData(SoundManager soundManager, string dataPath)
    {
        _datas.Clear();

        string[] header = { "BGMVolume", "SFXVolume" };
        _datas.Add(header);
        string[] value = { soundManager.BgmSound.ToString(), soundManager.SFXSound.ToString() };
        _datas.Add(value);

        BaseWriteData(dataPath);
    }
}