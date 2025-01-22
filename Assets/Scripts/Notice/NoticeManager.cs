using UnityEngine;
using Utils;

public class NoticeManager : MonoBehaviour
{
    // �̱���
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
                _message = "�������� �Ľðڽ��ϱ�?";
                break;
            case ENoticeType.NotJam:
                _message = "���� �����մϴ�";
                break;
            case ENoticeType.NotGold:
                _message = "��尡 �����մϴ�";
                break;
            case ENoticeType.NotMaxSlime:
                _message = "�������� �ʹ� �����ϴ�";
                break;
        }
        _noticeUI.ShowMessage(_message);
    }

    public void HideMessage()
    {
        _noticeUI.HideMessage();
    }
}