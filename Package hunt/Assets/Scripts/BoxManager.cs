using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    KeyGenerator kg = new KeyGenerator();
    BoxSpawner bg;
    Dictionary<string, Box> preGeneratedBoxes = new Dictionary<string, Box>(); //pregenerated box values so theres always gonna be multiple options
    Dictionary<string, Box> spawnedBoxes = new Dictionary<string, Box>(); //dictionary which holds the boxes and subsequently makes the boxes findable by id
    public event Action<string> OnNewBox;
    [SerializeField]
    int MaxBoxes;//max boxes on one
    [SerializeField]
    float timer; // time between spawns;
    float currentTimer;
    private void Start()
    {
        bg = GetComponent<BoxSpawner>();//get the spawner
        currentTimer = Time.time;//get start time for spawning;
    }
    private void FixedUpdate()
    {
        if(Time.time-currentTimer == timer)
        {
            print("Spawn");
            //PushProductionLine();
        }
    }
    void PushProductionLine()
    {

    }
    void InitializeProductLine()
    {
        for(int i = 0; i < MaxBoxes; i++)
        {
            Box b = InitializeBox();
            preGeneratedBoxes.Add(b.GetTrackingCode(), b);
        }
    }
    Box  InitializeBox()
    {
        Box b = new Box(kg.GenerateKey("XXX###"));
        return b;
    }


}
