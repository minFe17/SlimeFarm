using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class AudioClipManager : MonoBehaviour
{
    // ╫л╠шео
    [Header("BGM")]
    AudioClip _bgm;

    [Header("SFX")]
    List<AudioClip> _sfxs = new List<AudioClip>();

    SoundManager _soundManager;
    AddressableManager _addressableManager;

    public AudioClip BGM { get => _bgm; }

    public async void Init()
    {
        _soundManager = GenericSingleton<SoundManager>.Instance;
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _bgm = await _addressableManager.GetAddressableAsset<AudioClip>("BGM"); 
        SetSFX();
    }

    async void SetSFX()
    {
        for (int i = 0; i < (int)ESFXSoundType.Max; i++)
        {
            string audioSoundName = ((ESFXSoundType)i).ToString();
            AudioClip audioSound = await _addressableManager.GetAddressableAsset<AudioClip>(audioSoundName);
            _sfxs.Add(audioSound);
        }
    }

    public void PlayBGM()
    {
        _soundManager.StartBGM(_bgm);
    }

    public void PlaySFXSound(ESFXSoundType audioType)
    {
        _soundManager.PlaySFX(_sfxs[(int)audioType]);
    }
}

public enum ESFXSoundType
{
    Button,
    Buy,
    Fail,
    GameStop,
    GameResume,
    Grow,
    Sell,
    Touch,
    Unlock,
    Max,
}