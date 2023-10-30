using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Slime : MonoBehaviour
{
    [Header("Type")]
    [SerializeField] ESlimeType _slimeType;

    [Header("Price")]
    [SerializeField] int _price;

    SlimeState _state;
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    SlimeManager _slimeManager;
    UIManager _uiManaeger;
    GameManager _gameManager;
    BorderManager _borderManager;
    RepositionManager _repositionManager;

    int _level;
    int _maxLevel = 3;
    float _exp;
    float _needExp;
    float _pickTime;

    public ESlimeType SlimeType { get => _slimeType; }
    public Animator Animator { get => _animator; }
    public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
    public int Level { get => _level; }
    public float PickTime { set => _pickTime = value; }

    void Awake()
    {
        ChangeState(new IdleState());
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _uiManaeger = GenericSingleton<UIManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _borderManager = GenericSingleton<BorderManager>.Instance;
        _repositionManager = GenericSingleton<RepositionManager>.Instance;
        CheckLevel();
    }

    void Update()
    {
        StateMainLoop();
        EXPTimer();
    }

    void OnMouseDown()
    {
        if (!_uiManaeger.UI.IsOpenUI)
            ChangeState(new TouchState());
    }

    void OnMouseUp()
    {
        if (_state.State == EStateType.Pick)
        {
            if (_uiManaeger.SellUI.IsSell)
                Sell();
            else
                ChangeState(new IdleState());
        }
    }

    void OnMouseDrag()
    {
        if (!_uiManaeger.UI.IsOpenUI)
            PickTimer();
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

    void EXPTimer()
    {
        if (_level == _maxLevel)
            return;

        _exp += Time.deltaTime;
        if (_exp >= _needExp)
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

    void PickTimer()
    {
        _pickTime += Time.deltaTime;
        if (_pickTime >= 0.5f)
            ChangeState(new PickState());
    }

    void Sell()
    {
        _gameManager.AddGold(_level * _price);
        //슬라임 리스트에서 제거
        Destroy(this.gameObject);
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

public enum EStateType
{
    Idle,
    Walk,
    Turn,
    Touch,
    Pick,
    Max,
}