public class RockSlime : Slime
{
    protected override void Awake()
    {
        base.Awake();
        _slimeType = ESlimeType.Rock;
        _slimeSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Rock");
        _shadowSprite.sprite = _spriteManager.SlimeSprite.GetSprite("Shadow");
    }
}