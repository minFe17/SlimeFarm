using UnityEngine;

public class RobotSlimeFactory : SlimeFactoryBase
{
    protected override void Init()
    {
        _slimePrefab = Resources.Load("Prefabs/Slime/Robot Slime") as GameObject;
        _factoryManager.AddFactorys(ESlimeType.Robot, this);
    }

    public override Slime MakeSlime(Vector3 position)
    {
        GameObject temp = Instantiate(_slimePrefab, position, Quaternion.identity);
        return temp.GetComponent<Slime>();
    }
}