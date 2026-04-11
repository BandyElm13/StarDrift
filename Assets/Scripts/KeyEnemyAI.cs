using UnityEngine;
using UnityEngine.AI;

public class KeyEnemyAI : MonoBehaviour
{
    private enum KeyEnemyState {Idle, Run};

    private KeyEnemyState currentState = KeyEnemyState.Idle;
    [SerializeField] private float SpotRange = 30f;
    [SerializeField] private float fleedistance = 15f;
    [SerializeField] private float rate = 0.5f;
    private Transform player;
    private EnemyStats stats;
    private NavMeshAgent agent;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = GetComponent<EnemyStats>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        timer -= Time.deltaTime;
        switch(currentState)
        {
            case KeyEnemyState.Idle:
            if(playerDistance <= SpotRange)
                currentState = KeyEnemyState.Run;
                break;
            
            case KeyEnemyState.Run:
            if(timer <= 0f)
                {
                    fleefromPlayer();
                    timer = rate;
                }
            if(playerDistance > SpotRange)
                {
                    agent.ResetPath();
                    currentState = KeyEnemyState.Idle;
                }
                break;
        }
    }

    private void fleefromPlayer()
    {
        Vector3 fleedir = (transform.position - player.position).normalized;
        Vector3 fleetar = (transform.position + fleedir * fleedistance);
        if(NavMesh.SamplePosition(fleetar, out NavMeshHit hit, fleedistance, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            return;
        }
        for(int i = 0; i < 8; i++)
        {
            Vector3 randomDir = Quaternion.Euler(0, i * 45, 0) * fleedir;
            Vector3 avalible = transform.position + randomDir * fleedistance;
            if(NavMesh.SamplePosition(avalible, out NavMeshHit randomhit, fleedistance, NavMesh.AllAreas))
            {
                agent.SetDestination(randomhit.position);
                return;
            }
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(transform.position, SpotRange);
    // }
}
