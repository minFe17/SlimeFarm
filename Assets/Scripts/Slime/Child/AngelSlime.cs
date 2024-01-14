public class AngelSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Angel;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Angel");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}