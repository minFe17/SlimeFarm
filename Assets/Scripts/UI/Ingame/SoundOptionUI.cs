using UnityEngine;
using UnityEngine.UI;
using Utils;

public class SoundOptionUI : MonoBehaviour
{
    [SerializeField] Slider _bgmSlider;
    [SerializeField] Slider _sfxSlider;

    SoundManager _soundManager;
    GameManager _gameManager;

    void Start()
    {
        _soundManager = GenericSingleton<SoundManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _bgmSlider.value = _soundManager.BgmSound;
        _sfxSlider.value = _soundManager.SFXSound;
    }

    public void ContollerBGMSlider()
    {
        _soundManager.BgmSound = _bgmSlider.value;
        _soundManager.ChangeBGMVolumn();
    }

    public void ControllerSFXSlider()
    {
        _soundManager.SFXSound = _sfxSlider.value;
        _soundManager.ChangeSFXVolumn();
    }

    public void SaveVolumeData()
    {
        _soundManager.SaveVolumeData();
    }

    public void ResumeGame()
    {
        _gameManager.ResumeGame();
    }

    public void ExitGame()
    {
        _gameManager.ExitGame();
    }
}