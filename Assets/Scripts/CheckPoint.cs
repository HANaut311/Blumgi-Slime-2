using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{   
    [SerializeField] private ParticleSystem winFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            // GetComponent<Animator>().SetTrigger("Activate");
            SoundManager.instance.PlaySFX(2);
            if(winFX != null)
                winFX.Play();



            if(SceneManager.GetActiveScene().buildIndex %5 ==0 && SceneManager.GetActiveScene().buildIndex > 1)
            {
                GameController.instance.ShowFireworksAndText();
                GameManager.instance.curPlayerSkin++;
            }
            else
                GameController.instance.SwitchOnNextScreen();

            if(GameManager.instance.specials == true)
            {   
                PlayerManager.instance.newPlayer++;
                if(PlayerManager.instance.newPlayer == 3)
                {
                    GameManager.instance.specials = false;
                    PlayerManager.instance.newPlayer =0;
                }
            }

            if(GameManager.instance.curPlayerSkin >= GameManager.instance.playerSkins.Count)
            {
                GameManager.instance.curPlayerSkin = 0;
            }

            GameManager.instance.SaveSkin();

        }
    }


}
