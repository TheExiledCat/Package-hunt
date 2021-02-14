using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    KeyGenerator kg = new KeyGenerator();
    BoxSpawner spawner;
    BoxRoller roller;
    [SerializeField]
    List<Box> preGeneratedBoxes = new List<Box>(); //pregenerated box values so theres always gonna be multiple options
    Dictionary<string, Box> spawnedBoxes = new Dictionary<string, Box>(); //dictionary which holds the boxes and subsiquently makes the boxes findable by id
    public event Action<string> OnNewBox;
    [SerializeField]
    int boxesPerSelection;//how many boxes before a new one is selected
    [SerializeField]
    float timer; // time between spawns;
    float currentTimer;

    int cycles; //total spawns so far, will change the speed of the line
    float startTimer;
    private void Start()
    {
        spawner = GetComponent<BoxSpawner>();//get the spawner
        roller = GetComponent<BoxRoller>();//get the virtual  conveyor belt
        currentTimer = Time.time;//get start time for spawning;
        startTimer = timer;
        roller.OnCycle += RemoveBox;
        InitializeProductLine();
    }
    private void FixedUpdate()
    {
        if(Time.time-currentTimer == timer)
        {
            print("Spawn");
            PushProductionLine();
        }
    }
    void PushProductionLine()//spawns the first box in the list and push a new one at the end
    {
        BoxObject bo =spawner.SpawnBox(preGeneratedBoxes[0],roller);
        spawnedBoxes.Add(bo.GetBox().GetTrackingCode(),bo.GetBox());
        preGeneratedBoxes.RemoveAt(0);
        InsertNewBox();
        RefreshTimer();
    }
    void InitializeProductLine()//fills the list with boxes for initialization
    {
        for(int i = 0; i < boxesPerSelection; i++)
        {
            InsertNewBox();
        }
    }
    void InsertNewBox()//adds new box to the generated list
    {
        Box b = InitializeBox();
        preGeneratedBoxes.Add(b);
        
    }
    void RemoveBox(Box _b)
    {
        spawnedBoxes.Remove(_b.GetTrackingCode());
    }
    void RefreshTimer()//refreshes the spawn timer
    {
        currentTimer = Time.time;
        cycles++;
    }
    Box  InitializeBox()
    {
        Box b = new Box(kg.GenerateKey("XXX###"));
        return b;
    }//creates a box


}
