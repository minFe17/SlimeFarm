using UnityEngine;

public class IdleState : SlimeState
{
    float _time;
    float _maxTime;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _maxTime = Random.Range(3, 5);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _maxTime)
            _slime.ChangeState(new WalkState());
    }
}