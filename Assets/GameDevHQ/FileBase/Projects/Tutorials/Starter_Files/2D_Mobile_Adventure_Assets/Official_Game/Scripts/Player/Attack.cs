using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool canHit = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if(hit != null)
        {
            if(canHit == true)
            {
                hit.Damage();
                canHit = false;
                StartCoroutine(ResetCanHit());
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator ResetCanHit()
    {
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }
}
