using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatfom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//va ch?m th� th�nh l?p cha c?a player
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)//tho�t ra th� tr? l?i b�nh th??ng
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
