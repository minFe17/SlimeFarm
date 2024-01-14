public class MummySlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Mummy;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Mummy");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}
