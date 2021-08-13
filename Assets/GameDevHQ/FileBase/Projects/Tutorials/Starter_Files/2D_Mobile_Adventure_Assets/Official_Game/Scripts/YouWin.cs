using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    public GameObject needKeyText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.hasKey == true)
            {
                GameManager.Instance.youWin = true;
                UIManager.Instance.YouWinScreen();
            }
            else
            {
                needKeyText.SetActive(true);
                Debug.Log("You Need the KEY");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
     if(other.tag == "Player")
        {
            needKeyText.SetActive(false);
        }
    }
}
