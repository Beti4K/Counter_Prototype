using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterBText;
    public Text CounterRText;
    public Text CounterYText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            GameManager.Instance.CountB += 1;
            CounterBText.text = "Silver: " + GameManager.Instance.CountB;
        }
        else if (other.gameObject.CompareTag("Red"))
        {
            GameManager.Instance.CountR += 1;
            CounterRText.text = "Copper: " + GameManager.Instance.CountR;
        }
        else if (other.gameObject.CompareTag("Yellow"))
        {
            GameManager.Instance.CountY += 1;
            CounterYText.text = "Gold: " + GameManager.Instance.CountY;
        }

        GameObject.Destroy(other);
    }
}
