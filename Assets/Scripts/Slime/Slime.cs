using UnityEngine;
using Utils;

public class Slime : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] protected SpriteRenderer _slimeSprite;
    [SerializeField] protected SpriteRenderer _shadowSprite;

    protected ESlimeType _slimeType;
    protected SpriteManager _spriteManager;

    SlimeState _state;
    Animator _animator;

    SlimeManager _slimeManager;
    UIManager _uiManager;
    GameManager _gameManager;
    BorderManager _borderManager;
    AudioClipManager _audioClipManager;

    int _level;
    int _maxLevel = 3;
    float _exp;
    float _needExp;
    float _pickTime;
    bool _isSaveSlime;

    public ESlimeType SlimeType { get => _slimeType; }
    public Animator Animator { get => _animator; }
    public SpriteRenderer SlimeSpriteRenderer { get => _slimeSprite; }
    public int Level { get => _level; set => _level = value; }
    public float EXP { get => _exp; set => _exp = value; }
    public float PickTime { set => _pickTime = value; }
    public bool IsSaveSlime { set => _isSaveSlime = value; }

    protected virtual void Awake()
    {
        ChangeState(new IdleState());
        _spriteManager = GenericSingleton<SpriteManager>.Instance;
    }

    public void Init()
    {
        _animator = GetComponent<Animator>();
        SetManager();
        CheckLevel();
    }

    void Update()
    {
        StateMainLoop();
        EXPTimer();
    }

    void SetManager()
    {
        _slimeManager = GenericSingleton<SlimeManager>.Instance;
        _uiManager = GenericSingleton<UIManager>.Instance;
        _gameManager = GenericSingleton<GameManager>.Instance;
        _borderManager = GenericSingleton<BorderManager>.Instance;
        _audioClipManager = GenericSingleton<AudioClipManager>.Instance;
    }

    void OnMouseDown()
    {
        if (!_uiManager.UI.IsOpenUI)
            ChangeState(new TouchState());
    }

    void OnMouseUp()
    {
        if (_state.State == EStateType.Pick)
        {
            if (_uiManager.SellUI.IsSell)
                Sell();
            else
                ChangeState(new IdleState());
        }
        _pickTime = 0f;
    }

    void OnMouseDrag()
    {
        if (!_uiManager.UI.IsOpenUI)
            PickTimer();
    }

    void StateMainLoop()
    {
        if (_state != null)
            _state.MainLoop();
    }

    void CheckLevel()
    {
        if (!_isSaveSlime)
        {
            _level = 1;
        }
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
        _audioClipManager.PlaySFXSound(ESFXSoundType.Grow);
    }

    void ChangeLevelAnimator()
    {
        _animator.runtimeAnimatorController = _slimeManager.LevelAnimatorControllers[_level - 1];
    }

    void PickTimer()
    {
        _pickTime += Time.deltaTime;
        if (_pickTime >= 1f)
            ChangeState(new PickState());
    }

    void Sell()
    {
        int price = _slimeManager.SlimeDatas[(int)_slimeType].Gold;
        _gameManager.AddGold(_level * price);
        _slimeManager.SellSlime(this);
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

    public void AddExp()
    {
        if (_level == _maxLevel)
            return;

        _exp++;
        if (_exp >= _needExp)
            LevelUp();
    }

    public void MakeJam()
    {
        PlantManager plantManager = GenericSingleton<PlantManager>.Instance;
        int jamOutputLevel = plantManager.JamOutputLevel;
        int jamOutput = plantManager.JamOutputDatas[jamOutputLevel].JamOutput;

        int makeJam = ((int)_slimeType + 1) * _level * jamOutput;
        GenericSingleton<GameManager>.Instance.AddJam(makeJam);
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