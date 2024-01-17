using UnityEngine;
using Utils;

public class Lobby : MonoBehaviour
{
    BackgroundAsset _backgroundAsset;
    CameraAsset _cameraAsset;
    GameObject _lobbyUIPrefab;

    void Start()
    {
        Init();
    }

    async void Init()
    {
        AddressableManager addressableManager = GenericSingleton<AddressableManager>.Instance;

        _backgroundAsset = GenericSingleton<BackgroundAsset>.Instance;
        _cameraAsset = GenericSingleton<CameraAsset>.Instance;
        _lobbyUIPrefab = await addressableManager.GetAddressableAsset<GameObject>("LobbyUI");
        CreateBackground();
    }

    async void CreateBackground()
    {
        await _backgroundAsset.Init();
        _backgroundAsset.CreateBackground(transform);
        CreateCamera();
    }

    async void CreateCamera()
    {
        await _cameraAsset.Init();
        Camera camera = _cameraAsset.CreateCamera(transform);
        CreateLobbyUI(camera);
    }

    void CreateLobbyUI(Camera camera)
    {
        GameObject temp = Instantiate(_lobbyUIPrefab, transform);
        temp.GetComponent<Canvas>().worldCamera = camera;
    }
}