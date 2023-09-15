using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    float speed;
    int shots = 0;

    ScoreManager scoreManager;
    GameManager gameManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();

        speed = Random.Range(1.5f, 4);
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
