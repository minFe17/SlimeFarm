using UnityEngine;

public class WalkState : SlimeState
{
    float _speedX;
    float _speedY;
    float _turnSpeed = 0.3f;
    float _time;
    float _walkTime = 2.5f;

    public override void OnEnter(Slime slime)
    {
        base.OnEnter(slime);
        _slime.Animator.SetBool("isWalk", true);
        SetWalkSpeed();
    }

    public override void MainLoop()
    {
        Walk();
    }

    public override void OnExit()
    {
        _slime.Animator.SetBool("isWalk", false);
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

    void Walk()
    {
        float newX = _speedX * Time.deltaTime;
        float newY = _speedY * Time.deltaTime;

        _slime.transform.Translate(newX, newY, newY);
        if (_slime.CheckBoard())
            Turn();
        CheckWalkTime();
    }

    void Turn()
    {
        Vector3 targetPos = (_slime.transform.position - _slime.Reposition()).normalized;
        _slime.transform.Translate(targetPos * _turnSpeed * Time.deltaTime);
    }

    void CheckWalkTime()
    {
        _time += Time.deltaTime;
        if (_time >= _walkTime)
            _slime.ChangeState(new IdleState());
    }
}
