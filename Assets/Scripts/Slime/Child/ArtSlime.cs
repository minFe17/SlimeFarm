public class ArtSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Art;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Art");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}