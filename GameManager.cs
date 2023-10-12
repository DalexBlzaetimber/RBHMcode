using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class GameManager : MonoBehaviour
{
    public int totalBricks = 0; // Total number of bricks in the level
    public TextMeshProUGUI scoreText; // Reference to the score text object in the UI
    public TextMeshProUGUI livesText; // Reference to the lives text object in the UI
    public TextMeshProUGUI levelText; // Reference to the level text object in the UI
    public GameObject gameOverCanvas; // Reference to the game over canvas in the UI
    public AudioClip lifeLostClip;
    public AudioClip gameOverClip;
    public int lives = 3; // Number of lives the player has
    public int level = 1; // Current level of the game
    public int score = 0; // Current score of the player
    public BrickSpawner brickSpawner; // Reference to the BrickSpawner script
    private AudioSource audioSource;
    private BrickSpawner spawner;
    public bool gameOver = false; // Flag to indicate if the game is over
    private string highScoreDataFilePath;
    private LeaderboardData leaderboardData;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Find all the brick tags in the level
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        totalBricks = bricks.Length;
        // Hide the game over canvas and name input canvas at the start of the game
        gameOverCanvas.SetActive(false);
        // Update the UI text for the current level and lives
        levelText.text = "" + level;
        livesText.text = "Lives: " + lives;
        // Initialize the high score data file path and load the existing leaderboard data if it exists
        highScoreDataFilePath = Application.persistentDataPath + "/leaderboard.json";
        leaderboardData = new LeaderboardData();
        if (File.Exists(highScoreDataFilePath))
        {
            string leaderboardJson = File.ReadAllText(highScoreDataFilePath);
            leaderboardData = JsonUtility.FromJson<LeaderboardData>(leaderboardJson);
        }

    }

    public void BrickDestroyed()
    {
        // Decrease the total number of bricks in the level
        totalBricks--;

        // Increase the score of the player
        score += 10;

        // Update the score UI text
        scoreText.text = "" + score;

        // If all bricks have been destroyed, go to the next level
        if (totalBricks == 0)
        {
            level++;
            levelText.text = "" + level;

            // Reset the level by spawning a new set of bricks with an increased area size
            brickSpawner.SpawnBricks();

        }
    }

    public void UpdateBrickLayout()
    {
        brickSpawner.rows++;
        brickSpawner.columns++;
    }
    public void BallLost()
    {
        // Decrease the number of lives the player has
        lives--;

        // Update the lives UI text
        livesText.text = "Lives: " + lives;

        // Play the life lost audio clip
        audioSource.clip = lifeLostClip;
        audioSource.Play();

        // If the player has no more lives, show the game over canvas and name input canvas, and stop the game
        if (lives == 0)
        {
            Time.timeScale = 0f;
            gameOverCanvas.SetActive(true);

            // Play the game over audio clip
            audioSource.clip = gameOverClip;
            if (score > GetLowestHighScore())
            {
                SaveHighScoreEntry();
            }

        }
    }
    public void SaveHighScoreEntry()
    {
        // Create a new leaderboard entry with the name and score
        LeaderboardEntry newEntry = new LeaderboardEntry();
        newEntry.score = score;
        newEntry.level = level;

        // Add the new entry to the leaderboard data
        leaderboardData.entries.Add(newEntry);

        // Sort the leaderboard entries by score in descending order
        leaderboardData.entries.Sort((a, b) => b.score.CompareTo(a.score));

        // Remove any excess entries beyond the maximum allowed
        while (leaderboardData.entries.Count > 10)
        {
            leaderboardData.entries.RemoveAt(leaderboardData.entries.Count - 1);
        }

        // Save the updated leaderboard data to the high score data file
        string leaderboardJson = JsonUtility.ToJson(leaderboardData);
        File.WriteAllText(highScoreDataFilePath, leaderboardJson);
    }

    private int GetLowestHighScore()
    {
        // Get the lowest high score in the leaderboard, or 0 if there are no entries
        if (leaderboardData.entries.Count > 0)
        {
            return leaderboardData.entries[leaderboardData.entries.Count - 1].score;
        }
        else
        {
            return 0;
        }
    }
    public void ClearSavedData()
    {
        // Delete the leaderboard data file if it exists
        if (File.Exists(highScoreDataFilePath))
        {
            File.Delete(highScoreDataFilePath);
        }

        // Clear the leaderboard data object
        leaderboardData = new LeaderboardData();
    }
}

// Data structure for a single leaderboard entry
[System.Serializable]
public class LeaderboardEntry
{
    public string name;
    public int score;
    public int level;
}

// Data structure for the leaderboard data (list of entries)
[System.Serializable]
public class LeaderboardData
{
    public List<LeaderboardEntry> entries;
}