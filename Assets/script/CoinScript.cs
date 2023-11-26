using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    [SerializeField] private Coin_Spawner spawner;
    [SerializeField] private float StrawBerryHeal;
    private GameObject EventSystem;
    private Coin_Spawner Coin_Spawner_instance;
    private LogicController LogicController_instance;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.FindGameObjectWithTag("GameController");
        Coin_Spawner_instance = EventSystem.GetComponent<Coin_Spawner>();
        LogicController_instance = EventSystem.GetComponent<LogicController>();
        foreach (var VARIABLE2 in FindObjectsOfType<CoinScript>())
        {
            VARIABLE2.gameObject.GetComponent<SpriteRenderer>().enabled = !LogicController_instance.nether;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        { 
            Destroy(gameObject);
            Coin_Spawner_instance.CurrentStrawBerryNumber--;
            LogicController_instance.AddScore();
            LogicController_instance.AdjustHealth(StrawBerryHeal);
        }
    }
}
