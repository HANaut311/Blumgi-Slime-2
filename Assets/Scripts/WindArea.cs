using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector3 direction;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position , groundCheckSize );
    }


}
