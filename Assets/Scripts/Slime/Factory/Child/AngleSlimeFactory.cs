using UnityEngine;

public class AngelSlimeFactory : SlimeFactoryBase
{
    protected override void Init()
    {
        _slimePrefab = Resources.Load("Prefabs/Slime/Angel Slime") as GameObject;
        _factoryManager.AddFactorys(ESlimeType.Angel, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}