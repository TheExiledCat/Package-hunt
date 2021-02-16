using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    GameManager gm;
    [SerializeField]
    DeathScreen ds;
    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<GameManager>();
        gm.OnDie += ShowScreen;
    }
    void ShowScreen(int _score)
    {
        ds.gameObject.SetActive(true);
        ds.SetEndScore(_score);
    }
    
}
