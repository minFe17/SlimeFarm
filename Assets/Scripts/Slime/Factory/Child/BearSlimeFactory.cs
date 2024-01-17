using UnityEngine;

public class BearSlimeFactory : SlimeFactoryBase
{
    protected override async void Init()
    {
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>("Bear Slime");
        _factoryManager.AddFactorys(ESlimeType.Bear, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}