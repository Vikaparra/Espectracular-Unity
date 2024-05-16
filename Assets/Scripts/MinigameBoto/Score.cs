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
        this.TotalScore=+points;
        this.onScore.Invoke(this.TotalScore);
    }
}

[Serializable]
public class ScoreEvent : UnityEvent<int>
{

}