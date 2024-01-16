public class PuddingSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Pudding;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Pudding");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}