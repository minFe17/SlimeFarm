using UnityEngine;

public class BorderManager : MonoBehaviour
{
    // ╫л╠шео
    GameObject _borderPrefab;

    public Vector2 TopRightPos { get; set; }
    public Vector2 BottomLeftPos { get; set; }

    public void CreateBoard(Transform parent)
    {
        if (_borderPrefab == null)
            _borderPrefab = Resources.Load("Prefabs/Border") as GameObject;

        GameObject temp = Instantiate(_borderPrefab, parent);
        temp.GetComponent<Border>().Init();
    }
}