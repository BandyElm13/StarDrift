using Unity.VisualScripting;
using UnityEngine;
public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 3f;

    private float shootDelay = 3.5f;
    private float shootTime = 0f;

    [SerializeField] private AudioSource shootAudio;
    [SerializeField] private AudioSource reloadAudio;



    void Update()
    {
        shootTime -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0))
        {
            if(shootTime <= 0f)
            {
                Fire();
                shootTime = shootDelay;
                shootAudio.timeSamples = (int)(0.2f * shootAudio.clip.frequency);
                shootAudio.Play();
                reloadAudio.PlayDelayed(shootAudio.clip.length);
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