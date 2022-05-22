using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    private void Awake()
    {
        PlayerPrefs.SetInt("healthplayer", currentHealth);
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        currentHealth = maxHealth;
        currentHealth = PlayerPrefs.GetInt("healthplayer");
    }
}
