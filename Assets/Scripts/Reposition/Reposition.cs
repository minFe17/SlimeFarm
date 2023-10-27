using UnityEngine;
using Utils;

public class Reposition : MonoBehaviour
{
    RepositionManager _repositionManager;

    void Start()
    {
        _repositionManager = GenericSingleton<RepositionManager>.Instance;
        _repositionManager.Repositions.Add(transform.position);
    }
}
