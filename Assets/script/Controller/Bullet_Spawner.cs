using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buller_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private float EnemyNumber = 1;
    [SerializeField] private float OffsetX = 0;
    [SerializeField] private float OffsetY = 0.8f;
    private float spawnNumber = 0;
    private float spawnDelay = 0;
    private float timer;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnNumber = 0;
        timer -= spawnDelay;
        spawnPosition = transform.position;
        spawnPosition.y = spawnPosition.y - OffsetY;
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


            if (spawnNumber < EnemyNumber)
            {
                Instantiate(bullet, spawnPosition, transform.rotation);
                spawnNumber++;
            }
        }
    }
}
