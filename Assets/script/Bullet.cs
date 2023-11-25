using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 50;
    [SerializeField] private float deadZone = 1500;

    float dirChangeTimeOut = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.position.x > deadZone)
        { Destroy(gameObject); } */
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        dirChangeTimeOut -= Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer ==3) { 
            Destroy(gameObject); 
        }
        if (collision.gameObject.layer == 6 && dirChangeTimeOut < 0)
        {
            moveSpeed = moveSpeed*-1;
            dirChangeTimeOut = 0.4f;
        }
    }
}
