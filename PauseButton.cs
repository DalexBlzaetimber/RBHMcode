using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreTextMesh;
    private SettingsUI settingsUI;
    private GameManager gameManager;
    private bool isPaused = false;
    private bool isGameOverUIVisible = false;

    void Start()
    {
        // hide the pause UI on start
        pauseUI.SetActive(false);
    }

    void Update()
    {
        // disable pause button and escape key functionality when game over UI is visible
        if (GameObject.FindObjectOfType<GameManager>().lives <= 0)
        {
            return; // if lives are 0 or less, don't pause the game
        }

        // pause the game when the player presses the "Escape" key
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (GameObject.FindObjectOfType<GameManager>().lives <= 0)
        {
            return; // if lives are 0 or less, don't pause the game
        }
        if (isPaused)
        {
            ResumeGame();
            
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        // Check if the game is already paused
        if (Time.timeScale == 0f)
        {
            // Unpause the game
            Time.timeScale = 1f;
            // Hide the pause menu
            pauseUI.SetActive(false);
        }
        else
        {
            // Pause the game

            Time.timeScale = 0f;
            // Show the pause menu
            pauseUI.SetActive(true);
        }
    }

    private void ResumeGame()
    {
        // hide the pause UI
        pauseUI.SetActive(false);


        // resume the game
     
        Time.timeScale = 1f;

        // clear the pause flag
        isPaused = false;
    }

    public void ExitToMainMenu()
    {

        // Unload current scene
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        // Load main game scene
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    // method to set game over UI visibility status
    public void SetGameOverUIVisibility(bool isVisible)
    {
        isGameOverUIVisible = isVisible;
    }
}