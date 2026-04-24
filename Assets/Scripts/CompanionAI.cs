using UnityEngine;

public class CompanionAI : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    private enum companionState {Follow, Heal, Idle}

    private companionState currentState = companionState.Idle;

    private Transform player;

    private PlayerStats ps;

    [SerializeField] private float followRange = 20f;
    [SerializeField] private float healRange = 2f;
    [SerializeField] private float healAmount = 10f;
    [SerializeField] private float healDelay = 2f;
    private float healTimer =  0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ps = player.GetComponent<PlayerStats>();
    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        healTimer += Time.deltaTime;

        switch(currentState)
        {
            case companionState.Idle:
            if(playerDistance <= followRange)
                {
                    currentState = companionState.Follow;
                }
            break;
            case companionState.Follow:
            if(playerDistance > followRange)
                {
                    currentState = companionState.Idle;

                } else if(playerDistance <= healRange)
                {
                    currentState = companionState.Heal;
                } else
                {
                    //looks at player
                    Vector3 direction = (player.position - transform.position).normalized;
                    transform.position += direction * speed * Time.deltaTime;
                    transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
                    transform.rotation *= Quaternion.Euler(0, 180, 0);
                }
            break;
            case companionState.Heal:
             if(playerDistance > healRange)
                {
                    currentState = companionState.Follow;
                } else if(healTimer >= healDelay)
                {
                    ps.healHealth(healAmount);
                    healTimer = 0f;
                }
            break;
        }
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, healRange);
    }
}
