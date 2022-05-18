using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Animator anim;
    public float kecepatan;
    private float scaleX;
    private Rigidbody2D rb;
    public float loncat;
    bool isJumping;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    public void jalan_kiri()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
        {
                GetComponent<Animator>().SetTrigger("jalan");
        }
        
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    public void jalan_kanan()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
        {
                GetComponent<Animator>().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.right * kecepatan * Time.fixedDeltaTime, Space.Self);
    }

    public void melompat()
    {
        if (!isJumping)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
            {
                player.GetComponent<Animator>().SetTrigger("lompat");
            }
        }
        if (!isJumping)
        {
            if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
            {
                GetComponent<Animator>().SetTrigger("lompat");
            }
        }
        rb.AddForce(new Vector2(0, loncat));
    }

    public void berhenti()
    {
        if (!isJumping)
        {
            GetComponent<Animator>().SetTrigger("stop");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jalan_kiri();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            jalan_kanan();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            berhenti();
        }
    }
}
