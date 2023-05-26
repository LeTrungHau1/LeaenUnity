using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void OnClickRestarButton()
    {
        if (gameManager.HasInstance)
        {
            gameManager.Instance.RestartGame();
        }
    }
    public void OnClickExitButton()
    {
        if (gameManager.HasInstance)
        {
            gameManager.Instance.EndGame();
        }
    }
}
