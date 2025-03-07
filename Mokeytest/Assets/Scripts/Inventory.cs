using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> collectedItems = new List<string>();
    public PlayerBonuses playerBonuses;  
    public UI_InGame uiInGame; 

    private int poisonCount = 0;
    private int powerUpCount = 0;

    public void AddItem(string item)
    {
        collectedItems.Add(item);

        if (item == "Poison")
        {
            poisonCount++;
            uiInGame.UpdatePoisonUI(poisonCount);  
        }
        else if (item == "PowerUP")
        {
            powerUpCount++;
            uiInGame.UpdatePowerUpUI(powerUpCount); 
        }
    }

    public void UseItem(string item)
    {
        if (collectedItems.Contains(item))
        {
            collectedItems.Remove(item); 

            if (item == "Poison")
            {
                playerBonuses.UsePoison(); 
            }
            else if (item == "PowerUP")
            {
                playerBonuses.UsePowerUP(); 
            }

            if (item == "Poison")
            {
                poisonCount--;
                uiInGame.UpdatePoisonUI(poisonCount);
            }
            else if (item == "PowerUP")
            {
                powerUpCount--;
                uiInGame.UpdatePowerUpUI(powerUpCount); 
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem("Poison");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem("PowerUP");
        }
    }
}
