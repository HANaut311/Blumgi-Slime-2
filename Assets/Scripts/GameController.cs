using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int nextLevel{get; private set;}
    private void Awake()
    {
        if(instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void ShowFireworksAndText()
    {
        StartCoroutine(ShowFireworksAndTextCoroutine());
    }

    IEnumerator ShowFireworksAndTextCoroutine()
    {
        yield return new WaitForSeconds(4f);
        TimeLineController timeline = FindObjectOfType<TimeLineController>();
        if (timeline != null)
        {
            timeline.SetTimelineActive(true);
        }

    }

    public void SwitchOnNextScreen()
    {   
        StartCoroutine(NextScreenCoroutine());
    }

    IEnumerator NextScreenCoroutine()
    {
        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {   
            int currentLevel = GameManager.instance.GetSavedLevel();
            nextLevel = currentLevel;
            
            if(SceneManager.GetActiveScene().buildIndex != 0)
            {
                nextLevel ++;
                PlayerManager.instance.playerDead = 0;
            }

            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(nextLevel );
            GameManager.instance.SetSavedLevel(nextLevel);
        }
        else
        {
            // Handle reaching the end of available levels (e.g., display a message or loop back to the first level).
            nextLevel = 0;
            SceneManager.LoadScene(nextLevel);
            GameManager.instance.SetSavedLevel(nextLevel);       
        }

    }


}
