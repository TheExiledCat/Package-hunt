using System;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    LayerMask boxes;
    public event Action<Box> OnClick;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, boxes)){
            if (Input.GetMouseButtonDown(0))
            {
                Box b = hit.collider.GetComponent<BoxObject>()?.GetBox();
                OnClick?.Invoke(b);//call the delegate on click
                print(b.GetTrackingCode());
            }
        }
    }
}
