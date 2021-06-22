using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;
    

    private enum State { idle, running, jumping, falling};
    private State state = State.idle;

    public LayerMask ground;
    public float speed = 5f;
    public float jumpForce = 15f;
    public int cherries = 0;
    
    //CherryBullet
    public GameObject cherrybulletPrefab;
    internal float position = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
                
    }

    // Update is called once per frame
    void Update()
    {

            Movement();

        VelocityState();
        anim.SetInteger("state", (int)state);

        if (Input.GetKeyDown(KeyCode.Q) && cherries > 0)
        {
            Cherry();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "collectable")
        {
            Destroy(collision.gameObject);
            cherries += 1;
        }

        else if (collision.tag == "dead")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.tag == "house")
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            if (state == State.falling)
            {
                Destroy(other.gameObject);
                Jump();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
       
       
    }
       
    private void Movement()
    {
        //left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        //right
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && coll.IsTouchingLayers(ground))
        {
            Jump();
        }

       

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    //Animation
    private void VelocityState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }

        }
        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
            
        }
        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }


    }

    private void Cherry()
    {
        Instantiate(cherrybulletPrefab, transform.position, transform.rotation);
        Debug.Log("Cherry");
        cherries -= 1;
    }
}
