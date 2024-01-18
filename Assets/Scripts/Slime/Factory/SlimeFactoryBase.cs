using UnityEngine;
using Utils;

public abstract class SlimeFactoryBase : MonoBehaviour
{
    protected SlimeFactoryManager _factoryManager;
    protected AddressableManager _addressableManager;
    protected GameObject _slimePrefab;
    protected ESlimeType _slimeType;

    protected abstract void Init();

    protected async void Awake()
    {
        _factoryManager = GenericSingleton<SlimeFactoryManager>.Instance;
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        Init();
        _factoryManager.AddFactorys(_slimeType, this);
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>($"{_slimeType} Slime");
    }

    public Slime MakeSlime(Vector3 position)
    {
        GameObject temp = GenericSingleton<ObjectPool>.Instance.PushSlime(_slimeType, _slimePrefab);
        temp.transform.position = position;
        return temp.GetComponent<Slime>();
    }
}