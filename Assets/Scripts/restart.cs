using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    private Player x;
    // Start is called before the first frame update
    void Start()
    {
        x = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("isDead", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            x.gameOver.SetActive(false);
            PlayerPrefs.SetInt("isDead", 0);
            SceneManager.LoadScene("mainMenu", LoadSceneMode.Additive);
        }
    }
}
