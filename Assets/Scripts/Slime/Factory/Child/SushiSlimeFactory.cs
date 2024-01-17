using UnityEngine;

public class SushiSlimeFactory : SlimeFactoryBase
{
    protected override async void Init()
    {
        _slimePrefab = await _addressableManager.GetAddressableAsset<GameObject>("Sushi Slime");
        _factoryManager.AddFactorys(ESlimeType.Sushi, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}