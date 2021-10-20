using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzelLevelSelection : MonoBehaviour
{
    private Vector3 kananPosisi;

    private bool kanan = false;

    private Sprite image;

    public DataBases dataBases;

    public ItemDatabase[] level;

    static int num = 0;

    int leveling;

    private void Awake()
    {
        SetUI(DataBases.GetRandomItem());
        switch (PlayerPrefs.GetInt("selectedLevel"))
        {
            case '0':
                leveling = 2;
                break;
            case '1':
                leveling = 5;
                break;
            case '2':
                leveling = 5;
                break;
            default:
                leveling = 2;
                break;
        }
        for (int i = 0; i <= 15; i++)
        {
            GameObject
                .Find("Piece (" + i + ")")
                .transform
                .Find("Gambar")
                .GetComponent<SpriteRenderer>()
                .sprite = image;
        }
    }

    private void Update()
    {
        GameObject.Find("MasterGame").SetActive(true);
        SetUI(DataBases.GetRandomItem());
        int selectedLevel = PlayerPrefs.GetInt("selectedLevel");
        this.SelectILevel(selectedLevel);
        for (int i = 0; i <= 15; i++)
        {
            if (
                !GameObject
                    .Find("Piece (" + i + ")")
                    .transform
                    .GetComponent<PieceScript>()
                    .diKananPosisi
                    .Equals(true)
            ) break;

            if (i == 15)
            {
                kanan = true;
            }
        }
    }

    private void SelectILevel(int levels)
    {
        switch (levels)
        {
            case '0':
                dataBases.items = level[0];
                break;
            case '1':
                dataBases.items = level[1];
                break;
            case '2':
                dataBases.items = level[2];
                break;
            default:
                dataBases.items = level[0];
                break;
        }
        dataBases.items = level[0];
        this.SetPuzzlesPotos(levels);
    }

    private void SetPuzzlesPotos(int levels)
    {
        if (kanan == true)
        {
            kanan = false;
            this.Resets();
            if (num <= leveling)
            {
                for (int i = 0; i <= 15; i++)
                {
                    GameObject
                        .Find("Piece (" + i + ")")
                        .transform
                        .Find("Gambar")
                        .GetComponent<SpriteRenderer>()
                        .sprite = image;
                }
                Score.scorePuzel += (levels + 1) * 10;
                num++;
                Debug.Log (num);
            }
            if (num == leveling)
            {
                GameObject
                    .Find("MasterGame")
                    .GetComponent<PuzzelLevelSelection>()
                    .enabled = false;
                GameObject
                    .Find("MasterGame")
                    .GetComponent<TimerSetting>()
                    .enabled = false;
                TimerSetting.GameAktif = false;
                SceneManager.LoadScene(2, LoadSceneMode.Single);
            }
        }
    }

    private void Resets()
    {
        for (int j = 0; j <= 15; j++)
        {
            GameObject
                .Find("Piece (" + j + ")")
                .GetComponent<PieceScript>()
                .acakGambar();
            GameObject
                .Find("Piece (" + j + ")")
                .GetComponent<PieceScript>()
                .diKananPosisi = false;
        }
    }

    private void SetUI(ItemScript i)
    {
        image = i.itemFoto;
    }
}
