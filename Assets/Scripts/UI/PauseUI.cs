using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] protected GameObject pausePanel;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;

    protected void Awake()
    {
        //resumeButton.onClick.AddListener(ResumeGame);
        //quitButton.onClick.AddListener(QuitGame);
    }
    void OnDestroy()
    {
        resumeButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
    public void ShowUI()
    {
        if (pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }
  

}
