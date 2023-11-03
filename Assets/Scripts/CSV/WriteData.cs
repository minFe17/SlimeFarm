using System.Collections.Generic;
using System.IO;
using System.Text;

public class WriteData
{
    void BaseWriteData(List<string[]> datas, string dataPath)
    {
        string delimiter = ",";
        string[][] outputs = datas.ToArray();

        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < outputs.Length; i++)
        {
            stringBuilder.AppendLine(string.Join(delimiter, outputs[i]));
        }
        using (StreamWriter outStream = File.CreateText(dataPath))
            outStream.Write(stringBuilder);
    }

    string[] AddSlimeData(int index, Slime slime)
    {
        List<string> value = new List<string>();
        value.Add((index + 1).ToString());
        value.Add(slime.SlimeType.ToString());
        value.Add(slime.Level.ToString());
        value.Add(slime.EXP.ToString());
        value.Add((slime.transform.position.x).ToString());
        value.Add((slime.transform.position.y).ToString());
        value.Add((slime.transform.position.z).ToString());

        return value.ToArray();
    }

    public void WriteSlimeData(SlimeManager slimeManager, string dataPath)
    {
        List<string[]> datas = new List<string[]>();
        List<Slime> slimes = slimeManager.Slimes;
        string[] header = new string[] { "Index", "SlimeType", "Level", "EXP", "PositonX", "PostionY", "PositionZ" };
        datas.Add(header);
        for (int i = 0; i < slimes.Count; i++)
        {
            string[] data = AddSlimeData(i, slimes[i]);
            datas.Add(data);
        }

        BaseWriteData(datas, dataPath);
    }

    public void WriteSlimeUnlockData(SlimeManager slimeManager, string dataPath)
    {
        List<string[]> datas = new List<string[]>();

        string[] header = new string[] { "Index", "Unlock" };
        datas.Add(header);
        for (int i = 0; i < slimeManager.SlimeUnlocks.Count; i++)
        {
            string[] value = new string[] { (i + 1).ToString(), slimeManager.SlimeUnlocks[i].ToString() };
            datas.Add(value);
        }

        BaseWriteData(datas, dataPath);
    }

    public void WritePlantLevelData(PlantManager plantManager, string dataPath)
    {
        List<string[]> datas = new List<string[]>();

        string[] header = new string[] { "MaxSlimeLevel", "JamOutputLevel" };
        datas.Add(header);
        string[] value = new string[] { plantManager.MaxSlimeLevel.ToString(), plantManager.JamOutputLevel.ToString() };
        datas.Add(value);

        BaseWriteData(datas, dataPath);
    }

    public void WriteGameData(GameManager gameManager, string dataPath)
    {
        List<string[]> datas = new List<string[]>();

        string[] header = new string[] { "Jam", "Gold" };
        datas.Add(header);
        string[] value = new string[] { gameManager.Jam.ToString(), gameManager.Gold.ToString() };
        datas.Add(value);

        BaseWriteData(datas, dataPath);
    }

    public void WriteSoundData(SoundManager soundManager, string dataPath)
    {
        List<string[]> datas = new List<string[]>();

        string[] header = new string[] { "BGMVolume", "SFXVolume" };
        datas.Add(header);
        string[] value = new string[] { soundManager.BgmSound.ToString(), soundManager.SFXSound.ToString() };
        datas.Add(value);

        BaseWriteData(datas, dataPath);
    }
}