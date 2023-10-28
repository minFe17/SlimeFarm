using UnityEngine;
using Utils;

public class GameGroundwork: MonoBehaviour
{
    void Start()
    {
        Init();
    }

    void Init()
    {
        Groundwork();
        GenericSingleton<GameManager>.Instance.Init();
        GenericSingleton<SlimeManager>.Instance.Init();
    }

    void Groundwork()
    {
        GenericSingleton<BorderManager>.Instance.CreateBoard(transform);
        GenericSingleton<RepositionManager>.Instance.Init(transform);
        CreateBackground();
        CreateCamera();
    }

    void CreateBackground()
    {
        GameObject backgroundPrefab = Resources.Load("Prefabs/Background") as GameObject;
        Instantiate(backgroundPrefab, transform);
    }

    void CreateCamera()
    {
        GameObject cameraPrefab = Resources.Load("Prefabs/Main Camera") as GameObject;
        GameObject temp = Instantiate(cameraPrefab, transform);
        Camera mainCamera = temp.GetComponent<Camera>();

        GenericSingleton<UIManager>.Instance.CreateUI(mainCamera);
    }
}