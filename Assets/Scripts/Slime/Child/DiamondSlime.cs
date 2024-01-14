public class DiamondSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Diamond;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Diamond");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}