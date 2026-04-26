using UnityEngine;

public class FlyingEnemyAI : MonoBehaviour
{
        private enum EnemyState {Idle, Chase, Attack}
    private EnemyState current = EnemyState.Idle;
    private Transform player;
    private EnemyStats stats;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackDelay = 1f;

    private float attackTimer =  0f;
    private float starterY;
    private bool isDiving = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = GetComponent<EnemyStats>();
        starterY = transform.position.y;
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        attackTimer -= Time.deltaTime;

        switch(current)
        {
            case EnemyState.Idle:

                transform.position = new Vector3(transform.position.x, starterY, transform.position.z);

                if (playerDistance <= chaseRange)
                {
                    current = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                if(playerDistance > chaseRange)
                {
                current = EnemyState.Idle;
                isDiving = false;
                } else if(playerDistance <= attackRange)
                {
                    current = EnemyState.Attack;
                } else
                {
                    Vector3 targetPosition = new Vector3(player.position.x, starterY, player.position.z);
                    Vector3 direction = (targetPosition - transform.position).normalized;
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
                    isDiving = true;
                    attackTimer = attackDelay;
                }
                if(isDiving)
                {
                    Vector3 diveDirection = (player.position - transform.position).normalized;
                    transform.position += diveDirection * stats.speed * 2f * Time.deltaTime;
                    transform.LookAt(player.position);
                    if(Vector3.Distance(transform.position, player.position) < 1)
                    {
                        DealDamage();
                        isDiving = false;
                        transform.position = new Vector3(transform.position.x, starterY, transform.position.z);
                        current = EnemyState.Chase;
                    }
                    {
                        
                    }
                }
                break;

        }
        
    }

    private void DealDamage()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
            playerStats.takeDamage(stats.enemyDamage);
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
