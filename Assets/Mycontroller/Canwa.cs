using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canwa : MonoBehaviour
{

    public GameObject Manu;
    public GameObject Loading;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadingof",4f);
    }

    private void loadingof()
    {
        Manu.SetActive(true);
        Loading.SetActive(false);
    }

    public void Load_Scene()
    {
        SceneManager.LoadScene("Forest");
    }
    public void Load_Scene1()
    {
        SceneManager.LoadScene("Flooded");
    } // Update is called once per frame
    void Update()
    {
        
    }
}
