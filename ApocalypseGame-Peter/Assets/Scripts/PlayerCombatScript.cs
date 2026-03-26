using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{

    public KeyCode playerAttack;
    public LayerMask enemyLayers;

    public Transform attackArea;
    public float attackRange = 0.5f;
    public int attackDamage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(playerAttack))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        //Detect enemies in range
        //the collider stores all the detected enemies we hit in the named variable
        Collider[] hitEnemies = Physics.OverlapSphere(attackArea.position, attackRange, enemyLayers); //creates a sphere to detect if an enemy is being collided with

        //Damage enemies
        foreach(Collider enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<EnemyStatsScript>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackArea == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackArea.position, attackRange); //this will just display the hit box of the player attack to easily edit it if needed
    }
}
