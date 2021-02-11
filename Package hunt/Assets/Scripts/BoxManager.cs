using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    KeyGenerator kg = new KeyGenerator();
    Dictionary<string, Box> spawnedBoxes = new Dictionary<string, Box>(); //dictionary which holds the boxes and subsequently makes the boxes findable by id
    Dictionary<string, Box> preGeneratedBoxes = new Dictionary<string, Box>();

    [SerializeField]
    float timer; // time between spawns;
    private void Start()
    {
        kg.GenerateKey("X#X###");
    }


}
