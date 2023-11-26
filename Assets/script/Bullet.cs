using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 50;
    private GameObject EventSystem;
    private LogicController LogicController_instance;
    private Bullet_Spawner Bullet_Spawner_instance;
    // [SerializeField] private float deadZone = 1500;
    float dirChangeTimeOut = 0;

    void Start()
    {
        EventSystem = GameObject.FindGameObjectWithTag("GameController");
        Bullet_Spawner_instance = FindObjectOfType<Bullet_Spawner>();
        LogicController_instance = EventSystem.GetComponent<LogicController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.x > deadZone)
        { Destroy(gameObject); } */
        transform.position += Vector3.right * (moveSpeed * Time.deltaTime);

        dirChangeTimeOut -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer ==3) { 
            Destroy(gameObject);
            Bullet_Spawner_instance.spawnedNumber--;
        }
        if (collision.gameObject.layer == 6 && dirChangeTimeOut < 0)
        {
            moveSpeed = moveSpeed*-1;
            dirChangeTimeOut = 0.4f;
        }
    }
}
