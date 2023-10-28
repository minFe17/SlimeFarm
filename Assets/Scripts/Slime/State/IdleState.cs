using UnityEngine;

public class IdleState : SlimeState
{
    float _IdleStateTime;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _IdleStateTime = Random.Range(3, 5);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _IdleStateTime)
            _slime.ChangeState(new WalkState());
    }
}