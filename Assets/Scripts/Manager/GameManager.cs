using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private const string saveLevelKey =  "SavedLevel";
    private const string save_data_key = "save_data_key";
    private const string saveSkinKey = "SavedSkin";

    public int savedLevel {get; private set;}

    public List<PlayerSkinData> playerSkins;

    public List<PlayerSkinData> specialSkins;
    public int curPlayerSkin;
    public bool specials = false;
    //public int basicPlayerSkin;

    public int levelWithSpecialSkinCount = 0;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SetupNewData();
    }

    public void SetupNewData(){
        if(PlayerPrefs.HasKey(save_data_key)) //&& PlayerPrefs.HasKey(save_skin_key))
        {
            LoadLevel();
            LoadSkin();
            //load data

        }
        else{
            savedLevel = 1;
            curPlayerSkin = 0;
            SaveLevel();
            SaveSkin();
            //khoi tao data moi
            PlayerPrefs.SetInt(save_data_key, 0);
            // PlayerPrefs.SetInt(save_skin_key, 0);
        }
        
    }
    #region Saved Level
    public int GetSavedLevel(){
        return savedLevel;
    }

    public void SetSavedLevel(int value){
        savedLevel = value;
        SaveLevel();
    }

    public void SaveLevel()
    {
        PlayerPrefs.SetInt(saveLevelKey, savedLevel);
    }

    private void LoadLevel()
    {
        savedLevel = PlayerPrefs.GetInt(saveLevelKey, 1);
    }
    #endregion

    #region Saved Skin
    public int GetSavedSkin(){
        return curPlayerSkin;
    }

    public void SetSavedSkin(int value){
        curPlayerSkin = value;
        SaveSkin();
    }

    public void SaveSkin()
    {
        PlayerPrefs.SetInt(saveSkinKey, curPlayerSkin);
    }

    private void LoadSkin()
    {
        curPlayerSkin = PlayerPrefs.GetInt(saveSkinKey, 1);
    }
    #endregion


}
