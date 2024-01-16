public class ArtSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Art;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Art");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}