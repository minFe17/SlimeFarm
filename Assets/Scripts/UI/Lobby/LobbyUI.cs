using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] Image _slimeImage;
    [SerializeField] Image _bearSlimeImage;

    SpriteAtlas _slimeSprite;

    async void Start()
    {
        _slimeSprite = await GenericSingleton<SpriteManager>.Instance.GetSlimeSprite();
        SetSlimeImage();
    }

    void SetSlimeImage()
    {
        _slimeImage.sprite = _slimeSprite.GetSprite("Normal");
        _bearSlimeImage.sprite = _slimeSprite.GetSprite("Bear");
    }

    public void GameStart()
    {
        SceneManager.LoadScene("IngameScene");
    }
}