using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStatsScript : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;

    public Slider healthBar;

    public int deathSceneIndex;

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
        //This changes the value of the slider to the current health value
        healthBar.value = currentHealth;
        healthText.text = "HP: " + currentHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            healthText.text = "HP: " + currentHealth;
            print("Dead!");
            SceneManager.LoadScene(deathSceneIndex);
        }
    }
}
