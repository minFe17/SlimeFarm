using UnityEngine;
using Utils;

public class PickState : SlimeState
{
    NoticeManager _noticeManager;
    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _state = EStateType.Pick;
        _noticeManager = GenericSingleton<NoticeManager>.Instance;
    }

    public override void MainLoop()
    {
        PickPoint();
    }

    public override void OnExit()
    {
        if (_slime.CheckBoard())
        {
            RepositionManager repositionManager = GenericSingleton<RepositionManager>.Instance;
            _slime.transform.position = repositionManager.Reposition();
        }
    }

    void PickPoint()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = worldPos.y;
        _slime.transform.position = worldPos;

        UIManager uiManager = GenericSingleton<UIManager>.Instance;
        if (uiManager.SellUI.IsSell)
            _noticeManager.SendMessage(ENoticeType.Sell);
        else
            _noticeManager.HideMessage();
    }
}