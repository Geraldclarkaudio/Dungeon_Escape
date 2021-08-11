using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
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
                Debug.Log("You Need the KEY");
            }
        }
    }
}
