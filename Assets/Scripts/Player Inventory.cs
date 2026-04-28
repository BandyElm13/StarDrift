using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cointext;
    public static int T_Coins = 19;

    public static HashSet<string> collectedCoins = new HashSet<string>();

    void Start()
    {
        cointext.text = T_Coins.ToString();
    }
    public void displaycollectCoins()
    {
        cointext.text = T_Coins.ToString();
    }
}
