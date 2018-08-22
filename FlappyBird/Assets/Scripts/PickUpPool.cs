using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPool : MonoBehaviour {

    public int pickUpPoolSize;
    public GameObject pickUpPrefab;
    public float spawnRate;
    public float pickUpMin;
    public float pickUpMax;

    private GameObject[] pickUps;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentpickUp = 0;

    // Use this for initialization
    void Start()
    {

        timeSinceLastSpawned = 0f;

        pickUps = new GameObject[pickUpPoolSize];
        for (int i = 0; i < pickUpPoolSize; i++)
        {

            pickUps[i] = (GameObject)Instantiate(pickUpPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
        {

            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(pickUpMin, pickUpMax);
            pickUps[currentpickUp].SetActive(true);
            pickUps[currentpickUp].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentpickUp++;
            if (currentpickUp >= pickUpPoolSize)
            {

                currentpickUp = 0;
            }
        }
    }
}
