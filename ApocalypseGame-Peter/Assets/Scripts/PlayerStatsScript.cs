using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsScript : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;

    public KeyCode loseHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set current health to the max health at start of scene
        currentHealth = maxHealth;
        //Changes the health display text to current health.
        healthText.text = "HP: " + currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //TO TEST OUT HEALTH LOSS FOR BUILD
        if (Input.GetKeyDown(loseHealth))
        {
            currentHealth -= 10;
            healthText.text = "HP: " + currentHealth;
            print("Lost Health!");
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthText.text = "HP: " + currentHealth;
            print("Dead!");
        }
    }
}
