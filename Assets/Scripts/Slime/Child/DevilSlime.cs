public class DevilSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Devil;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Devil");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}