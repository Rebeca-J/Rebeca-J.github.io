using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CherryBullet : MonoBehaviour
{ 
    Rigidbody2D cherry_Rb;
    public float cherrySpeed;
    public float cherryLife;
    Player player;
    Vector2 moveDirection;

    

    private void Start()
    {
        cherry_Rb = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = transform.position * cherrySpeed;
            cherry_Rb.velocity = new Vector2(-8, 4);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = transform.position * cherrySpeed;
            cherry_Rb.velocity = new Vector2(8, 4);
        }
        else
        {
            moveDirection = transform.position * cherrySpeed;
            cherry_Rb.velocity = new Vector2(8, 4);
        }

        Destroy(gameObject, cherryLife);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }




}
