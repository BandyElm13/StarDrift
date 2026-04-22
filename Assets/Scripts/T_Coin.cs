using UnityEngine;

public class T_Coin : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private PlayerInventory playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInventory.T_Coins++;
            playerInventory.collectCoins();
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
