using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    //variable for current item selected. 
    public int currentSelection;

    public int currentCost;

    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            if(player != null)
            {
                UIManager.Instance.OpenShop(player.diamonds);
            }
            shopPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item)
    {
        Debug.Log("Item Selected");

        //switch between item 

     switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(62);//flame sword
                currentSelection = 0;
                currentCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-40);
                currentSelection = 1; 
                currentCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-129);
                currentSelection = 2;
                currentCost = 100;
                break;
        }
    }

    public void BuyItem()
    { 
        
        if(player.diamonds >= currentCost)
        {
            //award item
            if(currentSelection == 2)
            {
                GameManager.Instance.hasKey = true;
            }

            player.diamonds -= currentCost;
            Debug.Log("Purchased: " + currentSelection);
            Debug.Log("Remaining Gems: " + player.diamonds);
            shopPanel.SetActive(false);
        }
        else
        {
            Debug.Log("You broke");
            shopPanel.SetActive(false);
        }
       //if player gems is Greater than or equal to item cost = award item else cancel sale. 
       //subtrct cost from player's gems. 

    }
}
