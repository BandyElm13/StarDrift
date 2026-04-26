using UnityEngine;
public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 3f;

    private float shootDelay = 1f;
    private float shootTime = 0f;



    void Update()
    {
        shootTime -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0))
        {
            if(shootTime <= 0f)
            {
                Fire();
                shootTime = shootDelay;
            }
        }
    }
    private void Fire()
    {
        GameObject spawn = Instantiate(bullet, firePoint.position, firePoint.rotation);

        Rigidbody rb = spawn.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}