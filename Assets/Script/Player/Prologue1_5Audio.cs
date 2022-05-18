using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue1_5Audio : MonoBehaviour
{
    public string sfx1;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlayMusic("Hutan");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerWalkSfx.currentSfxName = sfx1;
        }
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown("l"))
    //    {
    //        PlayerWalkSfx.currentSfxName = sfx1;
    //    }
    //    if (Input.GetKeyDown("m"))
    //    {
    //        PlayerWalkSfx.currentSfxName = sfx2;
    //    }
    //}
}
