using UnityEngine;

public interface ISlimeState
{
    Transform Transform { get; }
    Animator Animator { get; }
    SpriteRenderer SpriteRenderer { get; }

    void ChangeState(SlimeState state);
    void LoopState();
    bool CheckBoard();
}