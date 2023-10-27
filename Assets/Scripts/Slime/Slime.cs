using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Slime : MonoBehaviour
{
    SlimeState _state;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    BorderManager _borderManager;
    RepositionManager _repositionManager;


    public Animator Animator { get => _animator; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }

    void Awake()
    {
        ChangeState(new IdleState());
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _borderManager = GenericSingleton<BorderManager>.Instance;
        _repositionManager = GenericSingleton<RepositionManager>.Instance;
    }

    void Update()
    {
        StateMainLoop();
    }

    void StateMainLoop()
    {
        if (_state != null)
            _state.MainLoop();
    }

    public void ChangeState(SlimeState state)
    {
        if (_state != null)
            _state.OnExit();

        _state = state;
        if (_state != null)
            _state.OnEnter(this);
    }

    public bool CheckBoard()
    {
        Vector2 topRightBorder = _borderManager.TopRightPos;
        Vector2 bottomLeftBorder = _borderManager.BottomLeftPos;

        if (transform.position.x < bottomLeftBorder.x || transform.position.x > topRightBorder.x)
            return true;
        if (transform.position.y < bottomLeftBorder.y || transform.position.y > topRightBorder.y)
            return true;

        return false;
    }

    public Vector3 Reposition()
    {
        List<Vector3> repositions = _repositionManager.Repositions;
        int positionIndex = Random.Range(0, repositions.Count);
        return repositions[positionIndex];
    }
}