using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    string code; //the track id code to search for;
    
    public string GetTrackingCode()
    {
        return code;
    }
    public void SetTrackingCode(string _code)
    {
        code = _code;
    }
}
