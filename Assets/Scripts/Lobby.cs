using UnityEngine;
using Utils;

public class Lobby : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    async void Init()
    {
        await GenericSingleton<LoadAsset>.Instance.Init();
        CreateBackground();
    }

    void CreateBackground()
    {
        BackgroundAsset backgroundAsset =  GenericSingleton<BackgroundAsset>.Instance;
        backgroundAsset.CreateBackground(transform);
        CreateCamera();
    }

    void CreateCamera()
    {
        CameraAsset cameraAsset = GenericSingleton<CameraAsset>.Instance;
        Camera camera = cameraAsset.CreateCamera(transform);
        CreateLobbyUI(camera);
    }

    void CreateLobbyUI(Camera camera)
    {
        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        uiManager.CreateLobbyUI(camera, transform);
    }
}