using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles : MonoBehaviour
{
    public   GameObject player;
    public float moveSpeed;
    private GameObject col;
    private void OnTriggerEnter2D(Collider2D other)
    {
        col = gameObject.transform.Find("bubbleCollider").gameObject;

        player.transform.position = Vector2.Lerp(player.transform.position, gameObject.transform.position,Time.deltaTime*moveSpeed);
        
            col.SetActive(true);

            Debug.Log("suck yo mum");
        
        

      
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        col = gameObject.transform.Find("bubbleCollider").gameObject;
        col.SetActive(false);
    }
}
 