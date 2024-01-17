using UnityEngine;

public class KingSlimeFactory : SlimeFactoryBase
{
    protected override async void Init()
    {
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>("King Slime");
        _factoryManager.AddFactorys(ESlimeType.King, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}