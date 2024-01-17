using System.Threading.Tasks;
using UnityEngine;
using Utils;

public class BackgroundAsset : MonoBehaviour
{
    // ╫л╠шео
    AddressableManager _addressableManager;
    GameObject _background;

    public async Task Init()
    {
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _background = await _addressableManager.GetAddressableAsset<GameObject>("Background");
    }

    public void CreateBackground(Transform parent)
    {
        Instantiate(_background, parent);
    }
}