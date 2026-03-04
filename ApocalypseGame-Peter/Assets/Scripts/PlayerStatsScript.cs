using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsScript : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = "HP: " + currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
