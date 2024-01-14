public class UnicornSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Unicorn;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Unicorn");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}