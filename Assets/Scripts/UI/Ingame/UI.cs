using UnityEngine;
using Utils;

public class UI : MonoBehaviour
{
    [Header("Capital UI")]
    [SerializeField] CapitalUI _capitalUI;

    [Header("Sell UI")]
    [SerializeField] SellUI _sellUI;

    [Header("Option UI")]
    [SerializeField] GameObject _optionUI;

    [Header("Notice UI")]
    [SerializeField] NoticeUI _noticeUI;

    bool _isOpenUI;

    public bool IsOpenUI { get => _isOpenUI; set => _isOpenUI = value; }

    public void Init(Camera mainCamera)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        uiManager.UI = this;
        uiManager.CapitalUI = _capitalUI;
        uiManager.SellUI = _sellUI;
        uiManager.NoticeUI = _noticeUI;
    }

    public void ShowOption()
    {
        _optionUI.SetActive(true);
        _isOpenUI = true;
    }

    public void HideOption()
    {
        _optionUI.SetActive(false);
        _isOpenUI = false;
    }
}