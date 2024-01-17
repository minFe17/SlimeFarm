using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class LoadAsset : MonoBehaviour
{
    // �̱���

    public async Task Init()
    {
        await GenericSingleton<SpriteManager>.Instance.Init();
        await GenericSingleton<BackgroundAsset>.Instance.Init();
        await GenericSingleton<CameraAsset>.Instance.Init();
        await GenericSingleton<UIManager>.Instance.Init();
    }
}
