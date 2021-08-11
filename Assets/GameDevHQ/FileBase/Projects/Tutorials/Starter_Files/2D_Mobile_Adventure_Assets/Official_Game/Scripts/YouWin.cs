using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.youWin = true;
            UIManager.Instance.YouWinScreen();

            //UIManager stuff
        }
    }
}
