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
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer); //Checks if the player is on the right layer, if its in the sights range and if the position is in range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

    }

    void Chase()
    {
        agent.SetDestination(player.transform.position); //Causes the agent to go towards the players position
    }

    void Attack()
    {
        agent.SetDestination(transform.position); //Sets the destination to enemys current position, stopping them from moving 
    }

    void Patrol()
    {
        if (!walkPointSet) //If theres no walk point set:
        {
            SearchForDest();
        }

        if (walkPointSet)
        {
            agent.SetDestination(destPoint); //The agent will navigate towards the destination point given
        }

        if (Vector3.Distance(transform.position, destPoint) < 10) //If the distance between the enemy position and point is less than 10 units:
        {
            walkPointSet = false; //It sets the walk point bool to false and picks a new destination
        }
    }

    void SearchForDest() //This function will randomly choose a destination for the enemy on the nav mesh it's positioned on
    {
        float z = Random.Range(-walkRange, walkRange);
        float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z); //Picks random new position

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer)) //Checks if its inside the NavMesh area before applying new destination
        {
            walkPointSet = true;
        }
    }
}
