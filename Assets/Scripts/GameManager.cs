using System.Collections;
using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    // ╫л╠шео
    SlimeManager _slimeManager;
    UIManager _uiManager;
    CSVManager _csvManager;
    AudioClipManager _audioClipManager;

    int _jam;
    int _gold;
    int _maxJam;
    int _maxGold;
    float _jamCreateDelay = 3f;

    bool _isStopGame;

    public int Jam { get => _jam; set => _jam = value; }
    public int Gold { get => _gold; set => _gold = value; }

    public void Init()
    {
        _csvManager = GenericSingleton<CSVManager>.Instance;
        _csvManager.ReadGameData();
        _uiManager = GenericSingleton<UIManager>.Instance;
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        _maxJam = 999999999;
        _maxGold = 999999999;
        StartCoroutine(AutoRoutine());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CheckStopGame();
    }

    void CheckStopGame()
    {
        if (!_isStopGame && !_uiManager.UI.IsOpenUI)
            StopGame();
        else
            ResumeGame();
    }

    void StopGame()
    {
        _uiManager.UI.ShowOption();
        _isStopGame = true;
        Time.timeScale = 0f;
        _audioClipManager.PlaySFXSound(ESFXSoundType.GameStop);
    }

    void AutoCreateJam()
    {
        int count = _slimeManager.Slimes.Count;
        for (int i = 0; i < count; i++)
            _slimeManager.Slimes[i].MakeJam();
    }

    void SaveData()
    {
        _csvManager.WriteData();
    }

    void Exit()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        _uiManager.UI.HideOption();
        _isStopGame = false;
        Time.timeScale = 1f;
        _audioClipManager.PlaySFXSound(ESFXSoundType.GameResume);
    }

    public void AddJam(int jamAmount)
    {
        _jam += jamAmount;
        if (_jam >= _maxJam)
            _jam = _maxJam;
    }

    public void AddGold(int goldAmount)
    {
        _gold += goldAmount;
        if (_gold >= _maxGold)
            _gold = _maxGold;
    }

    public bool UseJam(int jam)
    {
        if (_jam - jam < 0)
            return false;
        else
        {
            _jam -= jam;
            return true;
        }
    }

    public bool UseGold(int gold)
    {
        if (_gold - gold < 0)
            return false;
        else
        {
            _gold -= gold;
            return true;
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        _audioClipManager.PlaySFXSound(ESFXSoundType.GameResume);
        SaveData();
        Invoke("Exit", 0.5f);
    }

    IEnumerator AutoRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_jamCreateDelay);
            AutoCreateJam();
            SaveData();
        }
    }
}
