using UnityEngine;
using Utils;

public class NoticeManager : MonoBehaviour
{
    // 싱글턴
    NoticeUI _noticeUI;

    public void Init()
    {
        _noticeUI = GenericSingleton<UIManager>.Instance.NoticeUI;
    }

    public void SendMessage(ENoticeType noticeType)
    {
        string message = null;
        switch(noticeType)
        {
            case ENoticeType.Sell:
                message = "슬라임을 파시겠습니까?";
                break;
            case ENoticeType.NotJam:
                message = "잼이 부족합니다";
                break;
            case ENoticeType.NotGold:
                message = "골드가 부족합니다";
                break;
            case ENoticeType.NotMaxSlime:
                message = "슬라임이 너무 많습니다";
                break;
        }
        _noticeUI.ShowMessage(message);
    }

    public void HideMessage()
    {
        _noticeUI.HideMessage();
    }
}

public enum ENoticeType
{
    None,
    Sell,
    NotJam,
    NotGold,
    NotMaxSlime,
    Max,
}