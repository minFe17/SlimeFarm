using UnityEngine;
using Utils;

public class Lobby : MonoBehaviour
{
    [SerializeField] Camera _camera;

    void Start()
    {
        Init();
    }

    async void Init()
    {
        await GenericSingleton<LoadAsset>.Instance.Init();
        CreateLobbyUI(_camera);
    }

    void CreateLobbyUI(Camera camera)
    {
        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        uiManager.CreateLobbyUI(camera, transform);
    }
}