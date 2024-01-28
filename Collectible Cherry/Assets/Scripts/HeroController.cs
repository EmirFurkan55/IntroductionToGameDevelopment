using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public Animator MyAnim;
    public Rigidbody2D MyRigbod;
    float x, y;
    public float MyMoveSpeed;
    public float JumpPower;
    public LayerMask GroundLayer;
    
    public bool isGrounded;
    public bool isFalling;

    public AudioSource JumpSoundEfect;
    



    private void Awake()
    {
        Application.targetFrameRate = 60;


    }
    void Start()
    {

    }


    void Update()
    {
        x = Input.GetAxis("Horizontal");
        FlipFunction();
        AnimatorMaster();
        CheckGround();
        CheckifFlying();
        CheckifFalling();
        if (isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.Space))

            {
                JumpSoundEfect.Play();
                MyRigbod.velocity = new Vector2(0, JumpPower);
                

            }
        }
        

    }


    void AnimatorMaster()
    {

        if (x != 0)
        {
            MyAnim.SetBool("Run", true);
            MyRigbod.velocity = new Vector2(x * MyMoveSpeed, MyRigbod.velocity.y);

        }


        else
        {
            MyAnim.SetBool("Run", false);
            MyRigbod.velocity = new Vector2(0, MyRigbod.velocity.y);

        }
        MyAnim.SetBool("Grounded", isGrounded);
        MyAnim.SetBool("Falling", isFalling);
        
    }


    void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.05f, GroundLayer);
    }


    void CheckifFalling()
    {
        if (MyRigbod.velocity.y < 0)
        {
            isFalling = true;

        }

        else
        {
            isFalling = false;


        }
    }


    void CheckifFlying()
    {
        if (MyRigbod.velocity.y > 0)
        {
            MyAnim.SetTrigger("Flying");
            
        }

        else
        {
            
        }
    }
    


    void FlipFunction()
    {
        if (transform.localScale.x > 0 && x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        else if (transform.localScale.x < 0 && x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }
    }
}
