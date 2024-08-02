
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MyEnemy : MonoBehaviour
{
    public static MyEnemy instance;
    private NavMeshAgent agent; // Reference to the agent
    private Animator anim; // Reference to the agent
    public float roamRadius = 10f;

    private int currentWaypointIndex = 0;

    public float viewRadius = 10f;
    [Range(0, 360)]
    public float viewAngle = 90f;
    
    
    public float playerDist;

    public LayerMask playerLayer;
    public LayerMask targetMaskNew;
    public LayerMask obstacleMask;

    public Transform visibleTarget;
     public float attackDistanceSquared = 4f;
    public Camera mainCamera;
    private bool playerInRadius = false;
    private bool playerAtack= false;
    private Collider[] targetsInViewRadius;
    public string blood;
    public AudioSource Player_Damege;
    private void Start()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
        visibleTarget = GameObject.Find("Player").transform;

        Bloody = GameObject.Find("Blood");
        //Player_D = GameObject.Find("Player_DAmage");
//       Bloody= Player_Trig.inst.Blood;
        //GenerateWaypoints();

        GameObject zombie = GameObject.Find("PLayer_DAmage");
        if (zombie != null)
        {
            Player_Damege = zombie.GetComponent<AudioSource>();
        }
               
            
        
     
        StartCoroutine(RoamCoroutine());
      
    }
    private float roamDelay = 0.5f; // Adjust the delay as needed
    private Vector3 temp;
    private bool first;
    public GameObject Bloody;
    private IEnumerator RoamCoroutine()
    {
        while (true)
        {
            if (!playerInRadius)
            {
                anim.SetFloat("walk", 1);
               
                float distanceToTarget = Vector3.Distance(agent.transform.position, visibleTarget.position);

                if (distanceToTarget <= playerDist)
                {
                    anim.SetTrigger("attack-1");
                    
                      targetsInViewRadius = Physics.OverlapSphere(transform.position, 2, playerLayer);
                     if (targetsInViewRadius.Length > 0)
                     {
                         
                         float distToTargetSquared = (visibleTarget.position - transform.position).sqrMagnitude;
                         
                         print("dist"  + distToTargetSquared);
                         if (distToTargetSquared <= attackDistanceSquared && playerAtack)
                         {
                             playerAtack=false;
                             
                             // Perform attack or other actions
                             AttackPlayer();
                         }
                     }
                     // Bloody.SetActive(true);
                    // Invoke("bloodyoff",0.5f);
                   // temp=   SpawnAgentOnNavMesh();
              }
                else
                {
                    targetsInViewRadius = null;
                    anim.SetTrigger(AIConstants.IsAttacking);

                        anim.SetFloat(AIConstants.Speed, 1, 0.1f, Time.deltaTime);
                   
                   
                   
                }

                if (agent.enabled == true)
                {
                    
                    agent.SetDestination(visibleTarget.position);
                }
         

          

                // Use the timer for delay
                float timer = 0f;
                while (timer < roamDelay)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
               
                agent.speed = 2f;
            }
            else
            {
                yield return null;
            }
        }
    }

    private void bloodyoff()
    {
        Bloody.GetComponent<Image>().enabled = false;
        if (Player_Damege != null)
        {
            Player_Damege.Stop();
        }
        //Player_D.Stop();
    }
    float timer;
    float timerforPlayer=1f;
    

    private void AttackPlayer()
    {
        Bloody.GetComponent<Image>().enabled = true;
        if (Player_Damege != null)
        {
            Player_Damege.Play();
        }
      //  Player_D.Play();
        
         Invoke("bloodyoff",0.5f);
         
        visibleTarget.GetComponent<Health>().ApplyDamage1(5);
      
  }
    private void AttackCor()
    {
        playerAtack=true;
    }
   
   
   
}

    
