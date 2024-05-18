using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float speed = 15.0f;
    private float bound = 10.0f;
    public bool gameActive;

    [SerializeField] GameObject gameOverWindow;

    void Update()
    {
        if (gameActive)
        {
            transform.position += new Vector3(0, 0, Input.GetAxis("Horizontal") * speed * Time.deltaTime);
            if (transform.position.z > bound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, bound);
            }
            else if (transform.position.z < -bound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -bound);
            }
        }
    }

    public void GameOver()
    {
        gameActive = false;
        gameOverWindow.SetActive(true);
    }
}
