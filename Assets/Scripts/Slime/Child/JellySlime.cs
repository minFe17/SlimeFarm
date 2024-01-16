public class JellySlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Jelly;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Jelly");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}