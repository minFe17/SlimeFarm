using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UIElements;
using Utils;

public class SpriteManager : MonoBehaviour
{
    // ╫л╠шео
    AddressableManager _addressableManager;
    SpriteAtlas _slimeSprite;
    SpriteAtlas _uiSprite;
    SpriteAtlas _backgroundSprite;

    public SpriteAtlas SlimeSprite { get => _slimeSprite; }
    public SpriteAtlas UISprite { get => _uiSprite; }
    public SpriteAtlas BackgroundSprite { get => _backgroundSprite; }

    public async Task Init()
    {
        _slimeSprite = await LoadAsset("SlimeSprite");
        _uiSprite = await LoadAsset("UISprite");
        _backgroundSprite = await LoadAsset("BackgroundSprite");
    }

    async Task<SpriteAtlas> LoadAsset(string address)
    {
        if (_addressableManager == null)
            _addressableManager = GenericSingleton<AddressableManager>.Instance;
        return await _addressableManager.GetAddressableAsset<SpriteAtlas>(address);
    }
}