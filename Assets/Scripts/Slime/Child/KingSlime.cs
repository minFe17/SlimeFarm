public class KingSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.King;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("King");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}