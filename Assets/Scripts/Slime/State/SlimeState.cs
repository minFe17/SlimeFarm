public class SlimeState
{
    protected Slime _slime;
    protected float _time;

    public virtual void OnEnter(Slime slime)
    {
        _slime = slime;
    }

    public virtual void MainLoop() { }

    public virtual void OnExit() { }

    protected virtual void CheckTime() { }
}