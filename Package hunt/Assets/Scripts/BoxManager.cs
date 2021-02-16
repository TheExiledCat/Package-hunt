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
    public event Action<List<Box>> OnSelection;
    public event Action<Box> OnRemove;
    Box selectedBox;
    [SerializeField]
    int boxesPerSelection;//how many boxes before a new one is selected, also amount before line speeds up
    [SerializeField]
    float timer; // time between spawns;
    float currentTimer;
    //[SerializeField]
    //float speedMultiplier; //speeds up the spawn and speed rate
    int cycles; //total spawns so far, will change the speed of the line
    float startTimer;
    private void Start()
    {
        spawner = GetComponent<BoxSpawner>();//get the spawner
        roller = GetComponent<BoxRoller>();//get the virtual  conveyor belt
        currentTimer = Time.time;//get start time for spawning;
        startTimer = timer;
        roller.OnCycle += RemoveBox;//sub to the delegate
        InitializeProductLine();
        Select();
    }
    private void FixedUpdate()
    {
        if(Time.time-currentTimer >= timer)
        {
            print("Spawn");
            PushProductionLine();
            if (cycles % boxesPerSelection==0&&selectedBox==null)//every x amount of cycles , where x is boxes per selection
            {
                Select();
            }
        }
    }
    public void Miss(Box _b)//protocol when a box is missed;
    {
        spawnedBoxes.Remove(_b.GetTrackingCode());
        Select();
    }
    #region methods
    public void Select()
    {

        OnSelection?.Invoke(preGeneratedBoxes);//call delegate to select a new box for extraction
    } 
    void PushProductionLine()//spawns the first box in the list and push a new one at the end
    {
        BoxObject bo =spawner.SpawnBox(preGeneratedBoxes[0],roller);
        spawnedBoxes.Add(bo.GetBox().GetTrackingCode(),bo.GetBox());
        preGeneratedBoxes.RemoveAt(0);
        InsertNewBox();
        RefreshTimer();
    }
    public void RemoveSelection(Box _b)//tell the spawner to despawn the box
    {
        spawner.DespawnBox(_b, roller);
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
        OnRemove?.Invoke(_b);
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
    #endregion
    public void SetSelected(Box _b)
    {
        selectedBox = _b;
    }

}
