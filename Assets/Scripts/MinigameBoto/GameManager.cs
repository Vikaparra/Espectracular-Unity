using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    private Score score;
    private Player boto;
    [SerializeField] private GameObject Right;
    [SerializeField] private GameObject GameFinished;

    protected virtual void Start()
    {
        this.boto = GameObject.FindObjectOfType<Player>();
        this.score = GameObject.FindObjectOfType<Score>();
    }

    public void PauseGame(){
        Time.timeScale = 0;
    }

    public void ReturnGame(){
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        this.score.SaveScore();
        GameFinished.gameObject.SetActive(true);

    }

    public virtual void ResetGame()
    {
        Time.timeScale = 1;
        this.boto.ResetPlayer();
        this.DestroyRemainingTrash();
        this.RegenerateTrash();
        this.score.ResetScore();
        Right.gameObject.SetActive(false);
        GameFinished.gameObject.SetActive(false);

    }

    private void DestroyRemainingTrash()
    {
        Trash[] trashList = GameObject.FindObjectsOfType<Trash>();
        foreach (Trash trash in trashList)
        {
            trash.SelfDestroy();
        }
    }
    private void RegenerateTrash()
    {
        TrashGenerator[] trashGeneratorList = GameObject.FindObjectsOfType<TrashGenerator>();
        foreach (TrashGenerator generator in trashGeneratorList)
        {
            generator.InstantiateTrash();
        }
    }
}
