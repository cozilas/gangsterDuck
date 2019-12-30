using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    public int jumpHight = 4;
    public int jumpDistance = 3;

    //is grounded variables
    public bool isGrounded;
    public LayerMask groundLayer;
    public float deadZone;

    //touch controls
    Vector2 startPos;
    Vector2 endPos;
    Vector2 direction;
    public bool stopJumping = true;

    //player components
    bool XAxisRotation;

    //pointer
    public bool hasStoppedJumping = false;

    private void Start()
    {

    }

    void Update()
    {
        jump();
    }

    void jump()
    {
        hasStoppedJumping = false;

        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.5f, transform.position.y - 0.53f), groundLayer);//in the second paramiter y-0.61f can be changed depending on how tall the player object is

        if (Input.touchCount > 0)
        {
            Touch patima = Input.GetTouch(0);

            switch (patima.phase)
            {
                case TouchPhase.Began:
                    startPos = patima.position;
                    break;

                case TouchPhase.Moved:
                    break;

                case TouchPhase.Ended:
                    endPos = patima.position;
                    direction.x = startPos.x - endPos.x;
                    deadZone = endPos.x - startPos.x;
                    stopJumping = false;

                    break;
            }


        }

        if (25 < Mathf.Abs(deadZone))//if the touch has been moved more than 25 pixels
        {

            if (Input.touchCount == 0 && direction.x < 0 && isGrounded && !stopJumping)
            {
                hasStoppedJumping = true;//for bubbles script

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jumpHight, jumpDistance), ForceMode2D.Impulse);//jumps left

                stopJumping = true;

                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            if (Input.touchCount == 0 && direction.x > 0 && isGrounded && !stopJumping)
            {
                hasStoppedJumping = true;//for bubbles script

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0 - jumpHight, jumpDistance), ForceMode2D.Impulse);//jumps right

                stopJumping = true;

                gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
            if (Input.touchCount > 0 && !isGrounded)
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
            }
            else
            {
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 3;
            }

        }
    }
}
