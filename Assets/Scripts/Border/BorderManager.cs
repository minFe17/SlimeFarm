using UnityEngine;
using Utils;

public class BorderManager : MonoBehaviour
{
    // ╫л╠шео
    GameObject _borderPrefab;
    AddressableManager _addressableManager;

    public Vector2 TopRightPos { get; set; }
    public Vector2 BottomLeftPos { get; set; }

    public async void Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _borderPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Border");
    }

    public void CreateBoard(Transform parent)
    {
        GameObject temp = Instantiate(_borderPrefab, parent);
        temp.GetComponent<Border>().Init();
    }
}