using System.Collections.Generic;
using UnityEngine;

public class RepositionManager : MonoBehaviour
{
    // ╫л╠шео
    List<Vector3> _repositions = new List<Vector3>();
    GameObject _repositionPrefab;

    public List<Vector3> Repositions { get => _repositions; }

    public void Init(Transform parent)
    {
        _repositions.Clear();
        CreateReposition(parent);
    }

    void CreateReposition(Transform parent)
    {
        if (_repositionPrefab == null)
            _repositionPrefab = Resources.Load("Prefabs/Reposition") as GameObject;

        Instantiate(_repositionPrefab, parent);
    }
}