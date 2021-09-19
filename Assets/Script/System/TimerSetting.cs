using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{

    public Text textTimer;

    public static float waktu = 5f;

    public static bool GameAktif = true;

    // Update is called once per frame
    void SetText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = menit.ToString("00") + ":" + detik.ToString("00");
    }

    float s;

    void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                waktu++;
                s = 0;
            }
        }
        int time = (int) waktu;
        if (GameAktif && waktu <= 0)
        {
            Score.time += (int)waktu;
            SceneManager.LoadScene(2, LoadSceneMode.Single);
            GameObject
                .Find("MasterGame")
                .GetComponent<PuzzelLevelSelection>()
                .enabled = false;
            GameAktif = false;
        }

        SetText();
    }
}
