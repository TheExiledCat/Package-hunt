using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    [SerializeField]
    TMP_Text code, score, hp;
    // Start is called before the first frame update
    void Start()
    {
        gm.OnSelection += UpdateCode;
        gm.OnScore += UpdateScore;
        gm.OnMiss += UpdateHealth;
    }

    // Update is called once per frame
    void UpdateCode(Box _b)
    {
        code.text = _b.GetTrackingCode();
        print("setting code");
    }
    void UpdateScore(int _score)
    {
        score.text ="Score: "+ _score.ToString("0");
    }
    void UpdateHealth(int _health)
    {
        hp.text = "Health: " + _health.ToString("0");
    }
}
