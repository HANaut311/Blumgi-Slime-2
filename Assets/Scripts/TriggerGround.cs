using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.GetComponent<Player>() != null)
        {
            SoundManager.instance.PlaySFX(1);
        }


    }
}
