using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    private Vector3 respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }

        if (other.CompareTag("Enemy2"))
        {
            currentHealth -= 15;

            healthBar.SetHealth(currentHealth);
        }

        if (other.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            currentHealth -= 25;
            healthBar.SetHealth(currentHealth);
        }
        else if (other.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 10;

        healthBar.SetHealth(currentHealth);
    }
}
