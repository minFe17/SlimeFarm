using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class OptionSprite : MonoBehaviour
{
    [SerializeField] Image _panelImage;
    [SerializeField] List<Image> _sliderBackgrounds;
    [SerializeField] List<Image> _fillImages;
    [SerializeField] List<Image> _handleImages;
    [SerializeField] List<Image> _buttonImages;

    SpriteAtlas _uiSprite;

    void Start()
    {
        _uiSprite = GenericSingleton<SpriteManager>.Instance.UISprite;
        SetSprite();
    }

    private void SetSprite()
    {
        _panelImage.sprite = _uiSprite.GetSprite("Panel");
        for (int i = 0; i < _sliderBackgrounds.Count; i++)
        {
            _sliderBackgrounds[i].sprite = _uiSprite.GetSprite("Panel");
            _fillImages[i].sprite = _uiSprite.GetSprite("Panel");
            _handleImages[i].sprite = _uiSprite.GetSprite("Panel");
        }

        for (int i = 0; i < _buttonImages.Count; i++)
            _buttonImages[i].sprite = _uiSprite.GetSprite("Panel");
    }
}