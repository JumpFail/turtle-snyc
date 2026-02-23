using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Sprite emptyTurtle;
    public Sprite fullTurtle;
    public Image[] turtles;

    public PlayerHealth playerHealth;

    void Start()
    {
        
    }

    void Update()
    {

        health = playerHealth.currentHealth;
        maxHealth = playerHealth.maxHealth;
        
        for (int i=0; i < turtles.Length; i++)
        {
            if(i < health)
            {
                turtles[i].sprite = fullTurtle;
            }
            else
            {
                turtles[i].sprite = emptyTurtle;
            }
            if(i < maxHealth)
            {
                turtles[i].enabled = true;
            }
            else
            {
                turtles[i].enabled = false;
            }
        }
    }
}

// link with main player