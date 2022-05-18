using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    private Animator anim;
    private GameObject head;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt Animation

        if(currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
        }
    }
     
    void Die()
    {
        Debug.Log("Enemy died!!");
    }
}
