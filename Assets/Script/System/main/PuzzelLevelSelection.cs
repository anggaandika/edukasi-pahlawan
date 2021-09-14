using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelLevelSelection : MonoBehaviour
{
    private Vector3 kananPosisi;

    private bool kanan = false;

    private Sprite image;

    public DataBases dataBases;

    public GameObject time;

    public ItemDatabase[] level;

    private void Update()
    {
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
        this.SetPuzzlesPotos();
    }

    private void SetPuzzlesPotos()
    {
        int num = 1;
        SetUI(DataBases.GetRandomItem());
        if (kanan == true)
        {
            kanan = false;
            this.Resets();
            if (num <= 5)
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
                num++;
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
