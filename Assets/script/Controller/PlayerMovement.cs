
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpPower = 1;

    [SerializeField] private float monsterDMG;
    private float horizontal;
    private bool alive = true;

    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    InputAct.GameActions actionmaps;

    void Start()
    {
        actionmaps = new InputAct().Game;
        actionmaps.Enable();
        
    }
    void Update()
    {
        if (alive)
        {
            // Debug.Log(Input.GetAxis("Horizontal"));
            horizontal = actionmaps.Walk.ReadValue<float>();
            // Input.GetButtonUp("Jump")
            if (actionmaps.Jump.triggered && IsGrounded())
            {
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpPower);
            }

            if (actionmaps.Jump.triggered && playerRigid.velocity.y > 0f)
            {
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, playerRigid.velocity.y * 0.5f);
            }
        }
    }
    private void FixedUpdate() { playerRigid.velocity = new Vector2(horizontal * moveSpeed, playerRigid.velocity.y); }
    private bool IsGrounded() { return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            // alive = false;
            // playerRigid.velocity = new Vector2(0, -5);
            // Destroy(gameObject.GetComponent<BoxCollider2D>());
            FindObjectOfType<LogicController>().AdjustHealth(monsterDMG * -1f);
        }
    }
}
