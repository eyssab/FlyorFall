using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" || collision.collider.tag == "Boost")
        {
            Player.GetComponent<Move2D>().isGrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground"  || collision.collider.tag == "Boost")
        {
            Player.GetComponent<Move2D>().isGrounded = false;
        }
    }
}
