using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class BuyUIButton : MonoBehaviour
{
    [Header("Button Type")]
    [SerializeField] EBuyButtonType _buttonType;

    [Header("Parent UI")]
    [SerializeField] UI _ui;

    [Header("Other Buy Button")]
    [SerializeField] BuyUIButton _otherButton;

    [Header("UI Panel Animator")]
    [SerializeField] Animator _animator;

    AudioClipManager _audioClipManager;
    SpriteAtlas _uiSprite;

    Button _button;
    Image _image;
    Sprite _onSprite;
    Sprite _offSprite;
    bool _isClick;

    async void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        _uiSprite = await GenericSingleton<SpriteManager>.Instance.GetUISprite();
        SetSprite();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _isClick)
            HideUI();
    }

    public void ClickButton()
    {
        if (!_isClick)
            ShowUI();
        else
            HideUI();
    }

    void ShowUI()
    {
        if (_ui.IsOpenUI)
            _otherButton.HideUI();
        _image.sprite = _onSprite;
        _animator.SetTrigger("doShow");
        _isClick = true;
        _ui.IsOpenUI = true;
        _audioClipManager.PlaySFXSound(ESFXSoundType.Button);
    }

    void SetSprite()
    {
        string buttonSprite = _buttonType.ToString();
        _onSprite = _uiSprite.GetSprite($"{buttonSprite} Over");
        _offSprite = _uiSprite.GetSprite($"{buttonSprite}");
        SetSpriteState();
    }

    void SetSpriteState()
    {
        SpriteState spriteState = new SpriteState();
        spriteState.highlightedSprite = _onSprite;
        spriteState.pressedSprite = _onSprite;
        spriteState.selectedSprite = _onSprite;

        _button.spriteState = spriteState;
    }

    public void HideUI()
    {
        _image.sprite = _offSprite;
        _animator.SetTrigger("doHide");
        _isClick = false;
        _ui.IsOpenUI = false;
        _audioClipManager.PlaySFXSound(ESFXSoundType.Button);
    }
}

public enum EBuyButtonType
{
    None,
    Slime,
    Plant,
    Max,
}