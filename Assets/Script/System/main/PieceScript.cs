using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PieceScript : MonoBehaviour
{
    private Vector3 kananPosisi;
    public bool diKananPosisi;
    public bool selected;
    // Start is called before the first frame update
    void Start()
    {
        kananPosisi = transform.position;
        this.acakGambar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, kananPosisi) < 0.5f)
        {
            if (!selected)
            {
                if (diKananPosisi == false)
                {
                    transform.position = kananPosisi;
                    diKananPosisi = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
    public void acakGambar() 
    {
        transform.position = new Vector3(Random.Range(3f, 5f), Random.Range(0f, 0f));
    }
}
