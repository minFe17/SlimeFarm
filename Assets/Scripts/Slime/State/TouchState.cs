using UnityEngine;
using Utils;

public class TouchState : SlimeState
{
    float _touchStateTime;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _slime.Animator.SetTrigger("doTouch");
        int makeJam = (int)_slime.SlimeType * _slime.Level;
        GenericSingleton<GameManager>.Instance.AddJam(makeJam);
        _slime.AddExp();
        _touchStateTime = Random.Range(2f, 4f);
    }

    public override void MainLoop()
    {
        CheckTime();
    }

    public override void OnExit()
    {
        
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _touchStateTime)
            _slime.ChangeState(new WalkState());
    }
}