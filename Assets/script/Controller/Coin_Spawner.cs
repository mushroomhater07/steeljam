using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private float spawnDelay = 0;
    [SerializeField] private float StrawberryNumber = 1;
    private LogicController game;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<LogicController>();
        timer -= spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        { timer += Time.deltaTime; }
        else { 
            timer = 0;
            
            if (game.spawnNumber < StrawberryNumber)
            {
                Instantiate(coin, new Vector3(Random.Range(-7, 7), transform.position.y, transform.position.z), transform.rotation);
                game.AddStrawberry();
            }
        }
    }
}
