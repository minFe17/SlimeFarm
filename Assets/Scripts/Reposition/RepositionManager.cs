using System.Collections.Generic;
using UnityEngine;
using Utils;

public class RepositionManager : MonoBehaviour
{
    // ╫л╠шео
    List<Vector3> _repositions = new List<Vector3>();
    GameObject _repositionPrefab;
    AddressableManager _addressableManager;

    public List<Vector3> Repositions { get => _repositions; }

    public async void Init()
    {
        _repositions.Clear();
        _addressableManager = GenericSingleton<AddressableManager>.Instance;
        _repositionPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Reposition");
    }

    public void CreateReposition(Transform parent)
    {
        Instantiate(_repositionPrefab, parent);
    }

    public Vector3 Reposition()
    {
        int positionIndex = Random.Range(0, _repositions.Count);
        return _repositions[positionIndex];
    }
}