using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float boundZ = 10.0f;
    private float waitingTime = 3.0f;
    [SerializeField] GameObject spawnPrefab;
    private Vector3 spawnPosition;

    public void StartGame()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitingTime);
        spawnPosition = new Vector3(5.4f, 18.0f, Random.Range(-boundZ, boundZ));
        Instantiate(spawnPrefab, spawnPosition, transform.rotation);
        StartCoroutine(Wait());
    }
}
