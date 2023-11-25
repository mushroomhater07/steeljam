using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buller_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float spawnRate = 3;
    private float spawnDelay = 2;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer -= spawnDelay;   
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
