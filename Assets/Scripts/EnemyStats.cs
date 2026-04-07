using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
        public float maxhealth = 100f;
        public float currentHealth;
        public float damage = 20f;
        public float speed = 2.5f;
    [SerializeField] private Slider EnemySLider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxhealth;
        EnemySLider.maxValue = maxhealth;
        EnemySLider.value = currentHealth;
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(maxhealth, 0, currentHealth);
        EnemySLider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
