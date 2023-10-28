using UnityEngine;
using Utils;

public class UI : MonoBehaviour
{
    [Header("Capital UI")]
    [SerializeField] CapitalUI _capitalUI;

    [Header("Sell UI")]
    [SerializeField] SellUI _sellUI;

    public void Init(Camera mainCamera)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        uiManager.UI = this;
        uiManager.CapitalUI = _capitalUI;
        uiManager.SellUI = _sellUI;
    }
}