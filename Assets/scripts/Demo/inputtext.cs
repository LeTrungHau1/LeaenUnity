using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputtext : MonoBehaviour
{
    public float directionx;
    public float directiony;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        directionx= Input.GetAxis("Horizontal");
        directiony= Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))//nhap 1 lan
        {
            Debug.Log("Jump");

        }
        if (Input.GetButton("Jump"))//giu nut cach
        {
            Debug.Log("Jump giu");

        }
        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("chuot");
        }
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("nhan g");
        }
    }
}
