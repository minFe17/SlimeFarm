using System.Collections.Generic;
using UnityEngine;
using Utils;

public class SlimeFactoryManager : MonoBehaviour
{
    // ╫л╠шео
    Dictionary<ESlimeType, SlimeFactoryBase> _slimeFactorys = new Dictionary<ESlimeType, SlimeFactoryBase>();

    GameObject _factoryPrefab;
    AddressableManager _addressableManager;

    public async void Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _factoryPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Factory");
        CreateFactory();
    }

    void CreateFactory()
    {
        Instantiate(_factoryPrefab, transform);
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