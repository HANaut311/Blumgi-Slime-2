// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class StartSceneController : MonoBehaviour
// {
//     [SerializeField] private Transform resPoint;
//     private bool isFirstLoad = true;

//     private void Start()
//     {
//         if (isFirstLoad)
//         {
//             PlayerManager.instance.respawnPoint = resPoint;
//             PlayerManager.instance.RespawnPlayer();
//             GameManager.instance.SaveCurrentLevel();
//             isFirstLoad = false;
//         }
//         else
//         {
//             int savedLevel = GameManager.instance.GetSavedLevel();
//             SceneManager.LoadScene(savedLevel);
//         }
//     }
// }
