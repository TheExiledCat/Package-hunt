using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box 
{
    
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
