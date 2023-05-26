using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Itemcolloctr : MonoBehaviour
{
    public delegate void Collectcherry(int cherry); //dịnh nghĩa hàm delegate
    public static Collectcherry collectcherrydelegate; //khai báo hàm delegate
    private int cherries = 0;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        if(gameManager.Instance != null)
        {
            cherries = gameManager.Instance.Cherries;
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("cherries"))
        {
            cherries++;           
           
            if(gameManager.Instance != null)
            {
                gameManager.Instance.updatacherries(cherries);
            }
            collectcherrydelegate(cherries);//phát sự kiện
            if (AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_COLLECT);
            }
            Debug.Log("cherries"+ cherries);
            Destroy(collision.gameObject);
        }
    }
}
