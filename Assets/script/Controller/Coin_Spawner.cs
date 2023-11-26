using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class Coin_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private float spawnDelay = 0;
    [SerializeField] private float StrawberryNumber = 1;
    private LogicController game;
    private float currentStrawBerryNumber;
    private float OffsetY;
    private float timer;

    public float CurrentStrawBerryNumber
    {
        get=> currentStrawBerryNumber;
        set => currentStrawBerryNumber = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<LogicController>();
        timer -= spawnDelay;
        OffsetY = -0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        { timer += Time.deltaTime; }
        else { 
            timer = 0;
            
            if (currentStrawBerryNumber < StrawberryNumber)
            {
                Instantiate(coin, new Vector3(Random.Range(-7, 7), OffsetY+Mathf.Round(Random.Range(0,1f))*14, transform.position.z), transform.rotation,GameObject.Find("bad_guys").transform);
                currentStrawBerryNumber++;
            }
        }
    }
}
