using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Transform resPoint;
    private void Start()
    {
        PlayerManager.instance.respawnPoint = resPoint;
        PlayerManager.instance.RespawnPlayer();
    }
}
