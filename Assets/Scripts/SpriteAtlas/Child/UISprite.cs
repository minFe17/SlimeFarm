using System.Threading.Tasks;
using UnityEngine.U2D;

public class UISprite : SpriteAtlasBase
{
    public override async Task<SpriteAtlas> GetSpriteAtlas()
    {
        _spriteLoader = new SpriteLoader();
        _loadCompletionSource = new TaskCompletionSource<SpriteAtlas>();
        await _spriteLoader.LoadSpriteAsync("UISprite", _loadCompletionSource);
        return await _loadCompletionSource.Task;
    }
}