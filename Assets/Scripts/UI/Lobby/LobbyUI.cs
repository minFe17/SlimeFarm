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

    void Start()
    {
        _slimeSprite = GenericSingleton<SpriteManager>.Instance.SlimeSprite;
        SetSlimeImage();
    }

    void SetSlimeImage()
    {
        _slimeImage.sprite = _slimeSprite.GetSprite("Normal");
        _bearSlimeImage.sprite = _slimeSprite.GetSprite("Bear");
    }

    public void GameStart()
    {
        GenericSingleton<UIManager>.Instance.ReleaseLobbyUI();
        SceneManager.LoadScene("IngameScene");
    }
}