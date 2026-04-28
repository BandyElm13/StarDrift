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
        if(PlayerInventory.T_Coins >= 0) {ToLevelOne.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelTwo.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelThree.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelFour.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelFive.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelSix.SetActive(true);}
        if(PlayerInventory.T_Coins >= 0) {ToLevelFinal.SetActive(true);}
        //1
        //4
        //7
        //10
        //13
        //16
        //19
    }


    void Update()
    {
        unlockLevels();
    }
}
