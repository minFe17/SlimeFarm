using UnityEngine;
using Utils;

public class TouchState : SlimeState
{
    float _touchStateTime;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _state = EStateType.Touch;
        _slime.Animator.SetTrigger("doTouch");
        MakeJam();
        _slime.AddExp();
        _touchStateTime = Random.Range(2f, 4f);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _touchStateTime)
            _slime.ChangeState(new WalkState());
    }

    void MakeJam()
    {
        int makeJam = (int)_slime.SlimeType * _slime.Level;
        GenericSingleton<GameManager>.Instance.AddJam(makeJam);
    }
}