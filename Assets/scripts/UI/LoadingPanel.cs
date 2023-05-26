using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private Slider loadingSlider;


    private void OnEnable()
    {
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("level1");
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            loadingSlider.value=asyncOperation.progress;
            loadingText.SetText($"LOADING SCENES: {asyncOperation.progress * 100}%");
            if(asyncOperation.progress>=0.9f)//0.1 còn lại dùng để chuyển scene
            {
                loadingText.SetText("press the space bar to continue");
                loadingSlider.value = 1f;
                if(Input.GetKeyDown(KeyCode.Space))
                {
                    asyncOperation.allowSceneActivation = true;
                    if(UIManager.HasInstance && gameManager.HasInstance)
                    {
                        UIManager.Instance.ActiveGamePanel(true);
                        UIManager.Instance.ActiveLoadingPanel(false);
                        gameManager.Instance.Startgame();
                    }
                }
            }
            yield return null;
        }
       
    }


}
