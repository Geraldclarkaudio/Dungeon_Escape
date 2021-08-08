using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    public GameObject aButton;
    public GameObject bButton;

    //variable for current item selected. 
    public int currentSelection;

    public int currentCost;

    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            aButton.SetActive(false);
            bButton.SetActive(false);
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
            aButton.SetActive(true);
            bButton.SetActive(true);
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

    }
}
