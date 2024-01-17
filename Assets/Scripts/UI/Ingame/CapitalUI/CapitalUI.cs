using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class CapitalUI : MonoBehaviour
{
    [SerializeField] List<Image> _panelImages;
    [SerializeField] List<Image> _borderImages;

    [Header("Jam")]
    [SerializeField] Image _jamIconImage;
    [SerializeField] Text _jamText;

    [Header("Gold")]
    [SerializeField] Image _goldIconImage;
    [SerializeField] Text _goldText;

    GameManager _gameManager;
    SpriteAtlas _uiSprite;

    float _uiJam;
    float _uiGold;

    void Start()
    {
        _gameManager = GenericSingleton<GameManager>.Instance;
        _uiSprite = GenericSingleton<SpriteManager>.Instance.UISprite;
        SetSprite();
    }

    void LateUpdate()
    {
        ShowJam();
        ShowGold();
    }

    void SetSprite()
    {
        for(int i=0; i<_panelImages.Count; i++)
        {
            _panelImages[i].sprite = _uiSprite.GetSprite("Panel");
            _borderImages[i].sprite = _uiSprite.GetSprite("Panel Border");
        }

        _jamIconImage.sprite = _uiSprite.GetSprite("Jam");
        _goldIconImage.sprite = _uiSprite.GetSprite("Gold");
    }

    public void ShowJam()
    {
        _uiJam = Mathf.SmoothStep(_uiJam, _gameManager.Jam, 0.5f);
        _jamText.text = string.Format("{0:n0}", (int)_uiJam);
    }

    public void ShowGold()
    {
        _uiGold = Mathf.SmoothStep(_uiGold, _gameManager.Gold, 0.5f);
        _goldText.text = string.Format("{0:n0}", (int)_uiGold);
    }
}