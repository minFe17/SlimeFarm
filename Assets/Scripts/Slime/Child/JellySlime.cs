public class JellySlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Jelly;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Jelly");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}