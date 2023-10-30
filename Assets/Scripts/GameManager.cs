using UnityEngine;
using Utils;

public class GameManager : MonoBehaviour
{
    // �̱���
    UIManager _uiManager;
    int _jam;
    int _gold;
    int _maxJam;
    int _maxGold;

    bool _isStopGame;

    public int Jam { get => _jam; }
    public int Gold { get => _gold; }

    public void Init()
    {
        // csv ���� �а� jam, gold �� ������ �ҷ�����
        // ������ �ʱⰪ
        _jam = 100;
        _gold = 200;
        _maxJam = 999999999;
        _maxGold = 999999999;
        if (_uiManager == null)
            _uiManager = GenericSingleton<UIManager>.Instance;
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
}
