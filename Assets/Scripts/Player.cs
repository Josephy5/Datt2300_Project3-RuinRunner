using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float yIncrement;
    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health = 3;

    public GameObject effect;
    private Shake shake;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject gameOver;
    public GameObject player;

    public GameObject teleportSound;
    public AudioSource music;

    void Start()
    {
        if (PlayerPrefs.GetInt("isOnMainMenu") == 0)
        {
            music.Play();
        }
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();//Shake motion
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isOnMainMenu") == 0)
        {
            if (health <= 0)
            {
                music.Stop();
                PlayerPrefs.SetInt("isDead", 1);
                spawner.SetActive(false);
                gameOver.SetActive(true);
                Destroy(gameObject);
            }

            healthDisplay.text = "Lives = " + health.ToString();

            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxHeight)
            {
                Instantiate(teleportSound, transform.position, quaternion.identity);
                shake.camShake();
                Instantiate(effect, transform.position, quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y + yIncrement);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight)
            {
                Instantiate(teleportSound, transform.position, quaternion.identity);
                shake.camShake();
                Instantiate(effect, transform.position, quaternion.identity);
                targetPos = new Vector2(transform.position.x, transform.position.y - yIncrement);
            }
        }
    }
}
