using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private float horizontalMove;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float scaleX;
    internal static object instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
    }

    //tekan tombol kiri
    public void PointerDownLeft()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
        {
            GetComponent<Animator>().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        moveLeft = true;
    }
    
    //tidak tekan tombol kiri
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    //tekan tombol kanan
    public void PointerDownRight()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
        {
            GetComponent<Animator>().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        moveRight = true;
    }

    //tidak tekan tombol kanan
    public void PointerUpRight()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(jalan)"))
        {
            GetComponent<Animator>().SetTrigger("stop");
        }
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        //jika tekan tombol kiri
        if (moveLeft)
        {
            horizontalMove = -speed;
        }

        //jika tekan tombol kanan
        else if (moveRight){
            horizontalMove = speed;
        }

        //jika tidak tekan tombol gerak
        else
        {
            horizontalMove = 0;
        }
    }

    public void jumpButton()
    {
        if(rb.velocity.y == 0)
        {
            GetComponent<Animator>().SetTrigger("lompat");
            rb.velocity = Vector2.up * jumpSpeed;
        }
    }

    //tambah movement force ke player
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
