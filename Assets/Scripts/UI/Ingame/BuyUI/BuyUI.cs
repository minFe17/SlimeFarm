using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using Utils;

public class BuyUI : MonoBehaviour
{
    [SerializeField] List<Image> _shadowImages = new List<Image>();
    [SerializeField] Image _panelImage;
    [SerializeField] Image _slimeImage;
    [SerializeField] Image _plantImage;

    SpriteAtlas _uiSprite;

    async void Awake()
    {
        _uiSprite = await GenericSingleton<SpriteManager>.Instance.GetUISprite();
        SetSprite();
    }

    void SetSprite()
    {
        _panelImage.sprite = _uiSprite.GetSprite("Panel");
        _slimeImage.sprite = _uiSprite.GetSprite("Slime");
        _plantImage.sprite = _uiSprite.GetSprite("Plant");

        for (int i = 0; i < _shadowImages.Count; i++)
            _shadowImages[i].sprite = _uiSprite.GetSprite("Shadow");
    }
}