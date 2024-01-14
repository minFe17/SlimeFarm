public class SushiSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Sushi;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Sushi");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}