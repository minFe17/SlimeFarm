using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.U2D;

public abstract class SpriteAtlasBase : MonoBehaviour
{
    protected TaskCompletionSource<SpriteAtlas> _loadCompletionSource;
    protected SpriteLoader _spriteLoader;

    public abstract Task<SpriteAtlas> GetSpriteAtlas();
}
