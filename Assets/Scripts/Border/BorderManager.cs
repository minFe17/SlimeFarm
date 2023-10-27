using UnityEngine;

public class BorderManager : MonoBehaviour
{
    // ╫л╠шео
    GameObject _borderPrefab;

    public Vector2 TopRightPos { get; set; }
    public Vector2 BottomLeftPos { get; set; }

    public void Init()
    {
        _borderPrefab = Resources.Load("Prefabs/Border") as GameObject;
        CreateBoard();
    }

    public void CreateBoard()
    {
        GameObject temp = Instantiate(_borderPrefab);
        temp.GetComponent<Border>().Init();
    }
}