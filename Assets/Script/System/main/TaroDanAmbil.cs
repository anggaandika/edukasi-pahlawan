using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TaroDanAmbil : MonoBehaviour
{
    public GameObject selectedPiece;
    int oil = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PieceScript>().diKananPosisi)
                {
                    selectedPiece = hit.transform.gameObject;
                    selectedPiece.GetComponent<PieceScript>().selected = true;
                    selectedPiece.GetComponent<SortingGroup>().sortingOrder = oil;
                    oil++;
                }
                else
                {
                    Debug.Log("bisa cuy");
                }
            }
            else
            {
                Debug.Log("");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (selectedPiece != null)
            {
                selectedPiece.GetComponent<PieceScript>().selected = false;
                selectedPiece = null;
            }
            else
            {
                ///// do noting
            }
        }
        if (selectedPiece != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}
