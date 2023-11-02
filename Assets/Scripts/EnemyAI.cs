using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [Header("Player/Enemy")]
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Animator enemyAnimator;

    [Header("Attacking")]
    public float timeBetweenAttacks = 5f;
    bool alreadyAttacked;
    private float timePlayerInAttackRange = 0f;
    private float requiredTimeInAttackRange = 1.5f; // Wymagany czas w zasiêgu ataku

    [Header("States")]
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [Header("EndGame")]
    public GameObject GamePlay;
    public GameObject LoseScreen;
    public GameObject Menu;



    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();


    }

    private void Update()
    {

        Vector3 currentPosition = transform.position;
        currentPosition.y = 0; // Ustaw sta³¹ wartoœæ Y
        
        transform.position = currentPosition;


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange)
        {
            enemyAnimator.SetTrigger("LookingAround");
            enemyAnimator.ResetTrigger("OrcWalk");
            timePlayerInAttackRange = 0f;

        }
        else if (playerInSightRange && !playerInAttackRange)
        {
            timePlayerInAttackRange = 0f;
            ChasePlayer();
        }
        else if (playerInSightRange && playerInAttackRange)
        {
            timePlayerInAttackRange += Time.deltaTime;
            if (timePlayerInAttackRange >= requiredTimeInAttackRange)
            {
                
                Debug.Log("Gracz jest w zasiêgu ataku przez co najmniej "+ requiredTimeInAttackRange + " sekundy.");
                EndGame();
                
            }

            AttackPlayer();
        }

    }

    private void EndGame()
    {   
        Cursor.visible = true;
        Menu.SetActive(true);
        LoseScreen.SetActive(true);
        GamePlay.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

        Invoke("ReloadScene", 3f);

    }

    private void ReloadScene()
    {
        
        SceneManager.LoadScene(0);
    }



    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        enemyAnimator.SetTrigger("OrcWalk");
        enemyAnimator.ResetTrigger("LookingAround");
    }
    private void AttackPlayer()
    {

        enemyAnimator.SetTrigger("Attack");
        enemyAnimator.ResetTrigger("OrcWalk");

        //transform.LookAt(player);

        if(!alreadyAttacked) 
        {

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked= false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
