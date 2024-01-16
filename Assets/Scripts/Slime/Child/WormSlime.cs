public class WormSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Worm;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Worm");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}