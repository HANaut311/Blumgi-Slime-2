using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{       
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {   

        if (scene.name.StartsWith("Level "))
        {
            int currentLevel = int.Parse(scene.name.Substring(6));
            UI.instance.UpdateLevelText(currentLevel);
        }
    }


}
