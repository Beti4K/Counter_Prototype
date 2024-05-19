using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeController : MonoBehaviour
{
    private float speed = 15.0f;
    private float bound = 10.0f;
    public float levelTime = 60.0f;
    public bool gameActive;

    [SerializeField] GameObject gameOverWindow;
    [SerializeField] Text Timer;

    private void Start()
    {
        Timer.text = "Time: " + levelTime.ToString() + "s";
    }

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
    
    public IEnumerator TimePass()
    {
        yield return new WaitForSeconds(1);
        if (levelTime <= 0)
        {
            GameOver();
        }
        else
        {
            levelTime -= 1.0f;
            Timer.text = "Time: " + levelTime.ToString() + "s";
            StartCoroutine(TimePass());
        }
    }
}
