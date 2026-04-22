using UnityEngine;

public class MakeThingAppearScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;

    void Start()
    {
        objectToSpawn.SetActive(false);
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objectToSpawn.SetActive(true);
        }
    }
}
