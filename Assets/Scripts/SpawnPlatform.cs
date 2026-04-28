using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    void Start()
    {
        platform.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            platform.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            platform.SetActive(false);
        }
    }
}
