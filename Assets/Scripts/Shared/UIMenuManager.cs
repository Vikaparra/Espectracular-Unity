using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private UnityEvent resetMinigame;
    
    //TODO: refactor this class so it is only responsible for
    // opening and closing menu manager. It doesn't need to deal
    // with reset game, or loading scenes (at least I think not)

    public void OpenMenu()
    {
        this.menuPanel.SetActive(true);
        this.gamePanel.SetActive(false);
    }
    public void BackToMinigame()
    {
        this.gamePanel.SetActive(true);
        this.menuPanel.SetActive(false);
    }
    public void ResetMinigame()
    {
        this.resetMinigame.Invoke();
        this.gamePanel.SetActive(true);
        this.menuPanel.SetActive(false);
    }
    public void BackToMainScene(string mainScene)
    {
        this.menuPanel.SetActive(false);
        SceneManager.LoadScene(mainScene);
    }
}
