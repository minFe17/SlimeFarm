using UnityEngine;
using UnityEngine.UI;
using Utils;

public class BuySlimeUI : MonoBehaviour
{
    [Header("Page")]
    [SerializeField] Text _pageText;

    [Header("Unlock Panel")]
    [SerializeField] Image _slimeImage;
    [SerializeField] Text _slimeName;
    [SerializeField] Text _slimeGold;

    [Header("Lock Panel")]
    [SerializeField] GameObject _lockPanel;
    [SerializeField] Image _lockSlimeImage;
    [SerializeField] Text _lockSlimeJam;

    SlimeManager _slimeManager;
    GameManager _gameManager;
    AudioClipManager _audioClipManager;
    NoticeManager _noticeManager;
    SpriteManager _spriteManager;
    
    int _page;

    void Start()
    {
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
        _noticeManager = GenericSingleton<NoticeManager>.Instance;
        _spriteManager = GenericSingleton<SpriteManager>.Instance;
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
        ChangeSlimeImage(slimeData, _lockSlimeImage);
        _lockSlimeJam.text = string.Format("{0:n0}", slimeData.Jam);
    }

    void UnlockSlime(SlimeData slimeData)
    {
        _lockPanel.SetActive(false);
        ChangeSlimeImage(slimeData, _slimeImage);
        _slimeName.text = slimeData.Name;
        _slimeGold.text = string.Format("{0:n0}", slimeData.Gold);
    }

    void ChangeSlimeImage(SlimeData slimeData, Image slimeImage)
    {
        ESlimeType slimeType = (ESlimeType)slimeData.Index-1;
        slimeImage.sprite = _spriteManager.SlimeSprite.GetSprite(slimeType.ToString());
        slimeImage.SetNativeSize();
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