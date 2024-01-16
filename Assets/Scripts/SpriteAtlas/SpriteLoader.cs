using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using Utils;

public class SpriteLoader : MonoBehaviour
{
    AddressableManager _addressableManager;

    public Task<SpriteAtlas> LoadSpriteAsync(string address, TaskCompletionSource<SpriteAtlas> completionSource)
    {
        if (_addressableManager == null)
            _addressableManager = GenericSingleton<AddressableManager>.Instance;
        Action<SpriteAtlas> callback = spriteAtlas => { completionSource.SetResult(spriteAtlas); };
        _addressableManager.LoadAsset<SpriteAtlas>(address, callback);

        return completionSource.Task;
    }
}