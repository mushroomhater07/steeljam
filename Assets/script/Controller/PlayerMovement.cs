
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator ani;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float jumpPower = 1;

    [SerializeField] private float monsterDMG;
    private float horizontal;
    // private bool alive = true;

    [SerializeField] private Rigidbody2D playerRigid;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public InputAct.GameActions actionmaps;
    private LogicController logic;
    public void EnableSwitch(bool yes)
    {
        if (yes) actionmaps.switch1.Enable();
        else actionmaps.switch1.Disable();
        logic.CoolDownDoneText.enabled = yes;
    }
    void Awake()
    {
        ani = GetComponent<Animator>();
        logic = FindObjectOfType<LogicController>();
        actionmaps = new InputAct().Game;
        actionmaps.Enable();
        actionmaps.switch1.performed += ctx => logic.ChangeDimension();
    }
    void Update()
    {
        // if (alive)
        // {
            // horizontal = Input.GetAxis("Horizontal")
            // Input.GetButtonUp("Jump")
            if (actionmaps.Jump.triggered && IsGrounded()) playerRigid.velocity = new Vector2(playerRigid.velocity.x, jumpPower);
            if (actionmaps.Jump.triggered && IsGrounded()) ani.SetTrigger("jump");//animator
            if (actionmaps.Jump.triggered && playerRigid.velocity.y > 0f) playerRigid.velocity = new Vector2(playerRigid.velocity.x, playerRigid.velocity.y * 0.5f);
            if(playerRigid.gameObject.transform.position.y < -10f) logic.GameOver();
        
    }

    public void DieAnimation(bool yes)
    {
        ani.SetBool("die",yes);
    }
    private void FixedUpdate() { playerRigid.velocity = new Vector2(actionmaps.Walk.ReadValue<float>() * moveSpeed, playerRigid.velocity.y); if(Mathf.Abs(actionmaps.Walk.ReadValue<float>())>0)ani.SetBool("run", true);else ani.SetBool("run",false); }
    private bool IsGrounded() { return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            // alive = false;
            // playerRigid.velocity = new Vector2(0, -5);
            // Destroy(gameObject.GetComponent<BoxCollider2D>());
            logic.AdjustHealth(monsterDMG * -1f);
            ani.SetTrigger("damage");
        }
    }
}
