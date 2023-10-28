using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글턴
    int _jam;
    int _gold;
    int _maxJam;
    int _maxGold;

    public int Jam { get => _jam; }
    public int Gold { get => _gold; }

    public void Init()
    {
        // csv 파일 읽고 jam, gold 값 있으면 불러오기
        // 없으면 초기값
        _jam = 100;
        _gold = 200;
        _maxJam = 999999999;
        _maxGold = 999999999;
    }

    public void AddJam(int jamAmount)
    {
        _jam += jamAmount;
        if(_jam >= _maxJam)
            _jam = _maxJam;
    }
}
