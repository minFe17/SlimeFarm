using UnityEngine;
using UnityEngine.U2D;

public class SpriteManager : MonoBehaviour
{
    // ╫л╠шео
    SpriteAtlas _slimeSprite;
    SpriteAtlas _uiSprite;
    SpriteAtlas _backgroundSprite;

    public SpriteAtlas SlimeSprite
    {
        get
        {
            if(_slimeSprite == null)
                _slimeSprite = Resources.Load("Prefabs/Sprite/SlimeSprite") as SpriteAtlas;
            return _slimeSprite;
        }
    }

    public SpriteAtlas UISprite
    {
        get
        {
            if (_uiSprite == null)
                _uiSprite = Resources.Load("Prefabs/Sprite/UISprite") as SpriteAtlas;
            return _uiSprite;
        }
    }

    public SpriteAtlas BackgroundSprite
    {
        get
        {
            if (_backgroundSprite == null)
                _backgroundSprite = Resources.Load("Prefabs/Sprite/BackgroundSprite") as SpriteAtlas;
            return _backgroundSprite;
        }
    }
}
