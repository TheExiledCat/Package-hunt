using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObject : MonoBehaviour
{
    Box myBox;
    public void SetBox(Box _b)
    {
        myBox = _b;
    }
    public Box GetBox()
    {
        return myBox;
    }
}
