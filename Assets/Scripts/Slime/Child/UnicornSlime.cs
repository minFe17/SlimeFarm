public class UnicornSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Unicorn;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Unicorn");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}