using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    int shots = 0;

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
        }

        if(collision.CompareTag("Player"))
        {
            Debug.Log("Game Over");
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
            Destroy(gameObject);
        }
    }
}
