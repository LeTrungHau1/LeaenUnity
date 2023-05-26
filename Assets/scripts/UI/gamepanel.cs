using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class gamepanel : MonoBehaviour
{
    [SerializeField]
   private TextMeshProUGUI cherriText;
    [SerializeField] private TextMeshProUGUI timeText;
    private float timeRemaining;
    private bool timeIsRunning=false;

    private void Start()
    {
        cherriText.text=gameManager.Instance.Cherries.ToString();
    }
    private void Update()
    {
        if(timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisPlayTime(timeRemaining);
            }
            else
            {
                Debug.Log("time has run out");
                timeRemaining = 0;
                timeIsRunning = false;
                timeText.text = string.Format("{0:00}:{1:00}", 0, 0);
                if(AudioManager.HasInstance)
                {
                    AudioManager.Instance.PlaySE(AUDIO.SE_LOSE);
                }
                if(UIManager.HasInstance)
                {
                    Time.timeScale = 0f;
                    UIManager.Instance.ActiveLosePanel(true);
                }
            }
        }
    }
    private void OnEnable()
    {
        //đăng ký sự kiện
        Itemcolloctr.collectcherrydelegate += onplayercollectcherry;
        SetTimeRemain(120);
        timeIsRunning=true;
    }
    private void OnDisable()
    {
        //hủy sự kiện
        Itemcolloctr.collectcherrydelegate -= onplayercollectcherry;
    
    }
    private void onplayercollectcherry(int value)
    {
        cherriText.text= value.ToString();
    }
    private void DisPlayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text= string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    public void SetTimeRemain(float value)
    {
        timeRemaining = value;
    }
}
