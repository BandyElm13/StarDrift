using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cointext;
    public static int T_Coins;

    void Start()
    {
        cointext.text = T_Coins.ToString();
    }
    public void collectCoins()
    {
        cointext.text = T_Coins.ToString();
    }
}
