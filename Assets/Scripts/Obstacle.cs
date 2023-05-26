using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    public GameObject effect;
    private Shake shake;

    public GameObject explosionSound;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionSound, transform.position, quaternion.identity);
            shake.camShake();
            Instantiate(effect, transform.position, quaternion.identity);
            other.GetComponent<Player>().health--;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
