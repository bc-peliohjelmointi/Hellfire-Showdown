using UnityEngine;
using UnityEngine.SceneManagement;   // <-- Needed for scene switching

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

        // Update UI on start (safe if UI is missing)
        if (UIHealthBar.instance != null)
            UIHealthBar.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log($"Player took {amount} damage. Current health: {currentHealth}");

        // Update health bar
        if (UIHealthBar.instance != null)
            UIHealthBar.instance.UpdateHealthBar(currentHealth, maxHealth);

        // Check death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Player healed {amount}. Current health: {currentHealth}");

        // Update health bar
        if (UIHealthBar.instance != null)
            UIHealthBar.instance.UpdateHealthBar(currentHealth, maxHealth);
    }

    void Die()
    {
        Debug.Log("Player died!");

        // Load the death screen scene
        SceneManager.LoadScene("DeathScreen");
        // Make sure "DeathScreen" is added to Build Settings!
    }
}
