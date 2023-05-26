using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        PlayerPrefs.SetInt("isOnMainMenu", 0);
        SceneManager.LoadScene("baseGame");
    }
    public void quit()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isOnMainMenu", 1);
        SceneManager.LoadScene("baseGame", LoadSceneMode.Additive);
        /*
         * REALLY GHETTO SOLUTION, THIS CAN CAUSE 2 INSTANCE OF THE SAME SCENE TO HAPPHEN
         * I REALLY DON'T WANT TO DO THIS, BUT WEBGL FORCED MY HAND. 
         */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
