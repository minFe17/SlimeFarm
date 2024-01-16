public class DevilSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Devil;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Devil");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}