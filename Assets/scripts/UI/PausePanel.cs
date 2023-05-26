using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
   public void OnclickedSettingButton()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
            UIManager.Instance.ActivePausePanel(false);
        }
    }
    public void OnclickedResumeButton()
    {
        if(gameManager.HasInstance && UIManager.HasInstance)
        {
            gameManager.Instance.Resumegame();
            UIManager.Instance.ActivePausePanel(false);
        }
    }
    public void OnclickedQuitButton()
    {
        if(gameManager.HasInstance)
        {
            gameManager.Instance.EndGame();
        }
    }
}
