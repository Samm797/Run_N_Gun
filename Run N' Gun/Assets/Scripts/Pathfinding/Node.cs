using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public float F_Cost { get { return _fCost; } }
    public float G_Cost { get { return _gCost; } }
    public float H_Cost { get { return _hCost; } }
    
    private float _fCost;
    private float _gCost;
    private float _hCost;

    public Node(float fCost, float gCost)
    {
        this._fCost = fCost;
        this._gCost = gCost;
        this._hCost = fCost + gCost;
    }
}
