using UnityEngine;

public class AngleSlimeFactory : SlimeFactoryBase
{
    protected override void Init()
    {
        _slimePrefab = Resources.Load("Prefabs/Slime/Angle Slime") as GameObject;
        _factoryManager.AddFactorys(ESlimeType.Angle, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}