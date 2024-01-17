using UnityEngine;
using Utils;

public class GameGroundwork : MonoBehaviour
{
    void Start()
    {
        Init();
    }

    void Init()
    {
        Groundwork();
        GenericSingleton<CSVManager>.Instance.Init();
        GenericSingleton<GameManager>.Instance.Init();
        GenericSingleton<SlimeManager>.Instance.Init();
        GenericSingleton<PlantManager>.Instance.Init();
        GenericSingleton<NoticeManager>.Instance.Init();
        SetSound();
    }

    void Groundwork()
    {
        GenericSingleton<SlimeFactoryManager>.Instance.Init();
        GenericSingleton<BorderManager>.Instance.CreateBoard(transform);
        GenericSingleton<RepositionManager>.Instance.Init(transform);
        CreateBackground();
        CreateCamera();
    }

    void CreateBackground()
    {
        BackgroundAsset backgroundAsset = GenericSingleton<BackgroundAsset>.Instance;
        backgroundAsset.CreateBackground(transform);
    }

    void CreateCamera()
    {
        CameraAsset cameraAsset = GenericSingleton<CameraAsset>.Instance;
        Camera camera = cameraAsset.CreateCamera(transform);
        GenericSingleton<UIManager>.Instance.CreateUI(camera);
    }

    void SetSound()
    {
        GenericSingleton<SoundManager>.Instance.Init();
        AudioClipManager audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        audioClipManager.PlayBGM();
    }
}