using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class UIManager : MonoBehaviour
{
    // ╫л╠шео
    GameObject _uiPrefab;
    GameObject _lobbyUIPrefab;

    public UI UI { get; set; }
    public CapitalUI CapitalUI { get; set; }
    public SellUI SellUI { get; set; }
    public NoticeUI NoticeUI { get; set; }

    public async Task Init()
    {
        AddressableManager addressableManager = GenericSingleton<AddressableManager>.Instance;
        _uiPrefab = await addressableManager.GetAddressableAsset<GameObject>("IngameUI");
        _lobbyUIPrefab = await addressableManager.GetAddressableAsset<GameObject>("LobbyUI");
    }

    public void CreateUI(Camera mainCamera)
    {
        GameObject temp = Instantiate(_uiPrefab);
        temp.GetComponent<UI>().Init(mainCamera);
    }

    public void CreateLobbyUI(Camera camera, Transform parent)
    {
        GameObject temp = Instantiate(_lobbyUIPrefab, parent);
        temp.GetComponent<Canvas>().worldCamera = camera;
    }
}