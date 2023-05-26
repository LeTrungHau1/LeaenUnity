using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatfom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)//va ch?m thì thành l?p cha c?a player
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)//thoát ra thì tr? l?i bình th??ng
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

}
