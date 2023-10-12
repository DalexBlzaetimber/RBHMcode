using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadMainGameScene()
    {
        // Unload current scene
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        // Load main game scene
        SceneManager.LoadScene("Main game", LoadSceneMode.Single);
        // resume the game
        Time.timeScale = 1f;
    }
}
