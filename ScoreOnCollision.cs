using UnityEngine;

public class ScoreOnCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.score += 5;
            gameManager.scoreText.text = "" + gameManager.score;
        }
    }
}
