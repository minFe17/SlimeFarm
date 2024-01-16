public class NormalSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Normal;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Normal");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}