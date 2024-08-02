using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public static Health inst;
    
    [Header("Health UI")]
    [SerializeField]
    private Image _healthUI;

    public float CurrrentHealth;

    private float maxHealth;
    public Animator Player;
    public GameObject Alert_Penal;
    public AudioSource Player_death;
 

    private void Start()
    {
        //PickGun = GameObject.Find("guN");
        inst = this;
        GameObject zombie = GameObject.Find("Zombie");
        if (zombie != null)
        {
            Player_D = zombie.GetComponent<AudioSource>();
        } 
        GameObject plaerdeath = GameObject.Find("Death");
        if (plaerdeath != null)
        {
            Player_death = zombie.GetComponent<AudioSource>();
        }
        maxHealth = CurrrentHealth;
        if (_healthUI != null)
            _healthUI.fillAmount = CurrrentHealth / maxHealth;
       
    }

    // public void ApplyDamage(float damage)
    // {
    //     if (CurrrentHealth > 0)
    //     {
    //         CurrrentHealth -= damage;
    //         if (_healthUI != null)
    //             _healthUI.fillAmount = CurrrentHealth / _maxHealth;
    //     }
    // }
    public void ApplyDamage1(float damage)
    {
        if (CurrrentHealth > 0)
        {
            CurrrentHealth -= damage;
            if (_healthUI != null)
                _healthUI.fillAmount = CurrrentHealth / maxHealth;

        if (CurrrentHealth <= 0)
        {
            
            Player.SetTrigger("Death");
            Invoke("onGMAEOVER",1.5f);
        }
      
        }
        
    }
    public AudioSource Death;
    public void Deadman()
    {
        if (CurrrentHealth <= 0)
        {
            if (Player_death != null)
            {
                Player_death.Play();
            }
           // Death.Play();
            Player.SetTrigger("Death");
            Invoke("onGMAEOVER",1.5f);
        }
    }
    public void Dead1()
    {
        if (Player_death != null)
        {
            Player_death.Play();
        }
      //  Death.Play();
        Player.SetTrigger("Death");
        Invoke("onGMAEOVER",1.5f);
    }

  
    
    public AudioSource Player_D;
    public void ApplyDamage2(float damage)
    {
        if (CurrrentHealth > 0)
        {
          
            CurrrentHealth -= damage;
            if (_healthUI != null)
                _healthUI.fillAmount = CurrrentHealth / maxHealth;

            if (CurrrentHealth <= 0)
            {
                
                if (Player_D != null)
                {
                    Player_D.Play();
                }
            GetComponent<Animator>().SetTrigger("dead");
            GetComponent<NavMeshAgent>().enabled=false;
              Invoke("Dead",2);
            }
      
        }
        
    }

    public void Dead()
    {
        Destroy(gameObject);
    }
    public void onGMAEOVER()
    {
        
            GameManager.instace.Game_Over.SetActive(true);
    }
}
