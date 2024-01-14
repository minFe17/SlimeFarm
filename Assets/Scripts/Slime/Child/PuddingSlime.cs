public class PuddingSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Pudding;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Pudding");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}