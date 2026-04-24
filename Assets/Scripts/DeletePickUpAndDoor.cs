using UnityEngine;

public class DeletePickUpAndDoor : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy1;
    [SerializeField] private GameObject objectToDestroy2;

    void Start()
    {
        objectToDestroy1.SetActive(true);
        objectToDestroy2.SetActive(true);
    } 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            objectToDestroy1.SetActive(false);
            objectToDestroy2.SetActive(false);
        }
    }
}
