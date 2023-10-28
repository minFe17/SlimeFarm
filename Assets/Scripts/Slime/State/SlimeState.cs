public class SlimeState
{
    protected Slime _slime;
    protected EStateType _state;
    protected float _time;

    public EStateType State { get => _state; }

    public virtual void OnEnter(Slime slime)
    {
        _slime = slime;
    }

    public virtual void MainLoop() { }

    public virtual void OnExit() { }

    protected virtual void CheckTime() { }
}