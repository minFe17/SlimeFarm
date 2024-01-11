using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Background : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] SpriteRenderer _room;
    [SerializeField] SpriteRenderer _sky;
    [SerializeField] SpriteRenderer _shin;

    [Header("Cloud")]
    [SerializeField] List<SpriteRenderer> _clouds = new List<SpriteRenderer>();

    SpriteManager _spriteManager;

    void Start()
    {
        _spriteManager = GenericSingleton<SpriteManager>.Instance;
        SettingBackground();
    }

    void SettingBackground()
    {
        _room.sprite = _spriteManager.BackgroundSprite.GetSprite("Room");
        _sky.sprite = _spriteManager.BackgroundSprite.GetSprite("Sky");
        _shin.sprite = _spriteManager.BackgroundSprite.GetSprite("Shin");
        SettingCloud();
    }

    void SettingCloud()
    {
        for (int i = 0; i < _clouds.Count; i++)
        {
            ECloudType cloud = (ECloudType)i;
            _clouds[i].sprite = _spriteManager.BackgroundSprite.GetSprite(cloud.ToString());
        }    
    }
}

enum ECloudType
{
    CloudA,
    CloudB,
    Max,
}