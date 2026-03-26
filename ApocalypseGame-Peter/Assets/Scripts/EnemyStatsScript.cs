using UnityEngine;

public class EnemyStatsScript : MonoBehaviour
{

    //EnemyStats
    public int health, attack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //hurt animation?

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //Death anim?

        //Disable the enemy
        GetComponent<Collider>().enabled = false; //Disables the collider
        GetComponent<EnemyAIScript>().enabled = false;
        this.enabled = false; //disables this current script
    }
}
