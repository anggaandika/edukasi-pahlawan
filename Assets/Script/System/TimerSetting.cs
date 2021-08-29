using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    public Text textTimer;
    public float waktu = 100;

    public bool GameAktif = true;
    // Update is called once per frame

    void SetText() 
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") +":"+ detik.ToString("00");
    }

    float s;

    void Update()
    {        
        if (GameAktif)
        {
            s += Time.deltaTime;
                if(s >= 1) 
                {
                    waktu--;
                    s = 0;
                }
        }
        if (GameAktif && waktu <= 0)
        {
            Debug.Log("Game Kalah");
            GameAktif = false;
        }

        SetText();
    }


}
