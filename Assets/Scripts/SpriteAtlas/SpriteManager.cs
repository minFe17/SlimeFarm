using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

public class SpriteManager : MonoBehaviour
{
    // ╫л╠шео
    SpriteAtlasBase _spriteAtlasBase;
    SpriteAtlas _backgroundSprite;
    SpriteAtlas _slimeSprite;
    SpriteAtlas _uiSprite;

    public async Task<SpriteAtlas> GetSlimeSprite()
    {
        if (_slimeSprite == null)
        {
            _spriteAtlasBase = new SlimeSprite();
            _slimeSprite = await _spriteAtlasBase.GetSpriteAtlas();
        }
        return _slimeSprite;
    }

    public async Task<SpriteAtlas> GetUISprite()
    {
        if (_uiSprite == null)
        {
            _spriteAtlasBase = new UISprite();
            _uiSprite = await _spriteAtlasBase.GetSpriteAtlas();
        }
        return _uiSprite;
    }

    public async Task<SpriteAtlas> GetBackgroundSprite()
    {
        if (_backgroundSprite == null)
        {
            _spriteAtlasBase = new BackgroundSprite();
            _backgroundSprite = await _spriteAtlasBase.GetSpriteAtlas();
        }
        return _backgroundSprite;
    }
}