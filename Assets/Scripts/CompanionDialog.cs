using System.Collections.Generic;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class CompanionDialog : MonoBehaviour
{
    private float criticalHealth = 50;

    List<string> humphreyLog = new List<string>();

    public PlayerStats ps;

    [SerializeField] private TMP_Text humpheysText;

    private void addLogs()
    {
        //1. Introduction Only plays at the start of the tutorial
        humphreyLog.Add("Thank Goodness your awake. After your defeat I though you were a done.....Anyways Lets get moving Ok?");
        //2. Basic Controls and gravity
        humphreyLog.Add("Hold 'Shift' with W to Sprint. WASD to Move. Left Click to Shoot");
        humphreyLog.Add("You can use my power my pressing (Left Mouse + E) while looking at the intended direction");
        //3. Tells you your health is low at 20%
        humphreyLog.Add("Oh No you are injured, I will heal you right away");
        //4. collect a T coin
        humphreyLog.Add("You got a T-Coin, I wonder what those will be used for");
    }

    void Start()
    {
        addLogs();
    }

    void Update()
    {
          //Health is Low
        if(ps.currentHealth < criticalHealth)
        {
            humpheysText.text = humphreyLog[3];
            return;
        }

        //humpheys basic controls dialog
        if(Input.GetKey(KeyCode.Alpha1))
        {
            humpheysText.text = humphreyLog[1];
        //humpheys gravity change dialog
        } else if(Input.GetKey(KeyCode.Alpha2))
        {
            humpheysText.text = humphreyLog[2];
        } else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            humpheysText.text = "";
        }
    }

    
}
