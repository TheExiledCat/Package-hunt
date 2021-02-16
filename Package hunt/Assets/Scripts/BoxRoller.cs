using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxRoller : MonoBehaviour
{
    [SerializeField]
    float rollSpeed;
    float currentRollSpeed;
    Dictionary<Box,BoxObject> boxes = new Dictionary<Box,BoxObject>();
    public event Action<Box> OnCycle;
    [SerializeField]
    Vector3 startPos,endPos;
    #region getters
    public Vector3 GetStart()
    {
        return startPos+transform.position;
    }
    public Vector3 GetEnd()
    {
        return endPos+transform.position;
    }
    #endregion
    #region methods
    public void AddProductToLine(BoxObject _bo)// add a box to the conveyor belt
    {
        boxes.Add(_bo.GetBox(),_bo);
    }
    public void RemoveFromProductLine(Box _b)//remove a box from the conveyor belt
    {
       Destroy(boxes[_b].gameObject);
       boxes.Remove(_b);
    }
    void MoveLine()//move the boxes
    {
        foreach (KeyValuePair<Box, BoxObject> bo in boxes)//move all the boxes towards the end of the conveyor belt
        {
            bo.Value.transform.position = Vector3.MoveTowards(bo.Value.transform.position, endPos + transform.position, rollSpeed * Time.deltaTime);


        }
    }
    void CheckEnd()//check if a box is at the end
    {
        foreach (KeyValuePair<Box, BoxObject> bo in boxes)//move all the boxes towards the end of the conveyor belt
        {
            if (Vector3.Distance(bo.Value.transform.position, endPos + transform.position) < 0.1f)//if any box reaches the end
            {
                print("end reached");
                OnCycle?.Invoke(bo.Key);//call the delegate that deletes the box from the managers list
                RemoveFromProductLine(bo.Key);//remove the box from the line
                return;
            }
        }
    }
    public void SpeedUp(float multiplier)//speed up the line, not implemented
    {
        currentRollSpeed += (rollSpeed * multiplier) - rollSpeed;// grabs the initial multiplier value and ads it to the current one
    }
    #endregion
    private void Start()
    {
        currentRollSpeed = rollSpeed;
    }
    private void FixedUpdate()
    {
        MoveLine();
        CheckEnd();
    }
    
    private void OnDrawGizmos()//used for visualizing start and end positions, debugging
    {

        Gizmos.DrawWireCube(transform.position+startPos, Vector3.one/2);
        Gizmos.DrawWireCube(transform.position+endPos, Vector3.one/2);

    }
}
