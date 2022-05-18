using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jalan : MonoBehaviour
{
    public float kecepatan;
    private float scaleX;
    public float lompat;

    void Start()
    {
        scaleX = transform.localScale.x;
    }

    public void jalankiri()
    {
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("pedang(idle)"))
        {
            GetComponent<Animator>().SetTrigger("jalan");
        }
        transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate(Vector3.left * kecepatan * Time.fixedDeltaTime, Space.Self);
    }
    public void jalankanan()
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, lompat);
    }

    public void berhenti()
    {
        GetComponent<Animator>().SetTrigger("stop");
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jalankiri();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            jalankanan();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            berhenti();
        }

    }
}
