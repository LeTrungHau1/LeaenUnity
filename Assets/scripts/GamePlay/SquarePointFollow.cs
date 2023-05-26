using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquarePointFollow : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 2f;
    [SerializeField] private GameObject[] WayPoints;//2 ?i?m
    private int curWayPointIndex=0;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(WayPoints[curWayPointIndex].transform.position,transform.position)<0.1f)//kho?n cách c?a ?i?m v?i gameobject có trùng nhau không
        {
            curWayPointIndex++;
            if(curWayPointIndex>=WayPoints.Length)
            {
                curWayPointIndex = 0;
            }
        }
        transform.position=Vector3.MoveTowards(transform.position,WayPoints[curWayPointIndex].transform.position,movingSpeed*Time.deltaTime);   //duy chuy?n t? a->b v?i t?c d?
    }
}
