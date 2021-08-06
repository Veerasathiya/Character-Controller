using UnityEngine;
using System.Collections;

public class PlayerMoment : MonoBehaviour
{
    private Animator playerAnim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    

    private CharacterController controller;
    private Vector3 velocity;

    [SerializeField] private bool isGround;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private float jumpHeight;



    private Vector3 moveDirection;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Move();
    }

    

    void Move()
    {
        isGround = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");
    

        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);
        
       

        if(isGround)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if(moveDirection == Vector3.zero)
            {
                Idle();
            }
            moveDirection *= moveSpeed;


            if(Input.GetKeyDown(KeyCode.Space))
            {
                
                Jump(); 
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                
            }
            if (Input.GetKeyDown("q"))
            {
                Attack2();
             
            }

        }

                

        
        controller.Move(moveDirection * Time.deltaTime);

        velocity.y +=gravity *20* Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    void Idle()
    {
        playerAnim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }
    void Walk()
    {
        moveSpeed = walkSpeed;
        playerAnim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);


    }
    void Run()
    {
        moveSpeed = runSpeed;

        playerAnim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }
     
    private void Jump()
    {
        if(Input.GetKey("w") && Input.GetKey(KeyCode.Space))
        {
            Walk();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            playerAnim.SetTrigger("Jump");

        }else if(Input.GetKey("w") && Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            playerAnim.SetTrigger("Jump");
        }else if(Input.GetKey(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            playerAnim.SetTrigger("Jump");

        }

    }

    private void Attack()
    {

        playerAnim.SetTrigger("Attack");

        
    }

    private void Attack2()
    {
        //playerAnim.SetLayerWeight(playerAnim.GetLayerIndex("Jumb Layer"), 1);
        playerAnim.SetTrigger("Attack02");

        //yield return new WaitForSeconds(1f);
        //playerAnim.SetLayerWeight(playerAnim.GetLayerIndex("Jumb Layer"), 0);

    }



}
