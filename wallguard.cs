using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallguard : MonoBehaviour {
    private GameManager gameManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            Destroy(collision.gameObject);
            gameManager.BrickDestroyed();
        }
    }
}
