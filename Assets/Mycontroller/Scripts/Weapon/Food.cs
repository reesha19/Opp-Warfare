using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public DayNightCycle game; // Reference to the GameManager script
    public GameObject game1; // Reference to the GameManager script
    public AudioSource Eat_food_sound;
    private void Start()
    {
        GameObject eatfood = GameObject.Find("food_eat");
        if (eatfood != null)
        {
            Eat_food_sound = eatfood.GetComponent<AudioSource>();
        }
        game = GameObject.Find("GameManager").GetComponent<DayNightCycle>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure this is triggered by the player
        {
            if (Eat_food_sound != null)
            {
                Eat_food_sound.Play();
            }
            Eat_food_sound.Play();
                game.currentHunger += 0.08f;
                Destroy(gameObject);
            }
        
    }
}
