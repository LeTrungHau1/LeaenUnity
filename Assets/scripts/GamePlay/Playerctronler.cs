using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Playerctronler : MonoBehaviour
{
    [SerializeField] private TrailRenderer trailRenderer;//bóng khi lướt
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator amin;
    [SerializeField] private float directionx;
    [SerializeField] private float playerspeed;
    [SerializeField] private float jumpheight;
    private bool isjumping;
    private bool isdoulejump;
    [SerializeField] LayerMask jumpbleground; //ki?m tra có trên d?t không

    //bóng lướt của nhân vật

   
    private bool isDashing;
    private bool canDash = true;
    [SerializeField] private float dashingpower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldow = 1f;//1s sau dc lướt tiếp


    //hiệu ứng bụi
    [SerializeField] private ParticleSystem moveeffect;
    [SerializeField] private ParticleSystem jumpEffect;

    [Range(0,10)]
    [SerializeField] private int occuAftervelocity;

    [Range(0,0.2f)]
    [SerializeField] private float dustFormationPeriod;

    private float counter;



   



    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    void Start()
    {
        trailRenderer.emitting = false;
       
    }
    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }
    private MovementState movementState;

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }
        counter += Time.deltaTime;
        if(isgrouder() && Mathf.Abs(rb.velocity.x)>occuAftervelocity)
        {
            if(counter>dustFormationPeriod)
            {
                moveeffect.Play();
                counter = 0;
            }
        }



        directionx = Input.GetAxisRaw("Horizontal");

        ChanegeDirction();
        updateanimation();



        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_DASH);
            }
        }
        jumping();


    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        move();
       
       
    }
    private void ChanegeDirction()
    {
        if(directionx>0)//lật nhân vật
        {
            SpriteRenderer.flipX = false;
           

        }
        if (directionx < 0)
        {
            SpriteRenderer.flipX = true;
           
        }
       

    }
    private void updateanimation()
    {
        if (directionx != 0)
        {
            //Dang di chuyen
            movementState = MovementState.Running;
        }
        else
        {
            //Dung yen
            movementState = MovementState.Idle;
        }
        if (rb.velocity.y > 0.1f) 
        {
            movementState = MovementState.Jumping;
        }
        if (rb.velocity.y < -0.1f) 
        {
            movementState=MovementState.Falling;
        }

        amin.SetInteger("State", (int)movementState);

    }
    private void move()//duy chuyển trái phải
    {
        rb.velocity = new Vector2(directionx * playerspeed, rb.velocity.y);
       
    }
    private void jumping()//cho nhân vật bay lên bằng nhấn cách
    {

        if (Input.GetButtonDown("Jump"))
        {
            isjumping = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isjumping = false;
        }
        if(isgrouder() && !isjumping)
        {
            isdoulejump = false;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if(isgrouder()|| isdoulejump)
            {
                if(AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(AUDIO.SE_JUMP);
                }

                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
                isdoulejump= !isdoulejump;
                amin.SetBool("DoubleJump", !isdoulejump);

                //play effect jump
                if(!isdoulejump)
                {
                    jumpEffect.Play();
                }

            }
           
        }
    }
    private bool isgrouder()//kiểm tra va chạm với nền đất
    {
        return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, jumpbleground);
    }

    private IEnumerator Dash()
    {
        canDash= false;//khi nhân vật lướt,để nhân vật k lướt liên tục 2 lần
        isDashing = true;//chặn input khi nhân vật đang lướt
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;//set trong lúc =0 để nhân vật dang nhảy mà lướt để khong bị rối
        rb.velocity = new Vector2(directionx * dashingpower, 0f);//khoản cách lướt của nhân vật
        trailRenderer.emitting = true;//hiển thị hướng về khi lướt
        yield return new WaitForSeconds(dashingTime);// khoản thời gian nhân vật lướt
        trailRenderer.emitting=false;//tat duong về khi lướt
        rb.gravityScale= originalGravity;//cho vật duy chuyển binh thường
        isDashing = false;// cho nhan vat di chuyen binh thuong
        yield return new WaitForSeconds(dashingCooldow); //thoi gian cho de luot lan tiep theo
        canDash = true;// cho nhan vat luot lan tiep theo
        //Debug.Log("aaaa");
    }
}
