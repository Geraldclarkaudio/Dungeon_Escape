using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("UIMAnager is Null");
            }

            return _instance;
        }

    }


    public Text gemCountText;

    public Image selectionImage;

    public Text gemCount;

    public Image[] healthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        gemCountText.text = "" + gemCount + "G";
    }    

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCount.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        //loop through lives 
        for(int i = 0; i <= livesRemaining; i++)
        {
            //do nothing til max is hit
            if(i == livesRemaining)
            {
                //hide this one
                healthBars[i].enabled = false;
            }
        }
    
        //if i is equal to the lives remaining, hide that one 
    }

}
