using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using Utils;

public class SpriteManager : MonoBehaviour
{
    // ╫л╠шео
    AddressableManager _addreesableManager;
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
        if (_addreesableManager == null)
            _addreesableManager = GenericSingleton<AddressableManager>.Instance;
        return await _addreesableManager.GetAddressableAsset<SpriteAtlas>(address);
    }
}