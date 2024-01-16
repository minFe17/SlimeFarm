using System.Threading.Tasks;
using UnityEngine.U2D;

public class SlimeSprite : SpriteAtlasBase
{
    public override async Task<SpriteAtlas> GetSpriteAtlas()
    {
        _spriteLoader = new SpriteLoader();
        _loadCompletionSource = new TaskCompletionSource<SpriteAtlas>();
        await _spriteLoader.LoadSpriteAsync("SlimeSprite", _loadCompletionSource);
        return await _loadCompletionSource.Task;
    }
}