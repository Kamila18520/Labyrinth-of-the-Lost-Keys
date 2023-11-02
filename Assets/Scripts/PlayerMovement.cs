using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Animations")]
    public Animator PlayerAnim;


    [Header("Ground Check")]
    public LayerMask whatIsGround;
    public bool grounded;
    public Transform orientation;
    private float maxDistance;
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    public Rigidbody rb;



    private void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {  
        maxDistance = gameObject.transform.position.y;
        RaycastHit hit1; 
        Physics.Raycast(transform.position, Vector3.down, out hit1, maxDistance, whatIsGround);
        maxDistance = hit1.distance;


        RaycastHit hit2; 
        grounded = Physics.Raycast(transform.position, Vector3.down, out hit2 , maxDistance , whatIsGround);


        MyInput();
  

        if(grounded)
        {
            rb.drag = groundDrag;

        }
        else
        {
            rb.drag =  0;
        }
    }

    private void FixedUpdate()
    {

        if (grounded)
        {
        MovePlayer();
        }
       
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            RunAnim();
        }
        else
        {
            IdleAnim();
        }
        
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right* horizontalInput;

        
        if(grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed* 10f , ForceMode.Force);
            
        }
      // else if(!grounded) 
      // {
      //     rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
      //
      // }

    }

  
    private void RunAnim()
    {
        PlayerAnim.SetTrigger("Run");
        PlayerAnim.ResetTrigger("Idle");
    }
    private void IdleAnim()
    {
        PlayerAnim.SetTrigger("Idle");
        PlayerAnim.ResetTrigger("Run");
    }

}
