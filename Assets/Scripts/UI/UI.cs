using UnityEngine;
using Utils;

public class UI : MonoBehaviour
{
    [Header("CapitalUI")]
    [SerializeField] CapitalUI _capitalUI;

    public void Init(Camera mainCamera)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        uiManager.UI = this;
        uiManager.CapitalUI = _capitalUI;
    }
}