﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishlevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            completeLevel();


        }
    }
    private void completeLevel()
    {
        if(SceneManager.GetActiveScene().name.Equals("level2"))
        {
            if(AudioManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_VICTORY);
            }
            //hiện chiến thắng
            if (UIManager.HasInstance)
            {
                Time.timeScale = 0f;
                UIManager.Instance.ActiveVectoryPanel(true);
            }
        }
        else
        {
            if(AudioManager.HasInstance && UIManager.HasInstance)
            {
                AudioManager.Instance.PlaySE(AUDIO.SE_FINISH);
                AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_01);
                UIManager.Instance.Gamepanel.SetTimeRemain(240);
            }
            SceneManager.LoadScene("level2");
        }
    }
}
