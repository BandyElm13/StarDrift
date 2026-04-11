using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
        [SerializeField] private float maxHealth = 10;
        private float currentHealth;

        [SerializeField] private Slider healthBar;
        [SerializeField] private string dead;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
    }

    private void PlayerDeath()
    {
        if(currentHealth == 0)
        {
            SceneManager.LoadScene(dead);
        }
    }
    public void testDamage()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            currentHealth -= 10;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {
        testDamage();
        PlayerDeath();
    }

}
