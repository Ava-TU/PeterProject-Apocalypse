using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;

    BoxCollider boxCollider; //The attack collider box

    private Animator animator; //To play the animations

    [SerializeField]
    LayerMask groundLayer, playerLayer;

    //For Patrol
    Vector3 destPoint;
    bool walkPointSet;

    [SerializeField]
    float walkRange;

    //States
    [SerializeField]
    float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;

    [Header("States")]
    public bool isPatrol;
    public bool isChase;
    public bool isAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        //playerHealth = GetComponent<PlayerScript>();
        boxCollider = GetComponent<BoxCollider>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
