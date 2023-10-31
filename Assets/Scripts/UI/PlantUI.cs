using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PlantUI : MonoBehaviour
{
    [Header("Max Slime")]
    [SerializeField] Text _maxSlimeText;
    [SerializeField] Text _maxSlimeLevelUpGold;
    [SerializeField] GameObject _maxSlimeButton;

    [Header("Jam Output")]
    [SerializeField] Text _jamOutputText;
    [SerializeField] Text _jamOutputLevelUpGold;
    [SerializeField] GameObject _jamOutputButton;

    PlantManager _plantManager;
    GameManager _gameManager;

    void Start()
    {
        _plantManager = GenericSingleton<PlantManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        MaxSlimeChange();
        JamOutputChange();
    }

    void MaxSlimeChange()
    {
        int level = _plantManager.MaxSlimeLevel;
        if (level - 1 == _plantManager.MaxSlimeDatas.Count)
        {
            _maxSlimeButton.SetActive(false);
            return;
        }

        MaxSlimeData maxSlimeData = _plantManager.MaxSlimeDatas[level];
        _maxSlimeText.text = $"슬라임 수용량 {maxSlimeData.MaxSlime}";
        _maxSlimeLevelUpGold.text = string.Format("{0:n0}", maxSlimeData.MaxSlimeGold);
    }

    void JamOutputChange()
    {
        int level = _plantManager.JamOutputLevel;
        if (level - 1 == _plantManager.JamOutputDatas.Count)
        {
            _jamOutputButton.SetActive(false);
            return;
        }

        JamOutputData jamOutputData = _plantManager.JamOutputDatas[level];
        _jamOutputText.text = $"잼 생산량 x {jamOutputData.JamOutput}";
        _jamOutputLevelUpGold.text = string.Format("{0:n0}", jamOutputData.JamOutputGold);
    }

    void PlayFallSound()
    {
        AudioClipManager audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        audioClipManager.PlaySFXSound(ESFXSoundType.Fall);
    }

    public void BuyMaxSlime()
    {
        int level = _plantManager.MaxSlimeLevel;
        int gold = _plantManager.MaxSlimeDatas[level].MaxSlimeGold;
        bool isBuy = _gameManager.UseGold(gold);
        if (isBuy)
        {
            _plantManager.LevelUp(EPlantType.MaxSlime);
            MaxSlimeChange();
        }
        else
            PlayFallSound();
    }

    public void BuyJamOutput()
    {
        int level = _plantManager.JamOutputLevel;
        int gold = _plantManager.JamOutputDatas[level].JamOutputGold;
        bool isBuy = _gameManager.UseGold(gold);
        if (isBuy)
        {
            _plantManager.LevelUp(EPlantType.JamOutPut);
            JamOutputChange();
        }
        else
            PlayFallSound();
    }
}