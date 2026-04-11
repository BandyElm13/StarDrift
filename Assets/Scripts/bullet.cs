using System.Data.Common;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float damage = 20f; private float lifetime = 5f;
    private bool hit = false;

    void Start()
    {
        //Destroy(gameObject, lifetime);
    } 

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit something: " + other.gameObject.name + " tag: " + other.tag);
        if (hit) return;
        if (other.CompareTag("Player")) return;
        if (other.CompareTag("Gun")) return;

        hit = true;

        if(other.CompareTag("Enemy")) {
            //Debug.Log("Enemy has been hit");
            EnemyStats enemy = other.gameObject.GetComponentInParent<EnemyStats>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject, lifetime);
    }

}