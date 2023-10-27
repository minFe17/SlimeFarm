using System.Collections.Generic;
using UnityEngine;

public class RepositionManager : MonoBehaviour
{
    List<Vector3> _repositions = new List<Vector3>();
    GameObject _repositionPrefab;

    public List<Vector3> Repositions { get => _repositions; }

    public void Init()
    {
        _repositions.Clear();
        _repositionPrefab = Resources.Load("Prefabs/Reposition") as GameObject;
        CreateReposition();
    }

    void CreateReposition()
    {
        Instantiate(_repositionPrefab);
    }
}
