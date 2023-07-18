using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int curScore = 0;

    public int GetCurScore() {
        return curScore;
    }

    public void AddScore(int score) {
        curScore += score;
        Mathf.Clamp(curScore, 0, int.MaxValue);
        Debug.Log(curScore);
    }

    public void ResetScore() {
        curScore = 0;
    }

}
