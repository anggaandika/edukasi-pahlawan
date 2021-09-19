using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int time;
    public static int scorePice;
    public static int scorePuzel;

    public static Score score;

    private void Awake() {
        score = this;
    }
}
