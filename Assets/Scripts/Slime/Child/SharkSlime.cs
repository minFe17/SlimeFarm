public class SharkSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Shark;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Shark");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}