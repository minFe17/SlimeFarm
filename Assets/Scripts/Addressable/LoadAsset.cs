using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class LoadAsset : MonoBehaviour
{
    // ╫л╠шео
    public async Task Init()
    {
        await LoadLobbyAsset();
        LoadGroundworkAsset();
        LoadSlimeAsset();
        LoadSoundAsset();
        ReadOnlyDataAsset();
    }

    async Task LoadLobbyAsset()
    {
        await GenericSingleton<SpriteManager>.Instance.Init();
        await GenericSingleton<BackgroundAsset>.Instance.Init();
        await GenericSingleton<CameraAsset>.Instance.Init();
        await GenericSingleton<UIManager>.Instance.Init();
    }

    void LoadGroundworkAsset()
    {
        GenericSingleton<BorderManager>.Instance.Init();
        GenericSingleton<RepositionManager>.Instance.Init();
    }

    void LoadSlimeAsset()
    {
        GenericSingleton<SlimeFactoryManager>.Instance.Init();
        GenericSingleton<SlimeManager>.Instance.LoadAnimatorControllerAsset();
    }

    void LoadSoundAsset()
    {
        GenericSingleton<SoundManager>.Instance.Init();
        GenericSingleton<AudioClipManager>.Instance.Init();
    }

    void ReadOnlyDataAsset()
    {
        GenericSingleton<CSVManager>.Instance.Init();
    }
}