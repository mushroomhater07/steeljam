using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buller_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float spawnRate = 0;
    [SerializeField] private float EnemyNumber;
    [SerializeField] private float OffsetX = 0;
    [SerializeField] private float OffsetY;
    private float spawnedNumber = 0;
    private float spawnDelay = 0;
    private float timer;
    private Vector3 spawnPosition;
    private Vector3 newspawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnedNumber = 0;
        timer -= spawnDelay;
        spawnPosition = transform.position;
        spawnPosition.y += OffsetY;
        newspawnPosition = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;


            if (spawnedNumber < EnemyNumber)
            {
                Debug.Log(spawnPosition.y);
                newspawnPosition.x = spawnPosition.x + 5 + Random.Range(-7, 9);
                Instantiate(bullet, newspawnPosition, transform.rotation);
                spawnedNumber++;
            }
        }
    }
}
