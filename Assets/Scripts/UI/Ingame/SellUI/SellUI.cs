using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class SellUI : MonoBehaviour
{
    [SerializeField] Image _panelImage;
    [SerializeField] Image _shadowImage;
    [SerializeField] Image _sellImage;
    [SerializeField] Button _sellButton;

    SpriteAtlas _uiSprite;

    bool _isSell;

    public bool IsSell { get =>_isSell; }

    void Awake()
    {
        _uiSprite = GenericSingleton<SpriteManager>.Instance.UISprite;
        SetSprite();
    }

    void SetSprite()
    {
        _panelImage.sprite = _uiSprite.GetSprite("Panel");
        _shadowImage.sprite = _uiSprite.GetSprite("Shadow");
        _sellImage.sprite = _uiSprite.GetSprite("Sell");
        SetSpriteState();
    }

    void SetSpriteState()
    {
        Sprite onSprite = _uiSprite.GetSprite("Sell Over");

        SpriteState spriteState = new SpriteState();
        spriteState.highlightedSprite = onSprite;
        spriteState.pressedSprite = onSprite;
        spriteState.selectedSprite = onSprite;

        _sellButton.spriteState = spriteState;
    }

    public void Enter()
    {
        _isSell = true;
    }

    public void Exit()
    {
        _isSell = false;
    }
}