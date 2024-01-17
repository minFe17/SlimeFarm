using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class SoundManager : MonoBehaviour
{
    // ╫л╠шео
    CSVManager _csvManager;
    AddressableManager _addressableManager;
    GameObject _soundControllerPrefab;
    SoundController _soundController;

    int _index;
    float _bgmSound;
    float _sfxSound;

    public float BgmSound { get { return _bgmSound; } set { _bgmSound = value; } }
    public float SFXSound { get { return _sfxSound; } set { _sfxSound = value; } }

    public async void Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _soundControllerPrefab = await _addressableManager.GetAddressableAsset<GameObject>("SoundController");
    }

    public void CreateSoundController()
    {
        _index = 0;
        GameObject soundController = Instantiate(_soundControllerPrefab);
        _soundController = soundController.GetComponent<SoundController>();

        _csvManager = GenericSingleton<CSVManager>.Instance;
        _csvManager.ReadSoundData();

        ChangeBGMVolumn();
        ChangeSFXVolumn();
    }

    public void StartBGM(AudioClip audio)
    {
        _soundController.BGM.clip = audio;
        _soundController.BGM.Play();
    }

    public void StopBGM()
    {
        _soundController.BGM.Stop();
    }

    public void PlaySFX(AudioClip audio)
    {
        _soundController.SFX[_index].clip = audio;
        _soundController.SFX[_index].Play();
        _index++;
        if (_index == _soundController.SFX.Count)
            _index = 0;
    }

    public void ChangeBGMVolumn()
    {
        _soundController.BGM.volume = _bgmSound;
    }

    public void ChangeSFXVolumn()
    {
        for (int i = 0; i < _soundController.SFX.Count; i++)
            _soundController.SFX[i].volume = _sfxSound;
    }

    public void SaveVolumeData()
    {
        _csvManager.WriteSoundData();
    }
}