public class SlimeState
{
    protected Slime _slime;

    public virtual void OnEnter(Slime slime)
    {
        _slime = slime;
    }

    public virtual void MainLoop() { }

    public virtual void OnExit() { }
}
