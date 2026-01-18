using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public AudioSource clickSound;
    private bool isPaused = false;

    public GameObject instructionPanel; 

    void Start()
    {
       
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MenuScene") 
        {
            ShowMenu();
        }
        else 
        {
            ResumeGame();
        }
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused) ResumeGame();
                else ShowMenu();
            }
        }
    }

    public void ShowMenu()
    {
        if (menuPanel != null) menuPanel.SetActive(true);
        
        if (SceneManager.GetActiveScene().name != "MenuScene") Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (menuPanel != null) menuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    
    public void PlayGame()
    {
        if (clickSound) clickSound.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        if (clickSound) clickSound.Play();
        Application.Quit();
    }
    
    public void OpenInstructions()
    {
        if (clickSound) clickSound.Play();
        instructionPanel.SetActive(true);
        menuPanel.SetActive(false);    
    }
    public void CloseInstructions()
    {
        if (clickSound) clickSound.Play();
        instructionPanel.SetActive(false); 
        menuPanel.SetActive(true);
    }
}