using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    Box myBox;
    [SerializeField]
    TextMesh myCode;
    
    void SetText(string _code)
    {
        myCode.text = _code;
    }
    public void SetBox(Box _b)
    {
        myBox = _b;
        SetText(myBox.GetTrackingCode());
    }
    public Box GetBox()
    {
        return myBox;
    }
}
