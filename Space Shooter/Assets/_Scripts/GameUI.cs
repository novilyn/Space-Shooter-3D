using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameUI;

    private void Start()
    {
        ShowMainMenu();
    }

    void OnEnable()
    {
        EventManager.onStartGame += ShowGameUI;
    //    EventManager.onPlayerDeath += ShowGameUI;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= ShowGameUI;
    }

    void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    void ShowGameUI()
    {
        mainMenu.SetActive(false);
        gameUI.SetActive(true);
    }

 //   void HidePanel()
//    {
 //       isDisplayed = !isDisplayed;
 //       playButton.SetActive(isDisplayed);

        /*        if (isDisplayed)
                {
                    playButton.SetActive(false);
                }
                else
                {
                    playButton.SetActive(true);
                }
        */
 //   }


   
}
