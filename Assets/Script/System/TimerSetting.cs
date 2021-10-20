using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerSetting : MonoBehaviour
{
    // public Text textTimer;
    public static float waktu = 5f;

    public float wMedium = 250;

    public float wUp = 100;

    public static bool GameAktif = true;

    static int selectedLevel;

    // Update is called once per frame
    void SetText()
    {
        int menit = Mathf.FloorToInt(waktu / 60);
        int detik = Mathf.FloorToInt(waktu % 60);
        GameObject.Find("Canvas/waktu").GetComponent<Text>().text =
            menit.ToString("00") + ":" + detik.ToString("00");
    }

    private void Awake()
    {
        SetText();
    }

    float s;

    void Start()
    {
        selectedLevel = PlayerPrefs.GetInt("selectedLevel");
        if (selectedLevel == 0) waktu = 0;
        if (selectedLevel == 1) waktu = wMedium;
        if (selectedLevel == 2) waktu = wUp;
    }

    void Update()
    {
        if (GameAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                if (selectedLevel == 0)
                    waktu++;
                else
                    waktu--;
                s = 0;
            }
        }
        SetText();
        int time = (int) waktu;
        if (selectedLevel != 0)
        {
            if (GameAktif && waktu <= 0)
            {
                Score.time += (int) waktu;
                SceneManager.LoadScene(2, LoadSceneMode.Single);
                GameObject
                    .Find("MasterGame")
                    .GetComponent<PuzzelLevelSelection>()
                    .enabled = false;
                GameObject
                    .Find("MasterGame")
                    .GetComponent<TimerSetting>()
                    .enabled = false;
                GameAktif = false;
            }
        }
    }
}
