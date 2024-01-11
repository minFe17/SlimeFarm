using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] Image _slimeImage;
    [SerializeField] Image _bearSlimeImage;

    SpriteManager _spriteManager;

    void Start()
    {
        _spriteManager = GenericSingleton<SpriteManager>.Instance;
        SetSlimeImage();
    }

    void SetSlimeImage()
    {
        _slimeImage.sprite = _spriteManager.SlimeSprite.GetSprite("Normal");
        _bearSlimeImage.sprite = _spriteManager.SlimeSprite.GetSprite("Bear");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("IngameScene");
    }
}