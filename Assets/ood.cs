using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ood : MonoBehaviour
{
    private static int counter = 0;

    public GameObject image_check;
    public GameObject P1;
    public GameObject P2;
    // UI Text element to display the counter
    public TextMeshProUGUI counterText;

    public AudioSource Sound;
    // Method called when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            Sound.Play();
            // Increment the counter
            counter+= 10;
            Destroy(gameObject);
            if (counter ==100)
            {
                image_check.SetActive(true);
                P1.SetActive(false);
                P2.SetActive(true);
                
            }
            // Update the UI text element
            if (counterText != null)
            {
                counterText.text = "" + counter.ToString();
            }
        }
    }
}
