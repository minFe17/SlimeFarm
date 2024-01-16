using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class BuySlimeSprite : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] List<Image> _panelImages;
    [SerializeField] List<Image> _slimeImage;

    [Header("Unlock Sprite")]
    [SerializeField] Image _goldIcon;

    [Header("Lock Sprite")]
    [SerializeField] Image _lockImage;
    [SerializeField] Image _jamIcon;

    [Header("Page Sprite")]
    [SerializeField] Image _leftPageImage;
    [SerializeField] Image _rightPageImage;
    [SerializeField] Button _leftPageButton;
    [SerializeField] Button _rightPageButton;

    SpriteAtlas _uiSprite;
    SpriteAtlas _slimeSprite;

    async void Awake()
    {
        SpriteManager spriteManager = GenericSingleton<SpriteManager>.Instance;
        _uiSprite = await spriteManager.GetUISprite();
        _slimeSprite = await spriteManager.GetSlimeSprite();
        SetSprite();
    }

    void SetSprite()
    {
        for(int i=0; i<_panelImages.Count; i++)
            _panelImages[i].sprite = _uiSprite.GetSprite("Panel");
        SetUnlockSprite();
        SetLockSprite();
        SetPageSprite();
    }

    void SetUnlockSprite()
    {
        _goldIcon.sprite = _uiSprite.GetSprite("Gold");
    }

    void SetLockSprite()
    {
        _lockImage.sprite = _uiSprite.GetSprite("Lock");
        _jamIcon.sprite = _uiSprite.GetSprite("Jam");
    }

    void SetPageSprite()
    {
        _leftPageImage.sprite = _uiSprite.GetSprite("Left Page");
        Sprite onSprite = _uiSprite.GetSprite("Left Page Over");
        _leftPageButton.spriteState = SetSpriteState(onSprite);

        _rightPageImage.sprite = _uiSprite.GetSprite("Right Page");
        onSprite = _uiSprite.GetSprite("Right Page Over");
        _rightPageButton.spriteState = SetSpriteState(onSprite);
    }

    SpriteState SetSpriteState(Sprite onSprite)
    {
        SpriteState pageSpriteState = new SpriteState();
        pageSpriteState.highlightedSprite = onSprite;
        pageSpriteState.pressedSprite = onSprite;
        pageSpriteState.selectedSprite = onSprite;

        return pageSpriteState;
    }

    public void ChangeSlimeImage(SlimeData slimeData, ELockType lockType)
    {
        ESlimeType slimeType = (ESlimeType)slimeData.Index - 1;
        _slimeImage[(int)lockType].sprite = _slimeSprite.GetSprite(slimeType.ToString());
        _slimeImage[(int)lockType].SetNativeSize();
    }
}