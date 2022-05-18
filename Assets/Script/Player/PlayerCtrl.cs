using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// make the player move left/right
/// </summary>
public class PlayerCtrl : MonoBehaviour
{

    public int speedBoost;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = Input.GetAxisRaw("Horizontal"); //value will be 1, -1 or 0
        playerSpeed *= speedBoost;
        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();
    }
    void MoveHorizontal(float playerSpeed)
    {
            rb.velocity = new Vector2(playerSpeed,rb.velocity.y);
    }

    // Update is called once per frame
    void StopMoving()
    {

    }
}