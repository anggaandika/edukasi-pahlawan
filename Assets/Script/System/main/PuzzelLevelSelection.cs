using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelLevelSelection : MonoBehaviour
{
    private Vector3 kananPosisi;
    private Sprite image;
    public DataBases dataBases;
    public GameObject time;
    public ItemDatabase[] level;

    private void Update()
    {
        int selectedLevel = PlayerPrefs.GetInt("selectedLevel");
        this.SelectILevel(selectedLevel);
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
        int tester = 0;
        string data = 1 + "-" + num;
        SetUI(DataBases.GetItemById(data));
        for (int i = 0; i <= 15; i++)
        {
            if (GameObject.Find("Piece (" + i + ")").GetComponent<PieceScript>().diKananPosisi == true)
            {
                if (tester == 15)
                {
                    this.Resets();
                    if (num <= 5)
                    {
                        GameObject.Find("Piece (" + i + ")").transform.Find("Gambar").GetComponent<SpriteRenderer>().sprite
                        = image;
                    }
                    num++;
                }
                tester++;
            }
            // GameObject.Find("Piece (" + i + ")").transform.Find("Gambar").GetComponent<SpriteRenderer>().sprite
            // = image;
        }
    }
    private void Resets()
    {
        for (int j = 0; j <= 15; j++)
        {
            GameObject.Find("Piece (" + j + ")").GetComponent<PieceScript>().acakGambar();
            GameObject.Find("Piece (" + j + ")").GetComponent<PieceScript>().diKananPosisi = false;
        }
    }

    private void SetUI(ItemScript i)
    {
        image = i.itemFoto;
    }
}