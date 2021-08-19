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
                StartCoroutine(StartOver());

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

    IEnumerator StartOver()
    {
        UIManager.Instance.YouWinScreen();
        yield return new WaitForSeconds(5.0f);
        GameManager.Instance.gameOver = true;
    }
}
