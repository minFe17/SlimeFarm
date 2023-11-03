using UnityEngine;
using Utils;

public class NoticeManager : MonoBehaviour
{
    // �̱���
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
                message = "�������� �Ľðڽ��ϱ�?";
                break;
            case ENoticeType.NotJam:
                message = "���� �����մϴ�";
                break;
            case ENoticeType.NotGold:
                message = "��尡 �����մϴ�";
                break;
            case ENoticeType.NotMaxSlime:
                message = "�������� �ʹ� �����ϴ�";
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