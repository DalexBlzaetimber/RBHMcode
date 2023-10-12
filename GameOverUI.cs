using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreTextMesh;

    public void RestartGame()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // pause the game
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        // Unload current scene
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        // Load main game scene
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

}
