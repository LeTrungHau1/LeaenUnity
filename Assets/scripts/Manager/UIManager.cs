using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class UIManager : BaseManager<UIManager> 
{
    [SerializeField] 
    private menupanel menupanel;
    public menupanel Menupanel=> menupanel;

    [SerializeField]
    private gamepanel gamepanel;
    public gamepanel Gamepanel => gamepanel;

    [SerializeField]
    private SettingPanel settingPanel;
    public SettingPanel SettingPanel => settingPanel;

    [SerializeField]
    private LosePanel losePanel;
    public LosePanel LosePanel => losePanel;


    [SerializeField]
    private VictoryPanel victoryPanel;
    public VictoryPanel VictoryPanel => victoryPanel;

    [SerializeField]
    private PausePanel pausePanel;
    public PausePanel PausePanel => pausePanel;


    [SerializeField]
    private LoadingPanel loadingPanel;
    public LoadingPanel LoadingPanel => loadingPanel;



    void Start()
    {

        ActiveMenuPanel(true);
        ActiveGamePanel(false);
        ActiveSettingPanel(false);
        ActiveLosePanel(false);
        ActiveVectoryPanel(false);
        ActivePausePanel(false);
        ActiveLoadingPanel(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameManager.HasInstance && gameManager.Instance.Isplaying)
            {
                gameManager.Instance.Pausegame();
                ActivePausePanel(true);
            }
        }
    }


    public void ActiveMenuPanel(bool active)
    {
        menupanel.gameObject.SetActive(active);
    }
    public void ActiveGamePanel(bool active)
    {
        gamepanel.gameObject.SetActive(active);
    }
    public void ActiveSettingPanel(bool active)
    {
        settingPanel.gameObject.SetActive(active);
    }
    public void ActiveLosePanel(bool active)
    {
        losePanel.gameObject.SetActive(active);
    }
    public void ActiveVectoryPanel(bool active)
    {
        victoryPanel.gameObject.SetActive(active);
    }
    public void ActivePausePanel(bool active)
    {
        pausePanel.gameObject.SetActive(active);
    }
    public void ActiveLoadingPanel(bool active)
    {
        loadingPanel.gameObject.SetActive(active);
    }
}
