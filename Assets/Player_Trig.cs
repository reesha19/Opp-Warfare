using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Trig : MonoBehaviour
{
    public static Player_Trig inst;
    public GameObject Home_penal;
    public GameObject Home_penaltrue;
    public GameObject Blood;

    private void Start()
    {
        PickGun.SetActive(true);
        Invoke("Pickgunoff",3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Home"))
        {
            Home_penal.SetActive(true);
        }
     if (other.gameObject.CompareTag("Home_Active"))
        {
            Home_penaltrue.SetActive(true);
        }

       
    }
    public GameObject PickGun;

   
       
    

    private void Pickgunoff()
    {
        PickGun.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Home"))
        {
            Home_penal.SetActive(false);
        }
        if (other.gameObject.CompareTag("Home_Active"))
        {
            Home_penaltrue.SetActive(false);
        }
    }

    public GameObject Home;
    public GameObject check;
    public GameObject P2;
    public void Creat_home()
    {
        check.SetActive(true);
        P2.SetActive(false);
        Home.SetActive(true);
        Home_penaltrue.SetActive(false);
    }

   
}
