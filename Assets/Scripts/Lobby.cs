using UnityEngine;

public class Lobby : MonoBehaviour
{
    [Header("Prefab")]
    GameObject _backgroundPrefab;
    GameObject _cameraPrefab;
    GameObject _lobbyUIPrefab;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _backgroundPrefab = Resources.Load("Prefabs/Background") as GameObject;
        _cameraPrefab = Resources.Load("Prefabs/Main Camera") as GameObject;
        _lobbyUIPrefab = Resources.Load("Prefabs/UI/LobbyUI") as GameObject;
        CreateBackground();
    }

    void CreateBackground()
    {
        Instantiate(_backgroundPrefab, transform);
        CreateCamera();
    }

    void CreateCamera()
    {
        GameObject temp = Instantiate(_cameraPrefab, transform);
        Camera camera = temp.GetComponent<Camera>();
        CreateLobbyUI(camera);
    }

    void CreateLobbyUI(Camera camera)
    {
        GameObject temp = Instantiate(_lobbyUIPrefab, transform);
        temp.GetComponent<Canvas>().worldCamera = camera;
    }
}