using UnityEngine;

public class UIManager : MonoBehaviour
{
    // �̱���
    GameObject _uiPrefab;
    public UI UI { get; set; }
    public CapitalUI CapitalUI { get; set; }
    public SellUI SellUI { get; set; }
    public NoticeUI NoticeUI { get; set; }

    public void CreateUI(Camera mainCamera)
    {
        if (_uiPrefab == null)
            _uiPrefab = Resources.Load("Prefabs/UI/IngameUI") as GameObject;

        GameObject temp = Instantiate(_uiPrefab);
        temp.GetComponent<UI>().Init(mainCamera);
    }
}