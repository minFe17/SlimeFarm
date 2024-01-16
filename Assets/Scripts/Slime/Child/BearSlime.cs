public class BearSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Bear;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Bear");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}