using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Slime : MonoBehaviour
{
    [Header("Slime Type")]
    [SerializeField] ESlimeType _slimeType;

    SlimeState _state;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    SlimeManager _slimeManager;
    BorderManager _borderManager;
    RepositionManager _repositionManager;

    int _level;
    int _maxLevel = 3;
    float _exp;
    float _needExp;

    public ESlimeType SlimeType { get => _slimeType; }
    public int Level { get => _level; }
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
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        CheckLevel();
    }

    void Update()
    {
        StateMainLoop();
        EXPTime();
    }

    void OnMouseDown()
    {
        ChangeState(new TouchState());
    }

    void StateMainLoop()
    {
        if (_state != null)
            _state.MainLoop();
    }

    void CheckLevel()
    {
        // csv파일 읽기 (슬라임 레벨)
        // 파일이 없으면 레벨 1
        _level = 1;
        _needExp = _level * 100; 
        ChangeLevelAnimator();
    }

    void EXPTime()
    {
        if (_level == _maxLevel)
            return;

        _exp += Time.deltaTime;
        if(_exp >= _needExp)
            LevelUp();
    }

    void LevelUp()
    {
        _level++;
        _needExp = _level * 100;
        ChangeLevelAnimator();
    }

    void ChangeLevelAnimator()
    {
        _animator.runtimeAnimatorController = _slimeManager.LevelAnimatorControllers[_level - 1];
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

    public void AddExp()
    {
        if (_level == _maxLevel)
            return;

        _exp++;
        if (_exp >= _needExp)
            LevelUp();
    }
}