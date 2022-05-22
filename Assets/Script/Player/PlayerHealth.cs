using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHealth = 100;
    public static int currentHealth ;

    public HealthBar healthBar;
    private Vector3 respawnPoint;


    private void Awake()
    {
        PlayerPrefs.SetInt("healthplayer", currentHealth);

        currentHealth = PlayerPrefs.GetInt("healthplayer");
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        PlayerPrefs.SetInt("healthplayer", currentHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }

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

    void SaveHealth()
    {
        PlayerPrefs.SetInt("healthplayer", currentHealth);
    }
}
