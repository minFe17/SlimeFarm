using UnityEngine;

public class WalkState : SlimeState
{
    float _speedX;
    float _speedY;
    float _walkStateTime = 2.5f;

    public override void OnEnter(ISlimeState slime)     // Walk 상태 진입
    {
        base.OnEnter(slime);
        _state = EStateType.Walk;
        _slime.Animator.SetBool("isWalk", true);
        SetWalkSpeed();
    }

    public override void MainLoop()
    {
        Move();
    }

    public override void OnExit()   // Walk 상태 끝
    {
        _slime.Animator.SetBool("isWalk", false);
    }

    protected override void CheckTime()
    {
        _time += Time.deltaTime;
        if (_time >= _walkStateTime)
            _slime.ChangeState(new IdleState());    // Idle 상태로 변경
    }

    void SetWalkSpeed()
    {
        _speedX = Random.Range(-0.8f, 0.8f);
        _speedY = Random.Range(-0.8f, 0.8f);
        if (_speedX < 0)
            _slime.SpriteRenderer.flipX = true;
        else
            _slime.SpriteRenderer.flipX = false;
    }

    void Move()
    {
        if (_slime.CheckBoard())
            _slime.ChangeState(new TurnState());    // Turn 상태로 변경
        else
            Walk();

        CheckTime();
    }

    void Walk()
    {
        float newX = _speedX * Time.deltaTime;
        float newY = _speedY * Time.deltaTime;
        _slime.Transform.Translate(newX, newY, newY);
    }
}