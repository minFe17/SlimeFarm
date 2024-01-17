using UnityEngine;
using Utils;

public abstract class SlimeFactoryBase : MonoBehaviour
{
    protected SlimeFactoryManager _factoryManager;
    protected AddressableManager _addressableManager;
    protected GameObject _slimePrefab;

    protected void Awake()
    {
        _factoryManager = GenericSingleton<SlimeFactoryManager>.Instance;
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        Init();
    }
    protected abstract void Init();
    public abstract Slime MakeSlime(Vector3 position);
}