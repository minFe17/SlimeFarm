using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class CameraAsset : MonoBehaviour
{
    // ╫л╠шео
    AddressableManager _addressableManager;
    GameObject _camera;

    public async Task Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _camera = await _addressableManager.GetAddressableAsset<GameObject>("Main Camera");
    }

    public Camera CreateCamera(Transform parent)
    {
        GameObject temp = Instantiate(_camera, transform);
        Camera camera = temp.GetComponent<Camera>();
        return camera;
    }
}