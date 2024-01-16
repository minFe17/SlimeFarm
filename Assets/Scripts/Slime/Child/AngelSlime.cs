public class AngelSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Angel;
        _slimeSprite.sprite = _spriteAtlas.GetSprite("Angel");
        _shadowSprite.sprite = _spriteAtlas.GetSprite("Shadow");
    }
}