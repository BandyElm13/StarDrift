using UnityEngine;

public class MakeThingAppearScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject objectToDestory;

    void Start()
    {
        objectToSpawn.SetActive(false);
        objectToDestory.SetActive(true);
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objectToSpawn.SetActive(true);
            objectToDestory.SetActive(false);
        }
    }
}
