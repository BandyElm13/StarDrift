using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 2.5f;
    private float playerdamage = 50f;

    private float enemydamage = 25f;
    private float live = 5f;
    void Update()
    {
      Destroy(gameObject, live);
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats player = other.gameObject.GetComponent<PlayerStats>();
        if (other.CompareTag("Gun")) return;

        if(other.CompareTag("Player")) {
            if(player != null)
            {
                player.takeDamage(enemydamage);
            }
        } else if(other.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.gameObject.GetComponentInParent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerdamage);
            }
        }
        Destroy(gameObject, lifetime);
    }

}