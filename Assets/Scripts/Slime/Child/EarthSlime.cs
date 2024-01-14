public class EarthSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Earth;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Earth");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}