using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public GameObject Game_Over;
    public bool mobileControl;
    
    private GameObject mobileCanvas;
    public TextMeshProUGUI display_Text;
    public GameObject info;
    private void Awake()
    {
        
        if (instace == null)
        {
            instace = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        
        info.SetActive(true);
        DontDestroyOnLoad(gameObject);
        mobileCanvas = GameObject.Find("MobileInput");
     //   if (!mobileControl) Cursor.lockState = CursorLockMode.Locked;
        mobileCanvas.SetActive(mobileControl);
        Application.targetFrameRate = 60;
    }
    public GameObject[] images;// Array to hold your images
    public GameObject Win_panel; // Panel to show when all images are true
    
    // Call this method to check if all images are true
   
    private void Update()
    {
        if (AreAllImagesActive())
        {
            Win_panel.SetActive(true);
        }
        else
        {
            Win_panel.SetActive(false);
        }
       // CheckImages();
        float current = 0;
        current = Time.frameCount / Time.time;
        var avgFrameRate = (int)current;
        if (display_Text != null)
            display_Text.text = avgFrameRate.ToString() + " FPS";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_peal.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            info_peal.SetActive(true);
            Time.timeScale = 0;
        }
    }
    bool AreAllImagesActive()
    {
        // Check if all images are active
        foreach (GameObject image in images)
        {
            if (!image.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    public void retart()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(currentScene.name);
    Time.timeScale = 1;
    } 
    public void Manu()
    {
        Time.timeScale = 1;
    SceneManager.LoadScene("Manu");
    
    }

    public void Pausebtn()
    {
        
        Time.timeScale = 0;
      
    }
    public void Resumebtn()
    {
        
        Time.timeScale = 1;
    }

    public GameObject Pause_peal;
    public GameObject info_peal;

    public void Keycode_pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause_peal.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            info_peal.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
}
