public class CookSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Cook;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Cook");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}