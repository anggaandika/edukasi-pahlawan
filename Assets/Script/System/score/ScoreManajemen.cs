using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManajemen : MonoBehaviour
{
    public Text time;
    public Text puzel;
    public Text pice;
    public static ScoreManajemen score;
    private void Awake()
    {
        score = this;
    }
    
    private void Update() {
        puzel.text = Score.scorePice.ToString();
        pice.text = Score.scorePuzel.ToString();
        time.text = TimerSetting.waktu.ToString();
    }
}
