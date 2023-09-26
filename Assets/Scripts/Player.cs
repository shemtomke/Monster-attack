using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform bulletStartPosRight;
    public Transform bulletStartPosLeft;

    public GameObject bulletPrefab;
    public GameManager manager;

    // Update is called once per frame
    void Update()
    {
        if(!manager.isGameOver)
            PlayerController();
    }
    void PlayerController()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if touch is on the left or right side of the screen
            if (touch.position.x < Screen.width / 2)
            {
                // Turn left
                transform.GetComponent<SpriteRenderer>().flipX = false;

                // Fire a bullet when the screen is touched on the left side
                if (touch.phase == TouchPhase.Began)
                {
                    Shoot();
                }
            }
            else
            {
                // Turn right
                transform.GetComponent<SpriteRenderer>().flipX = true;

                // Fire a bullet when the screen is touched on the right side
                if (touch.phase == TouchPhase.Began)
                {
                    Shoot();
                }
            }
        }
        // Check for cursor input (for testing in the Unity Editor)
        else if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;

            // Check if cursor is on the left or right side of the screen
            if (mousePosition.x < Screen.width / 2)
            {
                // Turn left
                transform.GetComponent<SpriteRenderer>().flipX = false;
                Shoot();
            }
            else
            {
                // Turn right
                transform.GetComponent<SpriteRenderer>().flipX = true;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        if(transform.GetComponent<SpriteRenderer>().flipX)
            Instantiate(bulletPrefab, bulletStartPosRight.position, Quaternion.identity);
        else
            Instantiate(bulletPrefab, bulletStartPosLeft.position, Quaternion.identity);
    }
}