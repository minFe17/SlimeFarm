using System.Collections.Generic;
using UnityEngine;

public class SlimeFactoryManager : MonoBehaviour
{
    // ╫л╠шео
    Dictionary<ESlimeType, SlimeFactoryBase> _slimeFactorys = new Dictionary<ESlimeType, SlimeFactoryBase> ();

    public void Init()
    {
        CreateFactory();
    }

    void CreateFactory()
    {
        GameObject factory = Resources.Load("Prefabs/Factory") as GameObject;
        Instantiate(factory);
    }

    public void AddFactorys(ESlimeType key, SlimeFactoryBase value)
    {
        _slimeFactorys.Add(key, value);
    }

    public Slime MakeSlime(ESlimeType key, Vector3 position)
    {
        SlimeFactoryBase factory;
        _slimeFactorys.TryGetValue(key, out factory);
        return factory.MakeSlime(position);
    }
}