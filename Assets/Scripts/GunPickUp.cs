using UnityEditor.Rendering;
using UnityEditor.UI;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    private float speed = 90f;
    [SerializeField] private GameObject bruh;
    [SerializeField] private GameObject playerbruh;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            bruh.SetActive(false);
            playerbruh.SetActive(true);
        }
    }

    void Start()
    {
        bruh.SetActive(true);
        playerbruh.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * speed * Time.deltaTime, Space.Self);
    }
}
