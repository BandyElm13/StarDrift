using UnityEngine;

public class StarDriftHubLevelSustem : MonoBehaviour
{
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject ToLevelOne;
    [SerializeField] private GameObject ToLevelTwo;
    [SerializeField] private GameObject ToLevelThree;
    [SerializeField] private GameObject ToLevelFour;
    [SerializeField] private GameObject ToLevelFive;
    [SerializeField] private GameObject ToLevelSix;
    [SerializeField] private GameObject ToLevelFinal;
    void Start()
    {
        ToLevelOne.SetActive(false);
        ToLevelTwo.SetActive(false);
        ToLevelThree.SetActive(false);
        ToLevelFour.SetActive(false);
        ToLevelFive.SetActive(false);
        ToLevelSix.SetActive(false);
        ToLevelFinal.SetActive(false);
    }

    private void unlockLevels()
    {
        if(PlayerInventory.T_Coins == 1) {ToLevelOne.SetActive(true);}
        if(PlayerInventory.T_Coins == 4) {ToLevelTwo.SetActive(true);}
        if(PlayerInventory.T_Coins == 7) {ToLevelThree.SetActive(true);}
        if(PlayerInventory.T_Coins == 10) {ToLevelFour.SetActive(true);}
        if(PlayerInventory.T_Coins == 13) {ToLevelFive.SetActive(true);}
        if(PlayerInventory.T_Coins == 16) {ToLevelSix.SetActive(true);}
        if(PlayerInventory.T_Coins == 19) {ToLevelFinal.SetActive(true);}
        
    }


    void Update()
    {
        unlockLevels();
    }
}
