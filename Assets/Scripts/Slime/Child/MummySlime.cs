public class MummySlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Mummy;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Mummy");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}
