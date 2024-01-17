using UnityEngine;

public class UnicornSlimeFactory : SlimeFactoryBase
{
    protected override async void Init()
    {
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>("Unicorn Slime");
        _factoryManager.AddFactorys(ESlimeType.Unicorn, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}