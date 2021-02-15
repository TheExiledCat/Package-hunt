using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    [SerializeField]
    TMP_Text code;
    // Start is called before the first frame update
    void Start()
    {
        gm.OnSelection += UpdateCode;
    }

    // Update is called once per frame
    void UpdateCode(Box _b)
    {
        code.text = _b.GetTrackingCode();
        print("setting code");
    }
}
