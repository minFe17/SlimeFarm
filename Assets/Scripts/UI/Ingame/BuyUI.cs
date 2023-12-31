using UnityEngine;
using UnityEngine.UI;
using Utils;

public class BuyUI : MonoBehaviour
{
    [Header("Button Type")]
    [SerializeField] EBuyButtonType _buttonType;

    [Header("Parent UI")]
    [SerializeField] UI _ui;

    [Header("Other Buy Button")]
    [SerializeField] BuyUI _otherButton;

    [Header("UI Panel Animator")]
    [SerializeField] Animator _animator;

    AudioClipManager _audioClipManager;

    Image _image;
    Sprite _onSprite;
    Sprite _offSprite;
    bool _isClick;

    void Start()
    {
        SetSprite();
        _image = GetComponent<Image>();
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
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
        _onSprite = Resources.Load($"Prefabs/Sprite/UI/{buttonSprite} Over Sprite") as Sprite;
        _offSprite = Resources.Load($"Prefabs/Sprite/UI/{buttonSprite} Sprite") as Sprite;
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