using System.Collections;
using UnityEngine;


public class LaunchStar : MonoBehaviour
{
    [SerializeField] private GameObject endObject;
    [SerializeField] private float launchTime = 1.5f;
    [SerializeField] private float arc = 1.5f;
    [SerializeField] private float spinSpeed = 1f;
    [SerializeField] private float Speed = 20f;

    private bool hasLaunched = false;

    
    void Update()
    {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
        transform.Rotate(Vector3.left, Speed * Time.deltaTime);
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(!hasLaunched && other.CompareTag("Player"))
        {
            hasLaunched = true;
            StartCoroutine(LaunchPlayer(other.gameObject));
        }
    }

    private IEnumerator LaunchPlayer(GameObject player)
    {
        var pc = player.GetComponent<PlayerController>();
        var rb = player.GetComponent<Rigidbody>();
        pc.enabled = false;
        rb.isKinematic = true;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = endObject.transform.position;

        float elasped = 0f;

        while(elasped < launchTime)
        {
            elasped += Time.deltaTime;
            float t = elasped / launchTime;
            Vector3 line = Vector3.Lerp(startPosition, endPosition, t);
            float arcOffset = Mathf.Sin(t * Mathf.PI) * arc;
            player.transform.position = line + Vector3.up * arcOffset;

            player.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);
            player.transform.Rotate(Vector3.left, spinSpeed * Time.deltaTime, Space.Self);

            yield return null;
        }
        player.transform.position = endPosition;
        if(pc != null) pc.enabled = true;
        if(rb != null) rb.isKinematic = false;
        hasLaunched = false;
    }

}
