using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManajemen : MonoBehaviour
{
    public Text time;

    public Text puzel;

    public Text pice;

    public static ScoreManajemen score;

    string fileName = "";

    private void Awake()
    {
        score = this;
        fileName = Application.dataPath + "/Score.csv";

        TextWriter tw = new StreamWriter(fileName, false);
        tw.WriteLine("id,Time,Puzzel,Pieace");
        tw.Close();

        tw = new StreamWriter(fileName, true);
        tw
            .WriteLine((TimerSetting.waktu * 2) +
            "," +
            TimerSetting.waktu +
            "," +
            Score.scorePuzel +
            "," +
            Score.scorePice);
        tw.Close();
    }

    private void Update()
    {
        puzel.text = Score.scorePice.ToString();
        pice.text = Score.scorePuzel.ToString();
        time.text = TimerSetting.waktu.ToString();
    }

    public void Return()
    {
        PlayerPrefs.SetInt("Return", 1);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
