public class BearSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Bear;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Bear");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}