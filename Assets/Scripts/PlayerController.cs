using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator controller;

    public float WalkSpeed = 1f;

    private float rotSpeed = 80f;
    private float rot = 0f;


    private void Start()
    {
        controller = GetComponent<Animator>();
    }
    void WJump()
    {
        controller.SetBool("WalkJump", false);
    }
    private void FixedUpdate()
    {
     
        if(Input.GetKeyDown(KeyCode.Space))
        {
            controller.SetBool("Jump", true);
            
            
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            controller.SetBool("Jump", false);
        }

        if(Input.GetKey("w"))
        {
            controller.SetBool("Walk", true);
            transform.Translate(Vector3.forward * WalkSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.SetBool("WalkJump", true);


            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Invoke("WJump", 0.5f);
            }



        }
        else if(!Input.GetKeyUp("w"))
        {
            controller.SetBool("Walk", false);
        }


        if (Input.GetKey("s"))
        {
            controller.SetBool("Walk", true);
            transform.Translate(-Vector3.forward * 1 * Time.deltaTime);
        }
        else if(Input.GetKeyUp("s"))
        {
            controller.SetBool("Walk", false);
        }

        if(Input.GetKey("r"))
        {
            controller.SetBool("Run", true);
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }else
        {
            controller.SetBool("Run", false);
        }

        if(Input.GetKeyDown("q"))
        {
            controller.SetBool("SpellCast02", true);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }
        else
        {
            controller.SetBool("SpellCast02", false);
        }

        if(Input.GetKey("d"))
        {
            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);
            controller.SetBool("Walk", true);

        }else if(Input.GetKeyUp("d"))
        {
            controller.SetBool("Walk", false);
        }

        if (Input.GetKey("a"))
        {
            rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, rot, 0);
            controller.SetBool("Walk", true);

        }else if(Input.GetKeyUp("a"))
        {
            controller.SetBool("Walk", false);
        }

    }
}
