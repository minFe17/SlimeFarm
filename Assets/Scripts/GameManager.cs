using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱���
    int _jam;
    int _gold;

    public int Jam { get => _jam; }
    public int Gold { get => _gold; }

    public void Init()
    {
        // csv ���� �а� jam, gold �� ������ �ҷ�����
        // ������ �ʱⰪ
        _jam = 100;
        _gold = 200;
    }
}
