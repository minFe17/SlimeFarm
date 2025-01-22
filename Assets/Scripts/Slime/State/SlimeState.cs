public class SlimeState     // State 부모 클래스
{
    protected ISlimeState _slime;
    protected EStateType _state;
    protected float _time;

    public EStateType State { get => _state; }

    public virtual void OnEnter(ISlimeState slime)
    {
        _slime = slime;
    }

    public virtual void MainLoop() { }

    public virtual void OnExit() { }

    protected virtual void CheckTime() { }
}
