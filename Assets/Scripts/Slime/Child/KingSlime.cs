public class KingSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.King;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("King");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}