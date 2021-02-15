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
    Pointer p;
    Box NextBox;
    public event Action<Box> OnSelection;
    // Start is called before the first frame update
    void Start()
    {
        bm = GetComponent<BoxManager>();
        bm.OnSelection += Select;
        health = maxHealth;
    }

    private void Select(List<Box> boxes)
    {
        NextBox = boxes[UnityEngine.Random.Range(0, boxes.Count)];
        bm.SetSelected(NextBox);
        OnSelection?.Invoke(NextBox);

    }
}
