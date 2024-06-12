using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    Animator anim;
    [SerializeField] private ParticleSystem winFX;
    public GameObject fadeScreen;
    [HideInInspector] public Transform respawnPoint;
    [HideInInspector] public GameObject currentPlayer;
    public int newPlayer =0;
    [HideInInspector] public int playerDead = 0;
    // int intersitalAds = 0;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        anim = GameObject.Find("FadeScreen_Button").GetComponent<Animator>();
        fadeScreen.SetActive(false);

    }

    public void OnFalling()
    {
        KillPlayer();
        StartCoroutine(DelayStartCoroutine());

    }

    IEnumerator DelayStartCoroutine()
    {   
        if(SceneManager.GetActiveScene().buildIndex !=0 && GameManager.instance.specials == false)
        {
            playerDead ++;
            yield return new WaitForSeconds(1f);
            if (playerDead % 3 == 0 )
            {   
                UI.instance.RestartGameButton();
                fadeScreen.SetActive(true);
                anim.SetBool("fadeIn", true);
                yield return new WaitForSeconds(.1f);
                UI.instance.board.SetActive(true);
                
                UI.instance.anim.SetBool("Actived", true);
                UI.instance.board.GetComponent<BoardPopup>().OnOpen();

            }
            else
            {
                ActiveADS();
            }

        }
        else
        {
            yield return new WaitForSeconds(1f);
            // IntersitalAdsActive();
            UI.instance.RestartGameButton();

        }

    }

    // private void IntersitalAdsActive()
    // {   
    //     intersitalAds ++;
    //     if (intersitalAds == 31)
    //     {
    //         IntersitalAds.instance.ShowAd();
    //         intersitalAds = 0;
    //     }
    // }

    public void ActiveADS()
    {
        UI.instance.board.SetActive(false);
        fadeScreen.SetActive(false);
        UI.instance.RestartGameButton();
    }

    public void RespawnPlayer()
    {
        if (currentPlayer == null && GameManager.instance.specials == false)
        {   
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PlayerSkinData data = GameManager.instance.playerSkins.Where(s => s.ID == 0).FirstOrDefault();
                currentPlayer = Instantiate(data.Prefab, respawnPoint.position, transform.rotation);

            }
            else
            {
                PlayerSkinData data = GameManager.instance.playerSkins.Where(s => s.ID == GameManager.instance.curPlayerSkin).FirstOrDefault();
                currentPlayer = Instantiate(data.Prefab, respawnPoint.position, transform.rotation);
            }

        }
        else if(GameManager.instance.specials == true)
        {

            PlayerSkinData data = GameManager.instance.specialSkins.Where(s => s.ID == GameManager.instance.curPlayerSkin).FirstOrDefault();
            currentPlayer = Instantiate(data.Prefab, respawnPoint.transform.position, transform.rotation);
        }

    }

    public void KillPlayer()
    {
        Destroy(currentPlayer);


    }

    // public void SkinChanged()
    // {
    //     ///something       
    //     RewardedAds.instance.ShowAd((adSuccess)=> 
    //     {
    //         if(adSuccess)
    //         {   
    //             GameManager.instance.specials = true;
    //             KillPlayer();
    //             PlayerSkinData data = GameManager.instance.specialSkins.Where(s => s.ID == GameManager.instance.curPlayerSkin).FirstOrDefault();
    //             currentPlayer = Instantiate(data.Prefab, currentPlayer.transform.position, transform.rotation);
                
    //             if(winFX != null)
    //             {
    //                 winFX.transform.position = currentPlayer.transform.position;
    //                 winFX.Play();

    //             }
                
    //             Debug.Log("Changed Skin");
    //         }
    //     });
    // }


}
