using UnityEngine;
using UnityEngine.UI;
using Utils;

public class CapitalUI : MonoBehaviour
{
    [Header("Jam")]
    [SerializeField] Text _jamText;

    [Header("Gold")]
    [SerializeField] Text _goldText;

    GameManager _gameManager;

    float _uiJam;
    float _uiGold;

    void Start()
    {
        _gameManager = GenericSingleton<GameManager>.Instance;
    }

    void LateUpdate()
    {
        ShowJam();
        ShowGold();
    }

    public void ShowJam()
    {
        _uiJam = Mathf.SmoothStep(_uiJam, _gameManager.Jam, 0.5f);
        _jamText.text = string.Format("{0:n0}", (int)_uiJam);
    }

    public void ShowGold()
    {
        _uiGold = Mathf.SmoothStep(_uiGold, _gameManager.Gold, 0.5f);
        _goldText.text = string.Format("{0:n0}", (int)_uiGold);
    }
}