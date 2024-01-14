public class WormSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Worm;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Worm");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}