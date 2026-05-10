using UnityEngine;

public class EnemyStatsScript : MonoBehaviour
{

    public Animator animator;

    //EnemyStats
    public int health, attack;

    public AudioSource deathSound;

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

        //Death anim
        animator.SetBool("isDead", true);

        //plays sound
        deathSound.Play();

        //Disable the enemy
        GetComponent<Collider>().enabled = false; //Disables the collider
        GetComponent<EnemyAIScript>().isPatrol = false;
        GetComponent<EnemyAIScript>().isChase = false;
        GetComponent<EnemyAIScript>().isAttack = false;
        GetComponent<EnemyAIScript>().enabled = false;
        this.enabled = false; //disables this current script
    }
}
