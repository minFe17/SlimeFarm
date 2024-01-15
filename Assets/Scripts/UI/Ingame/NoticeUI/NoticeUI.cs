using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class NoticeUI : MonoBehaviour
{
    [SerializeField] SellUI _sellUI;

    [Header("Notice Text")]
    [SerializeField] Text _noticeText;

    [Header("Message Delay")]
    [SerializeField] float _hideDelay;

    [Header("Sprite")]
    [SerializeField] Image _panelImage;

    SpriteAtlas _uiSprite;

    RectTransform _rectTransform;
    Vector2 _showPosition;
    Vector2 _hidePosition;

    bool _isShow;

    void Start()
    {
        _uiSprite = GenericSingleton<SpriteManager>.Instance.UISprite;
        _rectTransform = GetComponent<RectTransform>();
        _showPosition = new Vector2(0, -3);
        _hidePosition = _rectTransform.anchoredPosition;
        SetSprite();
    }

    void SetSprite()
    {
        _panelImage.sprite = _uiSprite.GetSprite("Panel");
    }

    public void ShowMessage(string message)
    {
        _noticeText.text = message;
        _rectTransform.anchoredPosition = _showPosition;
        _isShow = true;

        if (_sellUI.IsSell)
            return;
        if(_isShow == true)
            Invoke("HideMessage", _hideDelay);
    }

    public void HideMessage()
    {
        _rectTransform.anchoredPosition = _hidePosition;
        _isShow = false;
    }
}