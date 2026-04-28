using TMPro;
using UnityEngine;
public class shoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 3f;

    private float shootDelay = 0.2f;
    private float shootTime = 0f;
    
    [SerializeField] private AudioSource shootAudio;
    [SerializeField] private AudioSource reloadAudio;

    [SerializeField] private TextMeshProUGUI ammountAmount;
    private int totalBullets = 15;
    private int currentBullets;
    private bool isReloading = false;
    private float reloadTime = 3.5f;
    private float reloadTimer = 0f;

    void Start()
    {
        currentBullets = totalBullets;
        UpdateAmmoUI();
    }

    void Update()
    {
        shootTime -= Time.deltaTime;
        if(isReloading)
        {
            reloadTimer -= Time.deltaTime;
            if(reloadTimer <= 0f)
            {
                currentBullets = totalBullets;
                isReloading = false;
                UpdateAmmoUI();
            }
            return;
        }
        if(Input.GetKeyDown(KeyCode.R) && currentBullets <= totalBullets)
        {
            startReload();
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(shootTime <= 0f)
            {
                if(currentBullets <= 0f)
                {
                    startReload();
                    return;
                }
                Fire();
                currentBullets--;
                UpdateAmmoUI();
                shootTime = shootDelay;
                
                shootAudio.timeSamples = (int)(0.2f * shootAudio.clip.frequency);
                shootAudio.Play();
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

    private void startReload()
    {
        isReloading = true;
        reloadTimer = reloadTime;
        reloadAudio.Play();
    }

    private void UpdateAmmoUI()
    {
        if(ammountAmount != null)
        {
            ammountAmount.text = currentBullets + " / " + totalBullets;
        }
    }
}