using UnityEngine;
using Utils;

public class Border : MonoBehaviour
{
    [SerializeField] Transform _topRight;
    [SerializeField] Transform _bottomLeft;

    BorderManager _borderManager;

    public void Init()
    {
        _borderManager = GenericSingleton<BorderManager>.Instance;
        _borderManager.TopRightPos = _topRight.position;
        _borderManager.BottomLeftPos = _bottomLeft.position;
    }
}