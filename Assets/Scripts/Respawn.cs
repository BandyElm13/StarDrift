using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject playertele;
    [SerializeField] private Transform player, destination;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playertele.SetActive(false);
            player.position = destination.position;
            playertele.SetActive(true);
        }
    }
}
