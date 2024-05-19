using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ForgeHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Recipe;
    [SerializeField] TextMeshProUGUI Score;
    private int points;
    private int healthPoints = 3;

    [SerializeField] int goldRecipe;
    [SerializeField] int copperRecipe;
    [SerializeField] int silverRecipe;

    [SerializeField] GameObject[] Prefabs;
    [SerializeField] TextMeshProUGUI[] Texts;
    [SerializeField] int[] Amounts;

    [SerializeField] Button[] Buttons;

    [SerializeField] GameObject gameOverWindow;
    [SerializeField] TextMeshProUGUI gameOverText;

    [SerializeField] TextMeshProUGUI lives;
    void Start()
    {
        points = 0;
        Score.text = "Score: " + points; 

        Amounts[0] = GameManager.Instance.CountY;
        Amounts[1] = GameManager.Instance.CountR;
        Amounts[2] = GameManager.Instance.CountB;

        Texts[0].text = "Remaining: " + Amounts[0];
        Texts[1].text = "Remaining: " + Amounts[1];
        Texts[2].text = "Remaining: " + Amounts[2];

        RecipeMaker();
    }

    public void AddMetal(int colorIndex)
    {
        if (Amounts[colorIndex] > 0)
        {
            Instantiate(Prefabs[colorIndex], new Vector3(Random.Range(-2.3f, -2.1f), 1.0f, Random.Range(-3.1f, -2.9f)), transform.rotation);
            Amounts[colorIndex] -= 1;
            Texts[colorIndex].text = "Remaining: " + Amounts[colorIndex];
        }
        else
        {
            Debug.Log("Not enough metal");
        }
    }

    public void Forge()
    {
        int gold = GameObject.FindGameObjectsWithTag("Yellow").Length;
        int copper = GameObject.FindGameObjectsWithTag("Red").Length;
        int silver = GameObject.FindGameObjectsWithTag("Blue").Length;

        if (gold == goldRecipe && silver == silverRecipe && copper == copperRecipe)
        {
            points += (gold + copper + silver) * 5;
            Score.text = "Score: " + points;
        }
        else
        {
            healthPoints -= 1;
            lives.text = "Mistakes allowed: " + healthPoints;
            if (healthPoints == 0)
            {
                GameOver();
            }
        }

        GameObject[] golds = GameObject.FindGameObjectsWithTag("Yellow");
        foreach (GameObject go in golds)
            Destroy(go);

        GameObject[] coppers = GameObject.FindGameObjectsWithTag("Red");
        foreach (GameObject go in coppers)
            Destroy(go);

        GameObject[] silvers = GameObject.FindGameObjectsWithTag("Blue");
        foreach (GameObject go in silvers)
            Destroy(go);

        RecipeMaker();
    }

    void RecipeMaker()
    {
        goldRecipe = Random.Range(0, 3);
        copperRecipe = Random.Range(0, 3);
        silverRecipe = Random.Range(0, 3);

        Recipe.text = "Gold: " + goldRecipe + "\nCopper: " + copperRecipe + "\nSilver: " + silverRecipe;
    }

    void GameOver()
    {
        gameOverText.text = "Oops! Too many mistakes!\nScore:" + points;
        gameOverWindow.SetActive(true);
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }

    }
    public void ResetGame()
    {
        GameManager.Instance.CountY = 0;
        GameManager.Instance.CountB = 0;
        GameManager.Instance.CountR = 0;
    }
}
