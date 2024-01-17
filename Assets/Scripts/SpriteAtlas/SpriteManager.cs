using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;
using Utils;

public class SpriteManager : MonoBehaviour
{
    // ╫л╠шео
    AddressableManager _addreesableManager;
    SpriteAtlas _backgroundSprite;
    SpriteAtlas _slimeSprite;
    SpriteAtlas _uiSprite;


    public async Task<SpriteAtlas> GetSlimeSprite()
    {
        if (_slimeSprite == null)
        {
            if (_addreesableManager == null)
                _addreesableManager = GenericSingleton<AddressableManager>.Instance;
            _slimeSprite = await _addreesableManager.GetAddressableAsset<SpriteAtlas>("SlimeSprite");
        }
        return _slimeSprite;
    }

    public async Task<SpriteAtlas> GetUISprite()
    {
        if (_uiSprite == null)
        {
            if (_addreesableManager == null)
                _addreesableManager = GenericSingleton<AddressableManager>.Instance;
            _uiSprite = await _addreesableManager.GetAddressableAsset<SpriteAtlas>("UISprites");
        }
        return _uiSprite;
    }

    public async Task<SpriteAtlas> GetBackgroundSprite()
    {
        if (_backgroundSprite == null)
        {
            if (_addreesableManager == null)
                _addreesableManager = GenericSingleton<AddressableManager>.Instance;
            _backgroundSprite = await _addreesableManager.GetAddressableAsset<SpriteAtlas>("BackgroundSprite");
        }
        return _backgroundSprite;
    }
}