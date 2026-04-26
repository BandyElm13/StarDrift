using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
        public float maxhealth = 100f;
        public float currentHealth;
        public float enemyDamage = 20f;
        public float speed = 2.5f;
        [SerializeField] private Slider EnemySLider;
    void Start()
    {
        currentHealth = maxhealth;
        EnemySLider.maxValue = maxhealth;
        EnemySLider.value = currentHealth;;
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxhealth);
        EnemySLider.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        EnemyDieKeySpawnOrSomething wes = GetComponent<EnemyDieKeySpawnOrSomething>();
        if(wes != null)
        {
            wes.spawnKey();

        }
        gameObject.SetActive(false);
        
    }
}
