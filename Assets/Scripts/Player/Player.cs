using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Animator anim {get; private set;}
    public Rigidbody2D rb {get; protected set;}

    
    [SerializeField] private GameObject popUPText;

    [Header("Collison info")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize;

    public PhysicsMaterial2D bounceMat, normalMat;

    [Header("Movement info")]
    public bool canJump = true;
    public float jumpValue = 0.0f;
    public float highValue = 0.0f;
    public bool canHight = true;

    public bool isWin {get; private set;}
    public bool isBusy { get; private set;}

    public CheckPoint fx {get; private set;}


    public bool inWindZone = false;
    public GameObject windZone;

    #region State
    public PLayerStateMachine stateMachine {get; private set;}
    public PlayerIdleState idleState {get; private set;}
    public PlayerJumpState jumpState {get; private set;}
    public PlayerAirState airState {get; private set;}
    public PlayerAimState aimState {get; private set;}
    public PlayerWinState winState {get; private set;}
    public PlayerFlyState flyState {get; private set;}

    #endregion


    private void Awake()
    {   
        stateMachine = new PLayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        aimState = new PlayerAimState(this, stateMachine, "Aim");
        winState = new PlayerWinState(this, stateMachine, "Win");
        flyState = new PlayerFlyState(this, stateMachine, "Jump");
    }


    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<CheckPoint>();
        stateMachine.Intialize(idleState);
    }


    private void Update()
    {   
        stateMachine.currentState.Update(); 
        CanJump();

        if(jumpValue > 0)
        {
            rb.sharedMaterial = bounceMat;

        }
        else
        {
            rb.sharedMaterial = normalMat;
        }

    }

    private void FixedUpdate()
    {
        if(inWindZone)
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
    }

    public bool IsGroundDetected() => Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0, Vector2.zero, 0, whatIsGround);


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }

    public void CanJump()
    {
        // if(jumpValue >= Mathf.Infinity && highValue >= Mathf.Infinity && IsGroundDetected())
        // {   
        //     rb.velocity = new Vector2(highValue, jumpValue);
        //     Invoke("ResetJump", 0.2f);

        // }
        if(jumpValue >= 130f && highValue >= 50f && IsGroundDetected())
        {
            jumpValue = 130f;
            highValue = 50f;
        }

    }

    private void ResetJump()
    {
        canJump = false;
        canHight = false;
        jumpValue = 0;
        highValue = 0;
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void Win()
    {   
        stateMachine.ChangeState(winState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CheckPoint>() != null)
        {
            Win();
            CreatePopUpText("Yeah !!");
        }

        if(collision.GetComponent<WindArea>() != null)
        {
            windZone = collision.gameObject;
            inWindZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<WindArea>() != null)
        {
            inWindZone = false;

        }
    }

    public void CreatePopUpText(string _text)
    {
        float randomX = Random.Range(-1, 1);
        float randomY = Random.Range(1.5f, 2.5f);

        Vector3 positionOffset = new Vector3(randomX, randomY, 0);
        GameObject newText = Instantiate(popUPText, transform.position + positionOffset, Quaternion.identity);
        newText.GetComponent<TextMeshPro>().text = _text; 


    }


}
