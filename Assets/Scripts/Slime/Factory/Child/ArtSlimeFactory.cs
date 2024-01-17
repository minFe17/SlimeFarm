using UnityEngine;

public class ArtSlimeFactory : SlimeFactoryBase
{
    protected override async void Init()
    {
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>("Art Slime");
        _factoryManager.AddFactorys(ESlimeType.Art, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}