using UnityEngine;
using UnityEngine.UI;

public class PlayerCombatScript : MonoBehaviour
{

    public KeyCode playerAttack;
    public LayerMask enemyLayers;
    public Image ui_Hand;
    public Sprite attackHand;
    public Sprite idleHand;

    public Transform attackArea;
    public float attackRange;
    public int attackDamage;

    public float attackRate;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            ui_Hand.sprite = idleHand;
            if (Input.GetKeyDown(playerAttack))
            {
               Attack();
                nextAttackTime = Time.time + 1f / attackRate; //sets when the next time you can attack is
            }
        }
    }

    void Attack()
    {
        //Play attack animation
        ui_Hand.sprite = attackHand;

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
