using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformtext : MonoBehaviour
{
    [SerializeField]
    private Transform Playertransform;
    [SerializeField]
    public float movespeed;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Playertransform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.red);        //k? ???ng th?ng 2 ?i?m
        Debug.Log("distance from enemy to player:" + direction.magnitude);


        //float distance = Vector3.Distance(transform.position, Playertransform.position);
        //Debug.Log("distance from enemy to player - 2:" + distance);

        direction.Normalize();    //duy chuyên ?i?u 
        transform.Translate(direction * Time.deltaTime * movespeed);   //duy chuyen toi diem ban dau nhanh ch?m d?n theo th?i gian



    }
}
