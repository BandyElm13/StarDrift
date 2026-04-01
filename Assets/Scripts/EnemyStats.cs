using UnityEngine;
using UnityEngine.Rendering;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
        public float health = 100f;
        public float currentHealth;
        public float damage = 20f;

        public float speed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
