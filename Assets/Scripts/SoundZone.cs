using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            SoundManager.instance.PlaySFX(3);
        }
    }
}
