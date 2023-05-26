using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menupanel : MonoBehaviour
{
    public void Onstargamebutton()
    {
        
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ActiveLoadingPanel(true);
            UIManager.Instance.ActiveMenuPanel(false);
        }
        //if(gameManager.HasInstance)
        //{
        //    gameManager.Instance.Startgame();
        //    gameManager.Instance.ChangeScene("level1");
        //}
    }
    public void onSettingButtonClick()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
           
        }
    }
}
