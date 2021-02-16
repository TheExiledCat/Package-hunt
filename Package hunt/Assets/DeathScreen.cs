using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    TMP_Text score;
    
    public void SetEndScore(int _score)
    {
        score.text = "Final Score: " + _score.ToString("0");
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
