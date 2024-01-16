public class EarthSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Earth;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Earth");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}