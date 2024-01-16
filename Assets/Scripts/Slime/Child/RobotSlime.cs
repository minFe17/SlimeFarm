public class RobotSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Robot;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Robot");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}