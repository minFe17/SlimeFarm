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
        GenericSingleton<ObjectPool>.Instance.Init();
        GenericSingleton<CSVManager>.Instance.Init();
        GenericSingleton<GameManager>.Instance.Init();
        GenericSingleton<SlimeManager>.Instance.Init();
        GenericSingleton<PlantManager>.Instance.Init();
        GenericSingleton<NoticeManager>.Instance.Init();
        SetSound();
    }

    void Groundwork()
    {
        GenericSingleton<BorderManager>.Instance.CreateBoard(transform);
        GenericSingleton<RepositionManager>.Instance.CreateReposition(transform);
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
        GenericSingleton<SoundManager>.Instance.CreateSoundController();
        AudioClipManager audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        audioClipManager.PlayBGM();
    }
}