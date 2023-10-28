using System.Collections;
using UnityEngine;

public class SellUI : MonoBehaviour
{
    bool _isSell;

    public bool IsSell { get =>_isSell; }

    public void Enter()
    {
        _isSell = true;
    }

    public void Exit()
    {
        _isSell = false;
    }
}
