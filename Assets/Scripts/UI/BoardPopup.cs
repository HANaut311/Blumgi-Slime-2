using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardPopup : MonoBehaviour
{
    [SerializeField] private Image playerSkin;

    public void OnOpen(){
        PlayerSkinData curPlayerData = GameManager.instance.playerSkins.Where(s => s.ID == GameManager.instance.curPlayerSkin).FirstOrDefault();
        playerSkin.sprite = curPlayerData.image;
    }

    public void OnOKRewardClick(){

    }
}
