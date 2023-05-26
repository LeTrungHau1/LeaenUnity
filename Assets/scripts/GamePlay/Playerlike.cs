using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerlike : MonoBehaviour
{
    [SerializeField] private Transform playerspawPoint;
    private Animator animator;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("checkpoint"))
        {
            playerspawPoint = collision.gameObject.transform;
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //animation die
        animator.SetTrigger("Death");
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySE(AUDIO.SE_DEATH);
        }
    }
    private void respawn()
    {
        this.transform.position=playerspawPoint.position;
        //cho nhân v?t duy chuy?n
        rb.bodyType= RigidbodyType2D.Dynamic;
        //reset animation
        animator.Rebind();
    }
}
