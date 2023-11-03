using System.Collections.Generic;
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

    public AudioClip BGM { get => _bgm; }

    public void Init()
    {
        _soundManager = GenericSingleton<SoundManager>.Instance;
        _bgm = Resources.Load("Prefabs/AudioClip/BGM") as AudioClip;
        SetSFX();
    }

    void SetSFX()
    {
        for (int i = 0; i < (int)ESFXSoundType.Max; i++)
        {
            string audioSoundName = ((ESFXSoundType)i).ToString();
            AudioClip audioSound = Resources.Load($"Prefabs/AudioClip/SFX/{audioSoundName}") as AudioClip;
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