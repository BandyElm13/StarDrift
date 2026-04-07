using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 3f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }
    private void Fire()
    {
        GameObject spawn = Instantiate(bullet, firePoint.position, firePoint.rotation);

        // Push it forward
        Rigidbody rb = spawn.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}