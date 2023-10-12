using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab; // Reference to the brick prefab that will be spawned
    public int rows = 5; // Number of rows of bricks
    public int columns = 7; // Number of columns of bricks
    public float spacing = 0.2f; // Spacing between bricks
    public float yOffset = 0.5f; // Vertical offset from the top of the screen
    public float zRange = 6f; // Horizontal range in which the bricks can spawn

    private GameManager gameManager; // Reference to the GameManager script

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SpawnBricks();
    }

    public void SpawnBricks()
    {
        // Clear all existing bricks
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("brick");
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }

        // Calculate the width of each brick and the total width of the brick wall
        float brickWidth = brickPrefab.GetComponent<Renderer>().bounds.size.x;
        float totalWidth = (brickWidth + spacing) * columns - spacing;

        // Calculate the starting z position for the brick wall
        float startZ = -zRange / 2f + brickWidth / 2f;

        // Double the number of rows and columns with each level increase
        rows += 1;
        columns += 1;

        // Spawn each row of bricks
        for (int i = 0; i < rows; i++)
        {
            // Calculate the y position of the current row
            float y = yOffset + i * (brickPrefab.GetComponent<Renderer>().bounds.size.y + spacing);

            // Spawn each brick in the row
            for (int j = 0; j < columns; j++)
            {
                // Calculate the z position of the current brick
                float z = startZ + j * (brickPrefab.GetComponent<Renderer>().bounds.size.x + spacing);

                // Instantiate the brick prefab at the calculated position
                GameObject brick = Instantiate(brickPrefab, new Vector3(0, y, z), Quaternion.identity);
                brick.transform.parent = transform;

                // Add the brick to the total brick count in the GameManager
                gameManager.totalBricks++;
            }
        }
    }


}