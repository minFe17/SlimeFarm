public class NormalSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Normal;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Normal");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}