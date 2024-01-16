public class CookSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Cook;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Cook");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}