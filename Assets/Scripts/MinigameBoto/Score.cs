using System;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField]
    private ScoreEvent onScore;
    public int TotalScore { get; private set; }

    public void AddPoint(int points = 1)
    {
        this.TotalScore += points;
        this.onScore.Invoke(this.TotalScore);
    }

    public void SaveScore()
    {
        int record = PlayerPrefs.GetInt("botoScore");
        if (this.TotalScore > record)
        {
            PlayerPrefs.SetInt("botoScore", this.TotalScore);
        }

    }

    public void ResetScore(){
        this.TotalScore = 0;
    }
}

[Serializable]
public class ScoreEvent : UnityEvent<int>
{

}