using UnityEngine;

public class TurnState : SlimeState
{
    Vector3 _reposition;

    float _turnSpeed = 0.3f;
    float _turnStateTime = 3f;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _state = EStateType.Turn;
        _slime.Animator.SetBool("isWalk", true);
        _reposition = _slime.Reposition();
    }

    public override void MainLoop()
    {
        Turn();
    }

    public override void OnExit()
    {
        _slime.Animator.SetBool("isWalk", false);
    }

    void Turn()
    {
        Vector3 targetPos = (_reposition - _slime.transform.position).normalized;
        _slime.transform.Translate(targetPos * _turnSpeed * Time.deltaTime);
        if (_slime.transform.position == _reposition)
            _slime.ChangeState(new IdleState());

        if (targetPos.x < 0)
            _slime.SpriteRenderer.flipX = true;
        else
            _slime.SpriteRenderer.flipX = false;

        CheckTime();
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _turnStateTime)
            _slime.ChangeState(new IdleState());
    }
}