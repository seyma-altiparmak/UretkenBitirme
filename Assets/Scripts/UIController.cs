using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private AudioController audioController;

    private void Start()
    {
        audioController = transform.GetComponent<AudioController>();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void GetActiveScene_Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void MainMenu_Load()
    {
        SceneManager.LoadScene(0);
    }
   
}