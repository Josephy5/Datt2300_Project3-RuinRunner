using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    private int check;
    public GameObject effect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if (check != 1)//ghetto way to prevent double score all together
            {
                if (PlayerPrefs.GetInt("isDead") != 1)
                {
                    score++;
                }
                check = 1;
            }
            Destroy(other.gameObject);//to look like the bomb enemy gets destoryed by the larger enemy
            Instantiate(effect, transform.position, quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isOnMainMenu") == 0)
        {
            if (check == 1)
            {
                check = 0;//Ghetto checker for the check var
            }
            scoreDisplay.text = "Score = " + score.ToString();
        }
    }
}
