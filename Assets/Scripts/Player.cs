using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Debug.Log("Shoot!");
    }
}
