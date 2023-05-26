using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawgameobject : MonoBehaviour
{
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject spawnobject;
    private GameObject runtimespawn;
    private float timedestroy = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           runtimespawn= Instantiate(spawnobject,spawnpoint);
            if(runtimespawn!=null)
            {
                destroy();
            }
        }
    }
    private void destroy()
    {
        Destroy(runtimespawn,timedestroy);
    }
}
