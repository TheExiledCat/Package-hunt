using System;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    LayerMask boxes;
    public event Action<Box> OnClick;
    void ScanBox()
    {
        Box b = hit.collider.GetComponent<BoxObject>()?.GetBox();
        if (b != null)
        {
            OnClick?.Invoke(b);//call the delegate on click
            print(b.GetTrackingCode());
        }
        else
        {
            print("huh");
        }

    }
    void FixedUpdate()
    {

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, boxes)){
            if (Input.GetMouseButton(0))
            {
                
                ScanBox();
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition));
    }
}
