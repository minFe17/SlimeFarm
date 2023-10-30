using System.IO;
using UnityEngine;
using Utils;

public class CSVManager : MonoBehaviour
{
    // 싱글턴
    SlimeManager _slimeManager;

    public void ReadSlimeData()
    {
        if (_slimeManager == null)
            _slimeManager = GenericSingleton<SlimeManager>.Instance;

        TextAsset slimeDatas = Resources.Load("Datas/SlimeData") as TextAsset;
        string[] data = null;
        using (StringReader stringReader = new StringReader(slimeDatas.text))
        {
            string baseData = stringReader.ReadToEnd();
            data = baseData.Split("\r\n");
        }
        if (data.Length < 2)
            return;
        for(int i = 1; i<data.Length; i++)
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
}