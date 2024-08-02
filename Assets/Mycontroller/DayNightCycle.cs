using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    
    
    public Image hungerBar;
    public float maxHunger = 100f;
    public float currentHunger;
    private float hungerReductionInterval = 90f; // 1.5 minutes in seconds
    private float hungerElapsedTime = 0f;

    public Material daySkybox;
    public Material nightSkybox;
    public float cycleDuration = 180f; // 3 minutes in seconds
    public TextMeshProUGUI timeText; // Reference to the UI Text for time
    public TextMeshProUGUI dayText;  // Reference to the UI Text for day number
    public Light directionalLight; // Reference to the directional light
    
    public Color dayLightColor = Color.white; // Day light color
    public Color nightLightColor = Color.blue; // Night light color

    private float halfCycleTime;
    private float elapsedTime = 0f;
    private bool isDay = true;
    private int dayNumber = 1;
    public GameObject[] foodPrefabs; // Array to hold your food prefabs
    public Transform[] spawnPoints; // Array of spawn points for the food prefabs
    public float spawnInterval = 120f; // Time interval between spawns in seconds
    public int minFoodCount = 5; // Minimum number of food prefabs to spawn
    public int maxFoodCount = 6; // Maximum number of food prefabs to spawn
    public int hungerIncrease = 10;
    public GameObject servive_check;
   //
   
    void Start()
    {
        
        
        halfCycleTime = cycleDuration / 2f; // 1.5 minutes
        RenderSettings.skybox = daySkybox;
        directionalLight.color = dayLightColor;
        currentHunger = maxHunger;
        UpdateUI();
        UpdateHungerBar();
        InvokeRepeating("SpawnFood", 0f, spawnInterval);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        hungerElapsedTime += Time.deltaTime;

        if (elapsedTime >= halfCycleTime && isDay)
        {
            ChangeToNight();
        }
        else if (elapsedTime >= cycleDuration)
        {
            ResetCycle();
        }
        if (currentHunger > 0)
        {
            currentHunger -= maxHunger / 180 * Time.deltaTime;
            hungerBar.fillAmount = currentHunger;
        }
        else
        {
            currentHunger = 0;
            hungerBar.fillAmount = currentHunger;
        }

        if (currentHunger <= 0.5f && !isAlertShown)
        {
            alertPanel.SetActive(true);
            isAlertShown = true; // Set the flag to true to indicate alert has been shown
            Invoke("offALertpenal", 2f);
        }
        if (currentHunger <= 0f)
        {
            Health.inst.Dead1();
        }
        // if (hungerElapsedTime >= hungerReductionInterval)
        // {
        //     ReduceHunger();
        //     hungerElapsedTime = 0f;
        // }

        UpdateUI();
    }

    public GameObject alertPanel;
    private bool isAlertShown = false;
    private void offALertpenal()
    {
        alertPanel.SetActive(false);
    }
    void ReduceHunger()
    {
        currentHunger = Mathf.Max(0, currentHunger -100f);
        UpdateHungerBar();
        if (currentHunger <= 50f && !isAlertShown)
        {
           // StartCoroutine(ShowAlertPanel());
            isAlertShown = true;
        } 
        if (currentHunger <= 0f)
        {
            Health.inst.Dead1();
        }
    }

    void UpdateHungerBar()
    {
        hungerBar.fillAmount = currentHunger / maxHunger;
    }
    void ChangeToNight()
    {
        RenderSettings.skybox = nightSkybox;
        directionalLight.color = nightLightColor;
        isDay = false;
    }

    void ResetCycle()
    {
        elapsedTime = 0f;
        RenderSettings.skybox = daySkybox;
        directionalLight.color = dayLightColor;
        isDay = true;
        dayNumber++;
        if (dayNumber == 5)
        {
            servive_check.SetActive(true);
        }
    }
    public void IncreaseHunger(int amount)
    {
        currentHunger = Mathf.Min(maxHunger, currentHunger + amount);
        UpdateHungerBar();
    }
    private void SpawnFood()
    {
        int foodCount = Random.Range(minFoodCount, maxFoodCount + 1);
        for (int i = 0; i < foodCount; i++)
        {
            GameObject foodPrefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(foodPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    void UpdateUI()
    {
        // Calculate the current hour and minute in the 24-hour cycle
        float totalHours = (elapsedTime / cycleDuration) * 24f;
        int currentHour = Mathf.FloorToInt(totalHours);
        int currentMinute = Mathf.FloorToInt((totalHours - currentHour) * 60f);

        // Update the UI text elements
        timeText.text = string.Format("{0:D2}:{1:D2}", currentHour, currentMinute);
        dayText.text = "" + dayNumber;
    }

}
