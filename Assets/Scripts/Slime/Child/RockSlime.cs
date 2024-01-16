public class RockSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Rock;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Rock");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}