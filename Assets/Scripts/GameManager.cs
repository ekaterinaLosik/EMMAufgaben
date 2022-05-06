using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pausePanel;
    public GameObject deathPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            AudioListener.pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            AudioListener.pause = false;

        }
    }

    public void EndGame()
    {
        deathPanel.SetActive(true);
        StartCoroutine(WaitAndLoadMenu());
    }
    IEnumerator WaitAndLoadMenu()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Lobby");

    }
    public void ResumeGame(){
        Pause();
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause();
    }
    public void ExitToLobby(){
        SceneManager.LoadScene("Lobby");
    }
}
