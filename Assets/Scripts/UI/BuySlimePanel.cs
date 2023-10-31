using UnityEngine;
using UnityEngine.UI;
using Utils;

public class BuySlimePanel : MonoBehaviour
{
    [Header("Page")]
    [SerializeField] Text _pageText;

    [Header("UnLock Panel")]
    [SerializeField] Image _slimeImage;
    [SerializeField] Text _slimeName;
    [SerializeField] Text _slimeGold;

    [Header("Lock Panel")]
    [SerializeField] GameObject _lockPanel;
    [SerializeField] Image _lockSlimeImage;
    [SerializeField] Text _lockSlimeJam;

    SlimeManager _slimeManager;
    GameManager _gameManager;

    int _page;

    void Start()
    {
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
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
        _lockSlimeImage.sprite = slimeData.Sprite;
        _lockSlimeImage.SetNativeSize();
        _lockSlimeJam.text = string.Format("{0:n0}", slimeData.Jam);
    }

    void UnlockSlime(SlimeData slimeData)
    {
        _lockPanel.SetActive(false);
        _slimeImage.sprite = slimeData.Sprite;
        _slimeImage.SetNativeSize();
        _slimeName.text = slimeData.Name;
        _slimeGold.text = string.Format("{0:n0}", slimeData.Gold);
    }

    public void MoveLeftPage()
    {
        if (_page == 0)
            return;
        _page--;
        Change();
    }

    public void MoveRightPage()
    {
        if (_page == _slimeManager.SlimeDatas.Count - 1)
            return;
        _page++;
        Change();
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
    }

    public void BuySlime()
    {
        SlimeData slimeData = _slimeManager.SlimeDatas[_page];
        bool isBuy = _gameManager.UseGold(slimeData.Gold);
        if (isBuy)
        {
            _slimeManager.CreateSlime(_page);
            Change();
        }
    }
}