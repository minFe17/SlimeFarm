public class SharkSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Shark;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shark");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}