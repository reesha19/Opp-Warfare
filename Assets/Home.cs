using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    // Static counter shared among all instances of this script
    private static int counter = 0;
    public GameObject check_imag;

    public AudioSource Sound;
    // UI Text element to display the counter
    public TextMeshProUGUI counterText;

    // Method called when the player enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Sound.Play();

            // Increment the counter
            counter+=10;
            Destroy(gameObject);
            if (counter == 100)
            {
                check_imag.SetActive(true); 
            }
            // Update the UI text element
            if (counterText != null)
            {
                counterText.text = "" + counter.ToString();
            }
        }
    }
}
