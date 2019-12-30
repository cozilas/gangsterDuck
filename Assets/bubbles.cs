using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    //player testing
    public float moveSpeed;

    //rotate bubble animation
    int rotate = 0;

    private GameObject col;
    private bool isInBubble = false;
    private double colRadiusSize = 0;
    private bool notGrounded;
    private bool isGrounded;

    private void Start()
    {
        col = gameObject.transform.Find("bubbleCollider").gameObject;// remove it from lower;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        player.transform.position = Vector2.Lerp(player.transform.position, gameObject.transform.position, moveSpeed);

        col.SetActive(true);

        isInBubble = true;
    }
    private void OnTriggerExit2D(Collider2D player)//check if working 
    {
        col.SetActive(false);
        isInBubble = false;
        colRadiusSize = 0;
        col.GetComponent<EdgeCollider2D>().edgeRadius = 0;
        col.GetComponent<EdgeCollider2D>().enabled = true;

    }
    private void Update()
    {
        notGrounded = GameObject.Find("ducky").GetComponent<playerControls>().hasStoppedJumping;

        if (colRadiusSize <= 0.66 && isInBubble)//increases the radious of the collider
        {
            colRadiusSize += 0.05f;

            col.GetComponent<EdgeCollider2D>().edgeRadius += 0.05f;
        }

        if (isInBubble && notGrounded)//dissables bubbleCollider component
        {
            col.GetComponent<EdgeCollider2D>().enabled = false;/// DAME KAMI DISABLE TO COLLIDER             
        }

        //animate the bubbles
        if(rotate < 5)
        {
            gameObject.transform.Rotate(0, 0, 1);
            rotate++;
        }
        else
        {
            gameObject.transform.Rotate(0, 0, -1);
            rotate++;
            if(rotate == 10)
            {
                rotate = 0;
            }
        }
      
    }
}
