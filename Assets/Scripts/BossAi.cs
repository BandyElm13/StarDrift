using UnityEngine;

public class BossAi : MonoBehaviour
{
    public PlayerStats ps;
    public EnemyStats es;
    private Transform player;
    [SerializeField] private GameObject hitBox;
    [SerializeField] private GameObject GunArmLeft;
    [SerializeField] private GameObject GunArmRight;
    [SerializeField] private GameObject Bullet;

    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float attackDelay = 1f;
    private float attackTimer =  0f;

    //shooting range
    [SerializeField] private float shootRange = 8f;
    [SerializeField] private float shootDelay = 2f;
    [SerializeField] private float bulletSpeed = 10f;
    private float shootTimer = 0f;

    //Bosses States
    private enum BossState {Idle, Chase, Attack}
    private BossState current = BossState.Idle;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        es = GetComponent<EnemyStats>();
        ps = GetComponent<PlayerStats>();

        if(hitBox != null) hitBox.SetActive(true);
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        attackTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;

        switch(current)
        {
            case BossState.Idle:
                if (playerDistance <= chaseRange)
                {
                    current = BossState.Chase;
                }
                break;
            case BossState.Chase:
                if(playerDistance > chaseRange)
                {
                current = BossState.Idle;
                } else if(playerDistance <= attackRange)
                {
                    current = BossState.Attack;
                } else
                {
                    Vector3 direction = (player.position - transform.position).normalized;
                    transform.position += direction * es.speed * Time.deltaTime;
                    transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                    transform.Rotate(0f, -90f, 0f);

                    if(playerDistance <= shootRange && shootTimer <= 0f)
                    {
                        ShootFromArms();
                        shootTimer = shootDelay;
                    }
                }
                break;
            case BossState.Attack:
                    if (playerDistance > attackRange)
                {
                    current = BossState.Chase;
                }
                else if (attackTimer <= 0f)
                {
                    DealDamage();
                    attackTimer = attackDelay;
                }
                break;
        }
    }
    private void ShootFromArms()
    {
        if(Bullet == null) return;
        if(GunArmLeft != null)
        {
            FireBullet(GunArmLeft.transform);
        }
          if(GunArmRight != null)
        {
            FireBullet(GunArmRight.transform);
        }
    }

    private void FireBullet(Transform firePoint)
    {
        Vector3 direction = (player.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(Bullet, firePoint.position, Quaternion.LookRotation(direction));

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * bulletSpeed;
        }
    }

    private void DealDamage()
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
            playerStats.takeDamage(es.enemyDamage);
    }

    // Visualize ranges in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

}
