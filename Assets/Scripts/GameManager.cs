using System.Collections;
using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    // 싱글턴
    SlimeManager _slimeManager;
    UIManager _uiManager;
    int _jam;
    int _gold;
    int _maxJam;
    int _maxGold;
    float _jamCreateDelay = 3f;

    bool _isStopGame;

    public int Jam { get => _jam; }
    public int Gold { get => _gold; }

    public void Init()
    {
        // csv 파일 읽고 jam, gold 값 있으면 불러오기
        // 없으면 초기값
        _jam = 100;
        _gold = 200;
        _maxJam = 999999999;
        _maxGold = 999999999;
        if (_uiManager == null)
            _uiManager = GenericSingleton<UIManager>.Instance;
        if (_slimeManager == null)
            _slimeManager = GenericSingleton<SlimeManager>.Instance;
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
    }

    void ResumeGame()
    {
        _uiManager.UI.HideOption();
        _isStopGame = false;
        Time.timeScale = 1f;
    }

    void AutoCreateJam()
    {
        int count = _slimeManager.Slimes.Count;
        for (int i = 0; i < count; i++)
            _slimeManager.Slimes[i].MakeJam();
    }

    void AutoSave()
    {
        //파일쓰기
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

    IEnumerator AutoRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_jamCreateDelay);
            AutoCreateJam();
            AutoSave();
        }
    }
}
