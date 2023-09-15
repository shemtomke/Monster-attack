using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    public Slider slider;

    float speed;
    int shots = 0;

    ScoreManager scoreManager;
    GameManager gameManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();

        slider.value = 1;

        if(gameManager.currentMode == Modes.Normal)
        {
            speed = Random.Range(1.2f, 2f);
        }
        else
        {
            speed = Random.Range(2f, 5);
        }
    }

    private void Update()
    {
        Death();
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            shots++;
            slider.value -= 0.2f;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Game Over Shooter");
            gameManager.gamesPlayed++;
            gameManager.SaveGamesPlayed(gameManager.gamesPlayed);
        }
    }
    void Move()
    {
        if(transform.position.x < 0)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void Death()
    {
        if(shots >= 5)
        {
            scoreManager.score++;
            Destroy(gameObject);
        }
    }
}
