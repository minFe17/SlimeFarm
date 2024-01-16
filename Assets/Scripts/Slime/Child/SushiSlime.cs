public class SushiSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Sushi;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Sushi");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}