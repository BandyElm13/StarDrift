using UnityEngine;

public class PlayAudioOnEnter : MonoBehaviour
{
    [SerializeField] private AudioSource music;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            music.Play();
        }
    }
}
