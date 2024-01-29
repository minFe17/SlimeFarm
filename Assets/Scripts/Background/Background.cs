using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Utils;

public class Background : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] SpriteRenderer _room;
    [SerializeField] SpriteRenderer _sky;
    [SerializeField] SpriteRenderer _shin;

    [Header("Cloud")]
    [SerializeField] List<SpriteRenderer> _clouds;

    SpriteAtlas _backgroundSprite;

    void Awake()
    {
        _backgroundSprite = GenericSingleton<SpriteManager>.Instance.BackgroundSprite;
        SettingBackground();
    }

    void SettingBackground()
    {
        _room.sprite = _backgroundSprite.GetSprite("Room");
        _sky.sprite = _backgroundSprite.GetSprite("Sky");
        _shin.sprite = _backgroundSprite.GetSprite("Shin");
        SettingCloud();
    }

    void SettingCloud()
    {
        for (int i = 0; i < _clouds.Count; i++)
        {
            ECloudType cloud = (ECloudType)i;
            _clouds[i].sprite = _backgroundSprite.GetSprite(cloud.ToString());
        }
    }
}

enum ECloudType
{
    CloudA,
    CloudB,
    Max,
}