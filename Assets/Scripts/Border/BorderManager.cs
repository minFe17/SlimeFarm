using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class BorderManager : MonoBehaviour
{
    // �̱���
    GameObject _borderPrefab;
    AddressableManager _addressableManager;

    public async void Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _borderPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Border");
    }

    public Vector2 TopRightPos { get; set; }
    public Vector2 BottomLeftPos { get; set; }

    public void CreateBoard(Transform parent)
    {
        GameObject temp = Instantiate(_borderPrefab, parent);
        temp.GetComponent<Border>().Init();
    }
}