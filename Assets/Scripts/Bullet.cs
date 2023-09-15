using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private void OnEnable()
    {
        MoveBullet();
    }
    private void Update()
    {
        MoveBullet();
        DestroyBullet();
    }
    void MoveBullet()
    {
        if (transform.position.x > 0)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    void DestroyBullet()
    {
        if(transform.position.x > 10 || transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}