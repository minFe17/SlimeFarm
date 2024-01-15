using UnityEngine;
using UnityEngine.UI;
using Utils;

public class BuySlimeUI : MonoBehaviour
{
    [SerializeField] BuySlimeSprite _buySlimeSprite;

    [Header("Page")]
    [SerializeField] Text _pageText;

    [Header("Unlock Panel")]
    [SerializeField] Text _slimeName;
    [SerializeField] Text _slimeGold;

    [Header("Lock Panel")]
    [SerializeField] GameObject _lockPanel;
    [SerializeField] Text _lockSlimeJam;

    SlimeManager _slimeManager;
    GameManager _gameManager;
    AudioClipManager _audioClipManager;
    NoticeManager _noticeManager;
    
    int _page;

    void Start()
    {
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        _noticeManager = GenericSingleton<NoticeManager>.Instance;
        Change();
    }

    void Change()
    {
        SlimeData slimeData = _slimeManager.SlimeDatas[_page];
        _pageText.text = string.Format("#{0:00}", slimeData.Index);

        if (_slimeManager.SlimeUnlocks[_page])
            UnlockSlime(slimeData);
        else
            LockSlime(slimeData);

    }

    void LockSlime(SlimeData slimeData)
    {
        _lockPanel.SetActive(true);
        _buySlimeSprite.ChangeSlimeImage(slimeData, ELockType.Lock);
        _lockSlimeJam.text = string.Format("{0:n0}", slimeData.Jam);
    }

    void UnlockSlime(SlimeData slimeData)
    {
        _lockPanel.SetActive(false);
        _buySlimeSprite.ChangeSlimeImage(slimeData, ELockType.Unlock);
        _slimeName.text = slimeData.Name;
        _slimeGold.text = string.Format("{0:n0}", slimeData.Gold);
    }

    public void MoveLeftPage()
    {
        if (_page == 0)
            return;
        _page--;
        Change();
        _audioClipManager.PlaySFXSound(ESFXSoundType.Button);
    }

    public void MoveRightPage()
    {
        if (_page == _slimeManager.SlimeDatas.Count - 1)
            return;
        _page++;
        Change();
        _audioClipManager.PlaySFXSound(ESFXSoundType.Button);
    }

    public void UnlockingSlime()
    {
        SlimeData slimeData = _slimeManager.SlimeDatas[_page];
        bool isUnlock = _gameManager.UseJam(slimeData.Jam);
        if (isUnlock)
        {
            _slimeManager.UnlockSlime(_page);
            Change();
        }
        else
        {
            _audioClipManager.PlaySFXSound(ESFXSoundType.Fail);
            _noticeManager.SendMessage(ENoticeType.NotJam);
        }
    }

    public void BuySlime()
    {
        SlimeData slimeData = _slimeManager.SlimeDatas[_page];
        bool isMaxSlime = _slimeManager.CalculteMaxSlime();
        if (!isMaxSlime)
        {
            bool isBuy = _gameManager.UseGold(slimeData.Gold);
            if (isBuy)
                _slimeManager.CreateSlime((ESlimeType)_page);
            else
            {
                _audioClipManager.PlaySFXSound(ESFXSoundType.Fail);
                _noticeManager.SendMessage(ENoticeType.NotGold);
            }
        }
        else
        {
            _audioClipManager.PlaySFXSound(ESFXSoundType.Fail);
            _noticeManager.SendMessage(ENoticeType.NotMaxSlime);
        }
    }
}

public enum ELockType
{
    Unlock,
    Lock,
}