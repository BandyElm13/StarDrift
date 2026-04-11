using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 3f;
    [SerializeField] private LayerMask aimMask;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        AimMouse();
        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void AimMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            Vector3 aimTarget = hit.point;
            transform.LookAt(aimTarget);

            Vector3 direction = aimTarget - transform.position;
            if(direction.sqrMagnitude > 0.00f)
            {
                transform.rotation = Quaternion.LookRotation(direction);
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