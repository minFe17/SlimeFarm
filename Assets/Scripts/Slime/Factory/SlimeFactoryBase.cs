using UnityEngine;
using Utils;

public abstract class SlimeFactoryBase : MonoBehaviour
{
    protected SlimeFactoryManager _factoryManager;
    protected GameObject _slimePrefab;

    protected void Awake()
    {
        _factoryManager = GenericSingleton<SlimeFactoryManager>.Instance;
        Init();
    }
    protected abstract void Init();
    public abstract Slime MakeSlime(Vector3 position);
}