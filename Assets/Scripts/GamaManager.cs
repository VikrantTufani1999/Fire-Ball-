using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    [SerializeField]
    private GameObject WinPanel;
    [SerializeField]
    private GameObject LosePanel;

    private void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void ActivateWinPanel()
    {
        WinPanel.SetActive(true);
    }

    public void ActivateLosePanel()
    {
        LosePanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
