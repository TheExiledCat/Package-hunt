using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Box 
{
    [SerializeField]
    string code; //the track id code to search for;
    public Box (string _code)
    {
        code = _code;
    }
    public void Initialize(string _code)
    {
        code = _code;
    }
    public string GetTrackingCode()
    {
        return code;
    }
    public void SetTrackingCode(string _code)
    {
        code = _code;
    }
}
