using UnityEngine;

public class T_Coin : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private string coinID ;

    void Start()
    {
        if(PlayerInventory.collectedCoins.Contains(coinID))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInventory.T_Coins++;
            PlayerInventory.collectedCoins.Add(coinID);
            playerInventory.displaycollectCoins();
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
