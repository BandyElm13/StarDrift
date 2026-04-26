using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float damage = 20f; private float lifetime = 5f;
    private float live = 5f;

    void Update()
    {
      Destroy(gameObject, live);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun")) return;

        if(other.CompareTag("Player")) {
            PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
            if(player != null)
            {
                player.takeDamage(damage);
            }
        } else if(other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.gameObject.GetComponentInParent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject, lifetime);
    }

}