using UnityEngine;

public class NormalSlimeFactory : SlimeFactoryBase
{
    protected override void Init()
    {
        _slimePrefab = Resources.Load("Prefabs/Slime/Normal Slime") as GameObject;
        _factoryManager.AddFactorys(ESlimeType.Normal, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}