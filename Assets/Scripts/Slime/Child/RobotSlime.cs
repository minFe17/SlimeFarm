public class RobotSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Robot;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Robot");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}