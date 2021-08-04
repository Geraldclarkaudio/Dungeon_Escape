using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diamond : MonoBehaviour
{

    public int gems; // set the value in the inspector and increment "diamonds" depending on how many gems it collected.

    private void OnTriggerEnter2D(Collider2D other )
    {
         if(other.tag == "Player")
        {
            Player _player = other.GetComponent<Player>();
           
            if(_player != null)
            {
                _player.AddGems(gems);
               // _player.diamonds += gems;//takes diamonds and increments depending on number of gems collected.


                Destroy(this.gameObject);
            }
           
        }
    }
}
