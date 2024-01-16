public class DiamondSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Diamond;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Diamond");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}