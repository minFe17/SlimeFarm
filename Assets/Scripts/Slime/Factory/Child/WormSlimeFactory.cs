using UnityEngine;

public class WormSlimeFactory : SlimeFactoryBase
{
    protected override void Init()
    {
        _slimePrefab = Resources.Load("Prefabs/Slime/Worm Slime") as GameObject;
        _factoryManager.AddFactorys(ESlimeType.Worm, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}