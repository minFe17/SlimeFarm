using UnityEngine;
using Utils;

public class NoticeManager : MonoBehaviour
{
    // 싱글턴
    NoticeUI _noticeUI;

    string _message;

    public void Init()
    {
        _noticeUI = GenericSingleton<UIManager>.Instance.NoticeUI;
    }

    public void SendMessage(ENoticeType noticeType)
    {
        switch(noticeType)
        {
            case ENoticeType.Sell:
                _message = "슬라임을 파시겠습니까?";
                break;
            case ENoticeType.NotJam:
                _message = "잼이 부족합니다";
                break;
            case ENoticeType.NotGold:
                _message = "골드가 부족합니다";
                break;
            case ENoticeType.NotMaxSlime:
                _message = "슬라임이 너무 많습니다";
                break;
        }
        _noticeUI.ShowMessage(_message);
    }

    public void HideMessage()
    {
        _noticeUI.HideMessage();
    }
}