using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauzaControler : MonoBehaviour
{

    public static bool isPauza = false;
    public GameObject pauseMenuUi;
    public GameObject players;
    public GameObject enemis;
    public GameObject white;
    public GameObject black;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPauza)
            {
                Resume();
            }
            else
            {
                Pauza();
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        players.SetActive(true);
        enemis.SetActive(true);
        white.SetActive(true);
        black.SetActive(true);
        Time.timeScale = 1f;
        isPauza = false;
    }

    void Pauza()
    {
        pauseMenuUi.SetActive(true);
        players.SetActive(false);
        enemis.SetActive(false);
        white.SetActive(false);
        black.SetActive(false);
        Time.timeScale = 0f;
        isPauza = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
