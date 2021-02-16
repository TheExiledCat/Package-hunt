using System;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    int health;
    int points = 0;
    BoxManager bm;
    Pointer pointer;
    Box NextBox;
    public event Action<Box> OnSelection;
    public event Action<int> OnScore;
    public event Action<int> OnMiss;
    public event Action<int> OnDie;
    // Start is called before the first frame update
    void Awake()
    {
        bm = GetComponent<BoxManager>();
        pointer = GetComponent<Pointer>();
        bm.OnSelection += Select;
        pointer.OnClick += TrySelection;
        bm.OnRemove += CheckMiss;
        health = maxHealth;
    }
    void Score()//when the correct box is chosen
    {
        print("Good");
        points++;
        OnScore?.Invoke(points);
        bm.RemoveSelection(NextBox);
        bm.Select();
    }
    void Miss()//when the wrong box is chosen
    {
        print("Bad");

        health--;
        if (health <= 0)
        {
            Die();
        }
        OnMiss?.Invoke(health);
        
    }
    void ResetSelected()//set the selected box to null
    {
        NextBox = null;
    }
    void RemoveSelected()//remove the selected box from the lines
    {
       
        bm.Miss(NextBox);
        
    }
    void Die()
    {
        print("RIP");
        OnDie?.Invoke(points);
        Destroy(gameObject);
    }
    void CheckMiss(Box _b)//check wether a deleted box was the selected box
    {
        if (_b == NextBox)
        {
            Miss();
            RemoveSelected();
        }
        
    }
    void TrySelection(Box _b)//check wether or not the selected box is correct
    {
        if (_b == NextBox)
        {
            
            Score();
        }
        else
        {
            bm.RemoveSelection(_b);
            Miss();
        }
    }
    private void Select(List<Box> boxes)//pick a random box to choose as selected
    {
        NextBox = boxes[UnityEngine.Random.Range(0, boxes.Count)];
        bm.SetSelected(NextBox);
        OnSelection?.Invoke(NextBox);

    }
}
