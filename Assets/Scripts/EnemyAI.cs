using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyAI : MonoBehaviour
{
    private enum EnemyState {Idle, Chase, Attack}
    private EnemyState current = EnemyState.Idle;
    private Transform player;
    private EnemyStats stats;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDelay = 1f;

    private float attackTimer =  0f;
    private Vector3 idlePosition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = GetComponent<EnemyStats>();
        idlePosition = transform.position;
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        attackTimer -= Time.deltaTime;

        switch(current)
        {
            case EnemyState.Idle:
                if (playerDistance <= chaseRange)
                {
                    current = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                if(playerDistance > chaseRange)
                {
                current = EnemyState.Idle;
                } else if(playerDistance <= attackRange)
                {
                    current = EnemyState.Attack;
                } else
                {
                    Vector3 direction = (player.position - transform.position).normalized;
                    transform.position += direction * stats.speed * Time.deltaTime;
                    transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                }
                break;
            case EnemyState.Attack:
                    if (playerDistance > attackRange)
                {
                    current = EnemyState.Chase;
                }
                else if (attackTimer <= 0f)
                {
                    DealDamage();
                    attackTimer = attackDelay;
                }
                break;

        }
        
    }

    private void DealDamage()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
            playerStats.takeDamage(stats.damage);
    }

    // Visualize ranges in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
