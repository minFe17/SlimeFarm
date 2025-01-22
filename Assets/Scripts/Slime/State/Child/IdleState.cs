using UnityEngine;

public class IdleState : SlimeState     // Idle 상태
{
    float _idleStateTime;

    public override void OnEnter(ISlimeState slime)     // Idle 상태 진입
    {
        base.OnEnter(slime);
        _state = EStateType.Idle;
        _idleStateTime = Random.Range(3, 5);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _idleStateTime)
            _slime.ChangeState(new WalkState());    // Walk 상태로 변경
    }
}